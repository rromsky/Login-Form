using System.Data;
using MySql.Data.MySqlClient;


namespace Лаба_1_WF
{
    public partial class Form1 : Form
    {
        private void ShowBox(string message, string caption)
        {
            var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
        }
        bool RuleCheck = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

  

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register regForm = new register();
            regForm.Show();
            // this.Close();
        }

        private void roundButton1_Click_1(object sender, EventArgs e)
        {
            
                DB dB = new DB();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                String pass = textBox2.Text,
                    name = textBox1.Text;

                //  dB.openConnection();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @name AND `password` = @uP", dB.GetConnection());
                cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = pass;

                adapter.SelectCommand = cmd;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                    ShowBox("Ви успішно ввійшли", "Успіх!");
                else
                    ShowBox("Користувача не існує!", "Проблема!");

                //  dB.closeConnection();
            
            
        }
    }
}