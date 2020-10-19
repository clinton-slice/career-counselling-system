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
using System.Data;
using System.Threading;
using System.Windows.Threading;
using WpfPageTransitions;
using MySql.Data.MySqlClient;

namespace CCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Database Connection details
        string db_server = "localhost";
        string db_username = "root";
        string db_password = "";
        string db_database = "ccs_db";

        //Encryption/Decryption key for password
        public string cipher_text = "#@>CCS,6102<.";

        DispatcherTimer timer;
        database db;

        public string Dbstate = "Closed";
        bool db_disc_dialog_open = false;

        string logged_id = "";
        string logged_category = ""; 


        public MainWindow()
        {
            InitializeComponent();
            new dialog.splash(this).Show();
            db = new database(this, db_server, db_username, db_password, db_database);

            show_get_started();
   
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();

           
        }

        public MySqlConnection getDbConnection()
        {
            return db.conn;
        }

        public void show_get_started()
        {

            main.get_started newPage = new main.get_started(this);
            transition.TransitionType = PageTransitionType.Slide;
            transition.ShowPage(newPage);
        }

        public void show_new_account(string email)
        {

            main.new_account newPage = new main.new_account(this,email);
            transition.TransitionType = PageTransitionType.Fade;
            transition.ShowPage(newPage);
        }

        public void show_admin()
        {

            main.admin_login newPage = new main.admin_login(this);
            transition.TransitionType = PageTransitionType.Fade;
            transition.ShowPage(newPage);
        }

        public void show_resume_account(string id,string category,string name,string pass)
        {

            main.resume_account newPage = new main.resume_account(this,id,category,name,pass);
            transition.TransitionType = PageTransitionType.Fade;
            transition.ShowPage(newPage);
        }

        public void setAdminLoggedID(string user)
        {
            logged_id = user;
        }

        private void timer_tick(object sender, EventArgs e)
        {

            if (!db.DbConnected)
            { Thread tid2 = new Thread(new ThreadStart(openDatabase)); tid2.Start(); }
            else
            { db.conn.Ping(); }

            GC.Collect();

            if (Dbstate.Equals("Connecting"))
            {
                
                if (!db_disc_dialog_open)
                {
                    db_disc_dialog_open = true;
                    new dialog.db_disconnected(this).Show();
                }
            }

        }

 
        /// <summary>
        /// Calls a function from class database for connection to database 
        /// </summary>
        private void openDatabase()
        {
            db.OpenDB();
        }
 

        /// <summary>
        /// Call a function in class database for all database queries
        /// </summary>
        /// <param name="_query"></param>
        /// <returns></returns>
        public DataTable query(string _query)
        {
            return db.queryDB(_query);
        }



        /// <summary>
        /// Get the state of connection to database
        /// </summary>
        /// <param name="state"></param>
        public void dbstate(string state)
        {
            Dbstate = state;
            
           
        }


        /// <summary>
        /// Removes all apostrophe symbol from a text in order to avoid sql injection
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public string clean(string original)
        {
            if (original != null)
                return System.Text.RegularExpressions.Regex.Replace(original, "'", "");
            else
                return null;
        }


        public void db_disconnect_dialog_close()
        {
            db_disc_dialog_open = false;
        }

        public void signin(string id, string category)
        {
            logged_id = id;
            logged_category = category;
        }


        public void signout()
        {
            logged_id = "";
            logged_category = "";
        }


        public string getloggedCategory()
        { return logged_category; }

        public string getloggedId()
        { return logged_id; }


        public string getloggedname()
        {
            DataTable qry=null;

            if(logged_category.Equals("user"))
                qry = query("select fullname from user where user_id=" + getloggedId());

            if (logged_category.Equals("counselor"))
                qry = query("select fullname from counselor where counselor_id=" + getloggedId());

            string name = "";
            if (qry.Rows.Count > 0)
            {
                DataRow rw = qry.Rows[0];
                name= rw[0].ToString();
            }
            return name;
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
