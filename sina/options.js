/* global chrome */

'use strict'

document.addEventListener('DOMContentLoaded', restoreOptions)
var select = document.getElementById('channel')
select.addEventListener('change', saveOptions)

function restoreOptions () {
  chrome.storage.sync.get({
    channel: 'dev'
  }, function (items) {
    select.value = items.channel
  })
}

function saveOptions () {
  chrome.storage.sync.set({
    channel: select.value
  })
}
