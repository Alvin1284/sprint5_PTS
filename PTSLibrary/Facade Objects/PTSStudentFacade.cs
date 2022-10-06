using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Facade_Objects
{
    public class PTSStudentFacade : PTSSuperFacade
    {
        private DAO.StudentDAO dao;

        public PTSStudentFacade() : base(new DAO.StudentDAO())
        {
            dao = (DAO.StudentDAO)base.dao;
        }

        public Project[] GetListOfProjects(int studentId)
        {
            return (dao.GetListOfProjects(studentId)).ToArray();
        }
    }
}
