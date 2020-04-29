﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Device.Gpio;
using System.Threading;
using System.Diagnostics;

namespace SmartBlinds.Models
{
    public static class GPIO_Output
    {
        static GpioController controller = new GpioController();
        public static bool setup = false;

        public static void SetupPins()
        {
            controller.OpenPin(12, PinMode.Output);
            controller.OpenPin(16, PinMode.Output);
            controller.OpenPin(20, PinMode.Output);
            setup = true;
        }
        public static void SendOpen()
        {
            //set pin to high
            if(setup == false)
            {
                SetupPins();
            }

            
            controller.Write(12, PinValue.Low);
            Thread.Sleep(500);
            controller.Write(12, PinValue.High);
            Debug.Print("open");
            Console.WriteLine("open");
        }
        public static void SendClose()
        {
            //set pin to high
            if (setup == false)
            {
                SetupPins();
            }
            controller.Write(16, PinValue.Low);
            Thread.Sleep(500);
            controller.Write(16, PinValue.High);
            Debug.Print("Close");
            Console.WriteLine("close");
        }
        public static void SendStop()
        {
            //set pin to high
            if (setup == false)
            {
                SetupPins();
            }
            controller.Write(20, PinValue.Low);
            Thread.Sleep(500);
            controller.Write(20, PinValue.High);
            Debug.Print("stop");
            Console.WriteLine("stop");
        }
        public static int GetPhoto()
        {
            //get pin
            int light = 0;
            if (setup == false)
            {
                SetupPins();
            }
            /*
            controller.OpenPin(21, PinMode.Output);
            PinValue pinValue =  controller.Read(21);
            if(pinValue == PinValue.High)
            {
                //light
                light = 1;
            }
            else
            {
                //dark
                light = 0;
            }
            */
            Console.WriteLine("read photo");
            return light;
        }
    }
}
