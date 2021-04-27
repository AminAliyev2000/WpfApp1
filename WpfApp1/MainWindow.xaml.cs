using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Key { get; set; } = "ACO31HKyB0ikIMujth9b~CQXmpU6iLZ4LrLtmTIZYBA~ArHOu4vtH1k1lg3mtR4L9gLX3iF4J6GRtpT4aZbtsiX5QFNSJBDUwd-6Z0ROZ9mn";
        public ApplicationIdCredentialsProvider Provider { get; set; }
        public MainWindow()
        {
            this.DataContext = this;
            Provider = new ApplicationIdCredentialsProvider(Key);

            InitializeComponent();
            GetBuses();
            //Timer = new Timer();
            //Timer.Interval = 1000;
            //Timer.Elapsed += Timer_Elapsed;
            //Timer.Start();
        }

        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Dispatcher.Invoke(() =>
        //    {
        //        lbl1.Content = DateTime.Now.ToLongTimeString();
        //    }
        //    );
           
        //}

        public Timer Timer { get; set; }
        public void GetBuses()
        {
            var client = new HttpClient();
            var link = "https://www.bakubus.az/az/ajax/apiNew1";
            dynamic buses = JsonConvert.DeserializeObject(client.GetAsync(link).Result.Content.ReadAsStringAsync().Result);
            foreach(var item in buses.BUS)
            {
                dynamic bus = item["@attributes"];
                string name = bus["DRIVER_NAME"];
            }
        }
    }
}
