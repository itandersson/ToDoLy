using System;

namespace ToDoLy
{
    /// <summary>
    /// Lists items to buy
    /// </summary>
    public class ShoppingList : Task
    {
        /// <summary>
        /// Creates a shopping list
        /// </summary>
        /// <param name="shopName">The name of the store</param>
        /// <param name="list">Shopping list</param>
        /// <param name="taskTitle">Title</param>
        /// <param name="dueDate">Date when the task expires</param>
        /// <param name="status">Status can be active or inactive</param>
        public ShoppingList(string shopName, string list, string taskTitle, DateTime dueDate, bool status)
        {
            this.ShopName = shopName;
            this.List = list;
            base.TaskTitle = taskTitle;
            base.DueDate = dueDate;
            base.Status = status;
        }

        public string ShopName { get; set; }

        public string List { get; set; }

        public override string ToString()
        {
            string timeStart = (base.DueDate).ToString("yyyy/MM/dd");

            string outPut = this.ShopName + ", " + this.List + ", " + base.TaskTitle;

            return outPut;
        }
    }
}