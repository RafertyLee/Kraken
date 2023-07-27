# KrakenConsole

## 简介

使用IMGUI和Process异步读写实现的ksp内置命令行

## 安装方法

将KrakenConsole/bin/Debug/KrakenConsole.dll放入GameData启动游戏

## 使用方法

- 进入存档后左Alt+K显示或隐藏窗口
- 输入cls清屏
- 输入exit重启命令行

## 注意事项

- 隐藏窗口不会停止命令行运行，如果需要停止，请使用exit命令
- 每行输出尽量不要超过窗口宽度，否则文本框自动滚动和防溢出功能会出错
- 命令行每次启动会自动输入两次换行，可能会发生报错，报错信息中有“锘？”，此为待修复bug，不影响正常使用
- 仓库代码仅在1.6.1测试成功，如果在1.12等较新版本使用，需要调整引用项重新编译

- 使用其他代码编写的脚本，如果每次输出没有flush标准输出流缓存，需要手动flush，例如python

```python
#直接flush
print("content",flush=True)


#或者使用sys.stdout.flush()
from sys.stdout import flush
print("content")
flush()
```

## 已知问题

* exit指令目前没有杀掉已有进程，而是直接新开进程
* 1.6.1输入流出现BOM问题，每次重启命令行需要手动回车清除bom，不影响后续使用
