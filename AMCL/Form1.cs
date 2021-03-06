﻿using GetHash;
using JsonArchive;
using MineCraftLogin;
using ProfileSet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ZipArchive;

namespace AMCL
{
    public partial class AMCL : Form
    {
        public delegate void SetClient();   //定义全局控件处理委托
        public AMCL()
        {
            InitializeComponent();
        }
        #region 字段
        String versionLink = @"http://git.oschina.net/Antecer/AMCL/commits/master";//AMCL版本更新历史
        String UpdateVer = @"http://git.oschina.net/Antecer/AMCL/raw/master/AMCL/Properties/AssemblyInfo.cs";//AMCL最新版本号（判定是否需要更新）
        String UpdateExe = @"http://git.oschina.net/Antecer/AMCL/raw/master/AMCL/bin/Release/AMCL.exe";      //AMCL更新地址

        String VerURL = @"http://s3.amazonaws.com/Minecraft.Download/versions/";    //官方游戏下载地址（Ver.jar&Ver.json）
        String VerURLb = @"http://bmclapi.bangbang93.com/versions/";                //BMCL游戏下载地址
        String IndexsURL = @"http://s3.amazonaws.com/Minecraft.Download/indexes/";  //官方资源目录地址（index.json）
        String IndexsURLb = @"http://bmclapi.bangbang93.com/indexes/";              //BMCL资源目录地址
        String AssetsURL = @"http://resources.download.minecraft.net/";             //官方资源库地址
        String AssetsURLb = @"http://bmclapi.bangbang93.com/assets/";               //BMCL资源库地址
        String LibrariesURL = @"https://libraries.minecraft.net/";                  //官方运行库地址
        String BMCLLibURL = @"http://bmclapi.bangbang93.com/libraries/";            //BMCL运行库地址
        String ForgeLibURL = @"http://central.maven.org/maven2/";                   //Forge运行库备用地址
        String GameDir = "";    //主目录（../.minecraft）
        String strRun = "";     //启动参数
        String VerName = "";    //版本名称
        String JavaDir = "";    //Java地址
        String VerAssets = "";  //资源版本
        String screenSize = ""; //窗口尺寸
        #endregion
        #region 正版验证
        String accessToken = "";
        String clientToken = "";
        String playerUUID = "";
        String userName = "";
        String passWord = "";
        #endregion

        #region CMD启动程序的函数
        String DeBugMessage = null;
        Boolean DeBugBuff = false;
        /// <summary>
        /// CMD程序执行函数
        /// </summary>
        /// <param name="StartFileName">exe程序地址</param>
        /// <param name="StartFileArg">程序执行的参数</param>
        private void RunOrder(string StartFileName, string StartFileArg)
        {
            DeBugMessage = "[" + DateTime.Now.ToLongTimeString() + "] [启动参数]: " + StartFileArg + "\n";
            DeBugBuff = false;
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = StartFileName;      // 命令  
            CmdProcess.StartInfo.Arguments = StartFileArg;      // 参数  

            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
            CmdProcess.StartInfo.UseShellExecute = false;
            //CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
            //CmdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  

            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            CmdProcess.EnableRaisingEvents = true;                      // 启用Exited事件  
            CmdProcess.Exited += new EventHandler(CmdProcess_Exited);   // 注册进程结束事件  

            CmdProcess.Start();
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();
        }
        //异步调用，输出执行程序返回的普通消息
        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (DeBugBuff)
                {
                    DeBugMessage += e.Data.ToString() + "\n";
                }
                else
                {
                    InfoAdd(false, e.Data + "\n", Color.Black);
                    if (e.Data.IndexOf("Starting up SoundSystem") > -1)
                    {
                        HiddenWindow();  //隐藏启动器窗口
                        DeBugBuff = true;//启动游戏后不再将Debug数据输出到RichBox(防止richbox卡顿，暂时没别的办法)
                    }
                }
            }
        }
        //异步调用，输出执行程序返回的错误消息
        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (DeBugBuff)
                {
                    DeBugMessage += "[ERROR!]\n{\n" + e.Data.ToString() + "\n}\n";
                }
                else
                {
                    InfoAdd(false, "[ERROR!]\n{\n" + e.Data + "\n}\n", Color.Red);
                }
            }
        }
        /// <summary>
        /// CMD执行结束后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            ShowWindow();
            Thread.Sleep(3000);
            CloseInfoPanel();
        }
        /// <summary>
        /// 使用委托关闭Info信息界面，并显示Start界面
        /// </summary>
        private void CloseInfoPanel()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(CloseInfoPanel);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                InfoPanel.Visible = false;
                DeBugMessage = InfoBox.Text + DeBugMessage;
                File.WriteAllText(Application.StartupPath + @"\logs\AMCL.log", DeBugMessage);//保存运行日志
                InfoBox.Clear();
                StartPanel.Visible = true;
            }
        }
        #endregion

        //主窗口加载的时候触发
        private void AMCL_Load(object sender, EventArgs e)
        {
            AMCL_Update();  //启动软件更新程序
            LoadConfig();   //载入配置文件
        }

        //主窗口第一次显示的时候触发
        //窗体样式设计
        private void AMCL_Shown(object sender, EventArgs e)
        {
            StartPanel.BackColor = Color.FromArgb(0, 200, 200, 200);//启动面板背景色
            SetPanel.BackColor = Color.FromArgb(100, 200, 200, 200);//设置面板背景色
            AssetPanel.BackColor = Color.FromArgb(0, 200, 200, 200);//资源面板背景色
            if (ReadIni("背景设置", "BK[640x360]") != "")
            {
                if (File.Exists(ReadIni("背景设置", "BK[640x360]")) == false) return;
                this.BackgroundImage = Image.FromFile(ReadIni("背景设置", "BK[640x360]"));
            }
            else
            {
                WriteIni("背景设置", "BK[640x360]","");
            }
        }

        #region ini配置文件读写函数
        //向ini写入配置
        public static bool WriteIni(string Section, string Key, string Value)
        {
            String IniPath = Application.StartupPath + @"\AMCL.ini";
            if (!File.Exists(IniPath))//检查文件存在，若不存在则创建
            {
                FileStream fs;
                fs = File.Create(IniPath);
                fs.Close();
                WritePrivateProfileString("系统设置", "首次运行", "false", IniPath);
            }
            long Ret = WritePrivateProfileString(Section, Key, Value, IniPath);
            return Ret == 0L ? false : true;//返回0表示失败，非0表示成功
        }
        //从ini读取配置
        public static string ReadIni(string Section, string Key)
        {
            String IniPath = Application.StartupPath + @"\AMCL.ini";
            if (!File.Exists(IniPath))//检查文件存在，若不存在则创建
            {
                FileStream fs;
                fs = File.Create(IniPath);
                fs.Close();
                WritePrivateProfileString("系统设置", "首次运行", "true", IniPath);
            }
            StringBuilder ReStr = new StringBuilder(255);
            Int32 Size = 255;
            GetPrivateProfileString(Section, Key, "", ReStr, Size, IniPath);
            return ReStr.ToString();
        }
        [DllImport("kernel32")]//申明ini文件的写操作函数
        public static extern long WritePrivateProfileString//返回非0表示成功，0表示失败
        (
            string Section,         //指定的节名
            string Key,             //指定的键名
            string Value,           //保存字符串值
            string FilePath         //ini文件的绝对路径
        );
        [DllImport("kernel32")]//申明ini文件的读操作函数
        public static extern int GetPrivateProfileString
        (
            string Section,         //指定的节名
            string key,             //指定的键名
            string Def,             //如果未取得正确的值则返回自定义的字符串
            StringBuilder RetVal,   //保存字符串值
            int Size,               //指定RetVal的长度
            string FilePath         //ini文件的绝对路径
        );
        #endregion

        #region 无边框窗体移动函数
        Point mouseOff;
        bool moveFlag;
        //鼠标按下
        private void AMCL_MouseDown(object sender, MouseEventArgs e)
        {
            //Exit.Focus();                     //转移焦点
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                moveFlag = true;
            }
        }
        //鼠标弹起
        private void AMCL_MouseUp(object sender, MouseEventArgs e)
        {
            moveFlag = false;
        }
        //鼠标移动
        private void AMCL_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag)//移动窗体
            {
                Point mouseSet = System.Windows.Forms.Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
            }
        }
        #endregion

        #region 窗体事件处理函数
        //最小化按钮点击事件
        private void Hidden_Click(object sender, EventArgs e)
        {
            this.托盘图标.Visible = true;//显示托盘图标
            this.Hide();    //隐藏主窗口
        }
        //退出按钮点击事件
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //托盘图标点击事件
        private void 托盘图标_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.托盘图标.Visible = false;//隐藏托盘图标
                this.Show();    //显示主窗体
                this.TopMost = true;
                this.TopMost = false;
            }
        }
        //托盘菜单-显示
        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.托盘图标.Visible = false;//隐藏托盘图标
            this.Show();    //显示主窗体
            this.TopMost = true;
            this.TopMost = false;
        }
        //托盘菜单-退出
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HiddenWindow()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(HiddenWindow);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                this.托盘图标.Visible = true;//显示托盘图标
                this.Hide();    //隐藏主窗口
            }
        }
        private void ShowWindow()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(ShowWindow);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                this.托盘图标.Visible = false;//隐藏托盘图标
                this.Show();    //显示主窗体
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        #endregion

        #region 启动面板
        //启动游戏按钮
        private void GameStart_Click(object sender, EventArgs e)
        {
            if (VerList.Items.Count < 1) return;    //如果游戏选择列表为空则返回
            if (!File.Exists(JavaFile.Text))
            {
                MessageBox.Show("Java不存在！");
                ConfigSet.PerformClick();
                return;//如果Java不存在则返回
            }
            if (!Directory.Exists(GameFile.Text))
            {
                MessageBox.Show("游戏目录不存在！");
                ConfigSet.PerformClick();
                return;
            }
            if ((PassWord.Enabled == false) && (UserName.Text.Length < 3))
            {
                MessageBox.Show("用户名无效！");
                ConfigSet.PerformClick();
                UserName.Focus();
                return;
            }
            if ((PassWord.Enabled == true) && (UserName.Text.IndexOf("@") < 1))
            {
                MessageBox.Show("邮箱地址无效！");
                ConfigSet.PerformClick();
                UserName.Focus();
                return;
            }
            if (VerList.Items.Count > 0)
            {
                WriteIni("玩家配置", "游戏版本", VerList.SelectedItem.ToString());
                StartPanel.Visible = false;
                InfoPanel.Visible = true;

                string profiles = GameFile.Text + @"\launcher_profiles.json";//添加启动信息文件，若不存在
                if (!File.Exists(profiles))
                {
                    string profilesTxt = "{\n  \"clientToken\": \"\",\n  \"launcherVersion\": {\n    \"name\": \"1.6.11\",\n    \"format\": 17\n  }\n}"; 
                    File.WriteAllText(profiles, profilesTxt);
                }

                Game_Start();    //游戏文件完整性检查并启动游戏
            }
        }
        //版本选择列表
        private void VerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //获取更新按钮
        private void ClientUpdate_Click(object sender, EventArgs e)
        {
            StartPanel.Visible = false;
            AssetPanel.Visible = true;
            GetVerList();           //获取游戏版本列表
        }
        //配置设置按钮
        private void ConfigSet_Click(object sender, EventArgs e)
        {
            StartPanel.Visible = false;
            SetPanel.Visible = true;
        }
        //打开游戏文件夹
        private void OpenFolder_Click(object sender, EventArgs e)
        {
            if (VerList.Items.Count > 0)
            {
                System.Diagnostics.Process.Start(GameFile.Text + @"\versions\" + VerList.SelectedItem.ToString()); 
            }
        }
        //版本号超链接
        private void version_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(versionLink);
        }
        #endregion

        #region 程序初始化函数
        /// <summary>
        /// 加载程序配置
        /// </summary>
        private void LoadConfig()
        {
            string FirstRun = ReadIni("系统设置", "首次运行");
            if (FirstRun != "false")//判断首次运行，自动弹出设置界面
            {
                Initializer();
                StartPanel.Visible = false;
                SetPanel.Visible = true;
            }
            SetConfig("read");
            getGameList();
        }
        /// <summary>
        /// 初始化程序并尝试获取默认值
        /// </summary>
        private void Initializer()
        {
            WriteIni("系统设置","首次运行","false");
            if (Directory.Exists(Application.StartupPath + @"\.minecraft"))
            {
                GameFile.Text = @".minecraft";
            }

            string TotalSize = GetTotalPhysicalMemory();
            if (TotalSize != "unknow")
            {
                JavaSolt.Value = Convert.ToUInt32(TotalSize) / 4;
            }
            else JavaSolt.Value = Convert.ToUInt32(256);

            string strJavaFile = getValueRegEdit(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\javaws.exe\", "Path");
            if (strJavaFile != null)
            {
                JavaFile.Text = strJavaFile + @"\java.exe";
            }

            ScreenSize.Text = "默认大小";

            UserName.Text = "";
            PassWord.Text = "";
            Registered.Checked = false;
            SetConfig("write");
            WriteIni("玩家配置","游戏版本","");
        }
        /// <summary>
        /// 获取注册表的值
        /// </summary>
        /// <param name="path">路经</param>
        /// <param name="name">项名称</param>
        /// <returns>项值</returns>
        public string getValueRegEdit(string path, string name)
        {
            string value;
            try
            {
                Microsoft.Win32.RegistryKey obj = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey objItem = obj.OpenSubKey(path);
                value = objItem.GetValue(name).ToString();
            }
            catch (Exception e)//失败返回null
            {
                string err = e.Message;//
                return null;
            }
            return value;
        }
        #endregion

        #region 软件更新程序
        private void AMCL_Update()
        {
            version.Text = version.Text + Application.ProductVersion;
            Thread Update_Start = new Thread(new ThreadStart(UpdateStart));//创建一个新线程来执行更新
            Update_Start.IsBackground = true;   //设置此线程为后台线程
            Update_Start.Start();               //启动线程
        }
        /// <summary>
        /// 程序更新线程
        /// </summary>
        private void UpdateStart()
        {
            String FileAMCL = Application.ExecutablePath.Replace(".EXE",".exe");//本地文件路径
            if (File.Exists(FileAMCL + ".old")) File.Delete(FileAMCL + ".old");//删除旧文件

            Version newVersion = new Version(versioncheck(UpdateVer));      //获取更新程序版本号
            Version oldVersion = new Version(Application.ProductVersion);   //获取当前程序版本号
            if (newVersion > oldVersion)
            {
                DialogResult dr = MessageBox.Show("检测到新版本：" + newVersion.ToString() + "\r\n是否更新到最新版本？", "AMCL-Update", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    ShowInfoPanel();
                    InfoAdd(true, "正在下载更新...\n", Color.Black);
                    if (DownloadFile(UpdateExe, FileAMCL + ".tmp"))
                    {
                        InfoAdd(true, "更新下载完成！", Color.Red);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        InfoAdd(true, "更新下载失败！", Color.Red);
                        Thread.Sleep(1000);
                        HiddenInfoPanel();
                        return;
                    }
                }
            }
            if (File.Exists(FileAMCL + ".tmp"))
            {
                File.Move(FileAMCL, FileAMCL + ".old");
                File.Move(FileAMCL + ".tmp", FileAMCL);
                Application.Restart();
            }
        }
        /// <summary>
        /// 获取指定URL文件长度（大小）
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <returns>返回文件长度(string型)</returns>
        static Decimal GetHttpLength(string url)
        {
            Decimal length = 0;
            try
            {
                var req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                req.Method = "HEAD";
                req.Timeout = 5000;
                var res = (HttpWebResponse)req.GetResponse();
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    length = res.ContentLength;
                }
                res.Close();
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);//输出错误信息到标准输出流
            }
            return length;
        }
        /// <summary>
        /// 从指定网页提取字符串
        /// </summary>
        /// <returns>返回指定字符串</returns>
        private string versioncheck(string url)
        {
            string vertext = "0.0.0.0";
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), true);
                vertext = reader.ReadToEnd();
                reader.Dispose();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (vertext.Contains("AssemblyFileVersion"))
            {
                vertext = vertext.Substring(vertext.LastIndexOf("AssemblyFileVersion"));
                vertext = vertext.Replace("AssemblyFileVersion(\"", "").Replace("\")]", "");
            }
            return vertext;
        }
        /// <summary>
        /// 调用委托显示软件更新界面
        /// </summary>
        private void ShowInfoPanel()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(ShowInfoPanel);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                StartPanel.Visible = false; //隐藏开始面板
                SetPanel.Visible = false;   //隐藏设置面板
                InfoPanel.Visible = true;   //显示信息面板
            }
        }
        /// <summary>
        /// 调用委托隐藏软件更新界面
        /// </summary>
        private void HiddenInfoPanel()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(HiddenInfoPanel);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                InfoPanel.Visible = false;  //隐藏信息面板
                StartPanel.Visible = true;  //显示开始面板
            }
        }
        /// <summary>
        /// 使用委托添加内容到文本框
        /// </summary>
        /// <param name="time">时间标签</param>
        /// <param name="text">添加的内容</param>
        /// <param name="color">设置内容颜色</param>
        private void InfoAdd(bool time, String text, Color color)
        {
            if (this.InfoBox.InvokeRequired)//等待异步
            {
                InfoEndAdd fc = new InfoEndAdd(InfoAdd);
                this.Invoke(fc, time, text, color);//通过委托调用刷新方法
            }
            else
            {
                if (time) this.InfoBox.AppendText(DateTime.Now.ToLongTimeString() + " ");//添加时间标签
                this.InfoBox.Select(InfoBox.TextLength, 0); //移动光标到文本末尾
                this.InfoBox.SelectionColor = color;        //设置文本插入点颜色
                this.InfoBox.AppendText(text);              //在InfoBox末尾处插入文本
                this.InfoBox.ScrollToCaret();               //将控件的内容滚动到当前插入位置
            }
        }
        private delegate void InfoEndAdd(bool time, String text, Color color);//委托
        /// <summary>
        /// 使用委托添加内容到文本指定位置
        /// </summary>
        /// <param name="time"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        private void InfoAddx(int curA, int curB, String text, Color color)
        {
            if (this.InfoBox.InvokeRequired)//等待异步
            {
                InfoSelectAdd fc = new InfoSelectAdd(InfoAddx);
                this.Invoke(fc, curA, curB, text, color);//通过委托调用刷新方法
            }
            else
            {
                if(curA>0) this.InfoBox.Select(curA, curB);//正向选择文本
                else this.InfoBox.Select(InfoBox.TextLength + curA, curB);//逆向选择文本
                this.InfoBox.SelectionColor = color;//设置文本插入点颜色
                this.InfoBox.SelectedText = text;
            }
        }
        private delegate void InfoSelectAdd(int curA, int curB, String text, Color color);//委托
        #endregion

        #region 设置面板
        /// <summary>
        /// 获取本机物理内存大小
        /// </summary>
        /// <returns>返回内存大小(MByte)</returns>
        private string GetTotalPhysicalMemory()
        {
            try
            {
                string TotalSize = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    TotalSize = mo["TotalPhysicalMemory"].ToString();
                }
                moc = null;
                mc = null;
                TotalSize = (Convert.ToInt64(TotalSize) / 1024 / 1024).ToString();
                return TotalSize;
            }
            catch
            {
                return "unknow";
            }
        }
        /// <summary>
        /// 自动获取当前系统已安装的Java
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label5_Click(object sender, EventArgs e)
        {
            string strJavaFile = getValueRegEdit(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\javaws.exe\", "Path");
            if (strJavaFile != null)
            {
                JavaFile.Text = strJavaFile + @"\java.exe";
            }
        }
        //点击保存按钮
        private void SaveSet_Click(object sender, EventArgs e)
        {
            SetConfig("write");
            SetPanel.Visible = false;
            StartPanel.Visible = true;
            getGameList();
        }
        //点击取消按钮
        private void CancelSet_Click(object sender, EventArgs e)
        {
            SetConfig("read");
            SetPanel.Visible = false;
            StartPanel.Visible = true;
        }
        //正版登陆选项
        private void Registered_Click(object sender, EventArgs e)
        {
            if (PassWord.Enabled == true)
            {
                labelName.Text = "用户名称";
                Registered.Checked = false;
                PassWord.Enabled = false;
                PassWord.BackColor = Color.Lavender;
            }
            else
            {
                labelName.Text = "注册邮箱";
                Registered.Checked = true;
                PassWord.Enabled = true;
                PassWord.BackColor = Color.WhiteSmoke;
            }
        }
        /// <summary>
        /// 获取版本列表(并显示到列表框)
        /// </summary>
        public void getGameList()
        {
            string VerFile = GameFile.Text + @"\versions";
            if (Directory.Exists(VerFile))
            {
                string[] Versions = Directory.GetDirectories(VerFile);
                if (Versions.Length > 0)
                {
                    GameList.Items.Clear();
                    VerList.Items.Clear();
                    for (int i = 0; i < Versions.Length; i++)
                    {
                        int cutA = Versions[i].LastIndexOf('\\') + 1;
                        int cutB = Versions[i].Length;
                        string FileName = Versions[i].Substring(cutA, cutB - cutA);
                        if (File.Exists(Versions[i] + @"\" + FileName + @".jar") && File.Exists(Versions[i] + @"\" + FileName + @".json"))
                        {
                            GameList.Items.Add(FileName);
                            VerList.Items.Add(FileName);
                        }
                    }
                }
            }
            if (VerList.Items.Count > 0)
            {
                string LastPlay = ReadIni("玩家配置","游戏版本");
                if (VerList.Items.IndexOf(LastPlay) > -1) VerList.SelectedItem = LastPlay;
                else VerList.SelectedIndex = 0;
            }
            if (GameFile.Text == ".minecraft")
            {
                GameDir = Application.StartupPath + @"\.minecraft";
            }
            else
            {
                GameDir = GameFile.Text;    //获取游戏根目录
            }            
        }
        //游戏版本名称列表
        private void GameList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int posindex = GameList.IndexFromPoint(new Point(e.X, e.Y));
                if (posindex >= 0 && posindex < GameList.Items.Count)
                {
                    GameList.SelectedIndex = posindex;
                    鼠标右键菜单.Show(GameList, new Point(e.X, e.Y));
                }
            }
            GameList.Refresh();
        }
        private void 更改版本名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReNameBox.Text = GameList.SelectedItem.ToString();
            SetPanel.Enabled = false;
            ReNamePanl.Visible = true;
            ReNamePanl.BringToFront();
        }
        private void ReNameOk_Click(object sender, EventArgs e)//确定版本名称更改
        {
            string VerFile = GameFile.Text + @"\versions";//获取版本文件夹路径
            string VerNameFile = VerFile + @"\" + GameList.SelectedItem.ToString();//获取版本名称路径
            //修改Json中游戏ID名称
            StreamReader SR = new StreamReader(VerNameFile + @"\" + GameList.SelectedItem.ToString() + ".json", true);
            String ReJson = SR.ReadToEnd();
            SR.Dispose();
            ReJson = ReJson.Replace("\"id\": \"" + GameList.SelectedItem.ToString(), "\"id\": \"" + ReNameBox.Text);
            File.WriteAllText(VerNameFile + @"\" + GameList.SelectedItem.ToString() + ".json", ReJson);
            //重命名游戏版本json的名称
            File.Move(VerNameFile + @"\" + GameList.SelectedItem.ToString() + ".json", VerNameFile + @"\" + ReNameBox.Text + ".json");
            //重命名游戏版本jar的名称
            File.Move(VerNameFile + @"\" + GameList.SelectedItem.ToString() + ".jar", VerNameFile + @"\" + ReNameBox.Text + ".jar");
            //重命名版本文件夹的名称
            Directory.Move(VerFile + @"\" + GameList.SelectedItem.ToString(), VerFile + @"\" + ReNameBox.Text);
            getGameList();//刷新版本列表
            ReNamePanl.Visible = false;
            SetPanel.Enabled = true;
        }
        private void ReNameNo_Click(object sender, EventArgs e)//取消版本名称更改
        {
            ReNamePanl.Visible = false;
            SetPanel.Enabled = true;
        }
        private void 删除选中版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string VerFile = GameFile.Text + @"\versions";//获取版本文件夹路径
            string VerNameFile = VerFile + @"\" + GameList.SelectedItem.ToString();//获取版本名称路径
            DialogResult DelMessageBox = MessageBox.Show("确定要删除 \"" + GameList.SelectedItem.ToString() + "\" 吗？", "提示", MessageBoxButtons.YesNo);
            if (DelMessageBox == DialogResult.Yes)
            {
                Directory.Delete(VerNameFile, true);
                getGameList();//刷新版本列表
            }
        }
        //指定游戏目录
        private void SetGameFile_Click(object sender, EventArgs e)
        {
            DialogResult r = 浏览文件夹.ShowDialog();
            if (r == DialogResult.OK)
            {
                GameFile.Text = 浏览文件夹.SelectedPath;
                if (GameFile.Text == Application.StartupPath + @"\.minecraft")
                {
                    GameFile.Text = @".minecraft";
                }
                getGameList();
            }
        }
        //指定Java路径
        private void SetJavaFile_Click(object sender, EventArgs e)
        {
            DialogResult r = 浏览文件.ShowDialog();
            if (r == DialogResult.OK)
            {
                JavaFile.Text = 浏览文件.FileName;
            }
        }
        /// <summary>
        /// 读写程序配置
        /// </summary>
        /// <param name="set">"read"读取；"write"写入</param>
        private void SetConfig(string set)
        {
            if (set == "read")
            {
                SoltLabel.Text = "本机内存:" + GetTotalPhysicalMemory() + "MB";//只读项目

                GameFile.Text = ReadIni("系统设置", "游戏目录");
                JavaSolt.Value = Convert.ToUInt32(ReadIni("系统设置", "Java内存"));
                JavaFile.Text = ReadIni("系统设置", "Java路径");
                UserName.Text = ReadIni("玩家配置", "用户名称");
                PassWord.Text = ReadIni("玩家配置", "登录密码");
                if (ReadIni("玩家配置", "正版登陆") == "True")
                {
                    labelName.Text = "注册邮箱";
                    Registered.Checked = true;
                    PassWord.Enabled = true;
                    PassWord.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    labelName.Text = "用户名称";
                    Registered.Checked = false;
                    PassWord.Enabled = false;
                    PassWord.BackColor = Color.Lavender;
                }
                ScreenSize.Text = ReadIni("玩家配置", "游戏尺寸");
                if (ScreenSize.Text == "") ScreenSize.Text = "默认大小";
            }
            if (set == "write")
            {
                WriteIni("系统设置", "游戏目录",GameFile.Text);
                WriteIni("系统设置", "Java内存",JavaSolt.Value.ToString());
                WriteIni("系统设置", "Java路径",JavaFile.Text);
                WriteIni("玩家配置", "用户名称",UserName.Text);
                WriteIni("玩家配置", "登录密码",PassWord.Text);
                WriteIni("玩家配置", "正版登陆", Registered.Checked.ToString());
                WriteIni("玩家配置", "游戏尺寸", ScreenSize.Text);
            }
        }
        #endregion

        #region 启动游戏前的准备工作
        private void Game_Start()
        {
            userName = UserName.Text;                   //获取用户名
            passWord = PassWord.Text;                   //获取用户密码
            screenSize = ScreenSize.Text;               //设置窗口尺寸

            if (VerList.Items.Count < 1) return;
            VerName = VerList.SelectedItem.ToString();  //获取当前选定的游戏版本名称
            JavaDir = JavaFile.Text;                    //获取Java路径
            ReadUpdateFile(VerName);                    //获取更新配置

            Thread InspectGame = new Thread(new ThreadStart(GameCheck));//创建一个新线程来检测游戏完整性
            InspectGame.IsBackground = true;    //设置此线程为后台线程
            InspectGame.Start();                //启动线程
        }
        /// <summary>
        /// 游戏配置检查
        /// </summary>
        private void GameCheck()
        {
            if (PassWord.Enabled == true)  //正版登陆验证
            {
                InfoAdd(true, "正在进行正版验证...\n", Color.DarkGreen);
                String LoginJson = Login.login(userName, passWord, clientToken);
                if (LoginJson == "false")
                {
                    MessageBox.Show("登陆失败！");
                    CloseInfoPanel();
                    return;
                }
                else
                {
                    InfoAdd(true, "正版验证成功！\n", Color.DarkGreen);
                }
                var LoginData = J2D.JsonToDictionary(LoginJson);
                var Profile = (Dictionary<string, object>)LoginData["selectedProfile"];

                var AuthData = new Profile.authenticationDatabase();
                AuthData.displayName = Profile["name"].ToString();;
                AuthData.accessToken = LoginData["accessToken"].ToString();
                AuthData.uuid = Profile["id"].ToString();
                AuthData.username = userName;
                var Profiles = new Profile.profiles();
                Profiles.gameDir = GameDir;
                Profiles.lastVersionId = VerName;
                Profiles.resolution = screenSize;
                ProfileSet.Profile.ProfilesSave(Profiles, AuthData, LoginData["clientToken"].ToString());

                accessToken = LoginData["accessToken"].ToString();
                clientToken = LoginData["clientToken"].ToString();
                playerUUID = Profile["id"].ToString();
                userName = Profile["name"].ToString();
            }
            else
            {
                accessToken = "0";
                clientToken = "0";
                playerUUID = "0";
                userName = UserName.Text;
            }

            if (UpdateAuto.Checked == true) ModUpdateLine();
            strRun = GetRunStr();           //获取游戏启动参数(这一步已获取到资源文件版本号)
            try
            {
                LibCheck();                 //检查运行库是否有完整
                AssCheck();                 //检查资源库是否有完整
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            RunOrder(JavaDir, strRun);  //启动游戏
        }
        /// <summary>
        /// 检查运行库是否有缺失
        /// </summary>
        private void LibCheck()
        {
            String NativesPath = GameDir + @"\versions\" + VerName + @"\natives";//获取natives文件夹地址
            String JsonPath = GameDir + @"\versions\" + VerName + @"\" + VerName + ".json"; //获取JSON文件地址
            String Text = File.ReadAllText(JsonPath);

            InfoAdd(true, "检索libraries文件\n", Color.BlueViolet);
            Dictionary<string, object> JSON = J2D.JsonToDictionary(Text);   //将Json数据转成Dictionary字典
            ArrayList LibArray = (ArrayList)JSON["libraries"];              //将libraries转换为数组
            foreach (var Lib in LibArray)                                   //遍历libraries数组
            {
                Dictionary<string, object> Item = (Dictionary<string, object>)Lib;

                String[] temp = null;
                String file = null;
                String strURL = null;
                if (Item.ContainsKey("name"))
                {
                    temp = Item["name"].ToString().Split(':');     //拆分字符串获取文件地址
                    file = temp[0].Replace(".", "/");
                    for (int i = 1; i < temp.Length; i++)
                    {
                        file += "/" + temp[i];
                    }
                    file += "/" + temp[temp.Length - 2] + "-" + temp[temp.Length - 1] + ".jar";
                    if (file.IndexOf("forge") > -1) file = file.Replace(".jar", "-universal.jar");
                }
                if (Item.ContainsKey("natives"))                    //获取对应系统的库文件版本
                {
                    Dictionary<string, object> native = (Dictionary<string, object>)Item["natives"];
                    if (native.ContainsKey("windows"))
                    {
                        file = file.Replace(".jar", "-" + native["windows"] + ".jar");
                        file = file.Replace("${arch}", GetOSBit().ToString());
                    }
                    else continue;                                  //跳过windows不需要的natives
                }
                if (Item.ContainsKey("url"))                        //获取库文件的下载链接
                {
                    strURL = Item["url"] + file;
                }
                else
                {
                    strURL = LibrariesURL + file;
                }
                String libFile = GameDir + @"\libraries\" + file;   //获取Lib的本地路径
                if (File.Exists(libFile)) continue;                 //若文件存在则跳过

                InfoAdd(true, "下载libraries：" + Item["name"], Color.BlueViolet);
                if (DownloadFile(strURL, libFile))             //下载成功
                {
                    InfoAdd(false, "√\n", Color.Green);
                }
                else                                            //下载失败，换Forge源重试
                {
                    if (Item.ContainsKey("url")) strURL = ForgeLibURL + file;
                    else strURL = BMCLLibURL + file;
                    if (DownloadFile(strURL, libFile))         //下载成功
                    {
                        InfoAdd(false, "√\n", Color.Green);
                    }
                    else                                        //下载失败
                    {
                        File.Delete(strURL);
                        InfoAdd(false, "×\n", Color.Red);
                    }
                }
            }

            if (!Directory.Exists(NativesPath)) Directory.CreateDirectory(NativesPath);//判断natives文件夹是否存在
            foreach (var Lib in LibArray)                            //遍历libraries文件,查找natives库
            {
                Dictionary<string, object> Item = (Dictionary<string, object>)Lib;
                String[] temp = null;
                String file = null;
                if (Item.ContainsKey("extract"))                     //获取需要释放的natives文件
                {
                    temp = Item["name"].ToString().Split(':');       //拆分字符串获取文件地址
                    file = temp[0].Replace(".", @"\");
                    for (int i = 1; i < temp.Length; i++)
                    {
                        file += @"\" + temp[i];
                    }
                    file += @"\" + temp[temp.Length - 2] + "-" + temp[temp.Length - 1] + ".jar";

                    Dictionary<string, object> native = (Dictionary<string, object>)Item["natives"];
                    if (native.ContainsKey("windows"))
                    {
                        file = file.Replace(".jar", "-" + native["windows"] + ".jar");
                        file = file.Replace("${arch}", GetOSBit().ToString());
                    }
                    else continue;                                      //跳过windows不需要的natives
                    InfoAdd(true, "释放natives：" + Item["name"], Color.BlueViolet);
                    String libFile = GameDir + @"\libraries\" + file;   //获取Lib的本地路径
                    ZIP.UnZip(libFile, NativesPath);
                    InfoAdd(false, "√\n", Color.Green);
                }
            }
        }
        /// <summary>
        /// 检查资源库是否有缺失
        /// </summary>
        private void AssCheck()
        {
            if (VerAssets == "old")
            {
                InfoAdd(true, "暂不支持1.7.2以前的版本资源文件下载！(包括1.7.2)\n", Color.Red);
                InfoAdd(true, "如有需要，请移步至MCBBS论坛下载。\n", Color.Red);
                return;
            }
            String JsonPath = GameDir + @"\assets\indexes\" + VerAssets + ".json"; //获取资源JSON文件地址
            if (!File.Exists(JsonPath)) //判断目录文件是否存在
            {
                InfoAdd(true, "未找到对应版本的index.json文件，正在尝试从官方下载\n", Color.BlueViolet);
                if (DownloadFile(IndexsURL + VerAssets + ".json", JsonPath))//下载成功
                {
                    InfoAdd(true, "index.json下载成功！\n", Color.Green);
                }
                else                                        //下载失败，换源重试
                {
                    InfoAdd(true, "官方源下载index失败！\n", Color.Red);
                    InfoAdd(true, "尝试从BMCLAPI下载index.json文件\n", Color.BlueViolet);
                    if (DownloadFile(IndexsURLb + VerAssets + ".json", JsonPath))//下载成功
                    {
                        InfoAdd(true, "index.json下载成功！\n", Color.Green);
                    }
                    else                                        //下载失败
                    {
                        InfoAdd(true, "BMCLAPI源下载index失败！\n", Color.Red);
                        InfoAdd(true, "请检查网络连接是否正常，然后重试。\n", Color.Red);
                        return;
                    }
                }
            }

            String Text = File.ReadAllText(JsonPath);   //获取Json文档内容
            Dictionary<string, object> JSON = J2D.JsonToDictionary(Text);//将Json数据转成dictionary格式
            Dictionary<string, object> objects = (Dictionary<string, object>)JSON["objects"];
            foreach (KeyValuePair<string, object> item in objects)  //遍历objects节点
            {
                //String AssetName = item.Key.ToString() + "\n";    //获取子节点名
                String AssetHash = "";                      //创建资源文件SHA1存储变量
                //String AssetSize = "";                      //创建资源文件长度存储变量
                Dictionary<string, object> subItem = (Dictionary<string, object>)item.Value;
                foreach (var str in subItem)
                {
                    if (str.Key == "hash") AssetHash += str.Value;  //从Json获取资源文件的SHA1
                    //if (str.Key == "size") AssetSize += str.Value;  //从Json获取资源文件的长度
                }
                String AssetFile = GameDir + @"\assets\objects\" + AssetHash.Substring(0, 2) + @"\" + AssetHash;
                if (File.Exists(AssetFile)) //判断资源文件是否存在
                {
                    if (Hash.GetFileSHA1(AssetFile) == AssetHash) continue;
                    else File.Delete(AssetFile);
                }
                InfoAdd(true, "下载assets：" + AssetHash, Color.BlueViolet);
                AssetHash = AssetHash.Substring(0, 2) + "/" + AssetHash;
                if (DownloadFile(AssetsURL + AssetHash, AssetFile))//下载成功
                {
                    InfoAdd(false, "√\n", Color.Green);
                }
                else                                                //下载失败,更换BMCLAPI源重试
                {
                    if (DownloadFile(AssetsURLb + AssetHash, AssetFile))//下载成功
                    {
                        InfoAdd(false, "√\n", Color.Green);
                    }
                    else                                                 //下载失败
                    {
                        InfoAdd(false, "×\n", Color.Red);
                    }
                }
            }
        }
        /// <summary>
        /// http文件下载
        /// </summary>
        /// <param name="downLoadUrl">文件的url路径</param>
        /// <param name="saveFullName">需要保存在本地的路径(包含文件名)</param>
        /// <returns>成功返回true，失败返回false</returns>
        public bool DownloadFile(string downLoadUrl, string savePathName)
        {
            downLoadUrl = downLoadUrl.Replace(@"\", "/");
            savePathName = savePathName.Replace("/", @"\");
            string cachePath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);//获取IE临时目录(作为下载缓存使用)
            cachePath = cachePath + savePathName.Remove(0, savePathName.LastIndexOf(@"\"));       //设置下载临时文件
            String GreatFile = savePathName.Substring(0, savePathName.LastIndexOf(@"\"));         //创建目标存放路径
            if (!Directory.Exists(GreatFile)) Directory.CreateDirectory(GreatFile);
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(downLoadUrl);//根据URL获取远程文件流
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream sr = response.GetResponseStream();
                Stream sw = new FileStream(cachePath, FileMode.Create);//创建本地文件写入流

                Decimal WebFileBytes = response.ContentLength;
                Decimal DownloadByte = 0;
                Byte[] buf = new Byte[1024];//创建数据接收缓冲区
                Int32 osize = sr.Read(buf, 0, (int)buf.Length);
                while (osize > 0)
                {
                    DownloadByte += osize;
                    sw.Write(buf, 0, osize);
                    osize = sr.Read(buf, 0, (int)buf.Length);
                }
                sw.Close();
                sr.Close();
                File.Delete(savePathName);          //删除旧文件
                File.Move(cachePath, savePathName); //添加新文件
                return true;
            }
            catch (Exception)
            {
                if (request != null) request.Abort();
                return false;
            }
        }
        #endregion

        #region 构建启动参数
        /// <summary>
        /// 获取启动游戏的参数
        /// </summary>
        /// <returns>返回启动代码</returns>
        private string GetRunStr()
        {
            String StartPath = GameDir + @"\versions\" + VerName + @"\" + VerName + ".jar";//主程序地址
            String NativesPath = GameDir + @"\versions\" + VerName + @"\natives";//获取natives文件夹地址
            String JsonPath = GameDir + @"\versions\" + VerName + @"\" + VerName + ".json"; //获取JSON文件地址

            String RunStr = null;                       //定义启动参数字符串
            String LibList = null;                      //定义启动运行库字符串
            String Text = File.ReadAllText(JsonPath);   //载入version.json
            Dictionary<string, object> JSON = J2D.JsonToDictionary(Text);   //将Json数据转成dictionary格式
            ArrayList LibArray = (ArrayList)JSON["libraries"];              //将libraries转换为数组
            foreach (var Lib in LibArray)                                   //遍历libraries数组
            {
                Dictionary<string, object> Item = (Dictionary<string, object>)Lib;

                String[] temp = null;
                String file = null;
                if (Item.ContainsKey("name"))
                {
                    temp = Item["name"].ToString().Split(':');     //拆分字符串获取文件地址
                    file = temp[0].Replace(".", @"\");
                    for (int i = 1; i < temp.Length; i++)
                    {
                        file += @"\" + temp[i];
                    }
                    file += @"\" + temp[temp.Length - 2] + "-" + temp[temp.Length - 1] + ".jar";
                    if (file.IndexOf("forge") > -1) file = file.Replace(".jar", "-universal.jar");
                }
                if (Item.ContainsKey("extract")) continue;          //提取文件，不加入启动参数
                if (Item.ContainsKey("rules"))
                {
                    ArrayList rules = (ArrayList)Item["rules"];
                    if (rules.Count < 2) continue;                  //跳过windows不需要的lib
                }
                String libFile = GameDir + @"\libraries\" + file;   //获取Lib的本地路径
                LibList += libFile + ";";
            }
            RunStr = "-Xincgc -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmx" + JavaSolt.Value + "M ";
            RunStr += "-Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true ";
            RunStr += "-Djava.library.path=\"" + NativesPath + "\" ";
            RunStr += "-cp \"" + LibList + StartPath + "\" " + JSON["mainClass"] + " ";

            if (JSON.ContainsKey("assets")) VerAssets = JSON["assets"].ToString();  //获取资源文件版本
            else VerAssets = "old";
            var Arguments = new StringBuilder(JSON["minecraftArguments"].ToString());//定义启动参数字符串
            Arguments.Replace("${auth_player_name}", userName);//用户名
            Arguments.Replace("${version_name}", VerName);          //游戏版本号
            Arguments.Replace("${game_directory}", "\"" + GameDir + @"\versions\" + VerName + "\"");
            Arguments.Replace("${game_assets}", "\"" + GameDir + "\\assets\""); //资源文件目录
            Arguments.Replace("${assets_root}", "\"" + GameDir + "\\assets\"");
            Arguments.Replace("${assets_index_name}", VerAssets);   //资源文件版本
            Arguments.Replace("${auth_uuid}", playerUUID);                 //
            Arguments.Replace("${auth_access_token}", accessToken);         //
            Arguments.Replace("${user_properties}", "{}");
            Arguments.Replace("${user_type}", "Legacy");

            if (accessToken != "")                  //正版登陆加入Session参数
            {
                Arguments.Replace("--version", "--session " + accessToken + " --version");
            }
            if (screenSize == "FullScreen")         //设置游戏窗口大小
            {
                Arguments.Append(" --fullscreen");
            }
            else if (screenSize.Contains("*"))
            {
                String[] gamesize = screenSize.Trim().Split('*');
                Arguments.Append(" --width " + gamesize[0].Trim());
                Arguments.Append(" --height " + gamesize[1].Trim());
            }
            RunStr += Arguments.ToString();
            return RunStr;
        }
        /// <summary>
        /// 获取操作系统位数（x32/64）
        /// </summary>
        /// <returns>int</returns>
        public static int GetOSBit()
        {
            try
            {
                string addressWidth = String.Empty;
                ConnectionOptions mConnOption = new ConnectionOptions();
                ManagementScope mMs = new ManagementScope(@"\\localhost", mConnOption);
                ObjectQuery mQuery = new ObjectQuery("select AddressWidth from Win32_Processor");
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(mMs, mQuery);
                ManagementObjectCollection mObjectCollection = mSearcher.Get();
                foreach (ManagementObject mObject in mObjectCollection)
                {
                    addressWidth = mObject["AddressWidth"].ToString();
                }
                return Int32.Parse(addressWidth);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 32;
            }
        }
        #endregion

        #region 资源面板
        private void back_Click(object sender, EventArgs e)
        {
            AssetPanel.Visible = false;
            StartPanel.Visible = true;
        }
        /// <summary>
        /// 获取游戏版本列表
        /// </summary>
        private void GetVerList()
        {
            Thread GameVerList = new Thread(new ThreadStart(VerListCheck));//创建一个新线程来检测游戏完整性
            GameVerList.IsBackground = true;    //设置此线程为后台线程
            GameVerList.Start();                //启动线程
        }
        /// <summary>
        /// 检索版本列表文件，提取数据内容
        /// </summary>
        private void VerListCheck()
        {
            VerListClear(); //清空表格数据行
            VerType = "<所有>";
            VerTime = "<所有>";
            String JsonPath = GameDir + @"\versions\versions.json";         //获取资源JSON文件地址
            if (File.Exists(JsonPath)) File.Delete(JsonPath);               //删除旧的版本目录
            VerId = "正在获取";
            VerListAdd();
            if (DownloadFile(VerURL + "versions.json", JsonPath)) { }      //下载成功
            else                                                            //下载失败，换源重试
            {
                if (DownloadFile(VerURLb + "versions.json", JsonPath)) { } //下载成功
                else                                                        //下载失败
                {
                    VerListClear();
                    VerId = "获取失败";
                    VerType = "无";
                    VerTime = "无";
                    VerListAdd();
                    return;
                }
            }
            VerListClear();
            String Text = File.ReadAllText(JsonPath);                       //获取JSON文件内容
            Dictionary<string, object> JSON = J2D.JsonToDictionary(Text);   //将Json数据转成dictionary字典
            ArrayList VerArray = (ArrayList)JSON["versions"];               //将libraries转换为数组
            foreach (var version in VerArray)                               //遍历libraries数组
            {
                Dictionary<string, object> Item = (Dictionary<string, object>)version;
                VerId = Item["id"].ToString();
                VerType = Item["type"].ToString();
                VerTime = Item["releaseTime"].ToString();
                VerListAdd();
            }
        }
        String VerId, VerType, VerTime;
        /// <summary>
        /// 通过委托向表格添加数据
        /// </summary>
        private void VerListAdd()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(VerListAdd);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                VerGridView.Rows.Add(1);
                int index = VerGridView.Rows.Count - 1;
                VerGridView.Rows[index].Cells[0].Value = VerId;
                VerGridView.Rows[index].Cells[1].Value = VerType;
                VerGridView.Rows[index].Cells[2].Value = VerTime;
                VerGridView.Rows[index].Cells[3].Value = "双击下载";
            }
        }
        /// <summary>
        /// 通过委托清空表格数据行
        /// </summary>
        private void VerListClear()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(VerListClear);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                while (VerGridView.Rows.Count > 0)
                {
                    VerGridView.Rows.RemoveAt(VerGridView.Rows.Count - 1);
                }
            }
        }
        /// <summary>
        /// 带进度输出的Http文件下载
        /// </summary>
        /// <param name="downLoadUrl">文件的url路径</param>
        /// <param name="savePathName">需要保存在本地的路径(包含文件名)</param>
        /// <param name="Progress">这里加入需要输出进度的容器（如TextBox）</param>
        /// <returns></returns>
        public bool DownProgressFile(string downLoadUrl, string savePathName, DataGridViewCell Progress)
        {
            downLoadUrl = downLoadUrl.Replace(@"\", "/");
            savePathName = savePathName.Replace("/", @"\");
            string cachePath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);//获取IE临时目录(作为下载缓存使用)
            cachePath = cachePath + savePathName.Remove(0, savePathName.LastIndexOf(@"\"));       //设置下载临时文件
            String GreatFile = savePathName.Substring(0, savePathName.LastIndexOf(@"\"));         //创建目标存放路径
            if (!Directory.Exists(GreatFile)) Directory.CreateDirectory(GreatFile);
            HttpWebRequest httpWebRequest = null;
            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(downLoadUrl);//根据URL获取远程文件流
                httpWebRequest.UserAgent = "AMCL";
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                long totalBytes = httpWebResponse.ContentLength;
                Stream sr = httpWebResponse.GetResponseStream();
                Stream sw = new FileStream(cachePath, FileMode.Create);//创建本地文件写入流

                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = sr.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    sw.Write(by, 0, osize);
                    double percent = Convert.ToDouble(totalDownloadedByte) / Convert.ToDouble(totalBytes);
                    Progress.Value = percent.ToString("0.0%");      //将下载进度导出到指定容器
                    osize = sr.Read(by, 0, (int)by.Length);
                }
                sw.Close();
                sr.Close();
                File.Delete(savePathName);          //删除旧文件
                File.Move(cachePath, savePathName); //添加新文件
                return true;
            }
            catch (Exception)
            {
                if (httpWebRequest != null) httpWebRequest.Abort();
                return false;
            }
        }
        /// <summary>
        /// 下载指定的游戏版本
        /// </summary>
        /// <param name="RowNum">输入表格中指定的行号</param>
        private void DownSelectVer(int RowNum)
        {
            if (RowNum < 0) return;
            string SelectVer = VerGridView.Rows[RowNum].Cells[0].Value.ToString();
            if (SelectVer == "正在获取" || SelectVer == "获取失败") return;
            if(GameFile.Text.IndexOf(".minecraft") < 0)     //判断游戏根目录是否存在，若不存在则创建！
            {
                if(Directory.Exists(GameFile.Text))
                {
                    GameFile.Text = GameFile.Text + @"\.minecraft";
                }
                else
                {
                    GameFile.Text = Application.StartupPath + @"\.minecraft";
                }
                Directory.CreateDirectory(GameFile.Text);
                SetConfig("write"); 
            }
            string SelectDown = GameFile.Text + @"\versions\" + SelectVer + @"\";
            Directory.CreateDirectory(SelectDown);
            if (File.Exists(SelectDown + SelectVer + ".json") && File.Exists(SelectDown + SelectVer + ".jar"))
            {
                MessageBox.Show("指定的游戏版本已存在！");
                return;
            }
            if (DownProgressFile(VerURL + SelectVer + "/" + SelectVer + ".json", SelectDown + SelectVer + ".json", VerGridView.Rows[RowNum].Cells[3]))//下载成功
            {
                VerGridView.Rows[RowNum].Cells[3].Value = "JSON下载完成！";
            }
            else                                                            //下载失败，换源重试
            {
                if (DownProgressFile(VerURLb + SelectVer + "/" + SelectVer + ".json", SelectDown + SelectVer + ".json", VerGridView.Rows[RowNum].Cells[3]))//下载成功
                {
                    VerGridView.Rows[RowNum].Cells[3].Value = "JSON下载完成！";
                }
                else                                                        //下载失败
                {
                    VerGridView.Rows[RowNum].Cells[3].Value = "JSON下载失败！";
                    return;
                }
            }
            if (DownProgressFile(VerURL + SelectVer + "/" + SelectVer + ".jar", SelectDown + SelectVer + ".jar", VerGridView.Rows[RowNum].Cells[3]))//下载成功
            {
                VerGridView.Rows[RowNum].Cells[3].Value = "JAR下载完成！";
            }
            else                                                            //下载失败，换源重试
            {
                if (DownProgressFile(VerURLb + SelectVer + "/" + SelectVer + ".jar", SelectDown + SelectVer + ".jar", VerGridView.Rows[RowNum].Cells[3]))//下载成功
                {
                    VerGridView.Rows[RowNum].Cells[3].Value = "JAR下载完成！";
                }
                else                                                        //下载失败
                {
                    VerGridView.Rows[RowNum].Cells[3].Value = "JAR下载失败！";
                    return;
                }
            }
            VerGridView.Rows[RowNum].Cells[3].Value = "游戏下载完成！";
            getGameList();      //刷新本地游戏列表
        }
        /// <summary>
        /// 双击表格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowNumber = e.RowIndex;
            VerGridView.Enabled = false;
            DownSelectVer(RowNumber);
            VerGridView.Enabled = true;
        }

        /// <summary>
        /// 获取versions文件夹内子目录列表
        /// </summary>
        private void GetUpdateList()
        {
            string UpdateFile = GameFile.Text + @"\versions";
            if (Directory.Exists(UpdateFile))
            {
                string[] Versions = Directory.GetDirectories(UpdateFile);
                if (Versions.Length > 0)
                {
                    UpdateList.Items.Clear();
                    for (int i = 0; i < Versions.Length; i++)
                    {
                        int cutA = Versions[i].LastIndexOf('\\') + 1;
                        int cutB = Versions[i].Length;
                        string FileName = Versions[i].Substring(cutA, cutB - cutA);
                        UpdateList.Items.Add(FileName);
                    }
                }
            }
        }
        /// <summary>
        /// UpdateList列表选项更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdateList.SelectedIndex < 0) return;
            String SelectVer = UpdateList.SelectedItem.ToString();  //获取当前选定项
            ReadUpdateFile(SelectVer);
        }
        /// <summary>
        /// 读取整合包更新配置
        /// </summary>
        /// <param name="UpdateFile">选定的游戏名称</param>
        private void ReadUpdateFile(String SelectVer)
        {
            String UpdateList = GameFile.Text + @"\versions\" + SelectVer + @"\updatelist.json";
            String UpdateFile = GameFile.Text + @"\versions\" + SelectVer + @"\update.json";
            if (File.Exists(UpdateList))
            {
                String Text = File.ReadAllText(UpdateList);
                Dictionary<string, object> JSON = J2D.JsonToDictionary(Text);//将Json数据转成dictionary字典
                if (JSON.ContainsKey("updatelist"))
                {
                    if (File.Exists(UpdateFile))
                    {
                        String UpdateURL = File.ReadAllText(UpdateFile).Trim();
                        String TmpUpdateURL = JSON["updatelist"].ToString();
                        if (UpdateURL.IndexOf("√") > -1) TmpUpdateURL += "√";
                        if (UpdateURL.IndexOf("#") > -1) TmpUpdateURL += "#";
                        File.WriteAllText(UpdateFile,TmpUpdateURL);
                    }
                    else
                    {
                        File.WriteAllText(UpdateFile, JSON["updatelist"] + "√#");
                    }
                }
            }
            if (File.Exists(UpdateFile))
            {
                String UpdateURL = File.ReadAllText(UpdateFile).Trim();
                if (UpdateURL.IndexOf("√")>-1)
                {
                    UpdateAuto.Checked = true;
                    UpdateURL = UpdateURL.Replace("√", "");
                }
                else
                {
                    UpdateAuto.Checked = false;
                }
                if (UpdateURL.IndexOf("#") > -1)
                {
                    ConfigAuto.Checked = true;
                    UpdateURL = UpdateURL.Replace("#", "");
                }
                else
                {
                    ConfigAuto.Checked = false;
                }
                if ((UpdateURL.StartsWith("http://") || UpdateURL.StartsWith("https://")) && UpdateURL.EndsWith(".json"))
                {
                    UpdateJsonURL.Text = UpdateURL;
                }
                else
                {
                    UpdateJsonURL.Text = "";
                    UpdateAuto.Checked = false;
                    ConfigAuto.Checked = false;
                }
            }
            else
            {
                UpdateJsonURL.Text = "";
                UpdateAuto.Checked = false;
            }
        }
        /// <summary>
        /// 保存设置的UpdateJsonURL地址
        /// </summary>
        private void UpdateJsonURL_Save()
        {
            if (UpdateList.SelectedIndex < 0) return;
            String SelectVer = UpdateList.SelectedItem.ToString();  //获取当前选定项
            String UpdateFile = GameFile.Text + @"\versions\" + SelectVer + @"\update.json";
            String UpdateURL = UpdateJsonURL.Text;
            if ((UpdateURL.StartsWith("http://")|| UpdateURL.StartsWith("https://")) && UpdateURL.EndsWith(".json"))
            {
                if (UpdateAuto.Checked == true)
                {
                    UpdateURL = UpdateURL + "√";
                }
                if (ConfigAuto.Checked == true)
                {
                    UpdateURL = UpdateURL + "#";
                }
                File.WriteAllText(UpdateFile, UpdateURL);
            }
        }
        /// <summary>
        /// 控件失去焦点事件
        /// </summary>
        private void UpdateJsonURL_Leave(object sender, EventArgs e)
        {
            UpdateJsonURL_Save();
        }
        /// <summary>
        /// 复选框状态变更事件
        /// </summary>
        private void UpdateAuto_CheckedChanged(object sender, EventArgs e)
        {
            UpdateJsonURL_Save();
        }
        /// <summary>
        /// 复选框状态变更事件
        /// </summary>
        private void ConfigAuto_CheckedChanged(object sender, EventArgs e)
        {
            UpdateJsonURL_Save();
        }
        /// <summary>
        /// 点击“立即更新”按钮事件
        /// </summary>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateJsonStart();
        }
        /// <summary>
        /// 开启新线程更新客户端整合包
        /// </summary>
        private void UpdateJsonStart()
        {
            AssetPanel.Visible = false;     //隐藏资源更新面板
            InfoPanel.Visible = true;       //显示消息输出面板

            Thread ClientLine = new Thread(new ThreadStart(ModClientUpdate));//创建一个新线程来检测游戏完整性
            ClientLine.IsBackground = true;    //设置此线程为后台线程
            ClientLine.Start();                //启动线程
        }
        /// <summary>
        /// 整合包更新线程
        /// </summary>
        private void ModClientUpdate()
        {
            ModUpdateLine();
            Thread.Sleep(1000);
            CloseUpdateInfo();
        }
        /// <summary>
        /// 整合包mod更新子程序
        /// </summary>
        private void ModUpdateLine()
        {
            String UpdateURL = UpdateJsonURL.Text;
            String Text = GetHttpPage(UpdateURL);
            InfoAdd(false, "正在检查更新当前整合包\n", Color.ForestGreen);

            if ((Text.StartsWith("\"") && Text.EndsWith("\"")))//应对OSChina的临时应急方案
            {
                Text = Regex.Unescape(Text.Trim('\"'));
            }
            if (!(Text.StartsWith("{") && Text.EndsWith("}")))
            {
                InfoAdd(false, "当前整合包暂无更新\n", Color.ForestGreen);
                return;
            }

            Dictionary<string, object> JSON = J2D.JsonToDictionary(Text);//将Json数据转成dictionary字典
            try
            {
                if (JSON.ContainsKey("name"))   //判断指定的游戏目录是否存在
                {
                    String VersionDir = GameDir + @"\versions\" + JSON["name"].ToString();
                    if (!Directory.Exists(VersionDir)) Directory.CreateDirectory(VersionDir);
                    File.WriteAllText(VersionDir + "\\updatelist.json", Text);//保存updatelist.json文件
                }
                else
                {
                    InfoAdd(false, "指定的整合包更新链接不正确\n", Color.OrangeRed);
                    return;
                }

                if (JSON.ContainsKey("game"))//检查game节点是否存在
                {
                    InfoAdd(false, "正在检查更新游戏主文件\n", Color.ForestGreen);
                    ArrayList game = (ArrayList)JSON["game"];               //将game节点转换为数组
                    foreach (var Item in game)                              //遍历game数组
                    {
                        Dictionary<string, object> Subitem = (Dictionary<string, object>)Item;
                        String filePath = GameDir + @"\versions\" + JSON["name"] + @"\" + Subitem["name"];
                        String fileHash = Subitem["hash"].ToString();
                        if (File.Exists(filePath))
                        {
                            if (fileHash == Hash.FileStrToSHA1(filePath)) continue;
                            File.Delete(filePath);
                        }
                        InfoAdd(true, "正在更新" + Subitem["name"].ToString(), Color.Black);
                        if (DownloadFile(Subitem["url"].ToString(), filePath))
                        {
                            InfoAdd(false, "√\n", Color.Green);
                        }
                        else InfoAdd(false, "×\n", Color.Red);
                    }

                }

                if (JSON.ContainsKey("mods"))//检查mods节点是否存在
                {
                    InfoAdd(false, "正在检查更新MODS文件\n", Color.ForestGreen);
                    ArrayList modlist = new ArrayList();                    //创建本地mod列表数组
                    ArrayList mods = (ArrayList)JSON["mods"];               //将mods节点转换为数组
                    foreach (var Item in mods)                              //遍历mods数组，下载mod
                    {
                        Dictionary<string, object> Subitem = (Dictionary<string, object>)Item;
                        modlist.Add(Subitem["name"].ToString());
                        String modPath = GameDir + @"\versions\" + JSON["name"] + @"\mods\" + Subitem["name"];
                        String modHash = Subitem["hash"].ToString();
                        if (File.Exists(modPath))
                        {
                            if (modHash == Hash.FileStrToSHA1(modPath)) continue;
                            File.Delete(modPath);
                        }
                        InfoAdd(true, "正在更新" + Subitem["name"], Color.Black);
                        if (DownloadFile(Subitem["url"].ToString(), modPath))
                        {
                            InfoAdd(false, "√\n", Color.Green);
                        }
                        else InfoAdd(false, "×\n", Color.Red);
                    }

                    String modsPath = GameDir + @"\versions\" + JSON["name"] + @"\mods\";
                    DirectoryInfo modsInfo = new DirectoryInfo(modsPath);
                    FileInfo[] modslist = modsInfo.GetFiles();
                    foreach (var mod in modslist)                       //遍历本地mods，删除旧文件
                    {
                        if (mod.ToString().IndexOf("$") > -1) continue; //例外的删除文件（白名单）
                        if (modlist.Contains(mod.ToString())) continue; //跳过刚更新的文件
                        File.Delete(modsPath + mod);                    //删除旧文件
                    }
                }

                if (JSON.ContainsKey("configs")&&ConfigAuto.Checked)    //检查config节点存在与configauto是否选中
                {
                    InfoAdd(false, "正在检查更新config配置\n", Color.ForestGreen);
                    ArrayList configs = (ArrayList)JSON["configs"];     //将configs节点转换为数组
                    foreach (var Item in configs)                       //遍历configs数组
                    {
                        Dictionary<string, object> Subitem = (Dictionary<string, object>)Item;
                        String configPath = GameDir + @"\versions\" + JSON["name"] + @"\config\" + Subitem["name"];
                        String configHash = Subitem["hash"].ToString();
                        if (File.Exists(configPath))
                        {
                            if (configHash == Hash.FileStrToSHA1(configPath)) continue;
                        }
                        InfoAdd(true, "正在更新" + Subitem["name"], Color.Black);
                        if (DownloadFile(Subitem["url"].ToString(), configPath))
                        {
                            InfoAdd(false, "√\n", Color.Green);
                        }
                        else InfoAdd(false, "×\n", Color.Red);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            InfoAdd(false, "当前整合包更新完成\n", Color.ForestGreen);
        }
        
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <param name="WebUrl">网页URL</param>
        /// <returns>网页内容&错误信息</returns>
        public static String GetHttpPage(String WebUrl)
        {
            try
            {
                WebRequest request = WebRequest.Create(WebUrl);
                WebResponse response = request.GetResponse();
                StreamReader SR = new StreamReader(response.GetResponseStream(), true);
                String text = SR.ReadToEnd();
                SR.Close();
                response.Close();
                return text;
            }
            catch (Exception e)
            {
                return "[Error]" + e.Message;
            }
        }

        /// <summary>
        /// 关闭整合包更新信息并显示整合包更新界面
        /// </summary>
        private void CloseUpdateInfo()
        {
            if (this.InvokeRequired)//等待异步
            {
                SetClient fc = new SetClient(CloseUpdateInfo);
                this.Invoke(fc);//通过委托调用刷新方法
            }
            else
            {
                InfoPanel.Visible = false;
                InfoBox.Clear();
                AssetPanel.Visible = true;
            }
        }
        /// <summary>
        /// 选项卡切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectTab = TabControl.SelectedIndex;
            if (SelectTab == 1)
            {
                GetUpdateList();
                if (UpdateList.Items.Count > 0)
                {
                    UpdateList.SelectedIndex = 0;
                }
            }
        }
        #endregion

    }
}