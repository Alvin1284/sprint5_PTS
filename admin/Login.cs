using System;
using System.Windows.Forms;
using PTSLibrary;
using PTSLibrary.Facade_Objects;
namespace admin
{
    public partial class Login : Form
    {
  
        private PTSAdminFacade facade;
        private int Id;
        public Login()
        {
            InitializeComponent();
            facade = new PTSAdminFacade();
            Id = 0;
        }

        //Login Button 
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Id = facade.Authenticate(textBox1.Text, textBox2.Text);
                if (Id != 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Successfully logged in");
                    Home ob = new();
                    ob.Show();
                    

                }
                else
                {
                    MessageBox.Show("Incorrect Login details");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}