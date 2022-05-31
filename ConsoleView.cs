using ConsoleTableExt;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ToDoLy
{
    public class ConsoleView : IUser
    {
        static private List<Task> list = FileHelper.ReadJson(@"C:/Files/");

        List<ShoppingList> tempShoppingList = new List<ShoppingList>();
        List<Exercise> tempExerciseList = new List<Exercise>();
        List<BusTicket> tempBusTicketList = new List<BusTicket>();

        internal void start()
        {
            // Note: For testing only
            //private List<Task> list = new List<Task>();
            //list.Add(new ShoppingList("ICA Kvantum", "Mjölk, Smör, bröd.", "Inköp", DateTime.Parse("2022/04/2"), true) );
            //list.Add(new Exercise(false, true, 1000, "Motion", DateTime.Parse("2022/06/01"), true ) );
            //list.Add(new BusTicket(1199, "Malmö C", "Köp buss biljett", DateTime.Parse("2022/03/20"), true));
            //list.Add(new ShoppingList("Supermarket", "Frukost.", "Inköp", DateTime.Parse("2022/08/2"), false));
            //list.Add(new ShoppingList("Coop", "Panta flaskor", "Panta", DateTime.Parse("2022/01/2"), true));
            //list.Add(new Exercise(false, true, 1000, "Motion", DateTime.Parse("2022/06/03"), true));
            //list.Add(new Exercise(false, true, 1000, "Motion", DateTime.Parse("2022/06/06"), true));

            Boolean run = true;

            while (run)
            {
                int x = list.Count;
                int y = list.Where(x => !x.Status).Count(); //For false check

                string welcome = "Welcome to ToDoLy\n" +
                "You have " + x + " tasks todo and " + y + " tasks are done!\n" +
                "(1) Show Task List (by date or project)\n" +
                "(2) Add New Task\n" +
                "(3) Edit Task (update, mark as done, remove)\n" +
                "(4) Save and Quit\n";

                Console.WriteLine(welcome);
                Console.Write("Pick an option: ");
                int value = int.Parse(Console.ReadLine());

                try {
                    switch (value)
                    {
                        case 1:
                            showTaskList();
                            continue;
                        case 2:
                            Task item = addNewTask();
                            //If true add item
                            if (item != null) { list.Add(item); Console.WriteLine('\t' + "Thank you, a new task was successfully added." + '\n'); }
                            continue;
                        case 3:
                            editTask();
                            continue;
                        case 4:
                            FileHelper file = new FileHelper(@"C:/", "Files");
                            file.toJsonFile(list);
                            run = false;
                            break;
                    }
                }
                catch (Exception e) { Console.WriteLine('\t' + "\nError: " + e.Message + "\n"); }
            }
        }

        /// <summary>
        /// Show Task List (by date or project)
        /// </summary>
        public void showTaskList()
        {
            string sort = null;
            string showList = '\t' + "Show Task List (by date or project)" + '\n' +
                "\t(1) By date\n" +
                "\t(2) By project\n" +
                "\t(3) Go back\n";

            Console.WriteLine(showList);
            Console.Write("\tPick an option: ");
            int value = int.Parse(Console.ReadLine());
            Console.Write("\n");

            switch (value)
            {
                case 1:
                    sort = "sortByDate";
                    break;
                case 2:
                    sort = "sortByProject";
                    break;
                case 3:
                    break;
            }

            //If string is set, Display the sorted lists to the user
            if (sort != null) { printList(sort); }
        }

        /// <summary>
        /// Display the lists to the user
        /// </summary>
        /// <param name="sort">String must be set to either "sortByDate" or "sortByProject"</param>
        /// <exception cref="Exception">Throws exeption if sort is not set</exception>
        private void printList(string sort = null)
        {
            // 1. Must sort first
            if (sort == "sortByDate") { sortByDate(); }
            else if (sort == "sortByProject") { sortByProject(); }
            else { throw new Exception("An internal error occurred: Sort must be assigned!"); }

            List<Task> setId = new List<Task>();
            setId.AddRange(tempShoppingList);
            setId.AddRange(tempExerciseList);
            setId.AddRange(tempBusTicketList);

            int i = 1;
            // 2. Assign Id to all tasks
            foreach (Task task in setId)
            {
                task.Id = i;
                ++i;
            }

            //Display three tables
            ConsoleTableBuilder
                .From(tempShoppingList)
                .WithTitle("Shopping list ")
                .ExportAndWriteLine(TableAligntment.Center);

            ConsoleTableBuilder
                .From (tempExerciseList)
                .WithTitle("Exercice ")
                .ExportAndWriteLine(TableAligntment.Center);

            ConsoleTableBuilder
                .From(tempBusTicketList)
                .WithTitle("Buy bus ticket ")
                .ExportAndWriteLine(TableAligntment.Center);
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
                "\t(2) Exercise list\n" +
                "\t(3) Buy bus ticket list\n" + 
                "\t(4) Go back\n";

            Console.WriteLine(newTask);
            Console.Write("\tPick an option: ");
            int value = int.Parse(Console.ReadLine());

            switch (value)
            {
                case 1:
                    item = shoppingList();
                    break;
                case 2:
                    item = exerciseList();
                    break;
                case 3:
                    item = busTicketList();
                    break;
                case 4:
                    break;
            }

            return item;
        }

        /// <summary>
        /// User edit one Task
        /// </summary>
        /// <exception cref="Exception">Throws exeption if type does not exist</exception>
        public void editTask()
        {
            Task tempItem = null;

            //Display the sorted lists to the user
            printList("sortByDate");

            //The sorted list
            List<Task> sortedList = new List<Task>();
            sortedList.AddRange(tempShoppingList);
            sortedList.AddRange(tempExerciseList);
            sortedList.AddRange(tempBusTicketList);

            //Ask the user for Id
            string editTask = '\t' + "What task do you want to Edit? (Select a Id)";
            Console.WriteLine(editTask);
            Console.Write("\tPick an option: ");
            int valueId = int.Parse(Console.ReadLine());

            //The Task
            Task selectedTask = sortedList[--valueId];
            string type = selectedTask.GetType().ToString();
            int index = list.IndexOf(selectedTask);

            //Ask what the user wants to do with the task
            Console.WriteLine("\t" + selectedTask.ToString());
            string proceed = "\tThe task with Id:" + selectedTask.Id + " has been selected\n" +
                "\tHow do you want to proceed?\n" +
                "\t(1) Update task\n" +
                "\t(2) Mark as done\n" +
                "\t(3) Remove task\n" +
                "\t(4) Go back\n";

            Console.WriteLine(proceed);
            Console.Write("Pick an option: ");
            int value = int.Parse(Console.ReadLine());

            string text = "";

            switch (value)
            {
                case 1://Update task
                    if (type == "ToDoLy.ShoppingList") { tempItem = shoppingList(); }
                    else if (type == "ToDoLy.Exercise") { tempItem = exerciseList(); }
                    else if (type == "ToDoLy.BusTicket") { tempItem = busTicketList(); }
                    else { throw new Exception("An internal error occurred: Type does not exist!"); }
                    list[index] = tempItem;
                    text = "The task has been updated!";
                    break;
                case 2://Mark as done
                    list[index].Status = false;
                    text = "The task has been marked as done";
                    break;
                case 3://Remove task
                    list.Remove(selectedTask);
                    text = "The task has been removed";
                    break;
                case 4:
                    break;
            }

            Console.WriteLine( text ) ;
        }

        /// <summary>
        /// Sort a list by date
        /// </summary>
        private void sortByDate()
        {
            //Must run sort projects first
            sortByProject();

            //Sort the list by Date
            tempShoppingList = tempShoppingList.OrderBy(x => x.DueDate).ToList();
            tempExerciseList = tempExerciseList.OrderBy(x => x.DueDate).ToList();
            tempBusTicketList = tempBusTicketList.OrderBy(x => x.DueDate).ToList();
        }

        /// <summary>
        /// Sort a list by project
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void sortByProject()
        {
            //New empty lists
            tempShoppingList = new List<ShoppingList>();
            tempExerciseList = new List<Exercise>();
            tempBusTicketList = new List<BusTicket>();

            //Sort the list by Project
            foreach (Task task in list)
            {
                //If type is true, add to List 
                if (task is ShoppingList) { tempShoppingList.Add((ShoppingList)task); }
                else if (task is Exercise) { tempExerciseList.Add((Exercise)task); }
                else if (task is BusTicket) { tempBusTicketList.Add((BusTicket)task); }
                else { throw new Exception("An unexpected error occurred"); }
            }
        }

        public void save()
        {
            throw new System.NotImplementedException();
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
                Console.WriteLine('\t' + "\nError: " + e.Message + "\n");
            }

            return item;
        }

        /// <summary>
        /// Trying to create an object Exercise
        /// </summary>
        /// <returns>An Exercise or null</returns>
        private Exercise exerciseList()
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
                Console.WriteLine('\t' + "\nError: " + e.Message + "\n");
            }

            return item;
        }

        /// <summary>
        /// Trying to create an object BusTicket
        /// </summary>
        /// <returns>An BusTicket or null</returns>
        private BusTicket busTicketList()
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
                Console.WriteLine('\t' + "\nError: " + e.Message + "\n");
            }

            return item;
        }
    }
}