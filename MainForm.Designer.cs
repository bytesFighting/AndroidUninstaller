namespace AndroidUninstaller
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            check = new DataGridViewCheckBoxColumn();
            packageName = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            cancelCheck = new Button();
            search = new Button();
            searchText = new TextBox();
            activated = new Button();
            uninstall = new Button();
            packageManager = new Button();
            connect = new Button();
            copyPackage = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(copyPackage);
            splitContainer1.Panel2.Controls.Add(cancelCheck);
            splitContainer1.Panel2.Controls.Add(search);
            splitContainer1.Panel2.Controls.Add(searchText);
            splitContainer1.Panel2.Controls.Add(activated);
            splitContainer1.Panel2.Controls.Add(uninstall);
            splitContainer1.Panel2.Controls.Add(packageManager);
            splitContainer1.Panel2.Controls.Add(connect);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 416;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { check, packageName, name });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(800, 416);
            dataGridView1.TabIndex = 0;
            // 
            // check
            // 
            check.HeaderText = "选中";
            check.Name = "check";
            check.Width = 50;
            // 
            // packageName
            // 
            packageName.HeaderText = "包名";
            packageName.Name = "packageName";
            packageName.Width = 300;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.HeaderText = "应用";
            name.Name = "name";
            // 
            // cancelCheck
            // 
            cancelCheck.Location = new Point(327, 3);
            cancelCheck.Name = "cancelCheck";
            cancelCheck.Size = new Size(75, 23);
            cancelCheck.TabIndex = 6;
            cancelCheck.Text = "取消选中";
            cancelCheck.UseVisualStyleBackColor = true;
            cancelCheck.Click += CanselCheckAll;
            // 
            // search
            // 
            search.Location = new Point(713, 4);
            search.Name = "search";
            search.Size = new Size(75, 23);
            search.TabIndex = 5;
            search.Text = "搜索";
            search.UseVisualStyleBackColor = true;
            search.Click += SearchPackage;
            // 
            // searchText
            // 
            searchText.Location = new Point(535, 4);
            searchText.Name = "searchText";
            searchText.Size = new Size(172, 23);
            searchText.TabIndex = 4;
            // 
            // activated
            // 
            activated.Location = new Point(165, 3);
            activated.Name = "activated";
            activated.Size = new Size(75, 23);
            activated.TabIndex = 3;
            activated.Text = "当前打开";
            activated.UseVisualStyleBackColor = true;
            activated.Click += GetActivated;
            // 
            // uninstall
            // 
            uninstall.Location = new Point(246, 3);
            uninstall.Name = "uninstall";
            uninstall.Size = new Size(75, 23);
            uninstall.TabIndex = 2;
            uninstall.Text = "卸载选中";
            uninstall.UseVisualStyleBackColor = true;
            uninstall.Click += Uninstall;
            // 
            // packageManager
            // 
            packageManager.Location = new Point(84, 3);
            packageManager.Name = "packageManager";
            packageManager.Size = new Size(75, 23);
            packageManager.TabIndex = 1;
            packageManager.Text = "获取应用";
            packageManager.UseVisualStyleBackColor = true;
            packageManager.Click += GetInstalledPackages;
            // 
            // connect
            // 
            connect.Location = new Point(3, 3);
            connect.Name = "connect";
            connect.Size = new Size(75, 23);
            connect.TabIndex = 0;
            connect.Text = "连接";
            connect.UseVisualStyleBackColor = true;
            connect.Click += GetConnect;
            // 
            // copyPackage
            // 
            copyPackage.Location = new Point(408, 3);
            copyPackage.Name = "copyPackage";
            copyPackage.Size = new Size(75, 23);
            copyPackage.TabIndex = 7;
            copyPackage.Text = "复制包名";
            copyPackage.UseVisualStyleBackColor = true;
            copyPackage.Click += CopyPackageName;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            Text = "AndroidUninstaller";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button connect;
        private DataGridView dataGridView1;
        private Button packageManager;
        private Button uninstall;
        private DataGridViewCheckBoxColumn check;
        private DataGridViewTextBoxColumn packageName;
        private DataGridViewTextBoxColumn name;
        private Button activated;
        private Button search;
        private TextBox searchText;
        private Button cancelCheck;
        private Button copyPackage;
    }
}
