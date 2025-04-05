using ClnMinerva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpMinerva
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ProductoCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["codigo"].HeaderText = "Código";
            dgvLista.Columns["descripcion"].HeaderText = "Descripción";
            dgvLista.Columns["unidadMedida"].HeaderText = "Unidad de Medida";
            dgvLista.Columns["saldo"].HeaderText = "Saldo";
            dgvLista.Columns["precioVenta"].HeaderText = "Precio de Venta";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";
            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["codigo"];
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size = new Size(835, 362);
            listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(835, 362);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Size = new Size(835, 487);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
    }
}
