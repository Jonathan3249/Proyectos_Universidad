using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System;

namespace Proyecto2
{
    public partial class Empleados : Form
    {
        public static SqlCommand comando;
        public Empleados()
        {
            InitializeComponent();
            Cone();
        }

        public void Cone()
        {
            comando = new SqlCommand(@"Select * From Empleados", Conexion.conexion);
            Conexion.conexion.Open();
            DataTable tabla = new DataTable();
            SqlDataAdapter usar = new SqlDataAdapter(comando);
            usar.Fill(tabla);
            dataGridView1.DataSource = tabla;
            Conexion.conexion.Close();

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Opciones addDatos = new Opciones(1);           
            addDatos.ShowDialog();
            Cone();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string alias = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string contrasena = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string direccion = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            Opciones llamada1 = new Opciones(2, id, alias, contrasena, nombre, direccion);
            llamada1.ShowDialog();
            Cone();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           if ( e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    try
                    {
                        DialogResult respuesta = MessageBox.Show("Esta seguro de eliminar?",
                                        "confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (respuesta == DialogResult.Yes)
                        {
                            string query = "DELETE FROM Empleados  WHERE Id_empleado = " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
                            comando = new SqlCommand(query, Conexion.conexion);
                            Conexion.conexion.Open();
                            comando.ExecuteNonQuery();
                            Conexion.conexion.Close();
                            MessageBox.Show("Cliente Eliminado Exitosamente");
                            Cone();
                        }
                        else if (respuesta == DialogResult.No) Cone();
                    }
                    catch (Exception oo)
                    {
                        Conexion.conexion.Close();
                        MessageBox.Show(oo.ToString());
                    }
                }
                else MessageBox.Show("Seleccione algun dato de la tabla");

            }

        }
    }
}
