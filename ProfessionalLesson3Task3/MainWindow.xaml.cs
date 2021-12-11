using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;


namespace ProfessionalLesson3Task3
{

    //    Задание 3
    //Напишите приложение для поиска заданного файла на диске.Добавьте код, использующий
    //класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
    //добавьте возможность сжатия найденного файла.


    /// <summary> 
    /// Interaction logic for MainWindow.xaml 
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool hasBeenClicked = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            textBox.Text = textBox.Text.Replace("\"", "").Trim();

            if (textBox.Text != null && textBox.Text != "")
            {
                FileInfo file = new FileInfo(textBox.Text);
                if (file.Exists)
                {
                    using (StreamReader sr = new StreamReader(new FileStream(file.FullName, FileMode.Open, FileAccess.Read)))
                    {
                        //textBlock.Text = sr.ReadToEnd();
                        MessageBox.Show(sr.ReadToEnd());
                        sr.Close();
                    }
                }
                else
                    //textBlock.Text = "This file doesnt exist.";
                    MessageBox.Show("This file doesnt exist.");
            }
            else
                //textBlock.Text = "This file doesnt exist.";
                MessageBox.Show("This file doesnt exist.");
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                textBox.Text = string.Empty;
                hasBeenClicked = true;
            }
        }

        private void buttonChoose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)| *.*";

            if (ofd.ShowDialog() == true)
                textBox.Text = ofd.FileName;
        }
    }
}