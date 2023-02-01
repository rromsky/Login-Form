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

namespace Лаба_1_WF
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            textBox1.Text = "Логін";
            textBox2.Text = "Пароль";
        }

        private void register_Load(object sender, EventArgs e)
        {
            //Application.Exit();
        }
        private void ShowBox(string message, string caption)
        {
            var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
        }
        bool RuleCheck = false;


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Логін")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Логін";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                textBox2.Text = "Пароль";
            }
        }

        private void register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
        }

        private bool loginExist(String lg)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //  dB.openConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @name", dB.GetConnection());
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = lg;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                ShowBox("Такий логін вже зайнятий!", "Проблема!");
                return false;
            }
            return true;
        }



        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!RuleCheck)
            {
                ShowBox("Ти прочитав правила?", "Атата");
            }
            RuleCheck = !RuleCheck;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (RuleCheck)
            {
                if (textBox1.Text == "Логін")
                {
                    ShowBox("Введіть логін!", "Помилка!");
                    return;
                }
                if (textBox2.Text == "Пароль")
                {
                    ShowBox("Введіть пароль!", "Помилка!");
                    return;
                }
                if (!loginExist(textBox1.Text))
                {
                    return;
                }
                DB dBs = new DB();

                DataTable table1 = new DataTable();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();

                String pass = textBox2.Text,
                    name = textBox1.Text;


                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (id, login, password) VALUES (NULL, @name, @uP)", dBs.GetConnection());
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = pass;

                dBs.openConnection();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    ShowBox("Користувача створено!", "Успіх!");
                }
                else
                {
                    ShowBox("Користувача не створено.", "Проблема.");
                }

                dBs.closeConnection();
            }
        }
    }
}
