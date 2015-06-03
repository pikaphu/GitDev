using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TestSQLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            string sql2 = "insert into highscores (name, score) values ('Me', 9001)";
            SQLiteCommand command2 = new SQLiteCommand(sql2, m_dbConnection);
            command2.ExecuteNonQuery();

            string sql3 = "select * from highscores order by score desc";
            SQLiteCommand command3 = new SQLiteCommand(sql3, m_dbConnection);
            SQLiteDataReader reader = command3.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
        }

        //private SQLiteConnection sql_con;
        //private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
        //private DataSet DS = new DataSet();
        //private DataTable DT = new DataTable();

        //public void Mylitedata()
        //{
        //    SQLiteConnection.CreateFile("MyDatabase.db");
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //}

        //void SetConnection()
        //{
        //    sql_con = new SQLiteConnection
        //        ("Data Source=MyDatabase.db;Version=3;New=False;Compress=True;");
        //}

        //private void ExecuteQuery(string txtQuery)
        //{
        //    SetConnection();
        //    sql_con.Open();
        //    sql_cmd = sql_con.CreateCommand();
        //    sql_cmd.CommandText = txtQuery;
        //    sql_cmd.ExecuteNonQuery();
        //    sql_con.Close();
        //}

        //private void LoadData()
        //{
        //    SetConnection();
        //    sql_con.Open();
        //    sql_cmd = sql_con.CreateCommand();
        //    string CommandText = "select id, desc from mains";
        //    DB = new SQLiteDataAdapter(CommandText, sql_con);
        //    DS.Reset();
        //    DB.Fill(DS);
        //    DT = DS.Tables[0];
        //    //Grid.DataSource = DT;
        //    sql_con.Close();
        //}

        //private void Add()
        //{
        //    string txtSQLQuery = "insert into  mains (desc) values ('" + txtDesc.Text + "')";
        //    ExecuteQuery(txtSQLQuery);
        //}
    }
}
