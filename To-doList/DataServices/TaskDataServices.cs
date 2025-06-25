using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;    

using System.Linq;
using System.Text;
using To_doList.Models;

namespace To_doList.DataServices
{
    public class TaskDataService
    {
        private readonly string _filepath;
        private readonly string folderName = "TaskTurnner";
        private readonly string fileName = "Task.json";

        public TaskDataService()
        {
            string addDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(addDataPath, folderName);
            string dataFolder = Path.Combine(appFolder, "data");

            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            _filepath = Path.Combine(dataFolder, fileName);

            InitializeFile();
        }

        private void InitializeFile()
        {
            if (!File.Exists(_filepath))
            {
                File.AppendAllText(_filepath, JsonConvert.SerializeObject(new List<Task>()));            
            }

            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName));
        }

        public List<Task> LoadTasks()
        {
            string fileContent = File.ReadAllText(_filepath);
            return JsonConvert.DeserializeObject<List<Task>>(fileContent);
        }

        public void SaveTask(List<Task> tasks)
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(_filepath, json); 
        }

        public void AddTask(Task newtask)
        {
            newtask.Id = GenerteNewTaskId();
            var task = LoadTasks();
            //adding the new task
            task.Add(newtask);
            //saving th new json string
            SaveTask(task);
                
        }

        public void DeleteTask(int taskId)
        {
            var tasks = LoadTasks();
            tasks.RemoveAll(t=> t.Id == taskId);
            SaveTask(tasks);

        }

        public void UpdateTsk(Task updateTask)
        {
            //loading the task from the json tasks          
            var tasks = LoadTasks();
           
            var taskIndex = tasks.FindIndex(x => x.Id == updateTask.Id);

            if (taskIndex == -1)
            {
                tasks[taskIndex] = updateTask;
                SaveTask(tasks);    
            }
            
        }

        public int GenerteNewTaskId()
        {
            var tasks = LoadTasks();

            if (!tasks.Any())
            {
                return 1;
            }

            int maxId = tasks.Max(t => t.Id);

            return maxId + 1;   
        }


    }
}
