namespace AMCL
{
    partial class AMCL
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMCL));
            this.Exit = new System.Windows.Forms.Button();
            this.OpenFolder = new System.Windows.Forms.Button();
            this.StartPanel = new System.Windows.Forms.Panel();
            this.GameStart = new System.Windows.Forms.Button();
            this.VerList = new ControlEx.ComboBoxEx();
            this.ConfigSet = new System.Windows.Forms.Button();
            this.ClientUpdate = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.LinkLabel();
            this.提示 = new System.Windows.Forms.ToolTip(this.components);
            this.Hidden = new System.Windows.Forms.Button();
            this.SetPanel = new System.Windows.Forms.Panel();
            this.GameList = new System.Windows.Forms.ListBox();
            this.CancelSet = new System.Windows.Forms.Button();
            this.SaveSet = new System.Windows.Forms.Button();
            this.SystemSet = new System.Windows.Forms.GroupBox();
            this.SetGameFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.GameFile = new System.Windows.Forms.MaskedTextBox();
            this.SoltLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.JavaSolt = new System.Windows.Forms.NumericUpDown();
            this.SetJavaFile = new System.Windows.Forms.Button();
            this.JavaFile = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayerSet = new System.Windows.Forms.GroupBox();
            this.ScreenSize = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Registered = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.PassWord = new System.Windows.Forms.MaskedTextBox();
            this.UserName = new System.Windows.Forms.MaskedTextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.鼠标右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.更改版本名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.浏览文件夹 = new System.Windows.Forms.FolderBrowserDialog();
            this.浏览文件 = new System.Windows.Forms.OpenFileDialog();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.InfoBox = new System.Windows.Forms.RichTextBox();
            this.托盘图标 = new System.Windows.Forms.NotifyIcon(this.components);
            this.托盘菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReNameNo = new System.Windows.Forms.Button();
            this.ReNameOk = new System.Windows.Forms.Button();
            this.ReNameBox = new System.Windows.Forms.MaskedTextBox();
            this.ReNamePanl = new System.Windows.Forms.Panel();
            this.AssetPanel = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.VerGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.other = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ConfigAuto = new System.Windows.Forms.CheckBox();
            this.SampleJson = new System.Windows.Forms.GroupBox();
            this.SampleText = new System.Windows.Forms.TextBox();
            this.UpdateAuto = new System.Windows.Forms.CheckBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.UpdateJsonURL = new ControlEx.TextBoxEx();
            this.UpdateList = new System.Windows.Forms.ListBox();
            this.dataGridViewProgressColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPanel.SuspendLayout();
            this.SetPanel.SuspendLayout();
            this.SystemSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JavaSolt)).BeginInit();
            this.PlayerSet.SuspendLayout();
            this.鼠标右键菜单.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.托盘菜单.SuspendLayout();
            this.ReNamePanl.SuspendLayout();
            this.AssetPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SampleJson.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.CausesValidation = false;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Default;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.Black;
            this.Exit.Location = new System.Drawing.Point(618, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(20, 20);
            this.Exit.TabIndex = 0;
            this.Exit.TabStop = false;
            this.Exit.Text = "×";
            this.提示.SetToolTip(this.Exit, "关闭");
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // OpenFolder
            // 
            this.OpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFolder.BackColor = System.Drawing.Color.Transparent;
            this.OpenFolder.CausesValidation = false;
            this.OpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFolder.Location = new System.Drawing.Point(125, 61);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(75, 23);
            this.OpenFolder.TabIndex = 1;
            this.OpenFolder.TabStop = false;
            this.OpenFolder.Text = "打开目录";
            this.OpenFolder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpenFolder.UseVisualStyleBackColor = false;
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // StartPanel
            // 
            this.StartPanel.BackColor = System.Drawing.Color.LightGray;
            this.StartPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartPanel.Controls.Add(this.GameStart);
            this.StartPanel.Controls.Add(this.VerList);
            this.StartPanel.Controls.Add(this.ConfigSet);
            this.StartPanel.Controls.Add(this.ClientUpdate);
            this.StartPanel.Controls.Add(this.OpenFolder);
            this.StartPanel.Location = new System.Drawing.Point(428, 264);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(200, 84);
            this.StartPanel.TabIndex = 2;
            // 
            // GameStart
            // 
            this.GameStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GameStart.CausesValidation = false;
            this.GameStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GameStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GameStart.Location = new System.Drawing.Point(0, 0);
            this.GameStart.Name = "GameStart";
            this.GameStart.Size = new System.Drawing.Size(110, 52);
            this.GameStart.TabIndex = 4;
            this.GameStart.TabStop = false;
            this.GameStart.Text = "启动游戏";
            this.GameStart.UseVisualStyleBackColor = true;
            this.GameStart.Click += new System.EventHandler(this.GameStart_Click);
            // 
            // VerList
            // 
            this.VerList.CausesValidation = false;
            this.VerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VerList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.VerList.FormattingEnabled = true;
            this.VerList.Location = new System.Drawing.Point(0, 62);
            this.VerList.Name = "VerList";
            this.VerList.Size = new System.Drawing.Size(110, 20);
            this.VerList.TabIndex = 7;
            this.VerList.TabStop = false;
            this.VerList.SelectedIndexChanged += new System.EventHandler(this.VerList_SelectedIndexChanged);
            // 
            // ConfigSet
            // 
            this.ConfigSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigSet.CausesValidation = false;
            this.ConfigSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfigSet.Location = new System.Drawing.Point(125, 29);
            this.ConfigSet.Name = "ConfigSet";
            this.ConfigSet.Size = new System.Drawing.Size(75, 23);
            this.ConfigSet.TabIndex = 3;
            this.ConfigSet.TabStop = false;
            this.ConfigSet.Text = "配置设置";
            this.ConfigSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ConfigSet.UseVisualStyleBackColor = true;
            this.ConfigSet.Click += new System.EventHandler(this.ConfigSet_Click);
            // 
            // ClientUpdate
            // 
            this.ClientUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientUpdate.CausesValidation = false;
            this.ClientUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientUpdate.Location = new System.Drawing.Point(125, 0);
            this.ClientUpdate.Name = "ClientUpdate";
            this.ClientUpdate.Size = new System.Drawing.Size(75, 23);
            this.ClientUpdate.TabIndex = 2;
            this.ClientUpdate.TabStop = false;
            this.ClientUpdate.Text = "资源更新";
            this.ClientUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ClientUpdate.UseVisualStyleBackColor = true;
            this.ClientUpdate.Click += new System.EventHandler(this.ClientUpdate_Click);
            // 
            // version
            // 
            this.version.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.CausesValidation = false;
            this.version.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.version.ForeColor = System.Drawing.Color.Gray;
            this.version.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.version.LinkColor = System.Drawing.Color.Gray;
            this.version.Location = new System.Drawing.Point(12, 339);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(215, 12);
            this.version.TabIndex = 3;
            this.version.TabStop = true;
            this.version.Text = "MineCraft Launcher by Antecer Ver：";
            this.version.UseMnemonic = false;
            this.version.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.version_LinkClicked);
            // 
            // Hidden
            // 
            this.Hidden.BackColor = System.Drawing.Color.Transparent;
            this.Hidden.CausesValidation = false;
            this.Hidden.Cursor = System.Windows.Forms.Cursors.Default;
            this.Hidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hidden.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hidden.ForeColor = System.Drawing.Color.Black;
            this.Hidden.Location = new System.Drawing.Point(590, 2);
            this.Hidden.Name = "Hidden";
            this.Hidden.Size = new System.Drawing.Size(20, 20);
            this.Hidden.TabIndex = 6;
            this.Hidden.TabStop = false;
            this.Hidden.Text = "-";
            this.提示.SetToolTip(this.Hidden, "最小化到托盘");
            this.Hidden.UseVisualStyleBackColor = false;
            this.Hidden.Click += new System.EventHandler(this.Hidden_Click);
            // 
            // SetPanel
            // 
            this.SetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SetPanel.BackColor = System.Drawing.Color.Lavender;
            this.SetPanel.CausesValidation = false;
            this.SetPanel.Controls.Add(this.GameList);
            this.SetPanel.Controls.Add(this.CancelSet);
            this.SetPanel.Controls.Add(this.SaveSet);
            this.SetPanel.Controls.Add(this.SystemSet);
            this.SetPanel.Controls.Add(this.PlayerSet);
            this.SetPanel.Location = new System.Drawing.Point(60, 45);
            this.SetPanel.Name = "SetPanel";
            this.SetPanel.Size = new System.Drawing.Size(520, 270);
            this.SetPanel.TabIndex = 4;
            this.SetPanel.Visible = false;
            // 
            // GameList
            // 
            this.GameList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GameList.FormattingEnabled = true;
            this.GameList.ItemHeight = 12;
            this.GameList.Location = new System.Drawing.Point(10, 10);
            this.GameList.Name = "GameList";
            this.GameList.Size = new System.Drawing.Size(152, 244);
            this.GameList.TabIndex = 9;
            this.GameList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameList_MouseUp);
            // 
            // CancelSet
            // 
            this.CancelSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelSet.Location = new System.Drawing.Point(342, 231);
            this.CancelSet.Name = "CancelSet";
            this.CancelSet.Size = new System.Drawing.Size(75, 23);
            this.CancelSet.TabIndex = 7;
            this.CancelSet.Text = "取消";
            this.CancelSet.UseVisualStyleBackColor = true;
            this.CancelSet.Click += new System.EventHandler(this.CancelSet_Click);
            // 
            // SaveSet
            // 
            this.SaveSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveSet.Location = new System.Drawing.Point(424, 231);
            this.SaveSet.Name = "SaveSet";
            this.SaveSet.Size = new System.Drawing.Size(75, 23);
            this.SaveSet.TabIndex = 6;
            this.SaveSet.Text = "保存";
            this.SaveSet.UseVisualStyleBackColor = true;
            this.SaveSet.Click += new System.EventHandler(this.SaveSet_Click);
            // 
            // SystemSet
            // 
            this.SystemSet.BackColor = System.Drawing.Color.Transparent;
            this.SystemSet.Controls.Add(this.SetGameFile);
            this.SystemSet.Controls.Add(this.label6);
            this.SystemSet.Controls.Add(this.GameFile);
            this.SystemSet.Controls.Add(this.SoltLabel);
            this.SystemSet.Controls.Add(this.label4);
            this.SystemSet.Controls.Add(this.label5);
            this.SystemSet.Controls.Add(this.JavaSolt);
            this.SystemSet.Controls.Add(this.SetJavaFile);
            this.SystemSet.Controls.Add(this.JavaFile);
            this.SystemSet.Controls.Add(this.label3);
            this.SystemSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SystemSet.ForeColor = System.Drawing.Color.Black;
            this.SystemSet.Location = new System.Drawing.Point(178, 120);
            this.SystemSet.Name = "SystemSet";
            this.SystemSet.Size = new System.Drawing.Size(330, 100);
            this.SystemSet.TabIndex = 5;
            this.SystemSet.TabStop = false;
            this.SystemSet.Text = "系统配置";
            // 
            // SetGameFile
            // 
            this.SetGameFile.BackColor = System.Drawing.Color.Transparent;
            this.SetGameFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetGameFile.ForeColor = System.Drawing.Color.Black;
            this.SetGameFile.Location = new System.Drawing.Point(281, 74);
            this.SetGameFile.Name = "SetGameFile";
            this.SetGameFile.Size = new System.Drawing.Size(40, 21);
            this.SetGameFile.TabIndex = 16;
            this.SetGameFile.Text = "浏览";
            this.SetGameFile.UseVisualStyleBackColor = false;
            this.SetGameFile.Click += new System.EventHandler(this.SetGameFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "游戏目录";
            // 
            // GameFile
            // 
            this.GameFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GameFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameFile.Location = new System.Drawing.Point(77, 74);
            this.GameFile.Name = "GameFile";
            this.GameFile.Size = new System.Drawing.Size(195, 21);
            this.GameFile.TabIndex = 15;
            // 
            // SoltLabel
            // 
            this.SoltLabel.BackColor = System.Drawing.Color.Transparent;
            this.SoltLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SoltLabel.ForeColor = System.Drawing.Color.Black;
            this.SoltLabel.Location = new System.Drawing.Point(162, 24);
            this.SoltLabel.Name = "SoltLabel";
            this.SoltLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SoltLabel.Size = new System.Drawing.Size(110, 12);
            this.SoltLabel.TabIndex = 10;
            this.SoltLabel.Text = "本机内存:32767MB";
            this.SoltLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SoltLabel.UseMnemonic = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(140, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "MB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Java路径";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // JavaSolt
            // 
            this.JavaSolt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.JavaSolt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JavaSolt.Location = new System.Drawing.Point(77, 20);
            this.JavaSolt.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.JavaSolt.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.JavaSolt.Name = "JavaSolt";
            this.JavaSolt.Size = new System.Drawing.Size(60, 21);
            this.JavaSolt.TabIndex = 7;
            this.JavaSolt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.JavaSolt.Value = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            // 
            // SetJavaFile
            // 
            this.SetJavaFile.BackColor = System.Drawing.Color.Transparent;
            this.SetJavaFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SetJavaFile.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetJavaFile.ForeColor = System.Drawing.Color.Black;
            this.SetJavaFile.Location = new System.Drawing.Point(281, 47);
            this.SetJavaFile.Name = "SetJavaFile";
            this.SetJavaFile.Size = new System.Drawing.Size(40, 21);
            this.SetJavaFile.TabIndex = 13;
            this.SetJavaFile.Text = "浏览";
            this.SetJavaFile.UseVisualStyleBackColor = false;
            this.SetJavaFile.Click += new System.EventHandler(this.SetJavaFile_Click);
            // 
            // JavaFile
            // 
            this.JavaFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.JavaFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JavaFile.Location = new System.Drawing.Point(77, 47);
            this.JavaFile.Name = "JavaFile";
            this.JavaFile.Size = new System.Drawing.Size(195, 21);
            this.JavaFile.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Java内存";
            // 
            // PlayerSet
            // 
            this.PlayerSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerSet.Controls.Add(this.ScreenSize);
            this.PlayerSet.Controls.Add(this.label8);
            this.PlayerSet.Controls.Add(this.Registered);
            this.PlayerSet.Controls.Add(this.label2);
            this.PlayerSet.Controls.Add(this.PassWord);
            this.PlayerSet.Controls.Add(this.UserName);
            this.PlayerSet.Controls.Add(this.labelName);
            this.PlayerSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayerSet.ForeColor = System.Drawing.Color.Black;
            this.PlayerSet.Location = new System.Drawing.Point(178, 10);
            this.PlayerSet.Name = "PlayerSet";
            this.PlayerSet.Size = new System.Drawing.Size(330, 100);
            this.PlayerSet.TabIndex = 1;
            this.PlayerSet.TabStop = false;
            this.PlayerSet.Text = "玩家配置";
            // 
            // ScreenSize
            // 
            this.ScreenSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScreenSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ScreenSize.FormattingEnabled = true;
            this.ScreenSize.Items.AddRange(new object[] {
            "FullScreen",
            "1920*1080",
            "1680*1050",
            "1440*900",
            "1280*720",
            "1024*768",
            "800*600",
            "默认大小"});
            this.ScreenSize.Location = new System.Drawing.Point(77, 74);
            this.ScreenSize.Name = "ScreenSize";
            this.ScreenSize.Size = new System.Drawing.Size(120, 20);
            this.ScreenSize.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(18, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "游戏尺寸";
            // 
            // Registered
            // 
            this.Registered.AutoSize = true;
            this.Registered.BackColor = System.Drawing.Color.Transparent;
            this.Registered.Location = new System.Drawing.Point(226, 22);
            this.Registered.Name = "Registered";
            this.Registered.Size = new System.Drawing.Size(95, 16);
            this.Registered.TabIndex = 6;
            this.Registered.TabStop = true;
            this.Registered.Text = "启用正版登陆";
            this.Registered.UseVisualStyleBackColor = false;
            this.Registered.Click += new System.EventHandler(this.Registered_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "登陆密码";
            // 
            // PassWord
            // 
            this.PassWord.BackColor = System.Drawing.Color.Lavender;
            this.PassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PassWord.Enabled = false;
            this.PassWord.Location = new System.Drawing.Point(77, 47);
            this.PassWord.Name = "PassWord";
            this.PassWord.Size = new System.Drawing.Size(120, 21);
            this.PassWord.TabIndex = 2;
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserName.Location = new System.Drawing.Point(77, 20);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(120, 21);
            this.UserName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(18, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 12);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "用户名称";
            // 
            // 鼠标右键菜单
            // 
            this.鼠标右键菜单.AllowDrop = true;
            this.鼠标右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更改版本名称ToolStripMenuItem,
            this.删除选中版本ToolStripMenuItem});
            this.鼠标右键菜单.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.鼠标右键菜单.Name = "鼠标右键菜单";
            this.鼠标右键菜单.ShowImageMargin = false;
            this.鼠标右键菜单.Size = new System.Drawing.Size(116, 48);
            // 
            // 更改版本名称ToolStripMenuItem
            // 
            this.更改版本名称ToolStripMenuItem.Name = "更改版本名称ToolStripMenuItem";
            this.更改版本名称ToolStripMenuItem.ShowShortcutKeys = false;
            this.更改版本名称ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.更改版本名称ToolStripMenuItem.Text = "更改版本名称";
            this.更改版本名称ToolStripMenuItem.Click += new System.EventHandler(this.更改版本名称ToolStripMenuItem_Click);
            // 
            // 删除选中版本ToolStripMenuItem
            // 
            this.删除选中版本ToolStripMenuItem.Name = "删除选中版本ToolStripMenuItem";
            this.删除选中版本ToolStripMenuItem.ShowShortcutKeys = false;
            this.删除选中版本ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.删除选中版本ToolStripMenuItem.Text = "删除选中版本";
            this.删除选中版本ToolStripMenuItem.Click += new System.EventHandler(this.删除选中版本ToolStripMenuItem_Click);
            // 
            // 浏览文件
            // 
            this.浏览文件.FileName = "javaw.exe";
            this.浏览文件.Filter = "java.exe|java.exe|javaw.exe|javaw.exe";
            this.浏览文件.FilterIndex = 2;
            this.浏览文件.Title = "选择Java";
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InfoPanel.Controls.Add(this.InfoBox);
            this.InfoPanel.Location = new System.Drawing.Point(30, 30);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(580, 300);
            this.InfoPanel.TabIndex = 5;
            this.InfoPanel.Visible = false;
            // 
            // InfoBox
            // 
            this.InfoBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.InfoBox.Location = new System.Drawing.Point(3, 3);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ReadOnly = true;
            this.InfoBox.Size = new System.Drawing.Size(568, 288);
            this.InfoBox.TabIndex = 0;
            this.InfoBox.TabStop = false;
            this.InfoBox.Text = "";
            // 
            // 托盘图标
            // 
            this.托盘图标.ContextMenuStrip = this.托盘菜单;
            this.托盘图标.Icon = ((System.Drawing.Icon)(resources.GetObject("托盘图标.Icon")));
            this.托盘图标.Text = "AMCL";
            this.托盘图标.MouseClick += new System.Windows.Forms.MouseEventHandler(this.托盘图标_MouseClick);
            // 
            // 托盘菜单
            // 
            this.托盘菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.托盘菜单.Name = "托盘菜单";
            this.托盘菜单.Size = new System.Drawing.Size(101, 48);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // ReNameNo
            // 
            this.ReNameNo.BackColor = System.Drawing.Color.Transparent;
            this.ReNameNo.CausesValidation = false;
            this.ReNameNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReNameNo.ForeColor = System.Drawing.Color.Black;
            this.ReNameNo.Location = new System.Drawing.Point(178, 6);
            this.ReNameNo.Name = "ReNameNo";
            this.ReNameNo.Size = new System.Drawing.Size(40, 21);
            this.ReNameNo.TabIndex = 18;
            this.ReNameNo.TabStop = false;
            this.ReNameNo.Text = "取消";
            this.ReNameNo.UseVisualStyleBackColor = false;
            this.ReNameNo.Click += new System.EventHandler(this.ReNameNo_Click);
            // 
            // ReNameOk
            // 
            this.ReNameOk.BackColor = System.Drawing.Color.Transparent;
            this.ReNameOk.CausesValidation = false;
            this.ReNameOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReNameOk.ForeColor = System.Drawing.Color.Black;
            this.ReNameOk.Location = new System.Drawing.Point(132, 6);
            this.ReNameOk.Name = "ReNameOk";
            this.ReNameOk.Size = new System.Drawing.Size(40, 21);
            this.ReNameOk.TabIndex = 17;
            this.ReNameOk.TabStop = false;
            this.ReNameOk.Text = "确定";
            this.ReNameOk.UseVisualStyleBackColor = false;
            this.ReNameOk.Click += new System.EventHandler(this.ReNameOk_Click);
            // 
            // ReNameBox
            // 
            this.ReNameBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReNameBox.Location = new System.Drawing.Point(6, 6);
            this.ReNameBox.Name = "ReNameBox";
            this.ReNameBox.Size = new System.Drawing.Size(120, 21);
            this.ReNameBox.TabIndex = 2;
            // 
            // ReNamePanl
            // 
            this.ReNamePanl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReNamePanl.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ReNamePanl.CausesValidation = false;
            this.ReNamePanl.Controls.Add(this.ReNameNo);
            this.ReNamePanl.Controls.Add(this.ReNameBox);
            this.ReNamePanl.Controls.Add(this.ReNameOk);
            this.ReNamePanl.Location = new System.Drawing.Point(208, 164);
            this.ReNamePanl.Name = "ReNamePanl";
            this.ReNamePanl.Size = new System.Drawing.Size(224, 32);
            this.ReNamePanl.TabIndex = 10;
            this.ReNamePanl.Visible = false;
            // 
            // AssetPanel
            // 
            this.AssetPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AssetPanel.BackColor = System.Drawing.Color.LightGray;
            this.AssetPanel.Controls.Add(this.back);
            this.AssetPanel.Controls.Add(this.TabControl);
            this.AssetPanel.Location = new System.Drawing.Point(20, 30);
            this.AssetPanel.Name = "AssetPanel";
            this.AssetPanel.Size = new System.Drawing.Size(600, 300);
            this.AssetPanel.TabIndex = 11;
            this.AssetPanel.Visible = false;
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.back.BackColor = System.Drawing.Color.White;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.back.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.back.Location = new System.Drawing.Point(562, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 20);
            this.back.TabIndex = 1;
            this.back.Text = "返回";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // TabControl
            // 
            this.TabControl.CausesValidation = false;
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(600, 300);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.VerGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "新游戏获取";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // VerGridView
            // 
            this.VerGridView.AllowUserToAddRows = false;
            this.VerGridView.AllowUserToDeleteRows = false;
            this.VerGridView.AllowUserToResizeColumns = false;
            this.VerGridView.AllowUserToResizeRows = false;
            this.VerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.VerGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.VerGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.VerGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.type,
            this.time,
            this.other});
            this.VerGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerGridView.Location = new System.Drawing.Point(3, 3);
            this.VerGridView.MultiSelect = false;
            this.VerGridView.Name = "VerGridView";
            this.VerGridView.ReadOnly = true;
            this.VerGridView.RowHeadersVisible = false;
            this.VerGridView.RowTemplate.Height = 23;
            this.VerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VerGridView.Size = new System.Drawing.Size(586, 268);
            this.VerGridView.TabIndex = 0;
            this.VerGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VerGridView_CellDoubleClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "版本";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 35;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.type.HeaderText = "类型";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.type.Width = 35;
            // 
            // time
            // 
            this.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.time.HeaderText = "发布时间";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.time.Width = 59;
            // 
            // other
            // 
            this.other.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.other.HeaderText = "下载";
            this.other.Name = "other";
            this.other.ReadOnly = true;
            this.other.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.other.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.ConfigAuto);
            this.tabPage2.Controls.Add(this.SampleJson);
            this.tabPage2.Controls.Add(this.UpdateAuto);
            this.tabPage2.Controls.Add(this.UpdateButton);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.UpdateJsonURL);
            this.tabPage2.Controls.Add(this.UpdateList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "整合包更新";
            // 
            // ConfigAuto
            // 
            this.ConfigAuto.AutoSize = true;
            this.ConfigAuto.Location = new System.Drawing.Point(350, 53);
            this.ConfigAuto.Name = "ConfigAuto";
            this.ConfigAuto.Size = new System.Drawing.Size(72, 16);
            this.ConfigAuto.TabIndex = 17;
            this.ConfigAuto.Text = "MODS配置";
            this.ConfigAuto.UseVisualStyleBackColor = true;
            this.ConfigAuto.CheckedChanged += new System.EventHandler(this.ConfigAuto_CheckedChanged);
            // 
            // SampleJson
            // 
            this.SampleJson.Controls.Add(this.SampleText);
            this.SampleJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SampleJson.Location = new System.Drawing.Point(169, 79);
            this.SampleJson.Name = "SampleJson";
            this.SampleJson.Size = new System.Drawing.Size(412, 185);
            this.SampleJson.TabIndex = 16;
            this.SampleJson.TabStop = false;
            this.SampleJson.Text = "Json结构示例";
            // 
            // SampleText
            // 
            this.SampleText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SampleText.Location = new System.Drawing.Point(7, 18);
            this.SampleText.Multiline = true;
            this.SampleText.Name = "SampleText";
            this.SampleText.ReadOnly = true;
            this.SampleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SampleText.Size = new System.Drawing.Size(399, 159);
            this.SampleText.TabIndex = 0;
            this.SampleText.Text = resources.GetString("SampleText.Text");
            this.SampleText.WordWrap = false;
            // 
            // UpdateAuto
            // 
            this.UpdateAuto.AutoSize = true;
            this.UpdateAuto.Location = new System.Drawing.Point(428, 53);
            this.UpdateAuto.Name = "UpdateAuto";
            this.UpdateAuto.Size = new System.Drawing.Size(72, 16);
            this.UpdateAuto.TabIndex = 15;
            this.UpdateAuto.Text = "自动更新";
            this.UpdateAuto.UseVisualStyleBackColor = true;
            this.UpdateAuto.CheckedChanged += new System.EventHandler(this.UpdateAuto_CheckedChanged);
            // 
            // UpdateButton
            // 
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Location = new System.Drawing.Point(506, 50);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 14;
            this.UpdateButton.Text = "立即更新";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "UpdateURL：";
            // 
            // UpdateJsonURL
            // 
            this.UpdateJsonURL.BackGroundText = "在这里填入用于整合包更新的Json，例：http://../xx.json";
            this.UpdateJsonURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateJsonURL.Location = new System.Drawing.Point(169, 23);
            this.UpdateJsonURL.Name = "UpdateJsonURL";
            this.UpdateJsonURL.Size = new System.Drawing.Size(412, 21);
            this.UpdateJsonURL.TabIndex = 13;
            this.UpdateJsonURL.Leave += new System.EventHandler(this.UpdateJsonURL_Leave);
            // 
            // UpdateList
            // 
            this.UpdateList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UpdateList.FormattingEnabled = true;
            this.UpdateList.ItemHeight = 12;
            this.UpdateList.Location = new System.Drawing.Point(2, 4);
            this.UpdateList.Name = "UpdateList";
            this.UpdateList.Size = new System.Drawing.Size(152, 268);
            this.UpdateList.TabIndex = 10;
            this.UpdateList.SelectedIndexChanged += new System.EventHandler(this.UpdateList_SelectedIndexChanged);
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewProgressColumn1.HeaderText = "";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.ReadOnly = true;
            this.dataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AMCL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.ControlBox = false;
            this.Controls.Add(this.SetPanel);
            this.Controls.Add(this.StartPanel);
            this.Controls.Add(this.AssetPanel);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.ReNamePanl);
            this.Controls.Add(this.Hidden);
            this.Controls.Add(this.version);
            this.Controls.Add(this.Exit);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AMCL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMCL";
            this.Load += new System.EventHandler(this.AMCL_Load);
            this.Shown += new System.EventHandler(this.AMCL_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AMCL_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AMCL_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AMCL_MouseUp);
            this.StartPanel.ResumeLayout(false);
            this.SetPanel.ResumeLayout(false);
            this.SystemSet.ResumeLayout(false);
            this.SystemSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JavaSolt)).EndInit();
            this.PlayerSet.ResumeLayout(false);
            this.PlayerSet.PerformLayout();
            this.鼠标右键菜单.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.托盘菜单.ResumeLayout(false);
            this.ReNamePanl.ResumeLayout(false);
            this.ReNamePanl.PerformLayout();
            this.AssetPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VerGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.SampleJson.ResumeLayout(false);
            this.SampleJson.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button OpenFolder;
        private System.Windows.Forms.Button GameStart;
        private System.Windows.Forms.Button ConfigSet;
        private System.Windows.Forms.Button ClientUpdate;
        private System.Windows.Forms.Panel StartPanel;
        private System.Windows.Forms.LinkLabel version;
        private System.Windows.Forms.ToolTip 提示;
        private System.Windows.Forms.Panel SetPanel;
        private System.Windows.Forms.GroupBox PlayerSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown JavaSolt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox PassWord;
        private System.Windows.Forms.MaskedTextBox UserName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label SoltLabel;
        private System.Windows.Forms.Button SetGameFile;
        private System.Windows.Forms.MaskedTextBox GameFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SetJavaFile;
        private System.Windows.Forms.MaskedTextBox JavaFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox SystemSet;
        private System.Windows.Forms.Button CancelSet;
        private System.Windows.Forms.Button SaveSet;
        private System.Windows.Forms.ContextMenuStrip 鼠标右键菜单;
        private System.Windows.Forms.RadioButton Registered;
        private System.Windows.Forms.ToolStripMenuItem 更改版本名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中版本ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog 浏览文件夹;
        private System.Windows.Forms.OpenFileDialog 浏览文件;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.RichTextBox InfoBox;
        private System.Windows.Forms.NotifyIcon 托盘图标;
        private System.Windows.Forms.Button Hidden;
        private ControlEx.ComboBoxEx VerList;
        private System.Windows.Forms.ListBox GameList;
        private System.Windows.Forms.Button ReNameNo;
        private System.Windows.Forms.Button ReNameOk;
        private System.Windows.Forms.MaskedTextBox ReNameBox;
        private System.Windows.Forms.Panel ReNamePanl;
        private System.Windows.Forms.Panel AssetPanel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView VerGridView;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.ListBox UpdateList;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn other;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox SampleJson;
        private System.Windows.Forms.CheckBox UpdateAuto;
        private System.Windows.Forms.Button UpdateButton;
        private ControlEx.TextBoxEx UpdateJsonURL;
        private System.Windows.Forms.TextBox SampleText;
        private System.Windows.Forms.ContextMenuStrip 托盘菜单;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ComboBox ScreenSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ConfigAuto;
    }
}

