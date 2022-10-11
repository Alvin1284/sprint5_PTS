using PTSLibrary;
using PTSLibrary.Facade_Objects;
using System.Reflection.Metadata;

namespace AdminApplication
{
    public partial class frmAdmin : Form
    {
        private PTSAdminFacade facade;
        private int adminId;
        private Student[] students;
        private Project[] projects;
        private Cohort[] cohorts;
        private Project selectedProject;
        private PTSLibrary.Task[] tasks;
        public frmAdmin()
        {
            InitializeComponent();
            facade = new PTSAdminFacade();
            adminId = 0;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                adminId = facade.Authenticate(this.txtUsername.Text, this.txtPassword.Text);
                if (adminId != 0)
                {
                    this.txtUsername.Text = "";
                    this.txtPassword.Text = "";
                    MessageBox.Show("Succesfully Logged in!");
                    tabControl1.SelectTab(1);
                    tabControl1.Enabled = true;
                }
                else
                {
                    tabControl1.SelectTab(0);
                    tabControl1.Enabled = false;
                    MessageBox.Show("Wrong Login Details");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                students = facade.GetListOfStudents();
                cbStudent.DataSource = students;
                cbStudent.DisplayMember = "Name";
                cbStudent.ValueMember = "id";
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if(txtProjectName.Text == "")
            {
                MessageBox.Show("You need to fill in the name field");
                return;
            }

            try
            {
                startDate = DateTime.Parse(txtProjectStart.Text);
                endDate = DateTime.Parse(txtProjectEnd.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("The date(s) are in the wrong format");
                return;
            }
            facade.CreateProject(txtProjectName.Text, startDate, endDate, (int)cbStudent.SelectedValue, adminId);
            txtProjectName.Text = "";
            txtProjectStart.Text = "";
            txtProjectEnd.Text = "";
            cbStudent.SelectedIndex = 0;
            MessageBox.Show("Proect Succesfully created");
            tabControl2.SelectTab(1);

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1)
            {
                projects = facade.GetListOfProjects(adminId);
                cbProjects.DataSource = projects;
                cbProjects.DisplayMember = "Name";
                cbProjects.ValueMember = "ProjectId";
                setProjectDetails();

                cohorts = facade.GetListOfCohorts();
                cbCohorts.DataSource = cohorts;
                cbCohorts.DisplayMember = "Name";
                cbCohorts.ValueMember = "CohortId";
            }
        }

        private void setProjectDetails()
        {
            selectedProject = projects[cbProjects.SelectedIndex];
            lblStartDate.Text = selectedProject.ExpectedStartDate.ToShortDateString();
            lblEndDate.Text = selectedProject.ExpectedEndDate.ToShortDateString();
            lblStudent.Text = ((Student)selectedProject.TheStudent).Name;
            UpdateTasks();
            
        }

        private void UpdateTasks()
        {
            tasks = facade.GetListOfTasks(selectedProject.ProjectId);
            lbTasks.DataSource = tasks;
            lbTasks.DisplayMember = "NameAndStatus";
            lbTasks.ValueMember = "TaskId";
        }

        private void cbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            setProjectDetails();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if(txtTaskName.Text == "")
            {
                MessageBox.Show("You need to fill in the name field");
                return;
            }

            try
            {
                startDate = DateTime.Parse(txtTaskName.Text);
                endDate = DateTime.Parse(txtTaskName.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("The date(s) are in the wrong format");
                return;
            }
            facade.CreateTask(txtTaskName.Text, startDate, endDate, (int)cbCohorts.SelectedValue, selectedProject.ProjectId);
            txtTaskName.Text = "";
            txtTaskStart.Text = "";
            txtTaskEnd.Text = "";
            cbCohorts.SelectedIndex = 0;
            MessageBox.Show("Task successfully created");
            UpdateTasks();
        }
    }
}