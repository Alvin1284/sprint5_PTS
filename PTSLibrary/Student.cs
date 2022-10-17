using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary
{
    //Marshal by value
    [Serializable]
    public class Student : User
    {
        public Student(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
