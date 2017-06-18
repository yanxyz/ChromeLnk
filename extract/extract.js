#!/usr/bin/env node

'use strict'

var fs = require('fs')
var exec = require('child_process').execSync

var args = process.argv
if (args.length < 3) help()

var exe = args[2]
var ver = getVer(exe)
unpack()
createShortCut()

function help () {
  console.log('Usage: node extract.js <chrome_installer.exe>')
  console.log()
  console.log('Examples:')
  console.log('node extract.js 43.0.2357.130_chrome_installer.exe')
  console.log('node extract.js 39.0.2145.4_chrome64_installer.exe')
  process.exit(1)
}

function getVer (str) {
  var re = /^(\d[\d\.]+)_chrome(64)?_installer\.exe$/
  var m = str.match(re)
  if (!m) {
    console.log('invalid name of chrome_installer.exe')
    console.log()
    help()
  }
  return m[1]
}

function unpack () {
  console.log('unpack...')
  var cmd = `7za x -o${ver} -aoa ${exe}`
  exec(cmd)
  var pkg = `${ver}/Chrome.7z`
  cmd = `7za x -o${ver} -aoa ${pkg}`
  exec(cmd)
  fs.unlink(pkg)
}

function createShortCut () {
  var cmd = `cscript.exe shortcut.vbs ${ver}`
  exec(cmd)
}
