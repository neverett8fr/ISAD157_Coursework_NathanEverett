using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ISAD157_Coursework_NathanEverett
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void connectMySQL()
        {
            string connstring = @"server=proj-mysql.uopnet.plymouth.ac.uk;userid=ISAD157_NEverett;password=ISAD157_22225597;database=isad157_neverett";
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(connstring);
                connection.Open();

                string query = "SELECT * FROM table_user;";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "table_user");
                DataTable dataTable = dataSet.Tables["table_user"];

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {                        
                        MessageBox.Show(row[col] + "\t");
                    }

                    MessageBox.Show("\n");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: {0}", e.ToString());
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }
        private void BTNSelectDataSource_Click(object sender, EventArgs e)
        {
            connectMySQL();
            
        }
    }
}
