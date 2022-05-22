using System;

namespace ToDoLy
{
    /// <summary>
    /// Reminds the user to buy a bus ticket
    /// </summary>
    public class BusTicket : Task
    {
        /// <summary>
        /// Creates a ToDoLy bus ticket
        /// </summary>
        /// <param name="price">The price of the bus ticket</param>
        /// <param name="area">Bus stop</param>
        /// <param name="taskTitle">Title</param>
        /// <param name="dueDate">Date when the task expires</param>
        /// <param name="status">Status can be active or inactive</param>
        public BusTicket(float price, string area, string taskTitle, DateTime dueDate, bool status)
        {
            this.Price = price;
            this.Area = area;
            base.TaskTitle = taskTitle;
            base.DueDate = dueDate;
            base.Status = status;
        }

        public float Price { get; set; }

        public string Area { get; set; }

        public override string ToString()
        {

            string outPut = "Testing";

            return outPut;
        }
    }
}