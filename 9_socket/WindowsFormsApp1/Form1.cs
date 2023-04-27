using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public NetworkStream m_stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        const int PORT = 2002;
        private Thread m_ThReader;

        public bool m_bStop = false;

        private TcpListener m_listener;
        private Thread m_thServer;

        public bool m_bConnect = false;
        TcpClient m_Client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.Load("https://blog.kakaocdn.net/dn/bezjux/btqCX8fuOPX/6uq138en4osoKRq9rtbEG0/img.jpg");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                txt_all.AppendText(msg + "\r\n");

                txt_all.Focus();
                txt_all.ScrollToCaret();

                txt_all.Focus();
            }));
        }

        public void ServerStart()
        {
            try
            {
                m_listener = new TcpListener(PORT);
                m_listener.Start();

                m_bStop = true;
                Message("클라이언트 접속 대기중");

                while (m_bStop)
                {
                    TcpClient hClient = m_listener.AcceptTcpClient();  // wait

                    if (hClient.Connected)
                    {
                        m_bConnect = true;
                        Message("클라이언트 접속");

                        m_stream = hClient.GetStream();
                        m_Read = new StreamReader(m_stream);
                        m_Write = new StreamWriter(m_stream);

                        m_ThReader = new Thread(new ThreadStart(Receive));  // thread use
                        m_ThReader.Start();
                    }

                }
            }
            catch
            {
                Message("시작 도중에 오류 발생");
                return;
            }
        }

        public void ServerStop()
        {
            if (!m_bStop) { return; }

            m_listener.Stop();

            m_Read.Close();
            m_Write.Close();

            m_stream.Close();

            m_ThReader.Abort();
            m_thServer.Abort();
        }

        public void Disconnect()
        {
            if(!m_bConnect) { return; }

            m_bConnect=false;
            m_Read.Close();
            m_Write.Close();

            m_stream.Close();
            m_ThReader.Abort();

            Message("상대방과 연결 중단");
        }

        public void Connect()
        {
            m_Client = new TcpClient();

            try
            {
                txt_serverIp.Text = "127.0.0.1";
                m_Client.Connect(txt_serverIp.Text, PORT);  // server ip & Port
            }
            catch
            {
                m_bConnect = true;
                return;
            }
            m_bConnect = true;
            Message("서버에 연결");

            m_stream = m_Client.GetStream();

            m_Read = new StreamReader(m_stream);
            m_Write = new StreamWriter(m_stream);

            m_ThReader = new Thread(new ThreadStart(Receive));  //Thread use
            m_ThReader.Start();
        }

        public void Receive()
        {
            try
            {
                while (m_bConnect)
                {
                    string szMessage = m_Read.ReadLine();
                    pictureBox1.Load(szMessage);
                    // https://blog.kakaocdn.net/dn/bezjux/btqCX8fuOPX/6uq138en4osoKRq9rtbEG0/img.jpg
                    if (szMessage != null)
                    {
                        Message("문제가 등장했습니다 !");
                    }
                }
            }
            catch
            {
                Message("데이터를 읽는 과정에서 오류가 발생");
            }
            Disconnect();
        }

        void Send()
        {
            try
            {
                m_Write.WriteLine(txt_send.Text);
                m_Write.Flush();

                Message(">>> : "+txt_send.Text);
                txt_send.Text = "";
            }
            catch
            {
                Message("데이터 전송 실패");
            }
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            if(btn_server.Text == "서버 켜기")
            {
                m_thServer = new Thread(new ThreadStart(ServerStart));
                m_thServer.Start();
               
                btn_server.Text = "서버 멈춤";
                btn_server.ForeColor = Color.Red;
            }
            else
            {
                ServerStop();
                btn_server.Text = "서버 켜기";
                btn_server.ForeColor = Color.Black;
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if(btn_connect.Text == "서버 연결")
            {
                Connect();
                if(m_bConnect)
                {
                    btn_connect.Text = "연결 끊기";
                    btn_connect.ForeColor = Color.Red;
                }
                else
                {
                    Disconnect();
                    btn_connect.Text = "서버 연결";
                    btn_connect.ForeColor = Color.Black;
                }
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void txt_send_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Send();
            }
        }

        private void txt_serverIp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
