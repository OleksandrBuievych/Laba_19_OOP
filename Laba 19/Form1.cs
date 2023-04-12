using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевірити, чи введено рядок для підрахунку слів
            if (string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                MessageBox.Show("Будь ласка, введіть рядок для підрахунку слів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Отримати введений рядок та очистити його від зайвих пробілів
            string inputString = inputTextBox.Text.Trim();

            // Розділити введений рядок на слова та підрахувати кількість кожного слова
            var wordFrequency = inputString.Split(' ')
                .GroupBy(word => word, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(group => group.Key, group => group.Count());

            // Вивести кількість кожного слова у вихідний лейбл
            outputLabel.Text = "Частота слів:\n";
            foreach (var pair in wordFrequency)
            {
                if (pair.Value > 1)
                {
                    outputLabel.Text += $"{pair.Key}: {pair.Value}\n";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Перевірити, чи введено рядок та слово для видалення
            if (string.IsNullOrWhiteSpace(inputTextBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть рядок для видалення слів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(deleteTextBox.Text))
            {
                MessageBox.Show("Будь ласка, введіть слово для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Отримати введений рядок та слово для видалення та очистити їх від зайвих пробілів
            string inputString = inputTextBox1.Text.Trim();
            var wordToRemove = deleteTextBox.Text.Trim();

            // Видалити всі входження вказаного слова з введеного рядка
            inputString = string.Join(" ", inputString.Split(' ')
                .Where(word => !string.Equals(word, wordToRemove, StringComparison.OrdinalIgnoreCase)));

            // Вивести змінений рядок у вікно
            MessageBox.Show($"{inputString}", "Відформатований текст");
        }
    }
}

