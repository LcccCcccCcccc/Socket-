using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            GetIp();
        }
        private void GetIp()//获取本机ip
        {
            string hostName = Dns.GetHostName();//本机名称
            IPAddress[] ipList = Dns.GetHostAddresses(hostName);//本机ip（包括ipv4和ipv6）
            foreach (IPAddress ip in ipList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    txtClientIp.Text = "192.168.8.137";// ip.ToString().Trim();
                }
            }
        }
        Socket socketSend = null;
        private void btnContent_Click(object sender, EventArgs e)//连接按钮
        {
            try
            {
                if (txtClientPoint.Text == "50000")
                {  
                    //创建负责通信的Socket
                    socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ip = IPAddress.Parse(txtClientIp.Text.Trim());
                    IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtClientPoint.Text.Trim()));
                    //获得远程要连接的IP和端口号
                    socketSend.Connect(point);
                    ShowMes("连接服务端成功" + "   时间：" + DateTime.Now.ToString());
                    txtClientPoint.Text = socketSend.LocalEndPoint.ToString().Split(':')[1];
                    //开新线程接收服务端的消息
                    Thread th = new Thread(Recive);
                    th.IsBackground = true;
                    th.Start();
                    timer1.Start();
                }
                else
                {
                    ShowMes("一个客户端只可以连接一次,不可重复连接" + "   时间：" + DateTime.Now.ToString());
                }
              
            }
            catch
            {
                if (txtClientPoint.Text != "50000")
                {
                    ShowMes("一个客户端只可以连接一次,不可重复连接" + "   时间：" + DateTime.Now.ToString());
                }
                else if (txtClientPoint.Text == "50000")
                {
                    ShowMes("服务端未开启监听" + "   时间：" + DateTime.Now.ToString());
                }
            }
        }

        private void Recive()//接收服务端不同的消息类型
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    int r = socketSend.Receive(buffer);
                    if (r == 0) break;

                    if (buffer[0] == 0)
                    {
                        string count = Encoding.UTF8.GetString(buffer, 1, r - 1);
                        ShowMes("服务端" + socketSend.RemoteEndPoint + "发送:  " + count + "   时间：" + DateTime.Now.ToString());
                    }
                    else if (buffer[0] == 1)
                    {

                        string lastName = string.Empty;
                        var dt = DateTime.Now.ToString().Replace(":","").Replace(" ","").Replace("/", "");

                        if (buffer[1] == 0)
                        {
                            lastName = $"{dt}.html";
                        }
                        else if (buffer[1] == 1)
                        {
                            lastName = $"{dt}.zip";
                        }
                        else if (buffer[1] == 2)
                        {
                            lastName = $"{dt}.exe";
                        }
                        else if (buffer[1] == 3)
                        {
                            lastName = $"{dt}.pdf";
                        }
                        else if (buffer[1] == 4)
                        {
                            lastName = $"{dt}.txt";
                        }
                        else if (buffer[1] == 5)
                        {
                            lastName = $"{dt}.doc";
                        }
                        else if (buffer[1] == 6)
                        {
                            lastName = $"{dt}.xlsx";
                        }
                        else if (buffer[1] == 7)
                        {
                            lastName = $"{dt}.xls";
                        }
                        else if (buffer[1] == 8)
                        {
                            lastName = $"{dt}.json";
                        }
                        //else if (buffer[1] == 9)
                        //{
                        //    lastName = $"{dt}.doc";
                        //}
                        else if (buffer[1] == 10)
                        {
                            lastName = $"{dt}.docx";
                        }
                        else if (buffer[1] == 11)
                        {
                            lastName = $"{dt}.js";
                        }
                        else if (buffer[1] == 12)
                        {
                            lastName = $"{dt}.rar";
                        }

                        string fileName = @"D:\test\";
                        string fileeXistence = @"D:\test";
                        try
                        {
                            if (!Directory.Exists(fileeXistence))
                            {
                                Directory.CreateDirectory(fileeXistence);
                            }
                            FileStream fs = new FileStream(fileName + lastName, FileMode.Create);
                            fs.Write(buffer, 2, r - 2);
                            fs.Close();
                            ShowMes("成功接收来自服务端的文件" + "   时间：" + DateTime.Now.ToString());
                            toService("客户端已成功接收文件");
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("未能找到路径"))
                            {
                                ShowMes("接收的文件未识别");
                                toService("客户端接收文件失败，发送的文件未识别");
                            }
                            else
                            {
                                toService("客户端接收文件失败");
                            }
                        }

                    }
                    else if (buffer[0] == 2)
                    {
                        ZhenDong();
                    }
                    else if (buffer[0] == 3)
                    {
                        string count = Encoding.UTF8.GetString(buffer, 1, r - 1);
                        xintiao(count);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("空路径名是非法的"))
                    {
                        ShowMes("您已取消请让服务端重新发送" + "   时间：" + DateTime.Now.ToString());
                        toService("客户端在保存文件的环节已取消");
                        continue;
                    }
                    else
                    {
                        ShowMes("服务端已断开连接" + "   时间：" + DateTime.Now.ToString());
                        txtClientPoint.Text = "50000";
                        break;
                    }
                }
            }
        }
        //骚扰震动
        private void ZhenDong()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.Location = new Point(420, 220);
                this.Location = new Point(424, 224);
            }
        }

        public void ShowMes(string mes)//提示消息
        {
            txtMes.AppendText(mes + "\r\n");
        }

        public void xintiao(string mes)//提示消息
        {
            label6.Text = mes;
        }

        private void btnSend_Click(object sender, EventArgs e)//发送消息按钮
        {
            try
            {
                if (txtSendMes.Text.Trim()!=string.Empty)
                {
                    string str = txtSendMes.Text.Trim();
                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    List<byte> list = new List<byte>();
                    list.Add(0);
                    list.AddRange(buffer);
                    byte[] newBuffer = list.ToArray();
                    socketSend.Send(newBuffer);
                    txtSendMes.Clear();
                    txtSendMes.Focus();
                }
                else
                {
                    if (txtClientPoint.Text=="50000")
                    {
                        ShowMes("尚未链接服务端!" + "   时间：" + DateTime.Now.ToString());
                    }
                    else
                    {
                        ShowMes("发送消息为空!" + "   时间：" + DateTime.Now.ToString());
                    }
                }
               

            }
            catch {
                ShowMes("尚未链接服务端" + "   时间：" + DateTime.Now.ToString());
            }
        }

        private void btnChose_Click(object sender, EventArgs e)//选择文件路径
        {
            if (txtClientPoint.Text == "50000")
            {
                ShowMes("尚未链接服务端!" + "   时间：" + DateTime.Now.ToString());
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = @"D\";
                open.Title = "选择要发送的文件";
                open.Filter = "所有文件|*.*";
                open.ShowDialog();
                txtFilePath.Text = open.FileName;
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)//发送文件按钮
        {
            try
            {
                using (FileStream fs = new FileStream(txtFilePath.Text.Trim(), FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    int r = fs.Read(buffer, 0, buffer.Length);
                    List<byte> list = new List<byte>();
                    list.Add(1);
                    list.AddRange(buffer);
                    byte[] newBuffer = list.ToArray();
                    socketSend.Send(newBuffer, 0, r + 1, SocketFlags.None);
                    txtFilePath.Clear();
                    ShowMes("请等待服务端接收文件" + "   时间：" + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                if (txtFilePath.Text==string.Empty)
                {
                    ShowMes("请选择文件路径" + "   时间：" + DateTime.Now.ToString());
                }
                else if (ex.ToString().Contains("未能找到文件"))
                {
                    ShowMes("文件路径错误，请重新输入" + "   时间：" + DateTime.Now.ToString());
                }
                else
                {
                    ShowMes("尚未链接服务端" + "   时间：" + DateTime.Now.ToString());
                }
               
            }
        }

        public void toService(string toclient)//向服务端发消息的方法封装
        {
            try
            {
                string str = toclient.Trim();
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //将list集合转换成新的数组
                byte[] newBuffer = list.ToArray();
                socketSend.Send(newBuffer);
                txtSendMes.Clear();
                txtSendMes.Focus();
            }
            catch (Exception ex)
            {
                ShowMes(ex.ToString());
            }

        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)//窗体关闭事件
        {
            try
            {
                DialogResult dr = MessageBox.Show("是否关闭客户端?", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                ShowMes(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//定时器
        {
            if (txtClientPoint.Text == "50000")
            {
                label3.Text = "未连接";
                label6.Text = "未连接";
                timer1.Stop();
            }
            else
            {
                label3.Text = "已连接";
            }
        }
    }
}
