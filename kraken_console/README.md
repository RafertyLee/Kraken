# KrakenConsole

使用IMGUI和Process异步读写实现的ksp内置命令行

将KrakenConsole/bin/Debug/KrakenConsole.dll放入GameData即可

使用其他代码编写的脚本，每次输出需要flush标准输出流缓存，例如python

```python
#直接flush
print("content",flush=True)


#或者使用sys.stdout.flush()
from sys.stdout import flush
print("content")
flush()
```

