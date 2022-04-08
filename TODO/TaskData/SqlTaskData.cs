using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Models;

namespace TODO.TaskData
{
    public class SqlTaskData : ITaskInterface
    {
        TasksAppContext _tac; 
        public SqlTaskData(TasksAppContext tac)
        {
            _tac = tac;
        }
        public Models.Task AddTask(Models.Task task)
        {
            _tac.Tasks.Add(task);
            _tac.SaveChanges();
            return task;
        }

        public string DeleteTask(int id)
        {
            var ot = GetOneTask(id, "");
            if(ot!=null)
            {
                _tac.Tasks.Remove(ot);
                _tac.SaveChanges();
                return "Success";
            }
            else
            {
                return "No Such Task with that ID";
            }
        }

        public List<Models.Task> GetAllTasks()
        {
            return _tac.Tasks.ToList();
        }

        public Models.Task GetOneTask(int id, string search)
        {
            var result = _tac.Tasks.Find(id);
            return result;
        }

        public List<Models.Task> GetTasks(string catname, string search)
        {
            List<Models.Task> alltask = GetAllTasks();
            List<Models.Task> cattask = new List<Models.Task>();
            for(int i=0; i<alltask.Count;i++)
            {
                if(alltask[i].CategoryName==catname)
                {
                    cattask.Add(alltask[i]);
                }
            }
            if(cattask!=null)
            {
                return cattask;
            }
            else
            {
                return null;
            }
        }

        public void MakeFavourite(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Task UpdateTask(int id, Models.Task task)
        {
            var ot = GetOneTask(id, "");
            if(ot!=null)
            {
                ot.CategoryName = task.CategoryName;
                ot.DueDate = task.DueDate;
                ot.Name = task.Name;
                ot.Priority = task.Priority;
                ot.Favourite = task.Favourite;
                _tac.Tasks.Update(ot);
                _tac.SaveChanges();
                return task;
            }
            return null;
        }
    }
}
