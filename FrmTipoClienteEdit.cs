using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDesconectado
{
    public partial class FrmTipoClienteEdit : Form
    {
        DataRow fila;
        public FrmTipoClienteEdit(DataRow filaEditar = null)
        {
            InitializeComponent();
            if(filaEditar != null)
            {
                this.fila = filaEditar;
                this.Text = "editar registro";
                mostrarDatos();
            }
        }

        private void AceptarCambios(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text)) ;
            {
                MessageBox.Show("debe ingresar un nombre valido", "sistemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;

        }
        private void mostrarDatos()
        {
            txtNombre.Text = this.fila["nombre"].ToString();
        }
    }
}
