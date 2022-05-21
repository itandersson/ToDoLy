using System;

namespace ToDoLy
{
    public abstract class Task
    {
        /// <summary>
        /// Title
        /// </summary>
        public string TaskTitle
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Date when the task expires
        /// </summary>
        public DateTime DueDate
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Status can be active or inactive
        /// </summary>
        public bool Status
        {
            get => default;
            set
            {
            }
        }
    }
}