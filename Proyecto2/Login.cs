using System;

using System.Data.Sql;
using System.Data.SqlClient;


using System.Windows.Forms;

namespace Proyecto2
{
    public partial class Login : Form
    {
        private string usuario, pass;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            pass = txtPass.Text;

            if (txtUsuario.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Los campos no deben quedar vacios.");
                txtUsuario.Focus();
                return;
            }
            else
            {
                Conexion.conexion.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Empleados WHERE Alias = '" + txtUsuario.Text + "' AND Pass = '" + txtPass.Text + "'", Conexion.conexion);
                SqlDataReader lector = comando.ExecuteReader();
                
                
                if(lector.Read() == true)
                {
                    Padre abrir = new Padre();
                    this.Hide();
                    abrir.Show();
                    
                    Conexion.conexion.Close();

                }
                else
                {
                    MessageBox.Show("Su nombre de usuario o contraseña son incorrectos.");
                    Conexion.conexion.Close();
                }

            }
                
        }

        public Login()
        {
            InitializeComponent();
            txtUsuario.Focus();
            
        }




    }
}
