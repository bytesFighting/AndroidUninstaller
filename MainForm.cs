using AndroidUninstaller.android;

namespace AndroidUninstaller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void GetConnect(object sender, EventArgs e)
        {
            string output = Android.ExecuteAdbCommand("devices");
            if (output.Contains("device"))
            {
                string[] lines = output.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    if (line.Contains("device") && !line.Contains("List of devices attached"))
                    {
                        string deviceId = line.Split("\t")[0];
                        MessageBox.Show($"已连接设备：{deviceId}");
                    }
                }
            }
            else
            {
                MessageBox.Show("未连接设备");
            }
        }

        private void GetInstalledPackages(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;

            string output = Android.ExecuteAdbCommand("shell pm list packages");

            string[] lines = output.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (line.StartsWith("package:"))
                {
                    string packageName = line["package:".Length..];
                    string appName = Package.GetAppName(packageName);
                    dataGridView1.Rows.Add(false, packageName, appName);
                }
            }
        }

        private void Uninstall(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["check"].Value is bool isChecked && isChecked)
                {
                    string packageName = row.Cells["packageName"].Value?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(packageName))
                    {
                        string output = Android.ExecuteAdbCommand($"shell pm uninstall {packageName}"); 
                        //string output = Android.ExecuteAdbCommand($"shell pm uninstall -k {packageName}");    -k 保留用户数据
                        if (output.Contains("Failure [-1000]"))
                        {
                            MessageBox.Show($"卸载失败：{packageName}");
                        }
                        //string output = Android.ExecuteAdbCommand($"shell pm uninstall --user 0 {packageName}");  // 需要root权限
                        //if (output.IndexOf("Failure [-1000]") != -1)
                        //{
                        //    MessageBox.Show($"卸载失败：{packageName}");
                        //}
                    }
                }
            }
        }

        private void GetActivated(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;

            string output = Android.ExecuteAdbCommand("shell \"dumpsys window | grep mCurrentFocus\"");

            string[] lines = output.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string packageLine = line.Trim();
                // dataGridView1.Rows.Add(true, packageLine, "");
                if (packageLine.StartsWith("mCurrentFocus=Window"))
                {
                    // dataGridView1.Rows.Add(true, packageName, packageLine);
                    // 提取包名：从 "mCurrentFocus=Window{ebce4e4 u0 mark.via/mark.via.Shell}" 中获取 "mark.via"
                    int start = packageLine.IndexOf(' ', packageLine.IndexOf(' ') + 1) + 1;          // 跳过 "u0"
                    // int slash = line.IndexOf("/", start);       // 找到第一个 "/"
                    int slash = packageLine.IndexOf('/', start);       // 找到第一个 "/"
                    if (slash > start)
                    {
                        string packageName = packageLine[start..slash];
                        dataGridView1.Rows.Add(true, packageName, "");
                    }
                }
            }
        }

        private void SearchPackage(object sender, EventArgs e)
        {
            string packageName = searchText.Text.Trim();
            if (string.IsNullOrEmpty(packageName))
            {
                MessageBox.Show("请输入要搜索的包名");
                return;
            }
            // 遍历所有行，仅保留包名中包含搜索关键字的行
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                var row = dataGridView1.Rows[i];
                var cellValue = row.Cells["packageName"].Value?.ToString();
                if (cellValue == null || !cellValue.Contains(packageName, StringComparison.OrdinalIgnoreCase))
                {
                    row.Cells["check"].Value = false;
                }
                else
                {
                    row.Cells["check"].Value = true;
                    // 显示跳转到该行
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    // dataGridView1.Display = i;
                    dataGridView1.Rows[i].Selected = true;
                }

            }

        }

        private void CanselCheckAll(object sender, EventArgs e)
        {
            // 遍历所有行，将检查框设为 false
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                var row = dataGridView1.Rows[i];
                row.Cells["check"].Value = false;
            }
        }

        private void CopyPackageName(object sender, EventArgs e)
        {
            var sb = new System.Text.StringBuilder();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["check"].Value is bool isChecked && isChecked)
                {
                    object? packageCellValue = row.Cells["packageName"].Value;
                    string? packageName = packageCellValue.ToString();
                    if (!string.IsNullOrEmpty(packageName))
                    {
                        sb.AppendLine(packageName);
                    }
                }
            }
            if (sb.Length > 0)
            {
                Clipboard.SetText(sb.ToString().TrimEnd('\n'));
                MessageBox.Show("已复制选中的包名");
            }
            else
            {
                MessageBox.Show("未选中任何包");
            }
        }
    }
}
