using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Diagnostics;
//using BepInEx; // BepInEx库，配合ScriptEngine和DemystifyExceptions调试
using System.Security.Policy;

/// <summary>
/// TODO: 
/// 1 使用toolbar按钮开关窗口
/// 2 重写ui，调整布局、字号，加入可拖动、调整大小，可以给命令、输出和错误给不同的字体颜色
/// 3 自动滚动到末行
/// 4 行数占满后，添加新行时自动清除第一行
/// </summary>

[KSPAddon(KSPAddon.Startup.AllGameScenes, false)] // 反正不调用游戏内的scene资源，直接允许任何情况下调用窗口
//[BepInPlugin("Kraken.Console", "KrakenConsole", "1.0")]  // BepInEx的Attribute设置，调试用不重要
public class Gui : MonoBehaviour //如果使用BepInEx，这里继承BaseUnityPlugin(如果我没记错)
{
    //window 整个窗体
    public Rect windowRect = new Rect(20, 20, 500, 300); // 窗体形状

    //scroll viewer 滚动窗口
    public Vector2 scrollViewVector = Vector2.zero; // 滚动条位置
    public Rect scrollViewPos = new Rect(25,25,450,220); // 显示区域的形状
    public Rect scrollViewRect = new Rect(0,0,400,1000); // 画布的形状
    public Rect textRect = new Rect(0,0,430,1000); // 画布上的文字框的形状

    //text area 显示命令行输出
    public string innerText { get; private set; } // 命令行内部文字

    //text Field 命令输入框
    public Rect textFieldRect = new Rect(22,260,430,20); // 命令输入框的形状
    public string command; // 输入命令的内容

    //button 重启命令行按钮，未实装，手动输入exit效果一样
    public Rect buttonRect;

    private CommandLine cmd; // 命令行控件
    private int lines; // 行数
    public bool activate; // 是否显示

    void Start()
    {
        // 初始化一些变量
        innerText = "";
        cmd = new CommandLine(this);
        lines = 0;
        command = "";
        //UnityEngine.Debug.Log("Kraken Console Loaded"); // debug用的
    }

    void Update()
    {
        // 按alt+k显示或不显示
        if (Input.GetKey(KeyCode.LeftAlt)&&Input.GetKeyDown(KeyCode.K)) activate = !activate;
    }

    void OnGUI()
    {
        // 绘制窗口
        if (activate) windowRect = GUI.Window(9988, windowRect, WindowFunction, "Kraken Console");
    }

    void WindowFunction(int windowID)
    {
        // 滚动条区域
        scrollViewVector = GUI.BeginScrollView(scrollViewPos, scrollViewVector, scrollViewRect); //滚动条区域本体
        GUI.TextArea(textRect, innerText); // 内部的文字框
        GUI.EndScrollView(); // 结束编辑滚动条

        // 指令条
        command = GUI.TextArea(textFieldRect, command); // 获取并显示正在编辑的指令

        // 如果指令条不为空，且末尾是换行\n，执行指令
        if (command != "" && command[command.Length-1] == '\n')
        {
            // cls指令清屏
            if (command == "cls\n")
            {
                innerText = "";
            }
            // exit指令重启命令行
            else if (command == "exit\n")
            {
                cmd.Restart();
                innerText = "";
                
            }
            // 将指令发送到命令行
            else
            {
                cmd.SendCommand(command);
                command = "";
            }
            //清空命令条
            command = "";
        }
    }
    public void AppendText(string text)
    {
        // 输出窗口显示新内容
        innerText += text + "\n";
        lines += 1;
    }
}
