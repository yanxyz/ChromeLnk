# Google Chrome

在天朝不能访问 google, 相应的，Google Chrome 安装与更新都是问题。

注意：下面说的是 Windows 平台。

## MyChrome

之前我一直用 [MyChrome](http://code.taobao.org/p/mychrome/wiki/index/)。
它可以用来制作便携版 Chrome，并且能自动更新。但是墙越来越高，
不能检查与下载更新。

在最近的版本里，作者试图解决这个问题。加入 python 脚本，查找可以访问的
google ip。但是在我这里没什么效果。更严重是，有时 Chrome 无法启动，
只能重启电脑解决。

因此，我决定不再用它，自己想办法解决。这个项目便是目前我的解决方案。

## 更新

sina 目录是一个 Chrome 扩展，作用是从新浪下载网站检查 Chrome 最新版本。

如果用 VPN 就不用这么折腾。但是又要折腾 VPN。

## 多版本

或者说便携版——我的目的是创建多版本的 Chrome 以用来测试兼容性。原理是使用选项
`--user-data-dir`。

extract 目录是一个 node.js 程序，作用是解压 chrome_installer.exe，并
生成一个快捷方式。



## 版权

MIT @ Ivan Yan
