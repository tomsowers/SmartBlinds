using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Device.Gpio;
using System.Device.I2c;
using System.Threading;

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

        //public string ComPort = "COM7";
        public bool UpdateControlMode()
        {
            bool worked = false;
            if(timeControl == true)
            {
                LightControl.lightControl = false;
                TimeControl.timeControl = true;
                TimeControl.openTime = openTime;
                TimeControl.closeTime = closeTime;
                Task tCon = new Task(() => TimeControl.TimeController());
                tCon.Start();
            }
            else if(lightControl == true)
            {
                TimeControl.timeControl = false;
                LightControl.lightControl = true;
                LightControl.lightControlModel = lightControlModel;
                Task lCon = new Task(() => LightControl.lightController());
                lCon.Start();
            }
            else
            {
                TimeControl.timeControl = false;
                LightControl.lightControl = false;
                //stop all automatic contorl loops
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

            if (open == true)
            {
                GPIO_Output.SendOpen();
            }
            else if (close == true)
            {
                GPIO_Output.SendClose();
            }
            else if (estop == true)
            {
                GPIO_Output.SendStop();
            }


            return worked;
        }
    }
}
