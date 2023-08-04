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
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;


/// <summary>
/// 
/// </summary>
public partial class ProcessController
{
    private Process cmdProcess; // 命令行进程对象
    private BackgroundWorker worker; // 输出流异步获取
    private BackgroundWorker errorWorker; // 错误流异步获取
    private Window window; // 使用命令行的Unity窗口

    public ProcessController(Window window)
    {
        this.window = window;
        Init();
    }

    // 初始化进程对象
    public void Init()
    {
        cmdProcess = new Process(); // 实例化命令行进程
        cmdProcess.StartInfo.CreateNoWindow = true; // 不创建窗口
        cmdProcess.StartInfo.FileName = @"cmd"; // 使用cmd开启进程
        cmdProcess.StartInfo.Arguments = "";
        cmdProcess.StartInfo.UseShellExecute = false; // 不使用shell
        cmdProcess.StartInfo.RedirectStandardError = true; // 重定向标准错误流
        cmdProcess.StartInfo.RedirectStandardInput = true; // 重定向标准输入流
        cmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出流
        cmdProcess.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(936); // 输出流编码
        cmdProcess.StartInfo.StandardErrorEncoding = Encoding.GetEncoding(936); // 错误流编码

        cmdProcess.Start(); // 启动线程

        cmdProcess.StandardInput.AutoFlush = true; // 自动刷新输入流

        // 启动输出流异步获取
        worker = new BackgroundWorker();
        worker.DoWork += Background_DoWork;
        worker.RunWorkerAsync();

        // 启动错误流异步获取
        errorWorker = new BackgroundWorker();
        errorWorker.DoWork += Error_DoWork;
        errorWorker.RunWorkerAsync();
    }

    // 重启进程
    public void Reset()
    {
        cmdProcess.Kill(); // 停止进程
        cmdProcess.CloseMainWindow();
        cmdProcess.Close();
        Init(); // 重新初始化
    }

    private void Background_DoWork(object sender, DoWorkEventArgs e)
    {
        while (true)
        {
            int c = cmdProcess.StandardOutput.Read();
            window.AppendChar((char)c);
        }
    }

    private void Error_DoWork(object sender, DoWorkEventArgs e)
    {
        while (true)
        {
            int c = cmdProcess.StandardError.Read();
            window.AppendChar((char)c);
        }
    }

    // 发送命令
    public void SendCommand(string cmd)
    {
        cmdProcess.StandardInput.WriteLine(cmd);
    }
}
