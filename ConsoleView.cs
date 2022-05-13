using System;
using System.Collections.Generic;

namespace ToDoLy
{
    public class ConsoleView : IUser
    {
        static private List<Task> list = new List<Task>();

        internal void start()
        {
            // Add task to the list.
            list.Add(new ShoppingList("ICA Kvantum", "Mjölk, Smör, bröd.", "Inköp", DateTime.Parse("2022/01/2"), true) );
            list.Add(new Exercise(false, true, 1000, "Motion", DateTime.Parse("2022/02/12"), true ) );
            list.Add(new BusTicket(1199, "Malmö C", "Köp buss biljett", DateTime.Parse("2022/03/20"), true));

            Boolean run = true;
            int x = list.Count;
            int y = 0;

            string welcome = "Welcome to ToDoLy\n" +
                "You have " + x + " tasks todo and " + y + " tasks are done!\n\n" +
                "(1) Show Task List (by date or project)\n" +
                "(2) Add New Task\n" +
                "(3) Edit Task (update, mark as done, remove)\n" +
                "(4) Save and Quit\n";

            while (run)
            {
                Console.WriteLine(welcome);
                Console.Write("Pick an option: ");
                int value = int.Parse(Console.ReadLine());

                switch (value)
                {
                    case 1:
                        showTaskList();
                        continue;
                    case 2:
                        //Task item = addNewTask();
                        //list.Add(item);
                        Console.WriteLine('\t' + "Thank you, a new task was successfully added." + '\n');
                        continue;
                    case 3:
                        //editTask(list);
                        continue;
                    case 4:
                        run = false;
                        break;
                }
            }
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
            Console.WriteLine('\t' + "Test!" + '\n');
        }
    }
}