using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CCS.dialog
{
    /// <summary>
    /// Interaction logic for splash.xaml
    /// </summary>
    public partial class splash : Window
    {
        MainWindow parent;
        DispatcherTimer timer;
        int percent = 0;
        public splash(MainWindow root)
        {
            parent = root;
            InitializeComponent();

            parent.Visibility = Visibility.Hidden;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

        }


        private void timer_tick(object sender, EventArgs e)
        {

            if(percent<100)
            {
                percent += 20;
            }
            else
            {
                timer.IsEnabled = false;
                this.Visibility = Visibility.Hidden;
                parent.Visibility = Visibility.Visible;
                this.Close();
            }

            bar.Value = percent;

        }






    }
}
