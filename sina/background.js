/* global check */

'use strict'

// show options page after install
chrome.runtime.onInstalled.addListener(function () {
  chrome.storage.sync.get('channel', function (items) {
    if (!items.channel) chrome.runtime.openOptionsPage()
  })
})

// check update when launch Chrome
chrome.runtime.onStartup.addListener(checkUpdates)
// checkUpdates()

function checkUpdates () {
  chrome.storage.sync.get({
    last: 0
  }, function (items) {
    var last = items.last
    var now = Date.now()
    if (now - last > 24 * 3600) return

    check('http://down.tech.sina.com.cn/page/40975.html')
    .then(function (data) {
      if (data.hasUpdates) notify('发现新版本。')
    })
    .catch(function (err) {
      notify(err.message)
    })
    .then(function () {
      chrome.storage.sync.set({ last: now })
    })
  })
}

function notify (msg) {
  chrome.notifications.create('', {
    type: 'basic',
    title: 'Chrome Update',
    iconUrl: 'icon-38.png',
    message: msg
  })
}
