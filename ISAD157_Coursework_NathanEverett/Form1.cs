using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

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

                DGVTableview.DataSource = dataTable;

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

        DataTable readExcelTable(OpenFileDialog excelDocument)
        {
            DataTable tableOutput; //the table returned from the function

            //setup excel connection |
            OleDbConnection dbConnection = null;                 
            if (Path.GetExtension(excelDocument.FileName) == ".csv") //checks it's correct / expected format
            {
                //creates a string used to setup connection
                //HDR = yes -- first row is header

                MessageBox.Show(Path.GetDirectoryName(excelDocument.FileName).ToString());
                MessageBox.Show(Path.GetFileName(excelDocument.FileName).ToString());
                MessageBox.Show(excelDocument.FileName.ToString());
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + Path.GetDirectoryName(excelDocument.FileName) + ";Extended Properties=\"Text;HDR=Yes;IMEX=1\"";

                dbConnection = new OleDbConnection(connectionString);
            }
            else
            {
                MessageBox.Show("File needs to be '.csv.' format");
            }
            //----------------


            //read excel document //convert excel document to DataTable class
            if (dbConnection != null)
            {
                try
                {
                    //below constructs sql statement to take data from the csv file
                    string sqlCommand = @"SELECT * FROM [" + Path.GetFileName(excelDocument.FileName) + "]";

                    OleDbCommand dbCommand = new OleDbCommand(sqlCommand, dbConnection);
                    OleDbDataAdapter dbAdapter = new OleDbDataAdapter(dbCommand);

                    tableOutput = new DataTable();
                    tableOutput.Locale = CultureInfo.CurrentCulture;
                    dbAdapter.Fill(tableOutput);


                    return tableOutput;
                }
                catch
                {
                    MessageBox.Show("Table is in wrong format!");
                }

            }
            //-------------------

            





            //return constructed DataTable table
            return null;
        }
        private void BTNSelectDataSource_Click(object sender, EventArgs e)
        {
            OFDLoadExcel.ShowDialog();
            DGVTableview.DataSource = readExcelTable(OFDLoadExcel);
            //connectMySQL();
            
        }
    }
}
