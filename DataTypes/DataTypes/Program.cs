using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataTypes.Data;
using DataTypes.Models;
using Microsoft.Extensions.Configuration;

namespace DataTypes
{
    class Program
    {
        /*Создать консольную виртуальную файловую систему. 
         * Пользователь может создавать свои папки, вкладывать их друг в друга, 
         * а также загружать настоящие файлы. Папки - являются виртуальными 
         * и хранятся на стороне БД. Файлы - состоят из настоящих файлов 
         * операционной системы и прикреплены к виртуальному пространству.*/

        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration["connectionString"];


            using (var context = new ApplicationContext(connectionString))
            {
                var folder = context.Folders.FirstOrDefault();
                context.Entry(folder).Collection("Folders").Load();
                var name = folder.Folders;
                Console.WriteLine(name.ToList()[0].Name);
            }

        }
    }
}
