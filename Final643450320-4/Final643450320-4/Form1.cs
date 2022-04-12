using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final643450320_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int price = 0, total = 0, getprice = 0;

            if (textBox1.Text == "")
            {
                textBox1.SelectAll();
                return;
            }
            if (textBox3.Text == "")
            {
                textBox3.SelectAll();
                return;
            }
            price = Convert.ToInt32(textBox1.Text);
            total = Convert.ToInt32(textBox3.Text);
            getprice = price * total;
            textBox5.Text = getprice.ToString();

            
            string Product = comboBox1.Text;
            string Price = textBox1.Text;
            string Total = textBox3.Text;
            string Getprice = textBox5.Text;
            string Coupon = textBox4.Text;
            string GetbillToprice = textBox8.Text;
            string PayBill = textBox9.Text;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = Product;
            dataGridView1.Rows[n].Cells[1].Value = Price;
            dataGridView1.Rows[n].Cells[2].Value = Total;
            dataGridView1.Rows[n].Cells[3].Value = Getprice;
            dataGridView1.Rows[n].Cells[4].Value = Coupon;
            dataGridView1.Rows[n].Cells[5].Value = GetbillToprice;
            dataGridView1.Rows[n].Cells[6].Value = PayBill;


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String[] readAllline = File.ReadAllLines(openFileDialog.FileName);

                String readAllText = File.ReadAllText(openFileDialog.FileName);
                for (int i = 0; i < readAllline.Length; i++)
                {
                    string allDATARAW = readAllline[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView1.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[2], allDATASplited[3]);

                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = " CSV(*.csv) |*.csv";
                bool FileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!FileError)
                    {
                        try
                        {
                            int columcount = dataGridView1.Columns.Count;
                            string column = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < outputCSV.Length; i++)
                            {
                                column += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += column;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[i].Value.ToString() + ",";
                                }

                            }
                            File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }

        }
    }
}
