using System;
using System.IO;
using System.Web.Script.Serialization;
using BookOfRecipes.Wpf.Models;

namespace BookOfRecipes.Wpf.Files
{
    public class FileHandling
    {
        private JavaScriptSerializer javaScriptSerializer;

        public FileHandling()
        {
            javaScriptSerializer = new JavaScriptSerializer();
        }

        public void Save(string path, Data data)
        {
            CheckFilePathNotNullOrEmpty(path);

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            
            string json = javaScriptSerializer.Serialize(data);
            File.WriteAllText(path, json);
        }

        public Data Load(string path)
        {
            CheckFilePathNotNullOrEmpty(path);
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File for given path: " + path + "does not exist.");
            }

            string json = File.ReadAllText(path);
            if (String.IsNullOrWhiteSpace(json))
            {
                return new Data();
            }
            
            return javaScriptSerializer.Deserialize<Data>(json);
        }

        private void CheckFilePathNotNullOrEmpty(String path)
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
        }
    }
}