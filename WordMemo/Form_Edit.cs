using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WordMemo
{
    public partial class Form_Edit : Form
    {
        public Form_Edit()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Insert(0, textBox1.Text);
                textBox1.Text = "";
            } else
            {
                dataGridView1.Rows.Insert(dataGridView1.CurrentCell.RowIndex, textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
            }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Encoding sjisEnc;

            try
            {
                sjisEnc = Encoding.GetEncoding("Shift_JIS");
                using (StreamWriter writer = new StreamWriter(Const.STR_TMP + Const.FILE_NAME, false, sjisEnc))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        writer.WriteLine(dataGridView1.Rows[i].Cells[0].Value);
                    }
                }
                File.Delete(Const.FILE_NAME);
                File.Move(Const.STR_TMP + Const.FILE_NAME, Const.FILE_NAME);
            } catch(Exception ex)
            {
                File.Delete(Const.STR_TMP + Const.FILE_NAME);
                MessageBox.Show(ex.Message, "エラーが発生しました");
            }


        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            StreamReader sr;
            string line = "";

            dataGridView1.ColumnCount = 1;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns[0].Width = 320;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.Columns[0].HeaderText = "一覧";

            try
            {
                using(sr = new StreamReader(Const.FILE_NAME, Encoding.GetEncoding("Shift_JIS")))
                {
                    for (int i = 0; (line = sr.ReadLine()) != null; i++)
                    {
                        dataGridView1.Rows.Insert(i, line);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラーが発生しました");
            }
        }
    }
}
