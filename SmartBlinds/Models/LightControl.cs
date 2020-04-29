using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBlinds.Models
{
    public static class LightControl
    {
        public static bool lightControl { get; set; }
        public static int lightControlModel { get; set; }

        public static void lightController()
        {
            while(lightControl == true)
            {
                //will need to check photo gpio pin

            }
        }
    }
}
