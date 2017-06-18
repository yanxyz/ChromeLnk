'use strict'

const config = require('./config')
const exec = require('child_process').execSync

const name = process.argv[2]

if (!name) {
  console.log('Usage: node shortcut.js <name> [-d]')
  console.log()
  console.log('name    use which property of config')
  console.log('-d      delete the shortcut and user-data-dir')
  process.exit()
}

if (!config[name]) {
  console.error('Error: config does not have the property:', name)
  process.exit()
}

const c = config[name]
let userdatadir
const a = c.args.map(function (x) {
  x = x.replace(/"/g, '\\q')
  if (x.startsWith('--user-data-dir=')) {
    userdatadir = x.replace('--user-data-dir=', '')
  }
  return x
}).join('\\b')

if (process.argv[3] === '-d') {
  if (!userdatadir) {
    console.log('Warn: config.' + name + '.args dose not have --user-data-dir')
    process.exit()
  }
  exec(`clear.vbs "${c.lnk}" "${userdatadir}"`)
} else {
  exec(`shortcut.vbs "${c.exe}" "${c.lnk}" "${a}"`)
}
