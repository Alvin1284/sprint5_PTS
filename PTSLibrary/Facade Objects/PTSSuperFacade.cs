using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    public class PTSSuperFacade : MarshalByRefObject
    {
        protected DAO.SuperDAO dao;

        public PTSSuperFacade(DAO.SuperDAO dao)
        {
            this.dao = dao;
        }

        public Task[] GetListOfTasks(Guid projectId)
        {
            return dao.GetListOfTasks(projectId).ToArray();
        }
    }
}
