using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_doList.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsComplete { get; set; }
        public TimeSpan Timer { get; set; }
        public TaskState TaskState { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public TaskImportance TaskImportance { get; set; }
    }

    public enum TaskState
    {
        /// <summary>
        /// The Task is still in progress
        /// </summary>
        InProgress,
        /// <summary>
        /// The Task has been marked completed
        /// </summary>
        Complete,
        /// <summary>
        /// The task hasn't been started yet
        /// </summary>
        Notstarted,
        Late,
        Archived,
        Deleted
    }
    public enum TaskCategory
    {
        Work,
        Personal,
        Home,   
        HealtWebelbeing,
        Finance,
        Shoping,
        SocialFamily,
        Education,
        Travel,
        Errands,
        HobbiesLeisure,
        VolunteeringCommunity,
        BirthDayAnniversaries,
        Porjects,
        LongTermsGoals 
    }
    public enum TaskImportance
    { 
        /// <summary>
        /// THe task is low level performance
        /// </summary>
        Low,
        /// <summary>
        /// The task is medium level importance
        /// </summary>
        Medium,
        /// <summary>
        /// The task is high Level importnace
        /// </summary>
        High,
        /// <summary>
        /// The task is critical concern importance
        /// </summary>
        Critical
    }
}
