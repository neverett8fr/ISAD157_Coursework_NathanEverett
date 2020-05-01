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

        void connectMySQL(string connectionString)
        {
            string connstring = @"server=proj-mysql.uopnet.plymouth.ac.uk;userid=ISAD157_NEverett;password=ISAD157_22225597;database=isad157_neverett";
            connstring = connectionString;
            
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
            catch
            {
                MessageBox.Show("Error: table or database credentials incorrect");
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

                //MessageBox.Show(Path.GetDirectoryName(excelDocument.FileName).ToString());
                //MessageBox.Show(Path.GetFileName(excelDocument.FileName).ToString());
                //MessageBox.Show(excelDocument.FileName.ToString());
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

                    //return constructed DataTable table assuming nothing null / not valid
                    return tableOutput;
                }
                catch
                {
                    MessageBox.Show("Table is in wrong format!");
                }

            }
            //-------------------       

            //returns null if exceptions thrown / csv file not valid
            return null;
        }

        public string setupConnection()
        {
            Form FRMReturnConnection = new Form();
            RadioButton RDBSetupConnection = new RadioButton();
            RadioButton RDBUsePreset = new RadioButton();


            Button BTNSubmit = new Button();
            Button BTNCancel = new Button();

            RDBSetupConnection.Text = "Setup MySQL Connection";
            RDBUsePreset.Text = "Use Preset MySQL Connection";

            BTNSubmit.Text = "Submit";
            BTNCancel.Text = "Cancel";
            BTNSubmit.DialogResult = DialogResult.OK;
            BTNCancel.DialogResult = DialogResult.Cancel;

            RDBSetupConnection.SetBounds(9, 20, 372, 13);
            RDBUsePreset.SetBounds(9, 50, 372, 13);
            BTNSubmit.SetBounds(228, 72, 75, 23);
            BTNCancel.SetBounds(309, 72, 75, 23);

            RDBSetupConnection.AutoSize = true;
            RDBUsePreset.AutoSize = true;
            BTNSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BTNCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            FRMReturnConnection.ClientSize = new Size(396, 107);
            FRMReturnConnection.Controls.AddRange(new Control[] { RDBSetupConnection, RDBUsePreset, BTNSubmit, BTNCancel });

            FRMReturnConnection.FormBorderStyle = FormBorderStyle.FixedDialog;
            FRMReturnConnection.StartPosition = FormStartPosition.CenterScreen;
            FRMReturnConnection.MinimizeBox = false;
            FRMReturnConnection.MaximizeBox = false;
            FRMReturnConnection.AcceptButton = BTNSubmit;
            FRMReturnConnection.CancelButton = BTNCancel;

            


            DialogResult dialogResult = FRMReturnConnection.ShowDialog();

            if (dialogResult.ToString() == "OK" && RDBUsePreset.Checked == true)
            {
                return "server=proj-mysql.uopnet.plymouth.ac.uk;userid=ISAD157_NEverett;password=ISAD157_22225597;database=isad157_neverett";
            }
            else if (dialogResult.ToString() == "OK" && RDBSetupConnection.Checked == true)
            {                
                string setupConnectionEnterCredentials()
                {
                    Form FRMReturnInformation = new Form();
                    
                    Button BTNSubmitInformation = new Button();
                    Button BTNCancelInformation = new Button();

                    Label LBLServer = new Label();
                    Label LBLUserID = new Label();
                    Label LBLPassword = new Label();
                    Label LBLDatabase = new Label();

                    TextBox TXTServer = new TextBox();
                    TextBox TXTUserID = new TextBox();
                    TextBox TXTPassword = new TextBox();
                    TextBox TXTDatabase = new TextBox();

                    LBLServer.Text = "Server Name / Address: ";
                    LBLUserID.Text = "User ID: ";
                    LBLPassword.Text = "Password: ";
                    LBLDatabase.Text = "Database Name: ";
                    BTNSubmitInformation.Text = "Submit";
                    BTNCancelInformation.Text = "Cancel";

                    TXTPassword.UseSystemPasswordChar = true;

                    BTNSubmitInformation.SetBounds(228, 180, 75, 23);
                    BTNCancelInformation.SetBounds(309, 180, 75, 23);
                    LBLServer.SetBounds(9, 10, 200, 13);
                    LBLUserID.SetBounds(9, 50, 200, 13);
                    LBLPassword.SetBounds(9, 90, 200, 13);
                    LBLDatabase.SetBounds(9, 130, 200, 13);
                    TXTServer.SetBounds(9, 30, 372, 13);
                    TXTUserID.SetBounds(9, 70, 372, 13);
                    TXTPassword.SetBounds(9, 110, 372, 13);
                    TXTDatabase.SetBounds(9, 150, 372, 13);


                    BTNSubmitInformation.DialogResult = DialogResult.OK;
                    BTNCancelInformation.DialogResult = DialogResult.Cancel;


                    BTNSubmitInformation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                    BTNCancelInformation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                    FRMReturnInformation.ClientSize = new Size(396, 220);
                    FRMReturnInformation.Controls.AddRange(new Control[] { BTNSubmitInformation, BTNCancelInformation, LBLUserID, LBLServer, 
                    LBLPassword, LBLDatabase, TXTUserID, TXTServer, TXTPassword, TXTDatabase});

                    FRMReturnInformation.FormBorderStyle = FormBorderStyle.FixedDialog;
                    FRMReturnInformation.StartPosition = FormStartPosition.CenterScreen;
                    FRMReturnInformation.MinimizeBox = false;
                    FRMReturnInformation.MaximizeBox = false;
                    FRMReturnInformation.AcceptButton = BTNSubmitInformation;
                    FRMReturnInformation.CancelButton = BTNCancelInformation;


                    DialogResult dialogCredentials = FRMReturnInformation.ShowDialog();

                    if (dialogCredentials.ToString() == "OK")
                    {
                        string connectionStringConstructor =
                            "server=" + TXTServer.Text +
                            ";userid=" + TXTUserID.Text + ";password=" + TXTPassword.Text + ";database=" + TXTDatabase.Text;
                                                
                        return connectionStringConstructor;
                    }



                        return null;
                }

                return setupConnectionEnterCredentials();
            }

            return null;


        }
        private void BTNSelectDataSource_Click(object sender, EventArgs e)
        {
            //OFDLoadExcel.ShowDialog();
            //DGVTableview.DataSource = readExcelTable(OFDLoadExcel);
            //connectMySQL();

            connectMySQL(setupConnection());
            

        }
    }
}
