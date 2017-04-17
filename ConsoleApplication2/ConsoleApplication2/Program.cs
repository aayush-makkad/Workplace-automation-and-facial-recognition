using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;

namespace ConsoleApplication2
{
    class Program
    {
        public SerialPort serialPort1 { get; private set; }

        static void Main(string[] args)
        {
            string output;
            System.IO.Ports.SerialPort serialPort1;
            try
            {
                //Program p = new Program();
                //p.establishConnection();
                String s1= Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
                IPAddress ipAd = IPAddress.Parse(s1);
                // use local m/c IP address, and 

                // use the same in the client


                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 4444);

                /* Start Listeneting at the specified port */
                myList.Start();

                Console.WriteLine("The server is running at port 4444...");
                Console.WriteLine("The local End point is  :" +
                                  myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
            m:
                Socket s = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = s.Receive(b);

                char cc = ' ';
                string test = null;
                Console.WriteLine("Recieved...");
                for (int i = 0; i < k - 1; i++)
                {
                    //Console.Write(Convert.ToChar(b[i]));
                    cc = Convert.ToChar(b[i]);
                    test += cc.ToString();
                    Console.Write(cc.ToString());
                }

                //switch (test)
                //{
                //    case "1":
                //        break;


                //}
                
                Program p = new Program();
                p.establishConnection(test);
                switch ("df")
                {

                    case "Lock_all" : Console.WriteLine("\ncaught Hey");
                        //Program p = new Program();
                        p.establishConnection("l");
                        break;
                    case "lock_selec":
                        //Program p = new Program();
                        p.establishConnection("u");
                        break;

                    default:
                        Console.WriteLine("\ncaught something else");
                        //Process cmd = new Process();
                        //cmd.StartInfo.FileName = "cmd.exe";
                        //cmd.StartInfo.RedirectStandardInput = true;
                        //cmd.StartInfo.RedirectStandardOutput = true;
                        //cmd.StartInfo.CreateNoWindow = true;
                        //cmd.StartInfo.UseShellExecute = false;
                        //cmd.Start();

                        //cmd.StandardInput.WriteLine("py ball_tracking.py");
                        //cmd.StandardInput.Flush();
                        //string output = cmd.StandardOutput.ReadToEnd();
                        //cmd.StandardInput.Close();
                        //cmd.WaitForExit();
                        //Console.Write("hey");




                        //Console.WriteLine(cmd.StandardOutput.ReadToEnd());

                        //    Console.WriteLine("got you");
                        //System.Diagnostics.Process process = new System.Diagnostics.Process();
                        //process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        //process.StartInfo.FileName = "cmd.exe";
                        //process.StartInfo.Arguments = "/c py ball_tracking.py";
                        //process.Start();
                        //output = process.StandardOutput.ToString();
                        

                        break;
                }

                ASCIIEncoding asen = new ASCIIEncoding();
              
                //Console.WriteLine(output);
                //if(output=="ball")
                //{
                //    s.Send(asen.GetBytes("threat"));
                //    Console.WriteLine("\nSent Acknowledgement");
                //    p.establishConnection("l");
                //}
               
                s.Close();


                /* clean up */
                goto m;
                s.Close();
                myList.Stop();
                Console.ReadLine();
            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

        private void establishConnection(String a)
        {
            serialPort1 = new SerialPort("COM3");
            serialPort1.BaudRate = 9600;

            serialPort1.Open();

            if (a == "dimAayush Makkad")
            { serialPort1.Write("a"); serialPort1.Close(); }
            if (a == "off fanAayush Makkad")
            { serialPort1.Write("b"); serialPort1.Close(); }
            if(a=="off fandAayush Makkad")
            { serialPort1.Write("p"); serialPort1.Close(); }
            if(a=="dimdAayush Makkad")
            { serialPort1.Write("o"); serialPort1.Close(); }

            serialPort1.Close();
            
          

        }


    }
}

