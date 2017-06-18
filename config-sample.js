'use strict'

const path = require('path')

const TEMP_DIR = process.env['TEMP']
const CHROME_DIR = path.join(process.env['LOCALAPPDATA'], 'Google/Chrome/Application')
const CHROME_EXE = path.join(CHROME_DIR, 'chrome.exe')

module.exports = {
  clean: {
    // exe should be absloute path
    exe: CHROME_EXE,
    lnk: 'lnk/clean.lnk',
    // List of Chromium Command Line Switches
    // http://peter.sh/experiments/chromium-command-line-switches/
    // It's better that path is always quoted in case it has space.
    args: [
      `--user-data-dir="${path.join(CHROME_DIR, 'clean')}"`,
      `--disk-cache-dir="${path.join(TEMP_DIR, 'Chrome', 'clean')}"`
    ]
  },
  zh: {
    exe: CHROME_EXE,
    lnk: 'lnk/zh.lnk',
    args: [
      `--user-data-dir="${path.join(CHROME_DIR, 'zh')}"`,
      `--disk-cache-dir="${path.join(TEMP_DIR, 'Chrome', 'zh')}"`,
      '--lang=zh',
      '--no-first-run'
    ]
  }
}
