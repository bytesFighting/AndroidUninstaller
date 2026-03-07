using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUninstaller.android
{
    internal class Android
    {
        public static string DefaultPath = "./android-debug-bridge/adb";
        public static string AdbPath => FindAdbInPath() ?? DefaultPath;

        /// <summary>
        /// 在环境变量 PATH 中查找 adb 可执行文件
        /// </summary>
        /// <returns>adb 完整路径；未找到返回空字符串</returns>
        public static string FindAdbInPath()
        {
            string pathEnv = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
            if (string.IsNullOrEmpty(pathEnv))
                return string.Empty;

            char separator = Environment.OSVersion.Platform == PlatformID.Win32NT ? ';' : ':';
            string[] paths = pathEnv.Split(separator);

            foreach (var dir in paths)
            {
                try
                {
                    string fullPath = System.IO.Path.Combine(dir, "adb");
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                        fullPath += ".exe";

                    if (System.IO.File.Exists(fullPath))
                        return fullPath;
                }
                catch
                {
                    // 忽略无效路径
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取 adb 可执行文件路径，优先使用环境变量 PATH 中查找
        /// </summary>
        
        public static string ExecuteAdbCommand(string arguments)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = AdbPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        StandardOutputEncoding = System.Text.Encoding.UTF8,
                        StandardErrorEncoding = System.Text.Encoding.UTF8
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    output += Environment.NewLine + error;
                }

                return output;
            }
            catch (Exception ex)
            {
                return $"Error executing adb command: {ex.Message}";
            }
        }

        public static async Task<string> ExecuteAdbCommandAsync(string arguments)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = AdbPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        StandardOutputEncoding = System.Text.Encoding.UTF8,
                        StandardErrorEncoding = System.Text.Encoding.UTF8
                    }
                };

                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    output += Environment.NewLine + error;
                }

                return output;
            }
            catch (Exception ex)
            {
                return $"Error executing adb command: {ex.Message}";
            }
        }

        public static string GetConnectedDevices()
        {
            return ExecuteAdbCommand("devices");
        }

        public static string GetInstalledPackages()
        {
            return ExecuteAdbCommand("shell pm list packages");
        }
    }

}
