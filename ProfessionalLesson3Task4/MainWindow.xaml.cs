using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
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
using Xceed.Wpf.Toolkit;

namespace ProfessionalLesson3Task4
{
    //    Задание 4
    //Создайте приложение WPF Application, позволяющее пользователям сохранять данные в
    //изолированное хранилище.
    //Для выполнения этого задания необходимо наличие библиотеки Xceed.Wpf.Toolkit.dll.Ее
    //можно получить через References -> Manage NuGet Packages… -> в поиске написать Extended
    //WPF Toolkit (помимо интересующей нас библиотеки будут установлены и другие), или же
    //скачать непосредственно на сайте http://wpftoolkit.codeplex.com/ и подключить в проект только
    //интересующую нас бибилиотеку(References -> Add Reference …).
    //1. Разместите в окне Label и Button.
    //2. Разместите в окне ColorPicker (данный инструмент предоставляется вышеуказанной
    //библиотекой). Для этого необходимо в XAML коде в теге Window подключить пространство
    //имен xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" . Также, нам понадобиться событие
    //Loaded окна.
    //3. Реализуйте, чтобы при выборе цвета из ColorPicker в Label выводилось название
    //выбранного цвета и в этот цвет закрашивался фон Label.По нажатию на кнопку, данные о
    //цвете сохраняются в изолированное хранилище.При запуске приложения заново, цвет фона
    //Label остается таким, каким был сохранен при предыдущих запусках приложения.



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();        // C:\Users\user\AppData\Local\IsolatedStorage\nxmmj04a.2wu\4nozapoq.v3i\Url.ul2fjholikebmv4vrwb5cefwv1kcu1hq\AssemFiles

        static BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        static FieldInfo field = storage.GetType().GetField("_rootDirectory", bindFlags);
        static string storagePath = (string)field.GetValue(storage);
        static DirectoryInfo storageDir = new DirectoryInfo(storagePath);
        static FileInfo file = new FileInfo($@"{storageDir.FullName}\config.cfg");

        public MainWindow()
        {
            InitializeComponent();

            if (file.Exists)
            {
                using (StreamReader sr = new StreamReader(new FileStream(file.FullName, FileMode.Open, FileAccess.Read)))
                {
                    label1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sr.ReadLine()));
                    label1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sr.ReadLine()));
                    sr.Close();
                }
            }
        }

        private void cpBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            label1.Background = new SolidColorBrush((Color)cpBackground.SelectedColor);
            label1.Foreground = new SolidColorBrush((Color)cpForeground.SelectedColor);

            using (StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("config.cfg", FileMode.OpenOrCreate, storage)))  // "C:\Users\user\AppData\Local\IsolatedStorage\nxmmj04a.2wu\4nozapoq.v3i\Url.ul2fjholikebmv4vrwb5cefwv1kcu1hq\AssemFiles\config.cfg"
            {
                sw.WriteLine(label1.Background.ToString());
                sw.WriteLine(label1.Foreground.ToString());
                sw.Close();
            }
        }
    }
}
