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

        /// <summary>
        /// Reads json from three files and returns a list
        /// </summary>
        /// <param name="p_filePath">The path</param>
        /// <returns>List of task</returns>
        public static List<Task> ReadJson(string p_filePath)
        {
            List<Task> tasks = new List<Task>();

            //Get files to deserialize
            string[] shoppingList = File.ReadAllLines(p_filePath + "ShoppingList.json");
            string[] exercise = File.ReadAllLines(p_filePath + "Exercise.json");
            string[] busTicket = File.ReadAllLines(p_filePath + "BusTicket.json");

            //Deserialize shoppingList
            foreach (string item in shoppingList)
            {
                tasks.Add((Task)JsonSerializer.Deserialize<ShoppingList>(item));
            }

            //Deserialize exercise
            foreach (string item in exercise)
            {
                tasks.Add((Task)JsonSerializer.Deserialize<Exercise>(item));
            }

            //Deserialize busTicket
            foreach (string item in busTicket)
            {
                tasks.Add((Task)JsonSerializer.Deserialize<BusTicket>(item));
            }

            return tasks;
        }

        /// <summary>
        /// Writes json to three files on the hard disk.
        /// </summary>
        /// <param name="list">The list to write from</param>
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