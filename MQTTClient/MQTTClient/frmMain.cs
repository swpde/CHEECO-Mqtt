using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using M2Mqtt;
using MQTTClient;
using M2Mqtt.Messages;
using System.Drawing;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.Threading;
using System.Data;
using log4net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.InteropServices.ComTypes;
using CPUUsage;
using System.Linq;

namespace MQTTClient
{
    
    public partial class frmMain : Form
    {
        string astrFile;
        string aFileCap;
        string strData;
        string EMQX_CLIENT_ID;

        string[] allFiles;
        public MqttClient mqttClient { get; set; } = null;
        public static int connectflag = 0;
        public static int isconnect = 0;
        public static byte disconnectedcount = 0;

        private static string EMQX_BROKER_IP = "mqtt.eaiot.cloud";
        private static int EMQX_BROKER_PORT = 8883;//1883;
        private string DataPath = "c:\\SendData";
        private string Filters = "*.json";
        private string CommandPath = "c:\\SendData\\CMD";
        private string CommandTopic = "Commands";
        public static int batchSize = 5;
        //  private string EMQX_CLIENT_ID;

        // public List<MqttClient> MqttClientList = new List<MqttClient>;


        /* 调用事件是在单独的线程中进行的 */
        //当推送消息成功后，该事件会被调用
        //DMS.MqttMsgPublished += MqttMsgPublished;
        //当连接断开后，该事件会被调用
        //DMS.ConnectionClosed += ConnectionClosed;
        //关注话题成功后，该事件会被调用
        //DMS.MqttMsgSubscribed += MqttMsgSubscribed;
        //取消关注成功后，该事件会被调用
        // DMS.MqttMsgUnsubscribed += MqttMsgUnsubscribed;
        //当接收到关注的消息后，该事件会被调用
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        // 消息函数
        [DllImport("user32.dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strclassName, string strWindowName);
        [DllImportAttribute("user32.dll")]


        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MAXIMIZE = 0xF030;//窗体最大化消息
        public const int SC_NOMAL = 0xF120;//窗体还原消息
        private static ILog log = LogManager.GetLogger("frmMain");

        //CPU
        public float cpuUsage = 0;
        public float prev_cpuUsage = 0;

        private String getTopic() {
            INIFile ConfigINI = new INIFile();
            string strSysPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory);
            string INIPath = strSysPath + "Config.ini";

            String iotcode = ConfigINI.INIRead("System Set", "SysID", "202300001", INIPath);
            String topic = "/rpc/ems" + iotcode.Substring(iotcode.Length - 7) + "/ems/strategy/request";
           
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("获取标题地址 : " +now);
          

            return topic;
        }

        public frmMain()
        {
            InitializeComponent();

            /*            Thread ClientRecThread = new Thread(ReadmqttData);
                        ClientRecThread.IsBackground = true;
                        ClientRecThread.Start();
                        ClientRecThread.Name = "";
                        //8.4
                        ClientRecThread.Priority = ThreadPriority.Normal;*/

            Thread thread = new Thread(SendmqttData);
            Thread ClientRecThread1 = thread;
            ClientRecThread1.IsBackground = true;
            ClientRecThread1.Start();
            ClientRecThread1.Name = "SendmqttData";
            ClientRecThread1.Priority = ThreadPriority.Highest;

            Thread ClientRecThread2 = new Thread(GetCPUUsage);
            ClientRecThread2.IsBackground = true;
            ClientRecThread2.Start();
            ClientRecThread2.Name = "GetCPUUsage";
            ClientRecThread2.Priority = ThreadPriority.Lowest;


            /*            Thread ClientRecThread2 = new Thread(creat);
                        ClientRecThread2.IsBackground = true;
                        ClientRecThread2.Start();
                        ClientRecThread2.Name = "";
                        //8.4
                        ClientRecThread2.Priority = ThreadPriority.Lowest ;*/


            //Task.Run(async () => { await ConnectMqttServerAsync(); });
            this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            //this.labProcessName.Text= Application.na
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = false;
            AutoScroll = true;
            MaximizeBox = true;
            this.tbReceiveTopic.Text = getTopic();
        }

        ~frmMain()
        {
            //System.Environment.Exit(0);
        }

        static void UpDate(string[] args)
        {
            string updateUrl = "https://yourserver.com/updates/update.zip";
            string localFilePath = "update.zip";

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(updateUrl), localFilePath);
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("UpDate : " + now);
        }

        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Console.WriteLine("Update downloaded successfully.");
                // Extract and install the update here
                string zipFilePath = @"path\to\your\zipfile.zip";
                string extractPath = @"path\to\extract\directory";

                ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                //Logger.LogInit();
                //DateTime now = DateTime.Now;
                //Logger.Info("WebClient_DownloadFileCompleted : " + now);
            }
            else
            {
                Console.WriteLine("Error downloading update: " + e.Error.Message);
            }
        }

        /// <summary>
        /// 启动其他程序
        /// </summary>
        /// <param name="FileName">需要启动的外部程序名称</param>
        /// <param name="Arguments">一个文件夹路径</param>
        public static bool OpenPress(string FileName, string Arguments)
        {
            // print(FileName);
            Process pro = new Process();
            if (System.IO.File.Exists(FileName))
            {
                pro.StartInfo.FileName = FileName;
                pro.StartInfo.Arguments = Arguments;
                pro.Start();
                //Logger.LogInit();
                //DateTime now = DateTime.Now;
                //Logger.Info("openfile : " + now);

                return true;
            }
            return false;
        }

        //关闭程序
        public void ClosePress(string name)
        {
            //获得任务管理器中的所有进程
            Process[] process = Process.GetProcesses();
            foreach (Process p1 in process)
            {
                try
                {
                    string processName = p1.ProcessName.ToLower().Trim();
                    //判断是否包含阻碍更新的进程
                    if (processName == name)
                    {
                        p1.Kill();
                    }
                }
                catch { }
            }
        }


        public static int GetPidByProcessName(string processName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(processName);
            foreach (Process p in arrayProcess)
            {
                return p.Id;
            }
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("GetPidByProcessName: " + now);

            return 0;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string strSysPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory);
            try
            {

                DataPath = strSysPath + "UpData";
                CommandPath = strSysPath + "UpData\\CMD";
                //Logger.LogInit();
                //DateTime now = DateTime.Now;
                //Logger.Info("frmMain_Load: " + now);

                if (!Directory.Exists(DataPath))
                {
                    Directory.CreateDirectory(DataPath);
                }

                mqttConnect();
                ListenTopic(CommandTopic);
            }
            catch { }
/*            tmSystem.Interval = 10000;
            tmSystem.Enabled = true;*/

        }

        /// <summary>
        /// 查询目录里的文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        string[] GetAllFileNames(string path, string pattern = "*.*")
        {

            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("GetAllFileNames: " + now);
            return Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);

        }

        public MqttClient CreateClient()
        {
            //string RecCommandInfo = new StackTrace().ToString();
            //Logger.Error("err:"+RecCommandInfo);
            INIFile ConfigINI = new INIFile();
            string strSysPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory);
            string INIPath = strSysPath + "Config.ini";
            String iotcode = ConfigINI.INIRead("System Set", "SysID", "202300001", INIPath).Trim();


            EMQX_CLIENT_ID = iotcode + "-mqtt";

            //EMQX_CLIENT_ID = Guid.NewGuid().ToString();
            //Logger.LogInit();
            DateTime now = DateTime.Now;

            //Logger.Info("CreateClient: " + now);
            try
            {
                //mqttClient = null;
                if (mqttClient != null)   { mqttClient.Disconnect(); }
                frmMain.connectflag = 1;
                //Logger.Error("获取mqtt连接状态: " + now);
                // mqttClient.ConnectionClosed
                //建立连接
                //mqttClient = new MqttClient(EMQX_BROKER_IP, EMQX_BROKER_PORT, false, null, null, MqttSslProtocols.TLSv1_2);
                mqttClient = new MqttClient(EMQX_BROKER_IP, EMQX_BROKER_PORT, true, null, null, MqttSslProtocols.TLSv1_2);
                //下面这种方法是个坑，并不能正常访问到MQTT服务器
                // mqttClient = new MqttClient(IPAddress.Parse(EMQX_BROKER_IP));
                //Logger.Error("mqtt1: " + now);

                /**************************************************************************************/
                /*                 
                 * 另外，要想实现QoS > 0的MQTT通讯，客户端在连接服务端时必须要将cleanSession设置为false。
                 * 如果这一步没有实现，那么客户端是无法实现QoS > 0的MQTT通讯。这一点非常关键，请您务必要留意。                          
                 */
             // (string clientId, string username, string password, bool willRetain, byte willQosLevel, bool willFlag, string willTopic, string willMessage, bool cleanSession, ushort keepAlivePeriod)
    
                    /**************************************************************************************/
                    //确认连接返回值
                    byte connectReturnCode = mqttClient.Connect(EMQX_CLIENT_ID, "aiot", "Lab123123123", false, 1, false, null, null, false, 60);// keepAlivePeriod 
                //mqttClient.Connect(EMQX_CLIENT_ID);
                //Logger.Error("mqtt连接: " + now);
                mqttClient.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                log.Debug("CreateClient-Connection return code: " + connectReturnCode);
                //MqttReceiver receiver = new MqttReceiver();
                /**************************************************************************************/
                /**************************************************************************************/
                //btnConnect.BackColor = Color.Green;
                //Logger.Error("更改按键颜色: " + now);

                return mqttClient;
            }
            catch (Exception ex)
            {
                log.Debug("CreateClient-进入断网状态 重新建立客户端");

                //MessageBox.Show(ex.Message);
                //meterg,meterp,metera,air  meter
                //ename==iot_code,eTime=time
            }
            //frmMain.connectflag = 1;
            return null;
        }

        // 建立MQTT连接
        private void mqttConnect()
        {
            //Logger.LogInit();
            DateTime now = DateTime.Now;
            //Logger.Info("mqttConnect: " + now);
            try
            {
   /*             if (btnConnect.BackColor == Color.Green)
                {
                    //断开连接
                    mqttClient.Disconnect();
                    btnConnect.BackColor = Color.Gray;
                    return;
                }*/
                CreateClient();
            }
            catch { }
        }

        //重连
        private void mqttReconnect() {
            //string RecCommandInfo = new StackTrace().ToString();
            //Logger.Error("err:"+RecCommandInfo);

           
            //Logger.LogInit();
            DateTime now = DateTime.Now;

            //Logger.Info("CreateClient: " + now);
            try
            {
                //mqttClient = null;
                /*                if (mqttClient != null)
                                    mqttClient.Disconnect();*/
                byte connectReturnCode = mqttClient.Connect(EMQX_CLIENT_ID,
                                            "aiot",// user,
                                            "Lab123123123",//pwd,
                                            false, // cleanSession
                                            60); // keepAlivePeriod 
                                                 //mqttClient.Connect(EMQX_CLIENT_ID);
                                                 //mqttClient.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                log.Debug("mqttReconnect-Connection ReCode: " + connectReturnCode);

                ListenTopic(CommandTopic);
                //btnConnect.BackColor = Color.Green;
                
            }
            catch (Exception ex)
            {
                //mqttClient.Connect()函数返回值异常进入断网状态 重新建立客户端
                log.Debug("mqttReconnect-进入断网状态 重新建立客户端");
                Thread.Sleep(10000);
                CreateClient();

            }

        }


        /// <summary>
        /// 给一个topic写数据
        /// </summary>
        /// <param name="currentTopic"></param>
        /// <param name="content"></param>
        public void Write2Topic(string currentTopic, string content)
        {
            //Logger.LogInit();
            DateTime now = DateTime.Now;
            //Logger.Info("Write2Topic: " + now);
            if (mqttClient != null && !string.IsNullOrEmpty(currentTopic) && !string.IsNullOrEmpty(content))
            {
                mqttClient.Publish(currentTopic, System.Text.Encoding.UTF8.GetBytes(content),
                    MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, true);//qos
         /*    log.Debug(" 发送数据");   */                                               //

            }
        }

        /// <summary>
        /// 设置监听一个topic
        /// </summary>
        /// <param name="aTopic"></param>
        public void ListenTopic(string aTopic)
        {
            //Logger.LogInit();
            DateTime now = DateTime.Now;
            //Logger.Info("ListenTopic: " + now);
            if (mqttClient != null && !string.IsNullOrEmpty(aTopic))
            {
                byte SubAck = (byte)mqttClient.Subscribe(new string[] { aTopic },new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  //订阅成功
                log.Debug(" 订阅返回值 :" + SubAck);

            }
        }

        //这段定义了收到消息之后做什么事情
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            string topic = e.Topic.ToString();
            string message = System.Text.Encoding.Default.GetString(e.Message);
            //Logger.LogInit();
            DateTime now = DateTime.Now;
            log.Debug("message: " + message);
            //同时订阅两个或者以上主题时，分类收集收到的信息
            //if (topic == tbTopic.Text)
            //{
            //    Invoke((new Action(() =>
            //    {
            //        txtReceiveMessage.Text = message;
            //    })));
            //}
            //reciveTopic.Text = topic;
            //reciveMessagetxt.Text = message;

        }

        // 断开MQTT连接
        private void closeconnect()
        {
            try
            {
                mqttClient.Disconnect();
            }
            catch { }
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;

            log.Debug(" tnConnect_Click");            
            //mqttConnect();
            mqttReconnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("button3_Click: " + now);
            tbReceiveTopic.Text = getTopic();
            ListenTopic(tbReceiveTopic.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //取消成功后，DMS.MqttMsgUnsubscribed事件会被调用
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("button4_Click: " + now);
            mqttClient.Unsubscribe(new string[] { tbReceiveTopic.Text });
        }

        private void tmSystem_Tick(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("tmSystem_Tick: " + now);
            GetandUpdate2Clound(true);

            Thread.Sleep(1000);
        }




        public void GetandUpdate2Clound(bool aDeleFile)
        {

            //Logger.LogInit();
            
/*            DateTime now = DateTime.Now;
            //Logger.Info("GetandUpdate2Clound: " + now);
            try
            {

                creat();
                ReadmqttData();
                SendmqttData();

                //Write2Topic("", "");
            }
            catch
            {
                btnConnect.BackColor = Color.Gray;
                Logger.Error("灰2: " + now);
                // CreateClient();
                //mqttClient.Disconnect();
                mqttClient = null;

            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("button2_Click: " + now);
            GetandUpdate2Clound(false);
        }

        private void CloseForm()
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("CloseForm: " + now);
            DialogResult result;//定义对话框窗口返回值结果类型 变量 result ; 
            result = MessageBox.Show("确定要退出数据上传软件吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information); // 获取Messagebox 的 返回值。

            if (result == DialogResult.Yes)
            {
                this.Close();
                System.Environment.Exit(0);
            }
            //Application.Exit();
            //Application.ExitThread(); 
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("btnClose_Click: " + now);
            CloseForm();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("frmMain_FormClosed: " + now);
            System.Environment.Exit(0);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("btnMin_Click: " + now);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("frmMain_Resize: " + now);
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           // if (!formClose)
            {
                //不是通过菜单关闭程序
                //Logger.LogInit();
                //DateTime now = DateTime.Now;
                //Logger.Info("frmMain_FormClosing: " + now);
                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        private void ShowForm()
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("ShowForm: " + now);
            if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                    this.Activate();//激活窗口
                    this.ShowInTaskbar = true;//托盘中显示
                    notifyIcon1.Visible = false;
                }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("notifyIcon1_MouseClick: " + now);
            if (e.Button == MouseButtons.Left)
            {

                ShowForm();
            }
        }

        private void cmsStop_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void tsmShowWin_Click(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("tsmShowWin_Click: " + now);
            ShowForm();
        }

        private void tsStop_Click(object sender, EventArgs e)
        {
            //Logger.LogInit();
            //DateTime now = DateTime.Now;
            //Logger.Info("tsStop_Click: " + now);
            CloseForm();
        }

        private void tbReceiveTopic_TextChanged(object sender, EventArgs e)
        {

        }
        private void ReadmqttData()
        {
            
        }
        private void SendmqttData()
        {
            while (true)
            {
                //问题代码 System.NullReferenceException
                {
                    if (mqttClient != null)
                    {
                       if(!mqttClient.IsConnected)  
                        {
                            /*************************************************************************************/
                            /*************************************************************************************/
                            //先断开连接
                            //closeconnect();
                            //添加记录掉线次数
                            log.Debug(" disconnectedcount:" + disconnectedcount);
                            btnConnect.BackColor = Color.Gray;
                            mqttReconnect();
                            isconnect = 0;
                            disconnectedcount++;
                            
                            /*************************************************************************************/
                            /*************************************************************************************/
                        }
                        else {
                            isconnect = 1;
                            btnConnect.BackColor = Color.Green;
                            //log.Debug("isconnect:" + isconnect);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        mqttConnect();
                    }
                }
                //CpuVale.Invoke((MethodInvoker)delegate { CpuVale.Text = "new value"; });
                //CpuVale.Text = Convert.ToString(cpuUsage);

                //allFiles = Array.Empty<string>();
                try
                {
                    if ( isconnect == 1)
                    {
                        allFiles = GetAllFileNames(DataPath, Filters);
                        log.Debug(" 全部文档数量:" + allFiles.Length);
                        //发送数据
                        if (allFiles.Length > 0)
                        {

                            //显示数据
                            labUpdateTime.Invoke((MethodInvoker)
                                delegate { labUpdateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
                                );

                            rtbUpdateFiles.Invoke((MethodInvoker)delegate { rtbUpdateFiles.Lines = allFiles; });


                            for (int i = 0; i < allFiles.Length; i += batchSize)
                            {


                                string[] batch = allFiles.Skip(i).Take(batchSize).ToArray();
                                // 逐个发送文件
                                foreach (string allFiles in batch)
                                {
                                    string fileName = Path.GetFileName(allFiles);

                                    aFileCap = fileName.Substring(1, 3);
                                    strData = File.ReadAllText(@allFiles);
                                    Write2Topic(aFileCap, strData);
                                    File.Delete(allFiles);
                                    //string destFile = Path.Combine(destDir, fileName);
                                    //File.Copy(file, destFile, true); // 覆盖目标文件
                                    //Console.WriteLine($"Transferred: {fileName}");
                                    //File.Delete(allFiles);
                                }
                                Thread.Sleep(1000);
                                log.Debug($"剩余文档数量:{allFiles.Length - i}");

                                //log.Debug("发送文件： " + allFiles[i]);
                                //astrFile = allFiles[i];
                                //aFileCap = Path.GetFileName(astrFile);
                                //aFileCap = aFileCap.Substring(1, 3);
                                //strData = File.ReadAllText(@astrFile);
                                //Write2Topic(aFileCap, strData);
                                //   File.Delete(astrFile);

                            }
                            log.Debug("SendMG---DONE DeleteMG---DONE");
                            //清空数组
                            allFiles = Array.Empty<string>();
                            rtbUpdateFiles.Invoke((MethodInvoker)delegate
                            {
                                rtbUpdateFiles.Lines = Array.Empty<string>();
                            });
                        }
                        Thread.Sleep(5000);
                    }
                }
                catch
                {
                    Thread.Sleep(1000);
                    //btnConnect.BackColor = Color.Gray;
                    // CreateClient();
                    //mqttClient.Disconnect();
                    //mqttClient = null;

                }
                Thread.Sleep(1000);
            }
        }


        public void GetCPUUsage()
        {
            // 通过进程名称获取目标进程
            CPUUsageExample.targetProcess = Process.GetProcessesByName("MQTTClient")[0];

            while (true)
            {

                //// 创建 PerformanceCounter 对象并设置相关参数
                //CPUUsageExample.cpuCounter = new PerformanceCounter("Process", "% Processor Time", CPUUsageExample.targetProcess.ProcessName, true);

                // 获取目标进程的 CPU 使用率
                cpuUsage = (CPUUsageExample.CheckCPUUsage());
                CpuVale.Invoke((MethodInvoker)delegate { CpuVale.Text = cpuUsage.ToString(); });
                float average_cpuUsage = (cpuUsage + prev_cpuUsage) / 2;
                log.Error($"Process CPU Usage: {average_cpuUsage}%");
                if(average_cpuUsage >= 5)
                {
                    log.Error("系统重启");
                    SoftwareRestart();

                }
                //Console.WriteLine($"Process CPU Usage: {cpuUsage}%");
                //Console.ReadLine();
                prev_cpuUsage = cpuUsage;
                Thread.Sleep(5000);

            }

        }
        public static void SoftwareRestart()
        {
            // 获取当前执行程序的路径
            //string currentPath = Process.GetCurrentProcess().MainModule.FileName;
            //// 启动新的进程
            //Process.Start(currentPath);
            //// 退出当前进程
            //Environment.Exit(0);

            Application.ExitThread();
            Application.Exit();
            Application.Restart();
            Process.GetCurrentProcess().Kill();

        }


        private void creat()
        {
            //检查连接
            while (true)
            {
                if (( ((mqttClient == null) || (!mqttClient.IsConnected))) && frmMain.connectflag == 1)
                {
                    if (mqttClient == null)
                    {
                        CreateClient();
                    }
                    else if (!mqttClient.IsConnected)
                    {
                        mqttClient.Disconnect();
                        mqttClient = null;
                        CreateClient();
                    }
           
                }

                Thread.Sleep(3000);

            }

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}