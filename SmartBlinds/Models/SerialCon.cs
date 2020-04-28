using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace SmartBlinds.Models
{
    

    /// <summary>
    /// Used to connect to propellor and transmit data
    /// </summary>
    public class SerialCon
    {
        public bool timeControl { get; set; }
        public bool lightControl { get; set; }
        public string openTime { get; set; }
        public string closeTime { get; set; }
        public int lightControlModel { get; set; }
        public string curTime { get; set; }
        public bool open { get; set; }
        public bool close { get; set; }
        public bool estop { get; set; }

        public string ComPort = "COM7";


        public void Test()
        {
            string test1 = "T";
            string test2 = "Checking";

            

            byte[] test1B = System.Text.Encoding.UTF8.GetBytes(test1);
            byte[] test2B = System.Text.Encoding.UTF8.GetBytes(test2);

            //SerialPort port = new SerialPort(this.ComPort, 9600, Parity.None, 8, StopBits.One);
            SerialPort port = new SerialPort(this.ComPort);
            port.Open();
            port.Write("T");
            //port.Write(test1B, 0, test1B.Length);

            //port.Write(test2B, 0, test2B.Length);

            port.Close();

        }
        public bool UpdateControlMode()
        {
            bool worked = false;

            try
            {
                //build strings to send
                string time = "Time;"+DateTime.Now.ToString("HH:mm:ss");
                
                string lightControl = "LightControl;" + this.lightControl.ToString();
                string timeControl = "TimeControl;" + this.timeControl.ToString();

                string lightCMode = "";
                if(this.lightControl == true)
                {
                    lightCMode = "LightMode;" + this.lightControlModel.ToString();
                    //0 is open during day and 1 is open at night
                }

                string timeCOpen = "";
                string timeCClose = "";
                if(this.timeControl == true)
                {
                    timeCOpen = "OpenTime;" + this.openTime;
                    timeCClose = "CloseTime;" + this.closeTime;
                }

                SerialPort port = new SerialPort(this.ComPort, 115200, Parity.None, 8, StopBits.One);
                //need to convert info to byte arrays
                byte[] timeB = System.Text.Encoding.UTF8.GetBytes(time);
                port.Open();
                port.Write(timeB, 0, timeB.Length);

                byte[] timeControlB = System.Text.Encoding.UTF8.GetBytes(timeControl);
                port.Write(timeControlB, 0, timeControlB.Length);
                if(this.timeControl == true)
                {
                    //also send opena close time
                    byte[] openB = System.Text.Encoding.UTF8.GetBytes(timeCOpen);
                    byte[] closeB = System.Text.Encoding.UTF8.GetBytes(timeCClose);
                    port.Write(openB, 0, openB.Length);
                    port.Write(openB, 0, closeB.Length);
                }

                byte[] lightControlB = System.Text.Encoding.UTF8.GetBytes(lightControl);
                port.Write(lightControlB, 0, lightControlB.Length);
                if(this.lightControl == true)
                {
                    byte[] modeB = System.Text.Encoding.UTF8.GetBytes(lightCMode);
                    port.Write(modeB, 0, modeB.Length);
                }
                //add more write statements to send the rest of the data
                port.Close();
                worked = true;
            }
            catch(Exception e)
            {

            }

            return worked;
        }
        /// <summary>
        /// Used to just send a command, ignore the control mode booleans
        /// </summary>
        /// <returns></returns>
        public bool SendCommand()
        {
            bool worked = false;



            return worked;
        }
    }
}
