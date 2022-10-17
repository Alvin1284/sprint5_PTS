using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    //Marshal by Value
    [Serializable]
    public class Cohort
    {
        private int id;
        private string name;
        private TeamLeader leader;

        public int CohortId
        {
            get { return id; }
            set { id = value; }
        }

        public TeamLeader Leader
        {
            get { return leader; }
            set { leader = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Cohort(int id, string name, TeamLeader leader)
        {
         
            this.name = name;
            this.id = id;
            this.leader = leader;
        }
    }
}
