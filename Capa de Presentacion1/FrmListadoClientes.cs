using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using CapaLogicaNegocio;

namespace Capa_de_Presentacion1
{
    public partial class FrmListadoClientes : DevComponents.DotNetBar.Metro.MetroForm
    {
        private clsCliente C = new clsCliente();

        int Listado = 0;

        public FrmListadoClientes()
        {
            InitializeComponent();
        }

        private void FrmListadoClientes_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 5000;
            ListarClientes();
            dataGridView1.ClearSelection();
        }

        private void ListarClientes() {
            DataTable dt = new DataTable();
            dt = C.Listado();
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0]);
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                }
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    DevComponents.DotNetBar.MessageBoxEx.Show("La Fila no debe Estar Seleccionada.");
            //}
            //else
            //{
                FrmRegistroCliente C = new FrmRegistroCliente(); 
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
                C.Show();
            //}
                ListarClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FrmRegistroCliente FrmC = new FrmRegistroCliente();
                FrmC.txtDni.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                FrmC.txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                FrmC.txtNombres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                FrmC.txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                FrmC.txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                FrmC.txtDni.Focus();
                FrmC.Show();
                if (dataGridView1.SelectedRows.Count > 0)
                    Program.Evento = 1;
                else
                    Program.Evento = 0;
                dataGridView1.ClearSelection();
            }
            else {
                DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Seleccione la Fila a Editar.","Sistema de Ventas.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            ListarClientes();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    timer1.Start();
                //MessageBox.Show("Se Prisiono la tecla enter");


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.ClearSelection();
            if (e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                C.Dni = txtBuscarCliente.Text;
                dt = C.BuscarCliente(C.Dni);
                try
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dt.Rows[i][0]);
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][5].ToString();
                    }
                    dataGridView1.ClearSelection();
                    timer1.Stop();
                }
                catch (Exception ex)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
                }
            }
            else {
                ListarClientes();
                timer1.Start();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
                timer1.Stop();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(DevComponents.DotNetBar.MessageBoxEx.Show("¿Está Seguro que Desea Sair.?", "Sistema de Ventas.", MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Listado) {
                case 0: ListarClientes(); break;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Program.IdCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.DocumentoIdentidad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Program.ApellidosCliente = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Program.NombreCliente = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) {
                if (e.KeyChar == 13){
                    DialogResult Resultado = new DialogResult();
                    Resultado = DevComponents.DotNetBar.MessageBoxEx.Show("Está Seguro que Desea Editar Los Datos del Cliente.", "Sistema de Ventas.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (Resultado == DialogResult.Yes){
                        FrmRegistroCliente FrmC = new FrmRegistroCliente();
                        FrmC.txtDni.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        FrmC.txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        FrmC.txtNombres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        FrmC.txtDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        FrmC.txtTelefono.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        FrmC.txtDni.Focus();
                        FrmC.Show();
                        if (dataGridView1.SelectedRows.Count > 0)
                            Program.Evento = 1;
                        else
                            Program.Evento = 0;
                        dataGridView1.ClearSelection();
                    }else {
                        dataGridView1.ClearSelection();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
