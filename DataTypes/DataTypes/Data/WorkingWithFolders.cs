using DataTypes.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataTypes.Data
{
    public class WorkingWithFolders
    {


        public void AddingToFolder(string way)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration["connectionString"];
            Console.WriteLine("Введите название папки");
            string nameFolder = way;
            nameFolder += Console.ReadLine();
            Folder folder = new Folder();
            folder.Name = nameFolder;
            using (var context = new ApplicationContext(connectionString))
            {
                context.Folders.Add(folder);
                context.SaveChanges();
            }
        }

        public void AddingToFiles(string way)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration["connectionString"];
            Console.WriteLine("Введите название файла с расширением");
            string nameFolder = Console.ReadLine();
            Files files = new Files();
            files.Name = way + nameFolder;
            using (var context = new ApplicationContext(connectionString))
            {
                context.Files.Add(files);
                context.SaveChanges();
            }
            FileInfo fileInfo = new FileInfo($"D:\\{nameFolder}");
            fileInfo.Create();
        }

        public void DirectoryOutput(string way)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration["connectionString"];
            List<Files> collectionFiles;
            List<Folder> collectionFolder;
            using (var context = new ApplicationContext(connectionString))
            {
                collectionFiles = context.Files.Take(context.Files.Count()).ToList();
                collectionFiles = collectionFiles.Where(files => files.Name.ToLower().Contains(way.ToLower())).ToList();
                collectionFolder = context.Folders.Take(context.Files.Count()).ToList();
                collectionFolder = collectionFolder.Where(files => files.Name.ToLower().Contains(way.ToLower())).ToList();
            }

            for (int i = 0; i < collectionFiles.Count; i++)
            {
                Console.WriteLine(collectionFiles[i].Name);
            }
            for (int i = 0; i < collectionFolder.Count; i++)
            {
                Console.WriteLine(collectionFolder[i].Name);
            }
        }
        public bool MovingAlongThePath(string way, string name)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration["connectionString"];

            using (var context = new ApplicationContext(connectionString))
            {
                var resultFiles = context.Files.Take(context.Files.Count()).ToList();
                resultFiles = resultFiles.Where(files => files.Name.ToLower().Contains(way.ToLower())).ToList();                
                var resultFolder = context.Files.Take(context.Files.Count()).ToList();
                resultFolder = resultFolder.Where(files => files.Name.ToLower().Contains(way.ToLower())).ToList();

                for (int i = 0; i < resultFiles.Count; i++)
                {
                    if (resultFiles[i].Name == way + name)
                    {
                        return true;
                    }
                }
                for (int i = 0; i < resultFolder.Count; i++)
                {
                    if (resultFolder[i].Name == way + name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


    }
}
