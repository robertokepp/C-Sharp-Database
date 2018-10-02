using System.Windows.Forms;
using DatabaseApp.Table;
using DatabaseApp.Test;
using System;

namespace WindowsFormsApp
{
    public partial class frmLogin : Form
    {
        bool useMicrosoftAccess = false;
        bool useMySQL = false;
        bool useSQL = false;

        TableMicrosoftAccess microsoftAccessTable = new TableMicrosoftAccess();
        TableMySQL mySQLTable = new TableMySQL();
        TableSQL SQLTable = new TableSQL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (useMicrosoftAccess)
            {
                testMicrosoftAccessConnection();
            }

            else if (useMySQL)
            {
                testMySQLConnection();
            }

            else if (useSQL)
            {
                testSQLConnection();
            }
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            if (useMicrosoftAccess)
            {
                if (microsoftAccessTable.checkLogin(txtUsername.Text, mtxtPassword.Text))
                {
                    frmMenu menuForm = new frmMenu();
                    menuForm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Username or Password invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    mtxtPassword.Text = "";
                }
            }

            if (useMySQL)
            {
                if (mySQLTable.checkLogin(txtUsername.Text, mtxtPassword.Text))
                {
                    frmMenu menuForm = new frmMenu();
                    menuForm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Username or Password invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    mtxtPassword.Text = "";
                }
            }

            if (useSQL)
            {
                if (SQLTable.checkLogin(txtUsername.Text, mtxtPassword.Text))
                {
                    frmMenu menuForm = new frmMenu();
                    menuForm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Username or Password invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    mtxtPassword.Text = "";
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void testMicrosoftAccessConnection()
        {
            bool test = TestMicrosoftAccess.testConnection();

            if (test == false)
            {
                MessageBox.Show("Connection Error: Microsoft Access Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void testMySQLConnection()
        {
            bool test = TestMySQL.testConnection();

            if (test == false)
            {
                MessageBox.Show("Connection Error: MySQL Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void testSQLConnection()
        {
            bool test = TestSQL.testConnection();

            if (test == false)
            {
                MessageBox.Show("Connection Error: SQL Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
