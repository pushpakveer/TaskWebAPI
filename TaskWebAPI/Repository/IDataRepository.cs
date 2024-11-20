namespace TaskWebAPI.Repository
{
    public interface IDataRepository
    {
        public void AddTask(Models.Task task);

        public bool DeleteTaskById(int id);

        public List<Models.Task> FindAllTasks();

        public Models.Task FindTaskById(int id);

        public bool UpdateStatus(int id);

        public bool UpdateTask(int id, Models.Task task);
        
    }
}
