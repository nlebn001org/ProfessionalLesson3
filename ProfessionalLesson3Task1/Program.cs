using System;
using System.IO;

namespace ProfessionalLesson3Task1
{

    //Создайте на диске 100 директорий с именами от Folder_0 до Folder_99, затем удалите их.

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInf = new DirectoryInfo(@"C:\Users\user\Desktop\IO tests\");


            for (int i = 0; i < 100; i++)
            {
                new DirectoryInfo($@"C:\Users\user\Desktop\IO tests\Folder{i}").Create();
            }

            //foreach (var item in dirInf.GetDirectories())
            //    item.Delete();


        }
    }
}
