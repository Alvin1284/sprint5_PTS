using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    public class PTSAdminFacade : PTSSuperFacade
    {
        private DAO.AdminDAO dao;
        public PTSAdminFacade() : base(new DAO.AdminDAO())
        {
            dao = (DAO.AdminDAO)base.dao;
        }
        public int Authenticate(string username, string password)
        {
            if (username == "" || password == "")
            {
                throw new Exception("Missing Data");
            }
            return dao.Authenticate(username, password);
        }
        public void CreateProject(string name, DateTime startDate, DateTime endDate, int studentId, int adminId)
        {
            if (name == null || name == "" || startDate == null || endDate == null)
            {
                throw new Exception("Missing Data");
            }
            dao.CreateProject(name, startDate, endDate, studentId, adminId);
        }
        public Student[] GetListOfStudents()
        {
            return (dao.GetListOfStudents()).ToArray();
        }
        public Project[] GetListOfProjects(int adminId)
        {
            return (dao.GetListOfProjects(adminId)).ToArray();

        }
        public Cohort[] GetListOfCohorts()
        {
            return (dao.GetListOfCohorts()).ToArray();
        }
        public void CreateTask(string name, DateTime startDate, DateTime endDate, int cohortId, Guid projectId)
        {
            if (name == null || name == "" || startDate == null || endDate == null)
            {
                throw new Exception("Missing Data");
            }
            dao.CreateTask(name, startDate, endDate, cohortId, projectId);
        }
    }
}
