using System;

namespace ToDoLy
{
    public abstract class Task
    {
        public abstract int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string TaskTitle { get; set; }

        /// <summary>
        /// Date when the task expires
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Status can be active or inactive
        /// </summary>
        public bool Status { get; set; }

        public abstract override string ToString();
    }
}