using TaskWebAPI.Helpers;
using TaskWebAPI.Models;
using Task = TaskWebAPI.Models.Task;
using TaskStatus = TaskWebAPI.Helpers.TaskStatus;

namespace TaskWebAPI.Repository
{
    public class DataRepository:IDataRepository
    {
         List<Task> tasks;

        public DataRepository() 
        {
            tasks = new List<Task>();
        }

        public void AddTask(Models.Task task)
        {   
            task.Created_At = DateTime.Now;  //Adding Time at Backend
            task.Updated_At = null;  //Even if added time during post request it is set null
            tasks.Add(task);
        }

        public bool DeleteTaskById(int id)
        {
            Task taskToRemove = tasks.Find(item => item.Id == id);
            if (taskToRemove!= null)
            {
                tasks.Remove(taskToRemove);
                return true;
            }

            return false;
        }

        public List<Models.Task> FindAllTasks()
        {
            return tasks;
        }

        public Models.Task FindTaskById(int id)
        {
            Task task = tasks.Find(item => item.Id == id);
            return task;
        }

        public bool UpdateStatus(int id)
        {
            Task task = tasks.Find(item => item.Id == id);
            if (task is not null)
            {
                task.Status = TaskStatus.Completed.ToString();
                task.Updated_At= DateTime.Now;  //Updated time in Backend
                return true;
            }
           
            return false;


        }

        public bool UpdateTask(int id, Models.Task task)
        {
            Task taskToUpdate=tasks.Find(item=>item.Id == id);
            
            if (taskToUpdate != null)
            {
                taskToUpdate.Updated_At = DateTime.Now;
                taskToUpdate.Due_Date = task.Due_Date;
                taskToUpdate.Status = task.Status;
                taskToUpdate.Title=task.Title;
                taskToUpdate.Description=task.Description;

                return true;
                
            }
            return false;
        }
    }
}
