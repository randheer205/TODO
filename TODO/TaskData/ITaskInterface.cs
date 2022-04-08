using System;
using System.Collections.Generic;
using TODO.Models;


namespace TODO.TaskData
{
    public interface ITaskInterface
    {
        public List<Task> GetAllTasks();

        public List<Task> GetTasks(String catname,String search);
        public Task AddTask(Task task);
        public Task UpdateTask(int id,Task task);
        public Task GetOneTask(int id,String search);
        public void MakeFavourite(int id);
        public String DeleteTask(int id);
    }
}
