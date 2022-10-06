using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    [Serializable]
    public class Project
    {
        private string name;
        private DateTime expectedStartDate;
        private DateTime expectedEndDate;
        private Student theStudent;
        private Guid projectId;
        private List<Task> tasks;

        public List<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        public Student TheStudent
        {
            get { return theStudent; }
            set { theStudent = value; }
        }

        public Guid ProjectId
        {
            get { return projectId; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime ExpectedStartDate
        {
            get { return expectedStartDate; }
            set { expectedStartDate = value; }
        }

        public DateTime ExpectedEndDate
        {
            get { return expectedEndDate; }
            set { expectedEndDate = value; }
        }

        public Project(string name, DateTime startDate, DateTime endDate, Guid projectId, Student student)
        {
            this.name = name;
            this.expectedStartDate = startDate;
            this.expectedEndDate = endDate;
            this.projectId = projectId;
            this.theStudent = student;
        }

        public Project(string name, DateTime startDate, DateTime endDate, Guid projectId, List<Task> tasks)
        {
            this.name = name;
            this.expectedStartDate = startDate;
            this.expectedEndDate = endDate;
            this.projectId = projectId;
            this.tasks = tasks;
        }
    }
}
