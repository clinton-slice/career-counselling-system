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
    /// Interaction logic for db_disconnected.xaml
    /// </summary>
    public partial class db_disconnected : Window
    {
        MainWindow parent;
        DispatcherTimer timer;
        int delay_close = 3;

        public db_disconnected(MainWindow root)
        {
            parent = root;
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if(parent.Dbstate.Equals("Closed"))
            {
                state.Foreground = Brushes.OrangeRed;
                state.Text = "Disconnected";
                delay_close = 3;
            }

            if (parent.Dbstate.Equals("Connecting"))
            {
                state.Foreground = Brushes.Gray;
                state.Text = "Reconnecting...";
                delay_close = 3;
            }

            if (parent.Dbstate.Equals("Open"))
            {
                state.Foreground = Brushes.ForestGreen;
                state.Text = "Connected";
           
            }

            if(--delay_close==0)
            { parent.db_disconnect_dialog_close(); this.Close(); }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            parent.db_disconnect_dialog_close();
            this.Close();
        }
    }
}
