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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Windows.Threading;

namespace CCS.counselor
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : UserControl
    {
        MainWindow parent;
        user_form subparent;
        DispatcherTimer timer;


        class RequestHolder
        {

            public int count { set; get; }
            public string id { set; get; }
            public string fullname { set; get; }
            public string date { set; get; }

        }


        public home(MainWindow root, user_form subroot)
        {
            parent = root;
            subparent = subroot;
            InitializeComponent();
            nameLabel.Content = "Logged in: " + parent.getloggedname();
            timer_tick(null, null);
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();


            DataTable qry = parent.query("select conversation_id,date_added,(select fullname from user where user.user_id=conversation.user_id) as name from conversation where counselor_id is null");
            int count = 0;
            foreach (DataRow rw in qry.Rows)
            {
                RequestHolder request = new RequestHolder();
                request.count = ++count;
                request.date = rw["date_added"].ToString();
                request.fullname = rw["name"].ToString();
                request.id = rw["conversation_id"].ToString();
                listView.Items.Add(request);
            }


        }


        private void timer_tick(object sender, EventArgs e)
        {
            try
            {
                if (!parent.getloggedId().Equals(""))
                {
                    DataTable qry = parent.query("select (select count(*) from user),(select count(*) from conversation where counselor_id=" + parent.getloggedId() + ")");
                    DataRow rw = qry.Rows[0];
                    user_count.Text = rw[0].ToString();

                    DataTable qry2 = parent.query("select * from conversation where counselor_id=" + parent.getloggedId() + " group by user_id");
                    counseled_count.Text = qry2.Rows.Count.ToString();
                    conversation_count.Text = rw[1].ToString();

                }
                else timer.IsEnabled = false;
            }
            catch (Exception) { }
        }


        private void accept(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            RequestHolder request = b.CommandParameter as RequestHolder;
            string id=request.id;

            DataTable qry = parent.query("select * from conversation where conversation_id=" + id + " and counselor_id is null");
            if(qry.Rows.Count==1)
            {
                parent.query("update conversation set counselor_id="+parent.getloggedId()+" where conversation_id=" + id + " and counselor_id is null");
            }
            else
            { MessageBox.Show("This request is no longer available","CCS"); }

            listView.Items.Remove(request);

        }



        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            subparent.Close();
        }

    
        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            timer.IsEnabled = false;
            subparent.show_home();
        }

        private void career_label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            timer.IsEnabled = false;
            subparent.show_career();
        }

        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            timer.IsEnabled = false;
            subparent.show_conversation();
        }

        private void label3_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            timer.IsEnabled = false;
            subparent.show_settings();
        }








    }
}
