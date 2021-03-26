using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int CurrentPageIndex = 0;

        public DataTable dt = new DataTable();

        public List<DataTable> dataTables = new List<DataTable>();

        public int index = 0;
        public int indexPage = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (cell.Selected)
                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Логин");
            dt.Columns.Add("Email");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Телефон");
            dataTables.Add(dt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (indexPage < dataTables.Count - 1)
            {
                this.dataGridView1.DataSource = dataTables[indexPage + 1];
                indexPage++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (indexPage > 0)
            {
                this.dataGridView1.DataSource = dataTables[indexPage - 1];
                indexPage--;
            }
        }
    }
}
