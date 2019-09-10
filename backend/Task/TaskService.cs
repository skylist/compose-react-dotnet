using System.Collections.Generic;
using backend.config;
using MongoDB.Driver;

namespace backend.task
{
    public class TaskService
    {
        private readonly IMongoCollection<Task> _mongoService;

        public TaskService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _mongoService = database.GetCollection<Task>(settings.DatabaseName);
        }
        public List<Task> getTaskList()
        {
            return _mongoService.Find(task => true).ToList();
        }
        public Task findTask(string id)
        {
            return _mongoService.Find(task => task._id == id).FirstOrDefault();
        }
        public Task createTask(Task task)
        {
            _mongoService.InsertOne(task);
            return task;
        }
        public void updateTask(string id, Task updatedTask)
        {
            _mongoService.ReplaceOne(task => task._id == id, updatedTask);
        }

        public void deleteTask(string id)
        {
            _mongoService.DeleteOne(task => task._id == id);
        }
    }
}