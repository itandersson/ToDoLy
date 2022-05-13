using System;
using System.Collections.Generic;

namespace ToDoLy
{
    public class ConsoleView : IUser
    {
        static private List<Task> list = new List<Task>();

        internal void start()
        {
            Console.WriteLine("Startar programmet!");
        }

        public void AddNewTask()
        {
            throw new System.NotImplementedException();
        }

        public void editTask()
        {
            throw new System.NotImplementedException();
        }

        public void save()
        {
            throw new System.NotImplementedException();
        }

        public void showTaskList()
        {
            throw new System.NotImplementedException();
        }
    }
}