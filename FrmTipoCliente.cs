using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdoNetDesconectado
{
    public partial class FrmTipoCliente : Form
    {
        //creamos la cadena de conexion y creamos un alias para sqldataadapter , sqlconection y el dataset

        string cadenaconxion = @"Server=localhost\SQLEXPRESS ; DataBase=BancoBD ; integrated security = true";
        SqlDataAdapter adaptador;
        SqlConnection conexion;
        DataSet datos;
        public FrmTipoCliente()
        {
            InitializeComponent();

            //creamos la instancia de la conexion

            conexion = new SqlConnection(cadenaconxion);

            //creamos la instancia del dataset

            datos = new DataSet();

            //creamos la instancia del adaptador

            adaptador = new SqlDataAdapter();

            //configuramos los metodos del adaptador

            adaptador.SelectCommand = new SqlCommand("SELECT * FROM TipoCliente ", conexion);

            adaptador.InsertCommand = new SqlCommand("INSERT INTO TipoCliente(nombre) VALUES(@NOMBRE)");
            adaptador.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 20, "nombre");
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cargarformulario(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            //llenar datos al dataset (datatable TipoCliente)
            adaptador.Fill(datos, "TipoCliente");

            //enlaxarlos datos a Datagredview

            dgvDatos.DataSource = datos.Tables["TipoCliente"];

        }

        private void NuevoRegistro(object sender, EventArgs e)
        {
            var frm = new FrmTipoClienteEdit();
           if(frm.ShowDialog() == DialogResult.OK)
            {
                var nuevaFila = datos.Tables["tipoCliente"].NewRow();
                nuevaFila["nombre"] = frm.Controls["txtnombre"].Text;

                datos.Tables["TipoCliente"].Rows.Add(nuevaFila);
                adaptador.Update(datos.Tables["TipoCliente"]);

            }
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            var filaActual = dgvDatos.CurrentRow;
                if (filaActual != null);
            {
                var ID = filaActual.Cells[0].Value.ToString();
                DataRow fila = datos.Tables["TipoCliente"].Select($"ID={ID}").FirstOrDefault();
            }
            var frm = new FrmTipoClienteEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("presionastes OK");
            }

           
        }
    }
}
