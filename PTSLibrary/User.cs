using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    //Marshal by Value
    [Serializable]
    public class User
    {
        protected string name;
        protected int id;

        public string Name
        {
            get { return name; }
        }

        public int Id
        {
            get { return id; }
        }
    }
}
