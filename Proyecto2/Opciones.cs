using System;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;

namespace Proyecto2
{
    public partial class Opciones : Form
    {
        int Opcion, Id;
        string Pass, Alias, Nombre, Direccion;

        public static SqlCommand comando;
        public Opciones(int opcion, int id = 0, string alias = "", string pass = "", string nombre = "", string direccion="")
        {
            InitializeComponent();
            Opcion = opcion;
            Id = id;
            Pass = pass;
            Alias = alias;
            Nombre = nombre;
            Direccion = direccion;
            if (opcion == 2) incluirDatos();
        }
        private void incluirDatos()
        {
            txtAlias.Text = Alias;
            txtcontrasena.Text = Pass;
            txtDireccion.Text = Direccion;
            txtNombre.Text = Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtAlias.Text != "" && txtcontrasena.Text != "" && txtNombre.Text != "" && txtDireccion.Text != "")
            {
                if (Opcion == 1) { guardar();  }
                if (Opcion == 2) { actualizar(); }
            }
            else MessageBox.Show("Los campos no deben quedar vacios.");

        }
        

        private void txtAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) txtcontrasena.Focus();
        }

        private void txtcontrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtNombre.Focus();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtDireccion.Focus();
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAceptar.PerformClick();
        }

        public void limpiar()
        {
            txtAlias.Text = "";
            txtcontrasena.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";

        }
        private void procedimientoAlmacenado()
        {
            comando.Parameters.AddWithValue("@alias", txtAlias.Text);
            comando.Parameters.AddWithValue("@pass", txtcontrasena.Text);
            comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
            comando.Parameters.AddWithValue("@direccion", txtDireccion.Text);
        }

        private void actualizar()
        {
           
            try
            {
                if (txtAlias.Text != "" && txtcontrasena.Text != "" && txtNombre.Text != "" && txtDireccion.Text != "")
                {
                    Conexion.conexion.Open();
                    string queryUp = "UPDATE Empleados SET [Alias] = @alias, [Pass] = @pass, [Nombre] = @nombre, [Direccion] = @direccion WHERE Id_empleado = " + Id + "";
                    comando = new SqlCommand(queryUp, Conexion.conexion);
                    procedimientoAlmacenado();
                    comando.ExecuteNonQuery();
                    Conexion.conexion.Close();
                    MessageBox.Show("El registro ha sido actualizado exitosamente.");
                    this.Dispose();
                }
                else MessageBox.Show("Los campos no deben quedar vacios.");
            }
            catch(Exception o)
            {
                o.ToString();
            }
        }
        public void guardar()
        {
            try
            {
                if (txtAlias.Text != "" && txtcontrasena.Text != "" && txtNombre.Text != "" && txtDireccion.Text != "")
                {
                    string agregar = "INSERT INTO Empleados(Alias, Pass, Nombre, Direccion) VALUES(@alias, @pass, @nombre, @direccion)";
                    Conexion.conexion.Open();
                    comando = new SqlCommand(agregar, Conexion.conexion);
                    procedimientoAlmacenado();
                    comando.ExecuteNonQuery();
                    Conexion.conexion.Close();
                    MessageBox.Show("Se ha agregado exitosamente");
                    this.Dispose();
                }
                else MessageBox.Show("Los campos no deben quedar vacios.");
            }
            catch (Exception o)
            {
                o.ToString();
            }
            
        }

    }
}
