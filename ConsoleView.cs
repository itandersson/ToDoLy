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

            while (run)
            {
                int x = list.Count;
                int y = 0;

                string welcome = "Welcome to ToDoLy\n" +
                "You have " + x + " tasks todo and " + y + " tasks are done!\n\n" +
                "(1) Show Task List (by date or project)\n" +
                "(2) Add New Task\n" +
                "(3) Edit Task (update, mark as done, remove)\n" +
                "(4) Save and Quit\n";

                Console.WriteLine(welcome);
                Console.Write("Pick an option: ");
                int value = int.Parse(Console.ReadLine());

                switch (value)
                {
                    case 1:
                        showTaskList();
                        continue;
                    case 2:
                        Task item = addNewTask();
                        //If no error add item
                        if (item != null) { list.Add(item); Console.WriteLine('\t' + "Thank you, a new task was successfully added." + '\n'); }
                        else { Console.WriteLine('\t' + "The task could not be added because an error occurred. Please try again" + '\n'); }
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

        /// <summary>
        /// Asks the user to enter which task to create
        /// </summary>
        /// <returns>An Task or null</returns>
        public Task addNewTask()
        {
            Task item = null;
            string newTask = '\t' + "What task do you want to create?" + '\n' +
                "\t(1) Shopping list\n" +
                "\t(2) Exercise round\n" +
                "\t(3) Buy bus ticket\n";

            Console.WriteLine(newTask);
            Console.Write("\tPick an option: ");
            int value = int.Parse(Console.ReadLine());

            switch (value)
            {
                case 1:
                    item = shoppingList();
                    break;
                case 2:
                    item = exercise();
                    break;
                case 3:
                    item = busTicket();
                    break;
            }

            return item;
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
            Console.WriteLine('\t' + "showTaskList()" + '\n');
        }

        /// <summary>
        /// Trying to create an object ShopingList
        /// </summary>
        /// <returns>An ShopingList or null</returns>
        private ShoppingList shoppingList()
        {
            ShoppingList item = null;

            try
            {
                Console.Write("\tEnter the name of the store: ");
                string shopName = Console.ReadLine();

                Console.Write("\tShopping list (text): ");
                string list = Console.ReadLine();

                Console.Write("\tTask title: ");
                string taskTitle = Console.ReadLine();

                Console.Write("\tDue date (Ex: 2022/05/09): ");
                string dueDate = Console.ReadLine();

                Console.Write("\n");

                item = new ShoppingList(shopName, list, taskTitle, DateTime.Parse(dueDate), true);
            }
            catch (Exception e)
            {
                item = null;
                Console.WriteLine('\t' + "Error: " + e.Message);
            }

            return item;
        }

        /// <summary>
        /// Trying to create an object Exercise
        /// </summary>
        /// <returns>An Exercise or null</returns>
        private Exercise exercise()
        {
            Exercise item = null;
            bool walk = false;
            bool run = false;

            try
            {
                Console.Write("\tEnter your decision to walk(1) or run(2): ");
                int exercise = int.Parse(Console.ReadLine());

                //If true set walk and run. else throw Exeption
                if (exercise == 1) { walk = true; run = false; }
                else if (exercise == 2) { walk = false; run = true; }
                else { throw new Exception("You must enter 1 or 2"); }

                Console.Write("\tEnter distance (In meters): ");
                int distance = int.Parse(Console.ReadLine());

                Console.Write("\tTask title: ");
                string taskTitle = Console.ReadLine();

                Console.Write("\tDue date (Ex: 2022/05/09): ");
                string dueDate = Console.ReadLine();

                Console.Write("\n");

                item = new Exercise(walk, run, distance, taskTitle, DateTime.Parse(dueDate), true);
            }
            catch (Exception e)
            {
                item = null;
                Console.WriteLine('\t' + "Error: " + e.Message);
            }

            return item;
        }

        /// <summary>
        /// Trying to create an object BusTicket
        /// </summary>
        /// <returns>An BusTicket or null</returns>
        private BusTicket busTicket()
        {
            BusTicket item = null;

            try
            {
                Console.Write("\tEnter ticket price: ");
                float price = float.Parse(Console.ReadLine());

                Console.Write("\tEnter area (Ex: Malmö C): ");
                string area = Console.ReadLine();

                Console.Write("\tTask title: ");
                string taskTitle = Console.ReadLine();

                Console.Write("\tDue date (Ex: 2022/05/09): ");
                string dueDate = Console.ReadLine();

                Console.Write("\n");

                item = new BusTicket(price, area, taskTitle, DateTime.Parse(dueDate), true);
            }
            catch (Exception e)
            {
                item = null;
                Console.WriteLine('\t' + "Error: " + e.Message);
            }

            return item;
        }
    }
}