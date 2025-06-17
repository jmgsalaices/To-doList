using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using To_doList.DataServices;
using To_doList.Models;

namespace To_doList.ViewModels
{
    internal class TaskViewModel : INotifyPropertyChanged
    {
        //this use for interact underliyn service
        private readonly TaskDataService _taskDataService;
        //collecton propierty task object observable 
        private ObservableCollection<Task> _tasks;
        /// <summary>
        /// publc collecton propierty task object observable 
        /// the main here is when notify whe values changed over observable collection
        /// </summary>
        /// </summary>
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set 
            {
                _tasks = value; 
                OnPropertyChanged(nameof(Tasks));

            }
        }
        
        /// <summary>
        /// Porpierty changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// show alllist  task colection 
        /// </summary>
        private void LoadTasks()
        {
            var TaskList = _taskDataService.LoadTasks();
            Tasks = new ObservableCollection<Task>(TaskList);       
        }
        /// <summary>
        /// Add new Tassk in the observble collection
        /// </summary>
        /// <param name="newTask"></param>
        public void AddNewTask(Task newTask)
        {
            _taskDataService.AddTask(newTask);
            LoadTasks();
        }
        /// <summary>
        /// update object Tassk in the observble collection
        /// </summary>
        /// <param name="updateTask"></param>
        public void UpdateTask(Task updateTask)
        {
            _taskDataService.UpdateTsk(updateTask);
            LoadTasks();
        }
        /// <summary>
        /// Delete espefific Tassk id in the observble collection
        /// </summary>
        /// <param name="task"></param>
        public void DeleteTask(int task)
        {
            _taskDataService.DeleteTask(task);
            LoadTasks();
        }

        /// <summary>
        /// Contructor for  Tas view model class
        /// </summary>
        TaskViewModel()
        {
            _taskDataService = new TaskDataService();   
        }
        /// <summary>
        /// On propiertyChaged   : this method notify whe values changed over observable collection
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
