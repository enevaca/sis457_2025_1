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
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotal.Text) && !string.IsNullOrEmpty(txtEfectivo.Text))
            { 
                txtCambio.Text = (Convert.ToDouble(txtEfectivo.Text) - Convert.ToDouble(txtTotal.Text)).ToString();
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            dtpFecha.MaxDate = DateTime.Now;
        }
    }
}
