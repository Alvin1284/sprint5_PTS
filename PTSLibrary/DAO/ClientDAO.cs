using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.DAO
{
    class ClientDAO : SuperDAO
    {
        public TeamLeader Authenticate(string username, string password)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            TeamLeader leader = null;
            sql = String.Format("SELECT DISTINCT Person.Name, UserId, TeamId FROM Person INNER JOIN Team ON(Team.TeamLeaderId = Person.UserId) WHERE Username = '{0}' AND Password = '{1}'", username, password);

            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    leader = new TeamLeader(dr["Name"].ToString(), (int)dr["CohortId"],
                   (int)dr["CohortId"]);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Accessing Database", ex);
            }
            finally
            {
                cn.Close();
            }
            return leader;
        }
        public List<Project> GetListOfProjects(int cohortId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Project> projects;
            projects = new List<Project>();
            sql = "SELECT P.* FROM Project AS P INNER JOIN Task AS T ON (P.ProjectId = T.ProjectId) WHERE T.CohortId = " + cohortId;
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student stud = GetStudent((int)dr["StudentId"]);
                    Project p = new Project(dr["Name"].ToString(), (DateTime)dr["ExpectedStartDate"],
                   (DateTime)dr["ExpectedEndDate"], (Guid)dr["ProjectId"], stud);
                    projects.Add(p);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list", ex);
            }
            finally
            {
                cn.Close();
            }
            return projects;
        }
    }
}
