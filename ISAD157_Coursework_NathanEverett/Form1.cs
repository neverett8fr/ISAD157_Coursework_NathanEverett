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
using System.Runtime.InteropServices;
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
        DataSet dataSetLocal;
        DataTable newTableData;
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

                //DGVTableview.DataSource = dataSetLocal.Tables["table_names"];

                for (int i = 0; i <= output.Tables["table_names"].Rows.Count - 1; i++) //repeat for amount of tables
                {
                    query = "SELECT * FROM " + output.Tables["table_names"].Rows[i][0] +  ";"; //this creates a query which will return all the tables in the database
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
            

            dataSetLocal = connectMySQL(setupConnection());       

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = dataSetLocal.Tables[CMBTableSelect.Text];
            DGVTableview.DataSource = dataTable;

        }



        void uploadTable(DataTable uploadTable)
        {
            //get info to upload to a server and any existing tables / info
            string connectionString = setupConnection();
            DataSet oldDataSet = connectMySQL(connectionString);
            //--------------

            //choose which table to upload to from the existing tables;
            string chooseUploadTableLocation()
            {
                Form FRMUploadLocation = new Form();

                Button BTNSubmitInformation = new Button();
                Button BTNCancelInformation = new Button();

                Label LBLText = new Label();
                ComboBox CMBTables = new ComboBox();


                //choose which table to upload to from exising tables;
                for (int i = 0; i <= oldDataSet.Tables["table_names"].Rows.Count - 1; i++)
                {
                    CMBTables.Items.Add(oldDataSet.Tables["table_names"].Rows[i][0]);
                }

                LBLText.Text = "Please select which table to upload to: ";                
                BTNSubmitInformation.Text = "Submit";
                BTNCancelInformation.Text = "Cancel";

                BTNSubmitInformation.SetBounds(228, 80, 75, 23);
                BTNCancelInformation.SetBounds(309, 80, 75, 23);
                LBLText.SetBounds(9, 10, 200, 13);       
                CMBTables.SetBounds(9, 25, 200, 13);

                BTNSubmitInformation.DialogResult = DialogResult.OK;
                BTNCancelInformation.DialogResult = DialogResult.Cancel;

                BTNSubmitInformation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                BTNCancelInformation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                FRMUploadLocation.ClientSize = new Size(396, 100);
                FRMUploadLocation.Controls.AddRange(new Control[] { BTNSubmitInformation, BTNCancelInformation, LBLText, CMBTables});

                FRMUploadLocation.FormBorderStyle = FormBorderStyle.FixedDialog;
                FRMUploadLocation.StartPosition = FormStartPosition.CenterScreen;
                FRMUploadLocation.MinimizeBox = false;
                FRMUploadLocation.MaximizeBox = false;
                FRMUploadLocation.AcceptButton = BTNSubmitInformation;
                FRMUploadLocation.CancelButton = BTNCancelInformation;


                DialogResult output = FRMUploadLocation.ShowDialog();

                if (output.ToString() == "OK")
                {
                    string tableOutput = CMBTables.Text;

                    return tableOutput;
                }



                return null;
            }
            string uploadTableLocation = chooseUploadTableLocation(); //calls function which returns which table the file should be uploaded to on user input
            //----------------------



            //check headers same -- convert if not
            bool sameHeaders = true; //excel document has different names for headers and in different orders as the database tables
            for (int i = 0; i <= uploadTable.Columns.Count - 1; i++)
            {                
                if (uploadTable.Columns[i].ColumnName != oldDataSet.Tables[uploadTableLocation].Columns[i].ColumnName)
                {                    
                    sameHeaders = false;
                }
            }

            string[] queryArray = new string[0];
            if (sameHeaders == false) //if false create queries / convert for all entries // if false its from the csv file
            {               
                Random rnd = new Random();
                for (int i = 0; i <= uploadTable.Rows.Count - 1; i++)
                {
                    int randomNum = rnd.Next(1, 99999999);
                    switch (uploadTableLocation)
                    {
                        case "table_user":
                            //1st column both user_id = UserID
                            //newRow["user_id"] = "Smith";
                            //newRow["name_first"] = "Smith";
                            //newRow["name_last"] = "Smith";
                            //newRow["hometown"] = "Smith";
                            //newRow["gender"] = "Smith";
                            //newRow["statusRelationship"] = "Smith";
                            //newRow["currentTown"] = "Smith";
                            //newRow["workplace_id"] = "Smith";
                            //newRow["school_id"] = "Smith";


                            //Create query then resizes and adds it to the array of queries
                            Array.Resize(ref queryArray, queryArray.Length + 1);
                            queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + @"(user_id, name_first, name_last, hometown, gender, statusRelationship, currentTown, workplace_id, school_id) "+
                                @"VALUES("+ uploadTable.Rows[i][0] +@", '"+ uploadTable.Rows[i][1]+@"', '"+ uploadTable.Rows[i][2]+@"', '"+
                                uploadTable.Rows[i][4]+@"', '" + uploadTable.Rows[i][3] + @"', '" + "Unknown" + @"', '" + uploadTable.Rows[i][5] + @"', 0, 0"+ ");";
                            //--------------------------------------------------------------


                            break;
                        case "table_workplace"://requires the user_id to exist in the user table
                            //this will have two queries -- one to create the new workplace, one to replace the workplace field in 'table_user' with foreign key
                            Array.Resize(ref queryArray, queryArray.Length + 1); //first query to create the workplace query
                            queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(workplace_id, workplace_name, employment_date_start, employment_date_end) " +
                                "VALUES(" + randomNum + ", '" + uploadTable.Rows[i][1] + "', '" + "0001/01/01" + "', '" + "0001/01/01" + "'" + ");";
                            
                            //second query to replace the field of user where id = specified
                            Array.Resize(ref queryArray, queryArray.Length + 1);
                            queryArray[queryArray.Length - 1] = "UPDATE table_user" + " SET workplace_id = " + randomNum + " WHERE user_id = " + uploadTable.Rows[i][0]+ ");";


                            break;
                        case "table_school"://requires the user_id to exist in the user table
                            Array.Resize(ref queryArray, queryArray.Length + 1); //first query to create the workplace query
                            queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(school_id, school_name, school_date_start, school_date_end) " +
                                "VALUES(" + randomNum + ", '" + uploadTable.Rows[i][1] + "', '" + "0001/01/01" + "', '" + "0001/01/01" + "'" + ");";
                                                        
                            //second query to replace the field of user where id = specified
                            Array.Resize(ref queryArray, queryArray.Length + 1);
                            queryArray[queryArray.Length - 1] = "UPDATE table_user" + " SET school_id = " + randomNum + " WHERE user_id = " + uploadTable.Rows[i][0] + ");";

                            break;
                        case "table_friends":

                            Array.Resize(ref queryArray, queryArray.Length + 1);
                            queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(unique_id, friend_id, user_id) " +
                                "VALUES(" + randomNum + ", " + uploadTable.Rows[i][0] + ", " + uploadTable.Rows[i][1] + ");";

                            break;
                        case "table_messages":

                            //newRow[0] = randomNum;//messageid //unknown have to create one and check doesnt exist
                            //newRow[1] = uploadTable.Rows[i][0];//senderid
                            //newRow[2] = uploadTable.Rows[i][1];//recieverid
                            //newRow[3] = uploadTable.Rows[i][2];//datetime
                            //newRow[4] = uploadTable.Rows[i][3];//textmessage

                            Array.Resize(ref queryArray, queryArray.Length + 1);
                            queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(message_id, sender_id, reciever_id, data_time, text_message) " +
                                "VALUES(" + randomNum + ", " + uploadTable.Rows[i][0] + ", " + uploadTable.Rows[i][1] +", '" +  uploadTable.Rows[i][2]  + "', '"+
                               uploadTable.Rows[i][3]+"'"+ ");";

                            break;
                    }
                }
            }
            else if (sameHeaders == true) //same headers means can take the information directly from same column names without converting the csv file
            {                
                //if headers same -- check new entry against old entry primary keys to see if data changed, if changed update, if doesnt exist create, if same ignore
                //think about ways to optimise this because this will take a very long time with large datasets and my bad searching methods
                for (int i = 0; i <= uploadTable.Rows.Count - 1; i++)
                {
                    bool replace = false;
                    for (int j = 0; j <= oldDataSet.Tables[uploadTableLocation].Rows.Count - 1; j++)
                    {                        
                        if (oldDataSet.Tables[uploadTableLocation].Rows[j][0].ToString() == uploadTable.Rows[i][0].ToString()) //if primary keys same means replace entry
                        {                            
                            replace = true;
                            break; //dont like using break -- but it speeds it up and once a match is found no longer required to search as primary keys are unique
                        }
                    }

                    if (replace == true) //query replacing with new uploadTable entry
                    {
                        //loop through for each header
                        for (int j = 0; j <= uploadTable.Columns.Count - 1; j++)
                        {
                            Array.Resize(ref queryArray, queryArray.Length + 1);
                            queryArray[queryArray.Length - 1] = "UPDATE " + uploadTableLocation +
                            " SET " + uploadTable.Columns[j].ColumnName.ToString() + " = " + uploadTable.Rows[i][j].ToString() +
                            " WHERE " + uploadTable.Columns[0].ColumnName.ToString() + " = " + uploadTable.Rows[i][0].ToString() + ");";

                        }                      
                        
                    }
                    else if (replace == false) //query adding new from uploadTable entry
                    {

                        switch (uploadTableLocation)
                        {
                            case "table_user":

                                //Create query then resizes and adds it to the array of queries
                                Array.Resize(ref queryArray, queryArray.Length + 1);
                                queryArray[queryArray.Length - 1] = @"INSERT INTO " + uploadTableLocation + @"(user_id, name_first, name_last, hometown, gender, statusRelationship, currentTown, workplace_id, school_id) " +
                                    @"VALUES(" + uploadTable.Rows[i][0] + ", '" + uploadTable.Rows[i][1] + "', '" + uploadTable.Rows[i][2] + "', '" +
                                    uploadTable.Rows[i][3] + "', '" + uploadTable.Rows[i][4] + "', '" + uploadTable.Rows[i][5] + "', '" + uploadTable.Rows[i][6] + "', "+ uploadTable.Rows[i][7]+
                                    ", " + uploadTable.Rows[i][8] + ");";
                                //--------------------------------------------------------------


                                break;
                            case "table_workplace"://requires the user_id to exist in the user table
                                                   //this will have two queries -- one to create the new workplace, one to replace the workplace field in 'table_user' with foreign key
                                Array.Resize(ref queryArray, queryArray.Length + 1); //first query to create the workplace query
                                queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(workplace_id, workplace_name, employment_date_start, employment_date_end) " +
                                    "VALUES(" + uploadTable.Rows[i][0] + ", '" + uploadTable.Rows[i][1] + "', '" + uploadTable.Rows[i][2] + "', '" + uploadTable.Rows[i][3] + "'" + ");";
                               
                                break;
                            case "table_school"://requires the user_id to exist in the user table
                                Array.Resize(ref queryArray, queryArray.Length + 1); //first query to create the workplace query
                                queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(school_id, school_name, school_date_start, school_date_end) " +
                                    "VALUES(" + uploadTable.Rows[i][0] + ", '" + uploadTable.Rows[i][1] + "', '" + uploadTable.Rows[i][2] + "', '" + uploadTable.Rows[i][3] + "'" + ");";
                               
                                break;
                            case "table_friends":

                                Array.Resize(ref queryArray, queryArray.Length + 1);
                                queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(unique_id, friend_id, user_id) " +
                                    "VALUES(" + uploadTable.Rows[i][0] + ", " + uploadTable.Rows[i][1] + ", " + uploadTable.Rows[i][2] + ");";
                                
                                break;
                            case "table_messages":

                                Array.Resize(ref queryArray, queryArray.Length + 1);
                                queryArray[queryArray.Length - 1] = "INSERT INTO " + uploadTableLocation + "(message_id, sender_id, reciever_id, data_time, text_message) " +
                                    "VALUES(" + uploadTable.Rows[i][0] + ", " + uploadTable.Rows[i][1] + ", " + uploadTable.Rows[i][2] + ", '" + uploadTable.Rows[i][3] + "', '" +
                                   uploadTable.Rows[i][4] + "'" + ");";
                                
                                break;
                        }

                    }
                }


            }
            //-----------------


            //acting on the queries created earlier
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            for (int i = 0; i <= queryArray.Length - 1; i++)
            {               
                MySqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = queryArray[i];
                //MessageBox.Show(sqlCommand.CommandText.ToString());
                sqlCommand.ExecuteNonQuery();
                
            }
            connection.Close();


            //---------------------

        }
        private void BTNLoadCSV_Click(object sender, EventArgs e)
        {
            OFDLoadExcel.ShowDialog();
            newTableData = readExcelTable(OFDLoadExcel);
            DGVTableview.DataSource = newTableData;
        }

        private void BTNUploadGroup_Click(object sender, EventArgs e)
        {

            newTableData = DGVTableview.DataSource as DataTable;      
            uploadTable(newTableData);
        }
    }
}
