using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Konvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private int ConvertRomanToLatin(string romanNumber)
        {
            // создаем словарь соответствий для каждой римской цифры
            Dictionary<char, int> romanValues = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int result = 0; // инициализируем результат
            int previousValue = 0; // хранит значение предыдущей цифры
            foreach (char c in romanNumber)
            {
                if (!romanValues.ContainsKey(c)) // проверяем, что введена корректная цифра
                {
                    return -1;
                }

                int currentValue = romanValues[c]; // текущее значение цифры
                if (currentValue > previousValue) // вычитаем предыдущую цифру, если она меньше текущей
                {
                    result -= 2 * previousValue; // умножаем на 2, так как предыдущую цифру мы уже прибавили
                }
                result += currentValue; // добавляем текущую цифру к результату
                previousValue = currentValue; // запоминаем текущую цифру
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string romanNumber = RomanTextBox.Text.ToUpper(); // переводим римскую цифру в верхний регистр
            int latinNumber = ConvertRomanToLatin(romanNumber); // конвертируем
            if (latinNumber != -1) // проверяем, что конвертация прошла успешно
            {
                textBox2.Text = latinNumber.ToString(); // выводим результат
            }
            else
            {
                MessageBox.Show("Некорректная римская цифра!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}