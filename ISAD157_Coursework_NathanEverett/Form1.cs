using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

using System.Text.RegularExpressions;



namespace ISAD157_Coursework_NathanEverett
{
    public partial class Form1 : Form
    {
        DataSet dataSetLocal;

        public Form1()
        {
            InitializeComponent();
        }

        DataSet connectMySQL(string connectionString)
        {

            MySqlConnection connection = null;

            DataSet output;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();


                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';"; //this query returns the names of the tables in use and puts it's data into a table
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                output = new DataSet();
                dataAdapter.Fill(output, "table_names");


                for (int i = 0; i <= output.Tables["table_names"].Rows.Count - 1; i++) //repeat for amount of tables
                {
                    query = "SELECT * FROM " + output.Tables["table_names"].Rows[i][0] + ";"; //this creates a query which will return all the tables in the database
                    dataAdapter = new MySqlDataAdapter(query, connection);
                    dataAdapter.Fill(output, output.Tables["table_names"].Rows[i][0].ToString()); //this populates the DataSet variable with all the tables
                    CMBTableSelect.Items.Add(output.Tables["table_names"].Rows[i][0].ToString());
                }






            }
            catch
            {
                MessageBox.Show("Error: table or database credentials incorrect");
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return output;
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
        {   //below sets up form stuff -- more complicated than needed but works
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
                string setupConnectionEnterCredentials() //creates form which returns a string to whatever calls it
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

            dataSetLocal = connectMySQL(setupConnection());
            for (int i = 0; i <= CMBTableSelect.Items.Count - 1; i++) {
                CMBTableSelectQuery.Items.Add(CMBTableSelect.Items[i]);
            }
            MessageBox.Show("Database Loaded In" + Environment.NewLine + "Use Dropdown To Select Table" + Environment.NewLine + "Click Cells To Populate User Profile");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DGVTableview.DataSource = dataSetLocal.Tables[CMBTableSelect.Text];

        }



        private void BTNLoadCSV_Click(object sender, EventArgs e)
        {
            OFDLoadExcel.ShowDialog(); //opens dialog box which allows selection of local file
            DGVTableview.DataSource = readExcelTable(OFDLoadExcel); //sets datagridview as the result of function (imports OFD to function to use)
        }


        private void BTNQuerySubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string expression = CMBQueryColumn.Text + " " + CMBQueryCondition.Text + " " + TXTQueryCondition.Text;
                DGVQueryTable.DataSource = dataSetLocal.Tables[CMBTableSelectQuery.Text].Select(expression).CopyToDataTable(); //try as if integer
            }
            catch
            {
                try
                {
                    string expression = CMBQueryColumn.Text + " " + CMBQueryCondition.Text + " '" + TXTQueryCondition.Text + "'";
                    DGVQueryTable.DataSource = dataSetLocal.Tables[CMBTableSelectQuery.Text].Select(expression).CopyToDataTable(); //if integer fails, try as string
                }
                catch
                {
                    //MessageBox.Show("Error message");
                }
            }
        }

        private void CMBTableSelectQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            CMBQueryColumn.Items.Clear();
            for (int i = 0; i <= dataSetLocal.Tables[CMBTableSelectQuery.Text].Columns.Count - 1; i++)
            {
                CMBQueryColumn.Items.Add(dataSetLocal.Tables[CMBTableSelectQuery.Text].Columns[i].ColumnName); //adds column names to combobox from table selected in other combobox
            }
        }


        




        private void DGVTableview_CellContentClick(object sender, DataGridViewCellEventArgs e) //should be able to click on any cell in any table hopefully
        {

            try
            {
                int userID = 0;
                string firstName;
                string lastName;
                string hometown;
                string gender;
                string relationshipStatus;
                string currentTown;
                DataSet workplaces = new DataSet();
                DataSet schools = new DataSet();

                for (int i = 0; i <= DGVTableview.Columns.Count - 1; i++)
                {
                    if (DGVTableview.Columns[i].Name == "user_id" | DGVTableview.Columns[i].Name == "sender_id") //most tables have user_id as foreign key, sender_id refers to user_id so can use it as user_id
                    {   //this bit finds the user_id of the row selected to use later
                        userID = Convert.ToInt16(DGVTableview.Rows[e.RowIndex].Cells[i].Value);

                        break;
                    }
                }

                //probably would make more sense to search the localTable using c# as it's already downloaded but will use mysql to get from the server as that's what this project is about;


                MySqlConnection connection = new MySqlConnection(setupConnection()); //defines a mySqlConnection object by getting data from function 
                connection.Open(); 

                string query = "SELECT name_first FROM table_user WHERE user_id = " + userID.ToString() + ";"; //this query returns first name from the table_user provided it matches the user_id
                MySqlCommand sqlCommand = new MySqlCommand(query, connection); //executes query made earlier at connection specified earlier
                firstName = Convert.ToString(sqlCommand.ExecuteScalar());

                query = "SELECT name_last FROM table_user WHERE user_id = " + userID.ToString() + ";";
                sqlCommand = new MySqlCommand(query, connection);
                lastName = Convert.ToString(sqlCommand.ExecuteScalar());

                query = "SELECT hometown FROM table_user WHERE user_id = " + userID.ToString() + ";";
                sqlCommand = new MySqlCommand(query, connection);
                hometown = Convert.ToString(sqlCommand.ExecuteScalar());

                query = "SELECT gender FROM table_user WHERE user_id = " + userID.ToString() + ";";
                sqlCommand = new MySqlCommand(query, connection);
                gender = Convert.ToString(sqlCommand.ExecuteScalar());

                query = "SELECT statusRelationship FROM table_user WHERE user_id = " + userID.ToString() + ";";
                sqlCommand = new MySqlCommand(query, connection);
                relationshipStatus = Convert.ToString(sqlCommand.ExecuteScalar());

                query = "SELECT currentTown FROM table_user WHERE user_id = " + userID.ToString() + ";";
                sqlCommand = new MySqlCommand(query, connection);
                currentTown = Convert.ToString(sqlCommand.ExecuteScalar());



                query = "SELECT workplace_name FROM table_workplace WHERE user_id = " + userID.ToString() + ";"; //populates dataset with all workplace names with user_id as foreign key
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                dataAdapter.Fill(workplaces, "table_workplaces");

                query = "SELECT school_name FROM table_school WHERE user_id = " + userID.ToString() + ";";
                dataAdapter = new MySqlDataAdapter(query, connection);
                dataAdapter.Fill(schools, "table_school");

                connection.Close();

                string schoolWorkplaceString = "";
                schoolWorkplaceString += "Workplaces: " + Environment.NewLine;
                for (int i = 0; i <= workplaces.Tables["table_workplaces"].Rows.Count - 1; i++)
                {
                    schoolWorkplaceString += " -- " + workplaces.Tables["table_workplaces"].Rows[i][0].ToString() + Environment.NewLine;
                }
                schoolWorkplaceString += Environment.NewLine + "Schools: " + Environment.NewLine;
                for (int i = 0; i <= schools.Tables["table_school"].Rows.Count - 1; i++)
                {
                    schoolWorkplaceString += " -- " + schools.Tables["table_school"].Rows[i][0].ToString() + Environment.NewLine;
                }


                RTBProfile.Text = "User Info" + Environment.NewLine + "User ID: " + userID + Environment.NewLine + "Name: " + firstName + " " + lastName +
                    Environment.NewLine + "Hometown: " + hometown + Environment.NewLine + "Gender: " + gender +
                    Environment.NewLine + "Relationship Status: " + relationshipStatus + Environment.NewLine + "Current Town: " + currentTown +
                    Environment.NewLine + Environment.NewLine + schoolWorkplaceString; 




                Regex regExp = new Regex("Workplaces|Schools|User Info"); //very basic Regex statement checking if any of text matches words in regex
                foreach (Match match in regExp.Matches(RTBProfile.Text))
                {
                    RTBProfile.Select(match.Index, match.Length);
                    RTBProfile.SelectionFont = new Font("New Times Roman", 15); // if regex matches -- formats the text

                }
            }
            catch { }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
