using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          
        }






        private string  isSetPort(int portNum,string ipAddress)
        {
            //ipAddress = getIpAddress();
            //ipAddress = "10.114.146.26";
            System.Net.IPAddress myIpAddress = IPAddress.Parse(ipAddress);
            IPEndPoint point = new IPEndPoint(myIpAddress, portNum);

            try
            {
                using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    sock.Connect(point);
                    return "连接成功！";
                }
            }
            catch (SocketException ex)
            {
                return ex.ToString();
            }
        }

        private string getIpAddress()
        {
            try
            {
                System.Net.IPHostEntry localhost = System.Net.Dns.GetHostByName(Dns.GetHostName());
                IPAddress localaddr = localhost.AddressList[0];
                return localaddr.ToString();
            }
            catch (Exception ex)
            {
                return " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = this.IP.Text;
                int protnum = Convert.ToInt32(this.Protnum.Text);
                string  msginfo = isSetPort(protnum, ip);
                this.info.Text = msginfo;
            }
            catch (Exception ex)
            {

                this.info.Text = "连接失败！"+ex.ToString();
            }
           




        }
    }
}
