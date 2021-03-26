using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string email = textBox4.Text;
            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            string phone = maskedTextBox1.Text;

            for (int i = 0; i < form1.dataTables.Count - 1; i++)
            {
                if (form1.dataTables[i].Rows.Count < 10)
                {
                    form1.index = i;
                    break;
                }
            }

            if (form1.dataTables[form1.index].Rows.Count < 10)
            {
                form1.indexPage = form1.index;

                form1.dataTables[form1.index].Rows.Add(login, email, firstName, lastName, phone);

                form1.dataGridView1.DataSource = form1.dataTables[form1.index];
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Логин");
                dt.Columns.Add("Email");
                dt.Columns.Add("Имя");
                dt.Columns.Add("Фамилия");
                dt.Columns.Add("Телефон");
                form1.dataTables.Add(dt);

                while (form1.dataTables[form1.index].Rows.Count >= 10)
                    form1.index++;
                form1.indexPage = form1.index;

                form1.dataTables[form1.index].Rows.Add(login, email, firstName, lastName, phone);

                form1.dataGridView1.DataSource = form1.dataTables[form1.index];
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if(!Regex.IsMatch(textBox2.Text, @"^[А-Яа-я||A-Za-z]+$"))
            {
                textBox2.BackColor = Color.Coral;
                e.Cancel = true;
            }
            else
            {
                textBox2.BackColor = Color.LightGreen;
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox3.Text, @"^[А-Яа-я||A-Za-z]+$"))
            {
                textBox3.BackColor = Color.Coral;
                e.Cancel = true;
            }
            else
            {
                textBox3.BackColor = Color.LightGreen;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[А-Яа-я||A-Za-z||0-9]+$"))
            {
                textBox1.BackColor = Color.Coral;
                e.Cancel = true;
            }
            else
            {
                textBox1.BackColor = Color.LightGreen;
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox5.Text, @"^[А-Яа-я||A-Za-z||0-9]+$"))
            {
                textBox5.BackColor = Color.Coral;
                e.Cancel = true;
            }
            else
            {
                textBox5.BackColor = Color.LightGreen;
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox4.Text, @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)"))
            {
                textBox4.BackColor = Color.Coral;
                e.Cancel = true;
            }
            else
            {
                textBox4.BackColor = Color.LightGreen;
            }
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if(!Regex.IsMatch(maskedTextBox1.Text, @"\(\d{3}\) \d{3}-\d{4}"))
            {
                maskedTextBox1.BackColor = Color.Coral;
                e.Cancel = true;
            }
            else
            {
                maskedTextBox1.BackColor = Color.LightGreen;
            }
        }
    }
}