# Project Kraken 代码规范

## 文件

### 代码文件命名

- 头文件：`xxx_xxx.h`

- 源码文件与对应头文件名保持一致：`xxx_xxx.cpp`

- 名称单词之间用下划线连接，不使用中文

### 代码文件结构以及示例

#### 头文件

- 后缀：*.h

```cpp
// 文档名称.h
// 功能说明：若干行

// 系统库文件
// C库写在前，C++库在后
#include <stdio.h>
#include <math.h>
#include <algorithm>
#include <string>
#include <vector>
#include <map>
...

// 项目内头文件
#include "lib1.h" // 说明：xxx
#include "lib2.h" // 说明：xxx
...

namespace A // 命名空间含义
{
    // 可选：定义前声明
    struct struct_A; // 说明
    struct struct_B; // 说明

    struct struct_A
    {
    public:
        std::string name; // 说明。eg. 载具名称
        vec3 vehicle_position; // 说明。eg. 载具绝对位置
    private:
        bool state1; // 说明。eg. 载具状态

    public:
        struct_A(std::string name); // 说明；参数说明（待确定是否需要）
        void do_something(); // 说明
    private:
        void helper_1(size_t size_in); // 说明
    }
    ...

    namespace B // 命名空间含义
    {
        struct struct_A1; // 说明
        struct struct_A2; // 说明
        ...
    }
}

```

#### 源码文件

- 后缀：*.cpp

```cpp
// 文档名称.cpp

#include "文档名称.h"


// 系统库文件（注释：只把头文件所需要的库文件include到头文件，其他的放这里）
#include <unordered_map>
#include <map>
#include <filesystem>


using namespace A; // 允许，可以using对应头文件中定义的命名空间
using namespace std; // 不允许

struct_A::struct_A(std::string name): name(name) // 同名变量
{
    this->name = name; // 不建议
    vehicle_position = vec3(0.0f); // 建议：说明目的
    ...
}

void struct_A::do_something()
{
    using namespace std::filesystem = fs; // 允许且建议
    using namespace std; // 允许但不建议

    std::string new_name; // 变量名清晰的，可以不需要注释
    size_t temp_size = 0; // 临时变量名称不清晰的，强烈建议注释

    if(...)
    {
        if(...)
        {
            if(...)
            {
                ...
                // 括号嵌套不超过3层
                // 超过时候，辅助函数放在private下
                helper_1(1000);

                // 善用TODO标记
                // TODO: 添加xxxxxx
            }
        }
    }
}
```

## 规范与建议

### 变量规范/建议

- 命名使用下划线法，名称清晰，多用小写。临时变量名称无需清晰，但是必须附注释
  
  - 示例：`int vehicle_state;` `std::vector<std::string> part_name_list;`
  - 示例：`int temp; // 存储某某临时变量`

- 不在全局空间内定义全局变量。尽量不定义命名空间内全局变量。尽量提高封装性。
  
  - 不建议：
    
    ```cpp
    namespace np
    {
        int mode1 = 0;
        int mode2 = 0;
    
        void do_something()
        {
            if(mode1 == 3)
            {
                ...
            }
            if(mode2 == 2)
            {
                ...
            }
        }
    }
    ```
  
  - 建议：
    
    ```cpp
    namespace np
    {
        enum class something_mode // 说明
        {
            modeA,
            modeB,
            modeC
        }
    
        struct mode_set // 说明
        {
        public:
            something_mode mode1;
            something_mode mode2;
    
        public:
            mode_set(something_mode mode1 = 0, something_mode mode2 = 0): mode1(mode1), mode2(mode2) {}
        }
    
        void do_something(mode_set input_mode_set) // 说明
        {
            if(input_mode_set.mode1 == 3)
            {
                ...
            }
            if(input_mode_set.mode2 == 2)
            {
                ...
            }
        }
    }
    ```

### 函数规范/建议

- 命名使用下划线法，名称清晰，多用小写

- 非`std::initializer_list<T>`的左花括号另起一行：提高可读性
  
  - 示例：
    
    ```cpp
    // 注释可以放这里
    void np::do_A() // 注释放这里也可以
    {
    
    }
    ```

### 类和结构规范/建议

- 命名使用下划线法，名称清晰，多用小写
  
  - 示例：`struct vehicle_spatial_info`

- 成员与方法分隔，巧用范围修饰符
  
  - 示例：
    
    ```cpp
    struct vehicle_spatial_info
    {
    // 成员
    public:
        vec3 position;
        vec4 rotation_quad;
        vec3 velocity;
    private:
        ...
    
    // 方法，与前文成员空行分割
    public:
        vehicle_spatial_info(vec3 position, vec4 rotation_quad, vec3 velocity); // 初始化类
        void do_something(); // I want to DOO something and put a note here
    private:
        void helper_1(); // 执行xxx
        int helper_2(vec3 pos); // pos：作用；执行，计算xxxx；输出：xxxx
    }
    ```












