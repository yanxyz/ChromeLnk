/* global chrome fetch TextDecoder */

'use strict'

function check (url) {
  return fetch(url, {
    method: 'get',
    headers: {
      'content-type': 'arraybuffer'
    }
  })
    .then(status)
    .then(parse)
    .then(compare)
}

function status (res) {
  if (!res.ok) return Promise.reject(res.statusText)

  return res.arrayBuffer().then(function (buf) {
    var dv = new DataView(buf)
    var decoder = new TextDecoder('gbk')
    return decoder.decode(dv)
  })
}

function parse (html) {
  var re = /<title>.*中文版 (.*) 下载.*<\/title>/
  var m = html.match(re)
  if (!m) throw new Error('matching none')

  var info = m[1]
  var dev = match(info, /\d[\d.]+(?= Dev)/)
  var beta = match(info, /\d[\d.]+(?= Beta)/)
  var stable = match(info, /\d[\d.]+(?=$)/)

  return {
    dev: dev,
    beta: beta,
    stable: stable,
    info: info
  }

  function match (str, re) {
    var m = str.match(re)
    if (m) return m[0]
  }
}

function ua () {
  var str = navigator.userAgent
  var ver = str.match(/Chrome\/([\d.]+)/)[1]
  var arch = str.includes('x64') ? 'x64' : 'x86'
  return {
    ver: ver,
    arch: arch
  }
}

function compare (versions) {
  return new Promise(function (resolve, reject) {
    chrome.storage.sync.get({
      channel: 'dev'
    }, function (items) {
      var channel = items.channel
      var v = versions[channel]
      if (v == null) {
        return reject(new Error(`missing ${channel} in ${versions.info}`))
      }

      var info = ua()
      var data = {
        versions: versions,
        channel: channel,
        version: info.ver,
        arch: info.arch,
        hasUpdates: false
      }
      var delta = compareVersion(v, info.ver)
      if (delta > 0) data.hasUpdates = true
      resolve(data)
    })
  })
}

function compareVersion (v1, v2) {
  if (v1 === v2) return 0

  var a1 = v1.split('.')
  var a2 = v2.split('.')
  for (let i = 0, len = a1.length; i < len; ++i) {
    let delta = a1[i] - a2[i]
    if (delta) return delta
  }
}
