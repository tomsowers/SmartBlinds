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
    /// Used to recieve the JSON data and call the SQL commands 
    /// </summary>
    public class SerialCon
    {
        public int blindState { get; set; }
        public int controlMode { get; set; }
        public string openTime { get; set; }
        public string closeTime { get; set; }
     
        public bool UpdateControlMode()
        {
            bool worked = false;
            try
            {
                SQLConnection.UpdateControl(this);
                worked = true;
            }
            catch(Exception ex)
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
            try
            {
                SQLConnection.SendCommand(this);
                worked = true;
            }
            catch(Exception e)
            {

            }
            

            return worked;
        }
    }
}
