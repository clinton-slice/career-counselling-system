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
using MySql.Data.MySqlClient;
using System.Windows.Threading;

namespace CCS.user
{
    /// <summary>
    /// Interaction logic for conversation.xaml
    /// </summary>
    public partial class conversation : UserControl
    {
        MainWindow parent;
        user_form subparent;
        int active_ = 0;
            
        DispatcherTimer timer;
        public conversation(MainWindow root, user_form subroot)
        {
            parent = root;
            subparent = subroot;
            InitializeComponent();
            loggedName.Content = "Logged in: " + parent.getloggedname();


            DataTable qry = parent.query("select *,(select fullname from counselor where counselor.counselor_id=conversation.counselor_id) as counselor_name from conversation where user_id=" + parent.getloggedId()+" ");
            int count = 0;

            foreach (DataRow rw in qry.Rows)
            {
                count++;

             
                StackPanel p1 = new StackPanel();
                p1.Orientation = Orientation.Vertical;
                p1.Name= "sp_" + rw["conversation_id"];


                StackPanel p2 = new StackPanel();
                p2.Orientation = Orientation.Horizontal;
                Label lb = new Label();
                lb.Content = "Conversation " + count;
                p2.Children.Add(lb);


                Image img_ = new Image();
                img_.Width = 20;
                img_.Height = 20;

                DataTable qry2 = parent.query("select count(*) from counselor_message where counselor_message.read=0 and conversation_id=" + rw["conversation_id"]);
                DataRow rw2 = qry2.Rows[0];
                if (Int32.Parse(rw2[0].ToString()) > 0)
                {
                   
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri("pack://application:,,,/CCS;component/Resources/inbox.png");
                    img.EndInit();

                    img_.Source = img;
                  
                }

                p2.Children.Add(img_);




                p1.Children.Add(p2);

                Label lb2 = new Label();
                lb2.Content = ":> " + rw["counselor_name"];
                lb2.FontWeight = FontWeights.Bold;

                p1.Children.Add(lb2);





                listBox.Items.Add(p1);
            }


            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();


        }


        private void timer_tick(object sender, EventArgs e)
        {
            timer.IsEnabled = false;
            if (!parent.getloggedId().Equals(""))
            {
                DataTable qry = parent.query("select *,(select fullname from counselor where counselor.counselor_id=conversation.counselor_id) as counselor_name,(select count(*) from counselor_message where counselor_message.read=0 and counselor_message.conversation_id=conversation.conversation_id ) as new_m from conversation where user_id=" + parent.getloggedId() + " ");
                int count = 0;

                foreach (DataRow rw in qry.Rows)
                {
                    count++;
                    bool found = false;
                    foreach (Object itm in listBox.Items)
                    {
                        StackPanel p1 = itm as StackPanel;
                        if (p1.Name.Equals("sp_" + rw["conversation_id"]))
                        {
                            found = true;

                            Label lab = p1.Children[1] as Label;
                            (lab).Content = ":> "+ rw["counselor_name"].ToString();

                            if (Int32.Parse(rw["new_m"].ToString()) > 0)
                            {
                              
                                if (Int32.Parse(rw["conversation_id"].ToString()) != active_)
                                {
                                    BitmapImage img = new BitmapImage();
                                    img.BeginInit();
                                    img.UriSource = new Uri("pack://application:,,,/CCS;component/Resources/inbox.png");
                                    img.EndInit();
                                    StackPanel p2 = p1.Children[0] as StackPanel;
                                    if (((Image)p2.Children[1]).Source==null)
                                    {
                                        System.Media.SystemSounds.Asterisk.Play();
                                    }

                                    ((Image)p2.Children[1]).Source = img;
                                }
                                else
                                { System.Media.SystemSounds.Asterisk.Play(); load(); }
                            }
                            else
                            {
                                StackPanel p2 = p1.Children[0] as StackPanel;
                                ((Image)p2.Children[1]).Source = null;
                            }


                            break;
                        }

                    }

                    if (!found)
                    {
                        new_conversation(Int32.Parse(rw["conversation_id"].ToString()), count, Int32.Parse(rw["new_m"].ToString()), rw["counselor_name"].ToString());
                    }


                }

                timer.IsEnabled = true;
            }

               
        }



        public void new_conversation(int id,int count,int unread,string name)
        {
            StackPanel p1 = new StackPanel();
            p1.Orientation = Orientation.Vertical;
            p1.Name = "sp_" +id;


            StackPanel p2 = new StackPanel();
            p2.Orientation = Orientation.Horizontal;
            Label lb = new Label();
            lb.Content = "Conversation " + count;
            p2.Children.Add(lb);


            Image img_ = new Image();
            img_.Width = 20;
            img_.Height = 20;

              if (unread > 0)
             {
                System.Media.SystemSounds.Asterisk.Play();
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri("pack://application:,,,/CCS;component/Resources/inbox.png");
                img.EndInit();

                img_.Source = img;

            }

            p2.Children.Add(img_);




            p1.Children.Add(p2);

            Label lb2 = new Label();
            lb2.Content = ":> " + name;
            lb2.FontWeight = FontWeights.Bold;

            p1.Children.Add(lb2);





            listBox.Items.Add(p1);
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

        private void send_button_Click(object sender, RoutedEventArgs e)
        {

            TextRange tr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            if(!tr.Text.Trim().Equals(""))
            {

                MySqlCommand comm = new MySqlCommand("insert into user_message (conversation_id,content,user_message.read,date_time_sent) values(" + active_+",@content,0,now())", parent.getDbConnection());
                comm.Parameters.Add("@content", tr.Text);
                comm.ExecuteNonQuery();

                load();
                richTextBox.Document.Blocks.Clear();
            }

        }

        private void result_button_Click(object sender, RoutedEventArgs e)
        {
            DataTable qry = parent.query("select assessment_id from conversation where conversation_id=" + active_);
            if (qry.Rows.Count > 0)
            {
                DataRow rw = qry.Rows[0];
                int active_assement = Int32.Parse((rw["assessment_id"]).ToString());
                new dialog.full_result(parent, active_assement).Show();
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            active_ = 0;
           

            if (listBox.SelectedItem != null)
            {

                StackPanel pn = listBox.SelectedItem as StackPanel;
                active_ = Int32.Parse(pn.Name.Split(new Char[] { '_' })[1]);
                send_button.IsEnabled = result_button.IsEnabled = true;
                load();

            }
            else
            { send_button.IsEnabled = result_button.IsEnabled = false;  }
        }
        

        public void load()
        {
            listBox1.Items.Clear();
            parent.query("update counselor_message set counselor_message.read=1 where conversation_id=" + active_);
            DataTable qry = parent.query("select *,'user' as cat,'You' as name from user_message where conversation_id=" + active_ + " union select *,'counselor' as cat,(select fullname from counselor where counselor.counselor_id=(select counselor_id from conversation where conversation.conversation_id=" + active_ + ")) as name from counselor_message where conversation_id=" + active_ + " order by date_time_sent");
            message_count.Content = "Messages: " + qry.Rows.Count;
            foreach (DataRow rw in qry.Rows)
            {

                StackPanel p1 = new StackPanel();
                p1.Orientation = Orientation.Vertical;
               

                if (rw["cat"].ToString().Equals("counselor"))
                {
                    p1.Background = Brushes.WhiteSmoke;
                
                }


                StackPanel p2 = new StackPanel();
                p2.Orientation = Orientation.Horizontal;

                Label lb1 = new Label();
                lb1.Content = rw["name"].ToString();
                lb1.FontWeight = FontWeights.Bold;


                Label lb2 = new Label();
                lb2.Content = rw["date_time_sent"].ToString();
                lb2.FontWeight = FontWeights.ExtraLight;


                p2.Children.Add(lb1);
                p2.Children.Add(lb2);

                p1.Children.Add(p2);


                StackPanel p3 = new StackPanel();
                p3.Orientation = Orientation.Horizontal;
                TextBlock tb = new TextBlock();
                tb.Text = rw["content"].ToString();
                tb.TextWrapping = TextWrapping.Wrap;
                tb.Width = 540;
                p3.Children.Add(tb);
                p1.Children.Add(p3);

                Label space = new Label();
                space.Height = 10;
                p1.Children.Add(space);


                listBox1.Items.Add(p1);
 
                listBox1.ScrollIntoView(p1);
            }
           
        }









    }
}
