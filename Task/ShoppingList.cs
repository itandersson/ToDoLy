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
            ShopName = shopName;
            List = list;
            base.TaskTitle = taskTitle;
            base.DueDate = dueDate;
            base.Status = status;
        }

        public string ShopName
        {
            get => default;
            set
            {
            }
        }

        public string List
        {
            get => default;
            set
            {
            }
        }
    }
}