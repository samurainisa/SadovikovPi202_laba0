using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Collections.Generic;

namespace SadovikovPi202_laba0
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)

        {
            double a, b, h, m, P;

            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите катет А");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Введите катет В");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Введите высоту H");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Введите массу M");
            }
            else
            {
                a = Convert.ToDouble(textBox2.Text);
                b = Convert.ToDouble(textBox3.Text);
                h = Convert.ToDouble(textBox4.Text);
                m = Convert.ToDouble(textBox6.Text);
                P = 2 * m / (a * b * h);
                textBox5.Text = P.ToString();

                double[] mass = new double[] { a, b, h, m };

                if (mass.Contains(0))
                    MessageBox.Show("Значения не могут быть равны 0");

            }
        }



        /*Телефонный справочник содержит данные об абонентах: фамилия, номер телефона (число формата xxyy),
         *годе установки телефон (формата аабб). вывести данные об абонентах, у которых уу=бб
         *а) сгенерировать данные, сохраняя их в формате csv, xml, или json
         *б) считывать данные из файлы и выполнять операции в соответствии с заданием*/


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите число в поле");
            }
            else if (textBox1.Text.Contains((char)0))
            {
                MessageBox.Show("Количество не может быть 0");
            }
            else
            {


                var folderpath = @"C:\Sadovikov_lab0";

                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }

                Random rnd = new Random();
                var filepath = @"C:\Sadovikov_lab0\csvtable.csv";

                using (StreamWriter writer = new StreamWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write), Encoding.Default))
                {

                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {
                        writer.WriteLine(String.Format("{0},{1},{2}", RandomGeneratorName(5, true), rnd.Next(1000, 9999), rnd.Next(1000, 9999)));
                    }
                }
            }
        }


        public string RandomGeneratorName(int length, bool name)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            char[] chars = new char[length];
            string validCharsLower = "abcdefghijklmnopqrstuvwxyz";
            string validCharsHigher = "ABCEDFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < length; i++)
            {
                if (i == 0 || !name)
                {
                    byte[] bytes = new byte[1];
                    rng.GetBytes(bytes);
                    Random rnd = new Random(bytes[0]);
                    chars[i] = validCharsHigher[rnd.Next(0, validCharsHigher.Length - 1)];
                }
                else
                {
                    byte[] bytes = new byte[1];
                    rng.GetBytes(bytes);
                    Random rnd = new Random(bytes[0]);
                    chars[i] = validCharsLower[rnd.Next(0, validCharsLower.Length - 1)];
                }

            }
            return (new string(chars));
        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }
        private void LoadInfo()
        {
            string delimiter = ",";
            string tableName = "abonents";
            string fileName = ("C:\\Sadovikov_lab0\\csvtable.csv");

            DataSet dataset = new DataSet();
            StreamReader sr = new StreamReader(fileName);

            dataset.Tables.Add(tableName);
            dataset.Tables[tableName].Columns.Add("Surname");
            dataset.Tables[tableName].Columns.Add("Number");
            dataset.Tables[tableName].Columns.Add("Date");

            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToCharArray());

            foreach(string r in rows)
            {
                string value = r.Trim('\n');
                if (value.Trim() == String.Empty)
                    continue;
                string[] items = r.Split(delimiter.ToCharArray());
                string yy = items[1].Substring(2, 2);
                string bb = items[2].Substring(2, 2);
                if (yy == bb)
     
                    dataset.Tables[tableName].Rows.Add(items);

            }
            this.dataGridView1.DataSource = dataset.Tables[0].DefaultView;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
          }
       }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
 }
                    
                
            

           