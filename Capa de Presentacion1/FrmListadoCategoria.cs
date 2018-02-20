using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaLogicaNegocio;

namespace Capa_de_Presentacion1
{
    public partial class FrmListadoCategoria : Form
    {
        private clsCategoria C = new clsCategoria();

        public FrmListadoCategoria()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("La Fila no debe Estar Seleccionada.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                FrmRegistrarCategoria C = new FrmRegistrarCategoria();
                C.Show();
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
        }

        private void FrmListadoCategoria_Load(object sender, EventArgs e)
        {
            ListarElementos();
            dataGridView1.ClearSelection();
        }

        private void ListarElementos() {
            dataGridView1.ClearSelection();
            DataTable dt = new DataTable();
            dt = C.Listar();
            try
            {
                dataGridView1.Rows.Clear();
            for (int i = 0; i <dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i][0]);
                dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
            }
            }
            catch (Exception ex)
            {   
                throw ex;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
        }

        private void txtBuscarCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ListarBusqueda();
            }
            else {
                ListarElementos();
            }
        }

        private void ListarBusqueda(){
            try
            {
            DataTable dt = new DataTable();
            clsCategoria C = new clsCategoria();
            C.Descripcion = txtBuscarCategoria.Text;
            dt = C.BuscarCategoria(C.Descripcion);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dt.Rows[i][0]);
                dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FrmRegistrarCategoria C = new FrmRegistrarCategoria();
                C.IdC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                C.txtCategoria.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
                C.Show();
            }
            else {
                MessageBox.Show("Debe Seleccionar la Fila a Editar Datos.","Sistema de Ventas",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Cancelar la Acción Realizada", "Sistema de Ventas.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
