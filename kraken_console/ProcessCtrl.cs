using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

public class CommandLine
{
    private Process p; // 内部命令行
    private Gui gui; // 用于异步输出结果
    public CommandLine(Gui gui)
    {
        Init();
        this.gui = gui;
    }
    public void SendCommand(string command)
    {
        p.StandardInput.Write(command); // 标准输入指令
        p.StandardInput.AutoFlush = true; // 把缓冲flush进去
    }
    public void Restart()
    {
        p.Kill(); // 关闭进程
        Init(); // 重开进程
    }

    void Init()
    {
        // 初始化进程
        p = new Process(); // 实例化进程
        ProcessStartInfo psi = p.StartInfo; // 进程启动信息管理器

        psi.FileName = "cmd.exe"; // 使用cmd执行
        psi.UseShellExecute = false; // 不使用shell，否则不支持标准输入输出流重定向

        psi.RedirectStandardError = true; // 重定向标准错误流
        psi.RedirectStandardInput = true; // 重定向标准输入流
        psi.RedirectStandardOutput = true; // 重定向标准输出流
        psi.StandardOutputEncoding = Encoding.GetEncoding(936); // 编码为936(其他设置极可能乱码)
        psi.StandardErrorEncoding = Encoding.GetEncoding(936); // 同上

        // 不创建窗口
        psi.CreateNoWindow = true; 
        psi.WindowStyle = ProcessWindowStyle.Hidden;

        p.Start(); // 启动线程

        // 启动输出流和错误流的异步读取
        p.BeginOutputReadLine();
        p.BeginErrorReadLine(); 
        p.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
        p.ErrorDataReceived += new DataReceivedEventHandler(ProcessErrorHandler);
    }
    void ProcessOutputHandler(System.Object sendingProcess,DataReceivedEventArgs outLine)
    {
        // 输出流处理
        //Control.CheckForIllegalCrossThreadCalls = false;
        if (outLine.Data != null) gui.AppendText(outLine.Data);
    }
    void ProcessErrorHandler(System.Object sendingProcess, DataReceivedEventArgs outLine)
    {
        // 错误流处理
        //Control.CheckForIllegalCrossThreadCalls = false;
        if (outLine.Data != null) gui.AppendText(outLine.Data);
    }
}
