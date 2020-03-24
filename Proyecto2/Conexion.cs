using System.Data.OleDb;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Proyecto2
{
    class Conexion
    {
        public static SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-VE5DR71\\SQLEXPRESS;Initial Catalog=DBEmpleados;Integrated Security=True");
        
    }
}
