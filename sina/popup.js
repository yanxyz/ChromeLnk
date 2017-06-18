/* global check */

'use strict'

const sina = {
  pageUrl: 'http://down.tech.sina.com.cn/page/40975.html',
  dev: [5, 6],
  beta: [7, 8],
  stable: [9, 10]
}

check(sina.pageUrl)
.then(function (data) {
  var c = data.channel
  var a = data.arch
  var html = `<p>${data.versions.info}</p><p>当前版本： ${data.version} ${c} ${a}</p>`

  if (data.hasUpdates) {
    let id = sina[data.channel][a === 'x64' ? 1 : 0]
    let ver = data.versions[c]
    html += `有新版本： <a href="http://down.tech.sina.com.cn/download/d_load.php?d_id=40975&down_id=${id}" target="_blank">${ver} ${c} ${a}</a>`
  } else {
    html += '<p>已是最新版本</p>'
  }

  document.getElementById('content').innerHTML = html
})
.catch(function (err) {
  document.getElementById('error').textContent = err
})
