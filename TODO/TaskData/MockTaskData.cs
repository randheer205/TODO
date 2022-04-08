using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Models;

namespace TODO.TaskData
{
    public class MockTaskData : ITaskInterface
    {
        private List<Task> tasks = new List<Task>()
        {
            new Task()
            {
                Id=101,
                Name="Task1",
                Priority = "High",
                DueDate = "11-5-20002",
                CategoryName = "Fantasy",
                IsDeleted = false,
                Favourite = false
            },
            new Task()
            {
                Id=105,
                Name="Task8",
                Priority = "Low",
                DueDate = "11-12-20502",
                CategoryName = "Fantasy",
                IsDeleted = false,
                Favourite = false
            }
        };
        public Models.Task AddTask(Task task)
        {
            tasks.Add(task);
            return task;
        }

        public string DeleteTask(int id)
        {
            var gt = GetOneTask(id, "");
            if(gt!=null)
            {
                tasks.Remove(gt);
                return "Task Removed";
            }    
            else
            {
                return "No Such Task";
            }
        }

        public List<Task> GetAllTasks()
        {
            return tasks;
        }

        public Task GetOneTask(int id, String search)
        {
            return tasks.SingleOrDefault(x => x.Id == id);
        }

        public List<Task> GetTasks(string catname, string search)
        {
            throw new NotImplementedException();
        }

        public void MakeFavourite(int id)
        {
            var otask = GetOneTask(id,"");
            otask.Favourite = true;
        }

        public Task UpdateTask(int id,Task task)
        {
            var otask = GetOneTask(id, "");
            otask.CategoryName = task.CategoryName;
            otask.DueDate = task.DueDate;
            otask.Favourite = task.Favourite;
            otask.Name = task.Name;
            otask.Priority = task.Priority;
            return task;
        }
    }
}
