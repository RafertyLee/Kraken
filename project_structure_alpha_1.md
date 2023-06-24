# Project Kraken 详细框架

## 组成部分

- Kraken Daemon：作为mod在KSP/KSP2中运行
  
  - 功能：获取游戏数据，并作为RPC服务器与Kraken Library通信
  
  - 基于kRPC

  - 提供便捷的程序内系统终端，保障全屏体验

- Kraken Library：用C++编写，供用户调用
  
  - 功能：为用户提供大量算法和功能，并与Kraken Daemon通信

- Kraken Bindings：用各种语言编写，为其他语言提供“绑定”
  
  - 主要计划支持语言：Python、VB.net
  
  - 短期内不会有较多的API开放，仅开放非常简单的模块

- Kraken Graphics：为用户提供高度可视化的操作，计划作为Kraken Daemon的拓展部分，在游戏内即可操控（未定）

## 开发顺序

1. Kraken Library与Kraken Daemon同步开发
   
   - 交互组主导开发，协调组辅助

2. Kraken Library算法开发
   
   - 算法组主导开发，协调组辅助

3. Kraken Bindings开发
   
   - 全体一起开发

4. Kraken Graphics：未有计划

## Kraken Library 组成部分

- 数据结构与物理结构（`kraken`）

- 与Daemon通信（`kraken::connection`）

- 载具控制器（`class kraken::controller`）
  
  - 包含：姿态控制，节流阀控制，载具信息获取
  
  - 控制器与载具绑定
  
  - 此部分的详细控制均为`kraken::api`与`kraken::module`所使用

- API（`kraken::api`）
  
  - 包含：获取并设置游戏，部分内容通过调用特定的`kraken::controller`方法实现
  
  - 举例：开关地图、RCS开关、SAS开关、太阳能板和降落伞

- 控制模块（`kraken::module`）
  
  - 操作模块
  
  - 举例：节点执行器，自动变轨节点创建器，自动起飞、降落


