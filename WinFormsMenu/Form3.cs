using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMenu
{
    public partial class Form3 : Form
    {
        public Form3(Form1 form)
        {
            InitializeComponent();

            form1 = form;
            input = form1.richTextBox1.Text;
        }

        public event EventHandler Change;
        public bool change = false;

        string text;
        string replace;
        string input;
        private int ind = 0;
        private int elem = 0;
        private int size = 0;
        private Form1 form1 = null;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            replace = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                if (textBox1.Text == null)
                {
                    MessageBox.Show("String is empty!");
                }
                else
                {
                    text = textBox1.Text;
                }

                if (!checkBox2.Checked && elem >= input.Length - 1)
                {
                    MessageBox.Show("Nothing found!");
                }
                else
                {
                    elem = input.ToLower().IndexOf(text.ToLower(), elem);
                    ind = elem++;
                    size = text.Length;
                }
            }
            else
            {
                if (!checkBox2.Checked && elem >= input.Length - 1)
                {
                    MessageBox.Show("Nothing found!");
                }
                else
                {
                    elem = input.IndexOf(text, elem);
                    ind = elem++;
                    size = text.Length;
                }
            }

            if (Change != null)
            {
                Change(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            replace = textBox2.Text;
            input = input.Insert(ind, replace);
            input = input.Remove(ind + replace.Length, text.Length);

            if (Change != null)
            {
                Change(this, new EventArgs());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                replace = textBox2.Text;
                input = input.Replace(text, replace);
            }
            catch
            {
                MessageBox.Show("String is empty!");
            }


            if (Change != null)
            {
                Change(this, new EventArgs());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int GetIndex()
        {
            return ind;
        }
        public int GetSize()
        {
            return size;
        }
        public string GetText()
        {
            return input;
        }
    }
}
