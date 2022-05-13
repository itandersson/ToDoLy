using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoLyV1
{
    internal class ToDoLyV1
    {
        static void Main2(string[] args)
        {
            List<Task2> list = new List<Task2>();

            // Add task to the list.
            list.Add( new Task2(DateTime.Parse("2022/01/2"), "Inköp", "Mjölk,Smör,bröd.") );
            list.Add( new Task2(DateTime.Parse("2022/02/12"), "Motion", "1000 meter.") );
            list.Add( new Task2(DateTime.Parse("2022/03/20"), "Köp buss biljett", "Till Malmö.") );


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
                        Task2 item = addNewTask();
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
        public static void showTaskList(List<Task2> list)
        {
            List<Task2> dateSorted = list.OrderBy(item => item.timeStart).ToList<Task2>();
            List<Task2> projectSorted = list.OrderBy(item => item.projectTitle).ToList<Task2>();
            List<Task2> sorted = null;
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

                foreach (Task2 task in sorted)
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

                foreach (Task2 task in sorted)
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
        public static Task2 addNewTask()
        {
            Console.WriteLine("\n\tCreate a new task below by entering title and text");
            Console.Write("\tProject title: ");
            string projectTitle = Console.ReadLine();

            Console.Write("\tProject text: ");
            string text = Console.ReadLine();

            Console.Write("\n");

            Task2 item = new Task2(DateTime.Now, projectTitle, text);

            return item;
        }

        public static void editTask(List<Task2> list)
        {
            Console.WriteLine("\n\tSelect the task you want to update, mark as finished or delete");


            string outPut = "\tProject".PadRight(30) + "Date".PadRight(30) + "Text".PadRight(10);

            Console.WriteLine("\t______________________________________________________________________________");
            Console.WriteLine(outPut);
            Console.WriteLine("\t______________________________________________________________________________");

            foreach (Task2 task in list ) 
            {
                Console.WriteLine( "\t" + task.ToString() );
            }

            Console.WriteLine("\t______________________________________________________________________________\n");

            Console.Write("\tProject: ");
            string input = Console.ReadLine();

            //Retrieve the first object that matches the input
            List<Task2> matches = list.Where(task => task.projectTitle == input).ToList<Task2>();
            Task2 firstMatche = matches.First<Task2>();

            Console.WriteLine("Test: " + matches.First<Task2>()) ;

            Console.Write("\n");
        }
    }

    class Task2
    {
        public DateTime timeStart { get; }
        private string timeEnd;
        public string projectTitle { get; }
        private Guid taskId;
        public string text { get; set; }

        public Task2(DateTime timeStart, string projectTitle, string text)
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

            string outPut = (this.projectTitle).PadRight(30) + timeStart.PadRight(30) +
                (this.text).PadRight(10);

            return outPut;
        }
    }
}
