# Kraken

## 语言选择 / Language

#### [en_US](https://github.com/RafertyLee/Kraken/blob/main/README.md)

---

## 什么是Kraken

**Kraken项目目前还处在启动阶段，以下的介绍是我们期望能够实现的目标**

kRPC 是坎巴拉太空计划(Kerbal Space Program, KSP)这款游戏的一个MOD，您能用编写程序的形式来对游戏中的载具进行控制。Kraken 是基于kRPC c++版本进行开发的动态链接库项目，可以在“利用编程玩游戏”的过程中为您提供各种帮助，它包括基本的物理计算，以及路径规划、自动驾驶和自动对接等功能。

#### [查看kRPC官方文档](https://krpc.github.io/krpc/index.html)

### Kraken的特性

- Kraken是跨语言的：和kRPC一样，可以在Java、python、C#和C等各主流语言中调用。
- Kraken是基于kRPC的：采用与kRPC相同的数据结构进行编写，可以与kRPC程序混用。
- Kraken是模块化设计的：它以基本的物理函数与控制算法为基础，建立起不同层级、不同用途的功能模块，并提供相应的API。

---

## 项目目标

- 为了编程：相信肯定是有“不管程序在做什么，我用一下程序就快乐”这样的人存在的，您可以直接利用Kraken中已经封装好的物理计算模块，并绕过大量物理、编程知识的学习，快速得到初步的运行效果。
- 为了游戏：我们深知KSP这个游戏中是存在着大量重复操作的，包括最基本的入轨、交会、对接、再入等过程，以及发射卫星、登月旅游、营救Kerman等合同，您可以将Kraken当作节省手操的工具，或者优化手操误差的工具。
- 降低入门门槛：kRPC是编程，对于未接触过编程的玩家，甚至是连基本的航空航天相关物理定律都不了解的玩家，直接上手kRPC的难度是极高的。尽管Kraken也是编程，我们希望通过更少的代码来让您快速实现一些诸如发射、对接等具体的功能。
- 增加教学引导：kRPC的例程是非常少的，这也变相增加了kRPC的入门难度。在开发的过程中，一方面，我们想要增加项目的数量，尽量对各种可能的需求场景进行覆盖；另一方面，我们会对封装程度比较高的复杂过程进行解释，以便更好地让您了解函数中在做什么，并方便您对参数甚至函数过程本身的修改。
- 避免重复性工作：kRPC为我们提供了大量的数据接口和交互形式，但并没有提供任何对于某个过程（如发射入轨、交会对接等）的解决方案，甚至可以发现在kRPC的开发中会出现人手一套的PID控制器，我们希望提供一些频繁使用的功能模块以防止出现重复造轮子的浪费。
- 加入可视化功能：kRPC程序内部的计算是抽象的，我们无法直观地观察到各种数据所构成的空间，为了让您能够快速地核对计算机的理解是否和您所想象的一致，我们会结合Qt来编写一些程序界面，包括交互的功能和快速绘图，进一步下拉入门和调试的门槛。

### Kraken交流平台

闻道有先后，术业有专攻，庞大的项目必然需要各个领域的取长补短，您开发的项目可能可以成功运行，但专业的人可以提供运算速度更快的、复杂度更低的、误差更加精确的方案，我们需要社区中更多的交流，希望对于Kraken项目的开发能够起到一定的作用。

### 项目计划

1. 编写与kRPC交互功能

2. 根据需要修改kRPC以适配Kraken功能

3. 编写算法库，提供自动发射，自动无大气/有大气着陆，自动执行节点等操作模块

4. 提供Kraken可视化工具，降低使用门槛

5. 编写文档，让新玩家无门槛入门Kraken

---

## 我们诚挚邀请您加入到项目中来

对于专业人员，怀抱着对KSP和kRPC的热爱，非常欢迎您加入我们，从对简单发射的尝试变为对目前最伟大也是唯一（悲）的kRPC库的贡献中来，集思广益，共同达到个人无法企及的成就
您可以提交pull request，或者联系项目维护者 [@RafertyLee](https://github.com/RafertyLee) 、贡献者 [@MrGEFORCE](https://github.com/MrGEFORCE)

#### [@RafertyLee](https://github.com/RafertyLee)其他联系方式

- 邮箱：[raferty2006@outlook.com](mailto:raferty2006@outlook.com)
- QQ：3546889584

#### [@MrGEFORCE](https://github.com/MrGEFORCE)其他联系方式

- 邮箱：[mr_geforce@qq.com](mailto:mr_geforce@qq.com)
- Bilibili：[Mr_GEFORCE的bilibili空间](https://space.bilibili.com/22746431)
- Q群：470568345（验证消息：Mr_GEFORCE的KSP生涯存档中的公司名字叫Mr.G INDUSTRIAL）

#### Project Kraken开发群

- Q群号：[830266535](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=49Yx0OIPuIwxxp71M4efdLDjUSkulXog&authKey=fYoJ320TiF%2Fu8kcAQBIxig4WzKFTQDY5URf7TfKWB9EwL8yGcpCZ6mH6AbPN6EFq&noverify=0&group_code=830266535)

---
