using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace Arduino
{
    class ArduinoCom
    {
        private SerialPort currentPort;
        private String port;
        private int rate;
         
        /// <summary>
        /// Property
        /// </summary>
        public String Port
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value)){
                    this.port = value;
                }
            }
            get{
                return port;
            }
        }

        public int Rate
        {
            set
            {
                if (value > 0)
                {
                    this.rate = value;
                }
                else
                {
                    this.rate = 0;
                }
            }
            get
            {
                return this.rate;
            }
        }

        public void connect()
        {
            this.currentPort = new SerialPort();
            this.currentPort.PortName = Port;
            this.currentPort.BaudRate = Rate;
            try
            {
                this.currentPort.Open();
                this.currentPort.Write("3");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
            }
            finally
            {
                this.currentPort.Close();
            }
        }        

    }
}
