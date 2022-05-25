using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ToDoLy
{
    public class FileHelper
    {
        private string filePath;

        /// <summary>
        /// The constructor tryes to create a new directory at the specified path
        /// </summary>
        /// <param name="path">Specify path</param>
        /// <param name="dir">Create new directory</param>
        public FileHelper(string path, string dir)
        {
            //Trying to create directory
            try { Directory.CreateDirectory(path + dir); }
            catch(Exception e) { Console.WriteLine(e.Message); }

            this.filePath = path + dir + "/";
        }

        public void ReadJson()
        {
            //string readText = File.ReadAllText(filePath + fileName);  // Read the contents of the file
            //Console.WriteLine(readText);
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves a list to the hard disk.
        /// Type of <Task> can contain three different types of objects,
        /// Therefore, three files are saved on the hard disk in this function.
        /// </summary>
        /// <param name="list">The list</param>
        public void toJsonFile(List<Task> list)
        {
            string fileName = "";

            try
            {
                //If the files already exist, delete them
                if (File.Exists(filePath + "ShoppingList.json")) { File.Delete(filePath + "ShoppingList.json"); }
                if (File.Exists(filePath + "Exercise.json")) { File.Delete(filePath + "Exercise.json"); }
                if (File.Exists(filePath + "BusTicket.json")) { File.Delete(filePath + "BusTicket.json"); }

                foreach (Task task in list)
                {
                    string jsonString = "";

                    //If type is true, create json string 
                    if (task is ShoppingList) { jsonString = JsonSerializer.Serialize((ShoppingList)task); fileName = "ShoppingList.json"; }
                    else if (task is Exercise) { jsonString = JsonSerializer.Serialize((Exercise)task); fileName = "Exercise.json"; }
                    else if (task is BusTicket) { jsonString = JsonSerializer.Serialize((BusTicket)task); fileName = "BusTicket.json"; }
                    else { throw new Exception("An unexpected error occurred"); }

                    //Append to a new file and close
                    StreamWriter r = File.AppendText(filePath + fileName);
                    r.WriteLine(jsonString);
                    r.Close();
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}