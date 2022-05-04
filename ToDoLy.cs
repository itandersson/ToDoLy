using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoLy
{
    internal class ToDoLy
    {
        static void Main(string[] args)
        {
            List<Task> list = new List<Task>();

            // Add task to the list.
            list.Add( new Task(DateTime.Parse("2022/01/2"), "Inköp", "Mjölk,Smör,bröd.") );
            list.Add( new Task(DateTime.Parse("2022/02/12"), "Motion", "1000 meter.") );
            list.Add( new Task(DateTime.Parse("2022/03/20"), "Köp buss biljett", "Till Malmö.") );


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
                int value = int.Parse( Console.ReadLine() );

                switch (value)
                {
                    case 1:
                        showTaskList(list);
                        continue;
                    case 2:
                        Task item = addNewTask();
                        list.Add(item);
                        Console.WriteLine('\t' + "Thank you, a new task was successfully added." + '\n');
                        continue;
                    case 3:
                        editTask(list);
                        continue;
                    case 4:
                        run = false;
                        break;
                }
            }
        }
        public static void showTaskList(List<Task> list)
        {
            List<Task> dateSorted = list.OrderBy(item => item.timeStart).ToList<Task>();
            List<Task> projectSorted = list.OrderBy(item => item.projectTitle).ToList<Task>();
            List<Task> sorted = null;
            string outPut = "";

            string text = "\tShow task list by date or project\n" +
                "\tPlease choose one of the options below,\n" +
                "\t(1) Date\n" +
                "\t(2) Project\n";

            Console.WriteLine(text);

            Console.Write("\tPick an option: ");
            int value = int.Parse(Console.ReadLine());

            //If user input 1
            if (value == 1)
            {
                sorted = dateSorted;
                outPut = "\tDate".PadRight(30) + "Project".PadRight(30) + "Text".PadRight(10);

                Console.WriteLine("\t______________________________________________________________________________");
                Console.WriteLine(outPut);
                Console.WriteLine("\t______________________________________________________________________________");

                foreach (Task task in sorted)
                {
                    string timeStart = (task.timeStart).ToString("yyyy/MM/dd");
                    Console.WriteLine("\t" + timeStart.PadRight(30) + (task.projectTitle).PadRight(30) +
                        (task.text).PadRight(10) + "\n");
                }
            }
            else
            {
                sorted = projectSorted;
                outPut = "\tProject".PadRight(30) + "Date".PadRight(30) + "Text".PadRight(10);

                Console.WriteLine("\t______________________________________________________________________________");
                Console.WriteLine(outPut);
                Console.WriteLine("\t______________________________________________________________________________");

                foreach (Task task in sorted)
                {
                    string timeStart = (task.timeStart).ToString("yyyy/MM/dd");
                    Console.WriteLine("\t" + (task.projectTitle).PadRight(30) + timeStart.PadRight(30) +
                        (task.text).PadRight(10) + "\n");
                }
            }
        }
        /// <summary>
        /// The user creates a new task
        /// </summary>
        public static Task addNewTask()
        {
            Console.WriteLine("\n\tCreate a new task below by entering title and text");
            Console.Write("\tProject title: ");
            string projectTitle = Console.ReadLine();

            Console.Write("\tProject text: ");
            string text = Console.ReadLine();

            Console.Write("\n");

            Task item = new Task(DateTime.Now, projectTitle, text);

            return item;
        }

        public static void editTask(List<Task> list)
        {
            int i = 0;
            Console.WriteLine("\n\tSelect the task nr you want to update, mark as finished or delete");


            string outPut = "\tDate".PadRight(30) + "Project".PadRight(30) + "Text".PadRight(10);

            Console.WriteLine("\t______________________________________________________________________________");
            Console.WriteLine(outPut);
            Console.WriteLine("\t______________________________________________________________________________");

            foreach (Task task in list ) 
            {
                Console.WriteLine( " Nr: " + i + "\t" + task.ToString() );
                i++;
            }

            Console.WriteLine("\t______________________________________________________________________________\n");

            Console.Write("\tSelect: ");
            string text = Console.ReadLine();

            Console.Write("\n");
        }
    }

    class Task
    {
        public DateTime timeStart { get; }
        private string timeEnd;
        public string projectTitle { get; }
        private Guid taskId;
        public string text { get; set; }

        public Task(DateTime timeStart, string projectTitle, string text)
        {
            //this.timeStart = DateTime.Now.ToString("h:mm:ss tt");
            this.timeStart = timeStart;
            this.taskId = new Guid();
            this.projectTitle = projectTitle;
            this.text = text;
        }

        public override string ToString() 
        {
            string timeStart = (this.timeStart).ToString("yyyy/MM/dd");

            string outPut = timeStart.PadRight(30) + (this.projectTitle).PadRight(30) +
                (this.text).PadRight(10);

            return outPut;
        }
    }
}
