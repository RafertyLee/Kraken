/* Kraken Console
 * Copyright (c) 2023 RafertyLee   <https://github.com/RafertyLee>
 * Copyright (c) 2023 Rat       <https://github.com/Rat-L>
 * Copyright (c) 2023 Stehsaer       <https://github.com/Stehsaer>
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU Affero General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *   GNU Affero General Public License for more details.
 *
 *   You should have received a copy of the GNU Affero General Public License
 *   along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Diagnostics;
//using BepInEx; // BepInEx库，配合ScriptEngine和DemystifyExceptions调试
//using System.Security.Policy;

/// <summary>
/// TODO: 
/// 1 使用toolbar按钮开关窗口
/// 2 强制中止指令
/// 3 (可选)调整布局、字号，加入可调整大小，给命令、输出和错误给不同的字体颜色
/// </summary>

[KSPAddon(KSPAddon.Startup.AllGameScenes, false)] // 反正不调用游戏内的scene资源，直接允许任何情况下调用窗口
//[BepInPlugin("Kraken.Console", "KrakenConsole", "1.0")]  // BepInEx的Attribute设置，调试用不重要
public class Window : MonoBehaviour //如果使用BepInEx，这里继承BaseUnityPlugin(如果我没记错)
{
    // window 整个窗体
    public Rect windowView = new Rect(20, 20, 500, 300); // 窗体形状

    // scroll viewer 滚动窗口
    public Vector2 scrollVector = Vector2.zero; // 滚动条位置
    public Rect scrollDisplayRect = new Rect(25,25,450,220); // 显示区域的形状
    public Rect scrollCanvasRect = new Rect(0,0,400,1000); // 画布的形状
    public Rect textRect = new Rect(0,0,430,1000); // 画布上的文字框的形状

    // text area 显示命令行输出
    public string outputText { get; private set; } // 命令行内部文字

    // text Field 命令输入框
    public Rect cmdLineRect = new Rect(22,260,430,20); // 命令输入框的形状
    public string command; // 输入命令的内容

    private ProcessController cmd; // 命令行控件
    public bool activate; // 是否显示
    private List<string> lines; // 行
    private bool scroll = false; // 下一帧滚动条是否跳转到行尾

    void Start()
    {
        // 初始化一些变量
        outputText = "";
        cmd = new ProcessController(this);
        command = "";
        lines = new List<string>();
        lines.Add("");
    }

    void Update()
    {
        // 按alt+k显示或不显示窗口
        if (Input.GetKey(KeyCode.LeftAlt)&&Input.GetKeyDown(KeyCode.K)) activate = !activate;
    }

    void OnGUI()
    {
        // 绘制窗口
        if (activate) windowView = GUI.Window(9988, windowView, WindowFunction, "Kraken Console");
    }

    void WindowFunction(int windowID)
    {
        GUIStyle style = GUI.skin.textArea; // 获取textArea预设
        style.fontSize = 15; // 设置字号

        // 滚动条区域
        scrollVector = GUI.BeginScrollView(scrollDisplayRect, scrollVector, scrollCanvasRect); //滚动条区域本体
        GUI.TextArea(textRect, outputText); // 内部的文字框
        GUI.EndScrollView(); // 结束编辑滚动条

        // 指令输入框
        command = GUI.TextArea(cmdLineRect, command); // 获取并显示正在编辑的指令

        // 如果指令条不为空，且末尾是换行\n，执行指令
        if (command != "" && command[command.Length-1] == '\n')
        {
            // cls指令清屏
            if (command == "cls\n")
            {
                lines.Clear(); // 清空输出行列表
                lines.Add(""); // 初始化第一行
            }
            // exit指令重启命令行
            else if (command == "exit\n")
            {
                lines.Clear();
                lines.Add("");
                cmd.Reset(); // 重启命令行
            }
            // 将指令发送到命令行
            else
            {
                cmd.SendCommand(command.Substring(0,command.Length-1));
            }
            // 清空命令输入框
            command = "";
        }
        int maxLineNum = (int)(textRect.height / style.lineHeight); // 可显示的最大行数
        int firstLineIdx; // 可显示的首行索引
        outputText = ""; // 清空输出
        // 计算可显示的首行索引
        if (lines.Count>maxLineNum) firstLineIdx = lines.Count - maxLineNum; 
        else firstLineIdx = 0;
        // 输出内容
        for(int i=firstLineIdx;i<lines.Count;i++) outputText += lines[i];
        // 滚动至最后一行
        if (scroll)
        {
            float yPos = lines.Count* style.lineHeight + 0.5f * style.lineHeight - scrollDisplayRect.height; // 滚动后的y位置
            if (yPos < 0) yPos = 0;
            scrollVector.y = yPos;
            scroll = false; // 下一帧不滚动
        }
        GUI.DragWindow(); // 窗口可拖动
    }

    // 输出列表插入字符
    public void AppendChar(char c)
    {
        lines[lines.Count - 1] += c; // 在最后一行末尾插入字符
        if (c == '\n') lines.Add(""); // 遇到换行符另起一行
        scroll = true; // 下一帧自动滚动
    }
}
