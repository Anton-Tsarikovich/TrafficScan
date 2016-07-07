using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace iipyLab7
{
    public enum Protocol
    {
        TCP = 6,
        UDP = 17,
        Unknown = -1
    };
    public partial class MainWindow : Form
    {
        private const double maxTraffic = 1;
        private bool buttonPressed = false;
        private DateTime startTime;
        private DateTime stopTime;
        private TimeSpan workingTime;

        private Timer timer;
        private Socket mainSocket;
        private byte[] byteData = new byte[4096];
        private double ipLenght = 0;
        private double tcpLenght = 0;
        private double secondLength = 0;
        private double totalLenght = 0;
        private uint tick = 0;
        private string postfixTotal = "bit";
        private string postfixLocal = "bit";

        private delegate void AddBytes();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButtonOnClick(object sender, EventArgs e)
        {
            if(!buttonPressed)
            {
                
                startButton.Text = "&Стоп";
                saveGraphic.Enabled = false;
                clearButton.Enabled = false;
                buttonPressed = true;
                startTime = DateTime.Now;
                startMeterage.Text = startTime.ToLongTimeString();
              
                setDiagramm();
                prepareSocket();
            }
            else
            {
                tick = 0;
                startButton.Text = "&Старт";
                timer.Enabled = false;
                startButton.Enabled = false;
                buttonPressed = false;
                saveGraphic.Enabled = true;
                clearButton.Enabled = true;
                stopTime = DateTime.Now;
                finishMeterage.Text = stopTime.ToLongTimeString();
                workingTime = stopTime - startTime;
                workTime.Text = workingTime.Hours.ToString() + ":" + workingTime.Minutes.ToString() + ":" + workingTime.Seconds.ToString();
                mainSocket.Close();
            }
        }

        private void prepareSocket()
        { 
            mainSocket = new Socket(AddressFamily.InterNetwork,
                      SocketType.Raw, ProtocolType.IP);
            IPHostEntry ipEntry = Dns.GetHostByName(Dns.GetHostName());
            IPAddress[] adr = ipEntry.AddressList;
            Console.WriteLine(adr[0].ToString());
            mainSocket.Bind(new IPEndPoint(IPAddress.Parse(adr[0].ToString()), 0));


            mainSocket.SetSocketOption(SocketOptionLevel.IP,
                                       SocketOptionName.HeaderIncluded,
                                       true);

            byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
            byte[] byOut = new byte[4] { 1, 0, 0, 0 };

            mainSocket.IOControl(IOControlCode.ReceiveAll,
                                 byTrue,
                                 byOut);

            mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(OnReceive), null);
        }
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = mainSocket.EndReceive(ar);

                ParseData(byteData, nReceived);

                if (buttonPressed)
                {
                    byteData = new byte[4096];

                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void ParseData(byte[] byteData, int nReceived)
        {
            IPheader ipHeader = new IPheader(byteData, nReceived);
            ipLenght = double.Parse(ipHeader.TotalLength);
            switch (ipHeader.ProtocolType)
            {
                case Protocol.TCP:
                    TCPheader tcpHeader = new TCPheader(ipHeader.Data, ipHeader.MessageLength);
                    tcpLenght += double.Parse(tcpHeader.HeaderLength);
                    break;
               
                case Protocol.Unknown:
                    break;
            }
           
            AddBytes addBytes = new AddBytes(onShowBytes);
            workTime.Invoke(addBytes);
        }

        private void onShowBytes()
        {
            secondLength += ipLenght + tcpLenght;
            if (postfixTotal.Equals("bit"))
                totalLenght += secondLength;
            else if (postfixTotal.Equals("Kbit"))
                totalLenght += secondLength / 1000;
            else if (postfixTotal.Equals("Mbit"))
                totalLenght += secondLength / 1E6;
        }

        private void setDiagramm()
        {

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timerTick;
            timer.Enabled = true;
            trafficDiagramm.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            trafficDiagramm.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            trafficDiagramm.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

        }
        private void timerTick(object sender, EventArgs e)
        {
            tick++;

            if(tick <= 15)
            {
                trafficDiagramm.ChartAreas[0].AxisX.Maximum = 15;
            }
            if(tick > 15)
            {
                trafficDiagramm.ChartAreas[0].AxisX.Maximum = tick;
                trafficDiagramm.ChartAreas[0].AxisX.Minimum = tick - 15;
            }
            

            if (secondLength >= 1000 && secondLength < 1E6)
            {
                secondLength = secondLength / 1000;
                postfixLocal = "Kbit";
            }
            if(secondLength >= 1E6)
            {
                secondLength = secondLength / 1E6;
                postfixLocal = "Mbit";
            }
            
            trafficCount.Text = secondLength.ToString("0.00") + postfixLocal;
            trafficDiagramm.ChartAreas.FindByName("ChartArea1").AxisY.Title = postfixLocal;
            
            trafficDiagramm.Series[0].Points.AddXY(tick, secondLength);
            if (WindowState == FormWindowState.Minimized && secondLength >= maxTraffic && postfixLocal.Equals("Kbit") || postfixLocal.Equals("Mbit"))
            {
                notifySniffer.BalloonTipTitle = "Трафик превысил норму";
                notifySniffer.BalloonTipText = "Значение текущего трафика за секунду = " + secondLength.ToString() + " " + postfixLocal;
                notifySniffer.ShowBalloonTip(2000);
            }
            
            if (totalLenght >= 1000 && totalLenght < 1000000 && postfixTotal.Equals("bit"))
            {
                totalLenght /= 1000;
                postfixTotal = "Kbit";
            }
            if (totalLenght >= 1000 && postfixTotal.Equals("Kbit"))
            {
                totalLenght /= 1000;
                postfixTotal = "Mbit";
            }
            totalTraffic.Text = totalLenght.ToString("0.00") + postfixTotal;
            secondLength = 0;
            tcpLenght = 0;
            ipLenght = 0;
            postfixLocal = "bit";


        }

        private void saveGraphic_Click(object sender, EventArgs e)
        {
            string tempTimeString = startTime.ToLongTimeString();
            trafficDiagramm.SaveImage("C:\\graphic/" + tempTimeString.Replace(":", "_") + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            saveGraphic.Enabled = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            trafficDiagramm.Series[0].Points.Clear();
            startButton.Enabled = true;
            secondLength = 0;
            totalLenght = 0;
            workTime.Text = "";
            totalTraffic.Text = "";
            finishMeterage.Text = "";
            startMeterage.Text = "";
            trafficCount.Text = "";
            postfixTotal = "bit";
            postfixLocal = "bit";
            trafficDiagramm.ChartAreas[0].AxisX.Maximum = 15;
            trafficDiagramm.ChartAreas[0].AxisX.Minimum = 0;
            clearButton.Enabled = false;
        }

        private void toTray_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void notifySniffer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}

