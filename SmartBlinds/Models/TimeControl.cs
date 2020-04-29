using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace SmartBlinds.Models
{
    public static class TimeControl
    {
        public static bool timeControl { get; set; }
        public static string openTime { get; set; }
        public static string closeTime { get; set; }


        public static void TimeController()
        {

            while (timeControl == true)
            {
                //run as long as time control is set to true
                string time = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");
                if (time == openTime)
                {
                    GPIO_Output.SendOpen();
                }
                else if (time == closeTime)
                {
                    //set close pin to high
                    GPIO_Output.SendClose();
                }

                Thread.Sleep(5000); //pause for 5 seconds so this isnt running too fast

            }

            Debug.Print("exit time control");
        }
    }
}
