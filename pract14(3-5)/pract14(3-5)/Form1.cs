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
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace pract14_3_5_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            
            Queue<int> queue = new Queue<int>();
            int n = int.Parse(textBox1.Text);
            if (regex.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Вводите только цифры!");
            }
            else
            if (n <= 0)
            {
                MessageBox.Show("Число не может быть равно 0 или быть меньше нуля", "Ошибка");
            }
            else
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Введите число", "Ошибка");
            }
            else
                for (int i = 1; i <= n; i++)
                {
                    queue.Enqueue(i);
                }
            while (queue.Count > 0)
            {
                int number = queue.Dequeue();
                listBox1.Items.Add(number);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Queue<string> young40 = new Queue<string>();

            string[] lines = File.ReadAllLines("people.txt");
            if (!File.Exists("people.txt"))
            {
                MessageBox.Show("Файл не найден");
            }
            else

                foreach (string line in lines)
            {
                string[] parts = line.Split(' ');

                int age;
                if (int.TryParse(parts[3], out age))
                {
                    if (age < 40)
                    {
                        young40.Enqueue(line);
                    }
                    
                }
            }

          

            while (young40.Count > 0)
            {
                listBox2.Items.Add(young40.Dequeue());
            }



        }
    

           

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

       
            Queue<string> old40 = new Queue<string>();

            string[] lines = File.ReadAllLines("people.txt");
            if (!File.Exists("people.txt"))
            {
                MessageBox.Show("Файл не найден");
            }
            else

                foreach (string line in lines)
            {
                string[] parts = line.Split(' ');

                int age;
                if (int.TryParse(parts[3], out age))
                {
                    if (age > 40)

                    {
                        old40.Enqueue(line);
                    }
                }
            }

            while (old40.Count > 0)
            {
                listBox2.Items.Add(old40.Dequeue());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Queue<string> people = new Queue<string>();
            string[] lines = File.ReadAllLines("people.txt");
            if(!File.Exists("people.txt"))
            {
                MessageBox.Show("Файл не найден");
            }
            else
            foreach (string line in lines)
            {
                people.Enqueue(line);
            }
            List<string> sortedPeople = people.OrderBy(p => 
            {
                string[] parts = p.Split(' ');
                int age;
                if (int.TryParse(parts[3], out age))
                {
                    return age;
                }
                else
                {
                    return int.MaxValue;
                }
            }).ToList();
            listBox3.Items.AddRange(sortedPeople.ToArray());
        }
    }
}
