using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.DAO
{
    class AdminDAO : SuperDAO
    {
        public int Authenticate(string username, string password)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            sql = String.Format("SELECT UserId FROM Person WHERE IsAdministrator = 1 AND Username = '{0}' AND Password = '{1}'", username, password);

            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            int id = 0;
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    id = (int)dr["UserId"];
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
            return id;
        }
        public void CreateProject(string name, DateTime startDate, DateTime endDate, int studentId, int administratorId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            Guid projectId = Guid.NewGuid();
            sql = "INSERT INTO Project (ProjectId, Name, ExpectedStartDate, ExpectedEndDate,StudentId, AdministratorId)";
            sql += String.Format("VALUES ( '{0}', '{1}', '{2}', '{3}', {4}, {5})", projectId, name, startDate, endDate, studentId, administratorId);
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Inserting", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Student> GetListOfStudents()
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Student> students;
            students = new List<Student>();
            sql = "SELECT * FROM Student";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student c = new Student(dr["Name"].ToString(), (int)dr["StudentId"]);
                    students.Add(c);
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
            return students;
        }
        public List<Project> GetListOfProjects(int adminId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Project> projects;
            projects = new List<Project>();
            sql = "SELECT * FROM Project WHERE AdministratorId = " + adminId;
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student cust = GetStudent((int)dr["CustomerId"]);
                    Project p = new Project(dr["Name"].ToString(), (DateTime)dr["ExpectedStartDate"],
                   (DateTime)dr["ExpectedEndDate"], (Guid)dr["ProjectId"], cust);
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
        public List<Cohort> GetListOfCohorts()
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            List<Cohort> cohorts;
            cohorts = new List<Cohort>();
            sql = "SELECT * FROM Cohort";
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cohort t = new Cohort((int)dr["CohortId"],dr["Name"].ToString(), null);
                    cohorts.Add(t);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error getting team list", ex);
            }
            finally
            {
                cn.Close();
            }
            return cohorts;
        }
        public void CreateTask(string name, DateTime startDate, DateTime endDate, int cohortId, Guid projectId)
        {
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            Guid taskId = Guid.NewGuid();
            sql = "INSERT INTO Task (TaskId, Name, ExpectedDateStarted, ExpectedDateCompleted,ProjectId, CohortId, StatusId)";
            sql += String.Format("VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6})", taskId, name, startDate, endDate, projectId, cohortId, 1);
            cn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd = new SqlCommand(sql, cn);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Inserting", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
