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
    public partial class Form2 : Form
    {
        public Form2(Form1 f, bool rev)
        {
            InitializeComponent();

            form1 = f;
            if (rev) radioButton2.Select();
            else radioButton1.Select();
        }

        public event EventHandler Change;

        private string input;
        private string text;
        private int ind;
        private int size;
        private int elem = 0;
        private Form1 form1 = null;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = form1.richTextBox1.Text;

            if (!checkBox1.Checked)
            {
                input = input.ToLower();
                text = text.ToLower();
            }

            if (radioButton2.Checked)
            {
                try
                {
                    elem = FindIndex(text, input, elem);
                    ind = elem++;
                }
                catch
                {
                    MessageBox.Show("Nothing found!");
                }
            }
            else if (radioButton1.Checked)
            {
                try
                {
                    elem = FindIndex(text, input, elem, true);
                    ind = elem--;
                }
                catch
                {
                    MessageBox.Show("Nothing found!");
                }
            }

            try
            {
                size = input.Length;

                if (Change != null)
                {
                    Change(this, new EventArgs());
                }
            }
            catch
            {
                MessageBox.Show("Nothing found!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int FindIndex(string str, string templ, int start = 1, bool revers = false)
        {

            string t = "";

            if (revers == false)
            {
                for (int item = start; item <= str.Length; item++)
                {
                    if (item <= str.Length)
                    {
                        if (t.Length <= templ.Length) 
                        {
                            if (t.Length < templ.Length) 
                            {
                                if ((item == str.Length) && checkBox2.Checked) item = 0;
                                t += str[item]; 
                            }
                            else if (t == templ) return item - templ.Length;
                            else t = t.Remove(0, 1) + str[item];
                        }
                        else
                        {
                            MessageBox.Show("Nothing found!");
                        }
                    }
                }
                return -1;
            }
            else if (revers == true)
            {
                for (int item = start; item >= -1; item--)
                {
                    if (item >= -1)
                    {
                        if (t.Length <= templ.Length) 
                        {
                            if (t.Length < templ.Length)
                            {
                                if ((item == -1) && checkBox2.Checked) item = str.Length - 1; 
                                t = str[item] + t;  
                            }
                            else if (t == templ) return item + 1;
                            else t = str[item] + t.Remove(t.Length - 1, 1);
                        }
                        else
                        {
                            MessageBox.Show("Nothing found!");
                        }

                    }
                }
                return -1;
            }
            return -1;
        }

        public bool change = false;

        public int GetIndex()
        {
            return ind;
        }
        public int GetSize()
        {
            return size;
        }
    }
}
