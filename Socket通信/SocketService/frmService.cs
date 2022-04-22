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

namespace SocketService
{
    public partial class frmService : Form
    {

        public frmService()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            cmbClientList.Items.Insert(0, "--请选择客户端--");
            cmbClientList.SelectedIndex = 0;
            GetIp();//获取本机ip
        }

        private void GetIp()//获取本机ip
        {
            string hostName = Dns.GetHostName();//本机名称
            IPAddress[] ipList = Dns.GetHostAddresses(hostName);//本机ip（包括ipv4和ipv6）
            foreach (IPAddress ip in ipList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    txtHostIp.Text = ip.ToString().Trim();//用的ip4
                }
            }
        }
        Socket socketWacth = null;
        private void btnListen_Click(object sender, EventArgs e)//监听按钮
        {
            try
            {
                //开始监听，在服务器端创建一个负责监听IP地址和端口号的Socket
                socketWacth = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Any;
                //创建端口
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtHostPoint.Text.Trim()));
                //监听
                socketWacth.Bind(point);
                ShowMes("监听已启动" + "   时间：" + DateTime.Now.ToString());
                socketWacth.Listen(10);//连接数量

                //给通信创建新的线程去执行
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(socketWacth);
                timer1.Start(); 
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("通常每个套接字地址(协议/网络地址/端口)只允许使用一次"))
                {
                    ShowMes("请勿重复监听" + "   时间：" + DateTime.Now.ToString());
                }
                else
                {
                    ShowMes(ex.ToString() + "   时间：" + DateTime.Now.ToString());
                }
            }
        }

        Socket socketSend = null;
        //将远程连接客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        private void Listen(object obj)
        {
            Socket skt = obj as Socket;//类型转换

            while (true)
            {
                try
                {
                    //等待客户端的连接，并且创建一个负责通信的Socket
                    socketSend = skt.Accept();
                    //将远程连接客户端的IP地址和Socket存入集合中
                    dicSocket.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                    //客户端IP地址和端口号存入下拉框
                    cmbClientList.Items.Add(socketSend.RemoteEndPoint.ToString());
                    ShowMes("客户端：" + socketSend.RemoteEndPoint.ToString() + ":连接成功" + "   时间：" + DateTime.Now.ToString());
                    //给通信创建新的线程去执行
                    Thread th = new Thread(Recive);
                    th.IsBackground = true;
                    th.Start(socketSend);
                }
                catch (Exception ex)
                {
                    ShowMes(ex.ToString());
                }
            }
        }

        private void Recive(object obj)
        {
            Socket ssd = obj as Socket;
            while (true)
            {
                try
                {
                    //客户端连接成功后，服务器应该接收客户端发来的消息
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    //实际接收到的有效字节数
                    int r = ssd.Receive(buffer);
                    if (r == 0) break;

                    if (buffer[0] == 0)//接收消息的处理
                    {
                        string str = Encoding.UTF8.GetString(buffer, 1, r - 1);
                        ShowMes("客户端" + ssd.RemoteEndPoint + "发送:  " + str + "   时间：" + DateTime.Now.ToString());
                    }
                    else if (buffer[0] == 1)//接收文件的处理
                    {
                        DialogResult dr = MessageBox.Show("客户端" + ssd.RemoteEndPoint.ToString() + "发送文件是否接收?", "提示", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            SaveFileDialog save = new SaveFileDialog();
                            save.InitialDirectory = @"C:\Users\user\Desktop";
                            save.Title = "选择文件保存的路径";
                            save.Filter = "所有文件|*.*";
                            save.ShowDialog(this);
                            using (FileStream fs = new FileStream(save.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                fs.Write(buffer, 1, r - 1);
                            }
                            MessageBox.Show("文件保存成功");
                            ShowMes("来自客户端:" + ssd.RemoteEndPoint.ToString() + "        发送的文件接收成功" + "   时间：" + DateTime.Now.ToString());
                            toClient(ssd, "服务端已成功接收文件");
                        }
                        else
                        {
                            ShowMes("来自客户端:" + ssd.RemoteEndPoint.ToString() + "        发送的文件接收失败" + "   时间：" + DateTime.Now.ToString());
                            toClient(ssd, "服务端拒绝文件的接收");
                            continue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("远程主机强迫关闭了一个现有的连接"))
                    {
                        dicSocket.Remove(ssd.RemoteEndPoint.ToString());
                        var cmb = ssd.RemoteEndPoint.ToString();
                        if (cmbClientList.Text == cmb)
                        {
                            cmbClientList.Text = cmbClientList.Items[0].ToString();
                        }
                        ShowMes("端口:" + cmb + "已强制关闭           " + DateTime.Now.ToString());
                        for (int i = 0; i < cmbClientList.Items.Count; i++)
                        {
                            if (cmbClientList.Items[i].ToString() == cmb)
                            {
                                cmbClientList.Items.RemoveAt(i);
                                break;
                            }
                        }
                        break;
                    }
                    else if (ex.ToString().Contains("空路径名是非法的"))
                    {
                        ShowMes("您已取消请让客户端重新发送" + "   时间：" + DateTime.Now.ToString());
                        toClient(ssd, "服务端在保存文件的环节已取消" + "   时间：" + DateTime.Now.ToString());
                        continue;
                    }

                }

            }
        }

        private void ShowMes(string mes)//提示消息
        {
            txtShowMes.AppendText(mes + "\r\n");
        }

        private void btnSendToClient_Click(object sender, EventArgs e)//发消息按钮
        {
            if (cmbClientList.SelectedIndex < 1)
            {
                ShowMes("请选择要发送的客户端     " + DateTime.Now.ToString());
            }
            else
            {
                try
                {
                    if (txtSendMes.Text.Trim() != string.Empty)
                    {
                        string str = txtSendMes.Text.Trim();
                        byte[] buffer = Encoding.UTF8.GetBytes(str);
                        List<byte> list = new List<byte>();
                        list.Add(0);
                        list.AddRange(buffer);
                        //将list集合转换成新的数组
                        byte[] newBuffer = list.ToArray();
                        string ip = cmbClientList.SelectedItem.ToString();
                        dicSocket[ip].Send(newBuffer);
                        txtSendMes.Clear();
                        txtSendMes.Focus();
                    }
                    else
                    {
                        ShowMes("发送消息为空!" + "   时间：" + DateTime.Now.ToString());
                    }

                }
                catch (Exception ex)
                {
                    ShowMes(ex.ToString());
                }
            }
        }

        private void btnShaken_Click(object sender, EventArgs e)//窗口抖动按钮
        {
            try
            {
                byte[] buffer = new byte[1];
                buffer[0] = 2;
                dicSocket[cmbClientList.SelectedItem.ToString()].Send(buffer);
            }
            catch
            {
                ShowMes("请选择要发送的客户端     " + DateTime.Now.ToString());
            }
        }
        string FileName=string.Empty;
        private void btnChose_Click(object sender, EventArgs e)//选择文件路径按钮
        {
            if (cmbClientList.Text == cmbClientList.Items[0].ToString() || cmbClientList.Text == string.Empty)
            {
                ShowMes("请选择要发送的客户端" + "   时间：" + DateTime.Now.ToString());
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = @"D\";
                open.Title = "选择要发送的文件";
                open.Filter = "所有文件|*.*";
                open.ShowDialog();
                txtFilePath.Text = open.FileName;
                 FileName = open.FileName;
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
                    string [] str =  FileName.Split('.');
                    if (str[str.Length-1] == "html")
                    {
                        list.Add(0);
                    }
                    else if (str[str.Length-1] == "zip")
                    {
                        list.Add(1);
                    }
                    else if (str[str.Length-1] == "exe")
                    {
                        list.Add(2);
                    }
                    else if (str[str.Length-1] == "pdf")
                    {
                        list.Add(3);
                    }
                    else if (str[str.Length-1] == "txt")
                    {
                        list.Add(4);
                    }
                    else if (str[str.Length-1] == "doc")
                    {
                        list.Add(5);
                    }
                    else if (str[str.Length-1] == "xlsx")
                    {
                        list.Add(6);
                    }
                    else if (str[str.Length-1] == "xls")
                    {
                        list.Add(7);
                    }
                    else if (str[str.Length-1] == "json")
                    {
                        list.Add(8);
                    }
                    //else if (str[str.Length-1] == "doc")
                    //{
                    //    list.Add(9);
                    //}
                    else if (str[str.Length-1] == "docx")
                    {
                        list.Add(10);
                    }
                    else if (str[str.Length - 1] == "js")
                    {
                        list.Add(11);
                    }
                    else if (str[str.Length - 1] == "rar")
                    {
                        list.Add(12);
                    }
                    list.AddRange(buffer);
                    byte[] newBuffer = list.ToArray();
                    dicSocket[cmbClientList.SelectedItem.ToString()].Send(newBuffer, 0, r + 2, SocketFlags.None);
                    txtFilePath.Clear();
                    ShowMes("请等待客户端接收文件" + "   时间：" + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("未能找到文件"))
                {
                    ShowMes("文件路径不正确" + DateTime.Now.ToString());
                }
                else if (ex.ToString().Contains("路径中具有非法字符"))
                {
                    ShowMes("路径中具有非法字符" + DateTime.Now.ToString());
                }
                else
                {
                    ShowMes("请选择要发送的客户端     " + DateTime.Now.ToString());

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//断开客户端按钮
        {
            if (cmbClientList.SelectedIndex == 0)
            {
                ShowMes("请选择正确端口     " + DateTime.Now.ToString());
            }
            else
            {
                DialogResult dr = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    var cmb = cmbClientList.SelectedIndex;
                    ShowMes("已删除端口:" + cmbClientList.Text + "   时间：" + DateTime.Now.ToString());
                    dicSocket[cmbClientList.Text].Dispose();
                    dicSocket.Remove(cmbClientList.Text);
                    cmbClientList.Items.RemoveAt(cmb);
                    cmbClientList.Text = cmbClientList.Items[0].ToString();
                }
            }
        }

        private void frmService_FormClosing(object sender, FormClosingEventArgs e)//窗口关闭事件
        {
            try
            {
                DialogResult dr = MessageBox.Show("关闭服务端会失去所有客户端的链接是否关闭?", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    for (int i = 1; i < cmbClientList.Items.Count; i++)
                    {
                        dicSocket[cmbClientList.Items[i].ToString()].Dispose();
                    }
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


        public void toClient(Socket ssd, string toclient)//向客户端发送消息的方法封装
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

                string ip = ssd.RemoteEndPoint.ToString();
                dicSocket[ip].Send(newBuffer);
                txtSendMes.Clear();
                txtSendMes.Focus();
            }
            catch (Exception ex)
            {
                ShowMes(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//计时器
        {
            if (dicSocket.Count > 0)
            {
                try
                {
                    foreach (var item in dicSocket)
                    {
                        XinTiao(item.Value, "已连接");
                    }
                }
                catch (Exception ex)
                {
                    foreach (var item in dicSocket)
                    {
                        XinTiao(item.Value, "未连接");
                    }
                }
            }

        }

        public void XinTiao(Socket ssd, string toclient)//心跳包（每3秒向客户端发送消息，确保客户端的连接是否畅通）
        {
            try
            {
                string str = toclient.Trim();
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                List<byte> list = new List<byte>();
                list.Add(3);
                list.AddRange(buffer);
                //将list集合转换成新的数组
                byte[] newBuffer = list.ToArray();
                string ip = ssd.RemoteEndPoint.ToString();
                dicSocket[ip].Send(newBuffer);
            }
            catch (Exception ex)
            {
                ShowMes(ex.ToString());
            }
        }


    }
}
