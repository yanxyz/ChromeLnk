#!/usr/bin/env node

'use strict'

const fs = require('fs')
const path = require('path')
const exec = require('child_process').execSync

const args = process.argv
if (args.length < 3) help()

const exe = args[2]
const ver = getVer(exe)
unpack()
createShortCut(ver)

function help () {
  console.log('Usage: node extract.js <chrome_installer.exe>')
  console.log()
  console.log('Examples:')
  console.log('node extract.js exe\\43.0.2357.130_chrome_installer.exe')
  console.log('node extract.js exe\\39.0.2145.4_chrome64_installer.exe')
  process.exit(1)
}

function getVer (str) {
  const re = /(\d[\d\.]+)_chrome(64)?_installer\.exe$/
  const m = str.match(re)
  if (!m) {
    console.log('invalid name of chrome_installer.exe')
    console.log()
    help()
  }
  return m[1]
}

function unpack () {
  console.log('unpack...')
  let cmd = `7za x -oexe/${ver} -aoa ${exe}`
  exec(cmd)
  let pkg = `exe/${ver}/Chrome.7z`
  cmd = `7za x -oexe/${ver} -aoa ${pkg}`
  exec(cmd)
  fs.unlink(pkg)
}

function createShortCut (ver) {
  const dir = path.join(__dirname, 'exe', ver)
  const exe = path.join(dir, 'Chrome-bin/chrome.exe')
  const lnk = `lnk/${ver}.lnk`
  const cache = path.join(process.env['TEMP'], 'Chrome', ver)
  const args = [
      `--user-data-dir="path.join(dir, 'User Data')"`,
      `--disk-cache-dir="${cache}"`,
      '--no-first-run'
    ].map(function (x) {
      return x.replace(/"/g, '\\q')
    }).join('\\b')

  const cmd = `shortcut.vbs "${exe}" "${lnk}" "${args}"`
  exec(cmd)
}
