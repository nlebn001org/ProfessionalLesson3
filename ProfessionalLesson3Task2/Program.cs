using System;
using System.IO;

namespace ProfessionalLesson3Task2
{
    //    Задание 2
    //Создайте файл, запишите в него произвольные данные и закройте файл.Затем снова откройте
    //этот файл, прочитайте из него данные и выведете их на консоль.
    class Program
    {

        static void Main(string[] args)
        {
            string input = "NewOpenWrite";

            FileInfo file = new FileInfo(@"C:\Users\user\Desktop\IO tests\newTest.txt");
            FileInfo file2 = new FileInfo(@"C:\Users\user\Desktop\IO tests\newTest2.txt");

            FileInfo fileSRW1 = new FileInfo(@"C:\Users\user\Desktop\IO tests\StreamRW1.txt");
            FileInfo fileSRW2 = new FileInfo(@"C:\Users\user\Desktop\IO tests\StreamRW2.txt");

            //using (FileStream writeFs = File.OpenWrite(file.FullName))
            //{
            //    byte[] arr = System.Text.Encoding.Default.GetBytes(input);
            //    writeFs.Write(arr, 0, arr.Length);
            //}

            //using (FileStream readFs = File.OpenRead(file.FullName))
            //{
            //    byte[] arr = new byte[readFs.Length];
            //    readFs.Read(arr, 0, arr.Length);
            //    string enc = System.Text.Encoding.Default.GetString(arr);
            //    Console.WriteLine(enc);
            //}

            try
            {
                using (StreamWriter sw = new StreamWriter(fileSRW1.FullName, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(input);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                using (StreamReader sr = new StreamReader(fileSRW1.FullName, System.Text.Encoding.UTF8))
                {
                    string read = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(fileSRW2.FullName, false, System.Text.Encoding.UTF8))
                    {
                        sw.Write(read);
                        sw.Close();
                    }
                    Console.WriteLine(read);
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //using (FileStream readFs = File.OpenRead(file.FullName))
            //{
            //    byte[] arr = new byte[readFs.Length];
            //    readFs.Read(arr, 0, arr.Length);
            //    string str = System.Text.Encoding.Default.GetString(arr);
            //    Console.WriteLine(str);

            //    if (!file2.Exists)
            //    {
            //        using (FileStream writeFs = File.OpenWrite(file2.FullName))
            //        {
            //            writeFs.Write(arr, 0, arr.Length);
            //        }
            //    }
            //}
        }
    }
}
