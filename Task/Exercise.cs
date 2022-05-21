using System;

namespace ToDoLy
{
    /// <summary>
    /// Reminds the user to go for a walk or run
    /// </summary>
    public class Exercise : Task
    {
        /// <summary>
        /// Date to go out and exercise
        /// </summary>
        /// <param name="walk">To walk</param>
        /// <param name="run">To run</param>
        /// <param name="distance">The distance in meters</param>
        /// <param name="taskTitle">Title</param>
        /// <param name="dueDate">Date when the task expires</param>
        /// <param name="status">Status can be active or inactive</param>
        public Exercise(bool walk, bool run, int distance, string taskTitle, DateTime dueDate, bool status)
        {
            Walk = walk;
            Run = run;
            Distance = distance;
            base.TaskTitle = taskTitle;
            base.DueDate = dueDate;
            base.Status = status;
        }

        public bool Walk
        {
            get => default;
            set
            {
            }
        }

        public bool Run
        {
            get => default;
            set
            {
            }
        }

        public int Distance
        {
            get => default;
            set
            {
            }
        }
    }
}