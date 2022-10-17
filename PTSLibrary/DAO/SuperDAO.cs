using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PTSLibrary.DAO
{
    public class SuperDAO
    {
        protected Student GetStudent(int studId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            Student stud;
            sql = "SELECT * FROM Student WHERE StudentId = " + studId;
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                dr.Read();
                stud = new Student(dr["Name"].ToString(), (int)dr["StudentId"]);
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting Student", ex);
            }
            finally
            {
                cn.Close();
            }
            return stud;
        }
        public List<Task> GetListOfTasks(Guid projectId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Task> tasks;
            tasks = new List<Task>();
            sql = "SELECT * FROM Task WHERE ProjectId = '" + projectId + "'";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Task t = new Task((Guid)dr["TaskId"], dr["TaskName"].ToString(),
                   (Status)((int)dr["StatusId"]));
                    tasks.Add(t);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error getting taks list", ex);
            }
            finally
            {
                cn.Close();
            }
            return tasks;
        }
    }
}
