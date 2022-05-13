using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoLy
{
    public interface IUser
    {
        void showTaskList();
        void AddNewTask();
        void editTask();
        void save();
    }
}