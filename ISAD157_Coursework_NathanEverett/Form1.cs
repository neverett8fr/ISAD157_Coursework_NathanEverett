using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        }
        private void BTNSelectDataSource_Click(object sender, EventArgs e)
        {
            connectMySQL();
            
        }
    }
}
