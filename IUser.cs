namespace ToDoLy
{
    public interface IUser
    {
        void showTaskList();
        Task addNewTask();
        void editTask();
        void save();
    }
}