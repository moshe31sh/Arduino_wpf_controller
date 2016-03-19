using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arduino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArduinoCom arduino;
        // Available baud rates
        private int[] baudrates = {
            4800,
            9600,
            14400,
            19200,
            28800,
            38400,
            57600,
            115200
        };

        public MainWindow()
        {
            InitializeComponent();
            init();
            arduino = new ArduinoCom();

        }
        private void init()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (String port in ports)
            {
                this.Ports.Items.Add(port);
            }
            foreach (int rate in baudrates)
            {
                this.Rates.Items.Add(rate);
            }

        }

        private void Dc_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.arduino.Port = Ports.SelectedItem.ToString();
            this.arduino.Rate = Int32.Parse(Rates.SelectedItem.ToString());
      


             this.arduino.connect();
        }

    }
}