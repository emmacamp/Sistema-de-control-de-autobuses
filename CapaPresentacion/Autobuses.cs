using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class Autobuses : Form
    {
        private string IdAutobus;
        private bool Edit = false;

        E_Autobuses objEntidad = new E_Autobuses();
        N_Autobuses objNegocio = new N_Autobuses();
        public Autobuses()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Autobuses_Load(object sender, EventArgs e)
        {
            Buscar("");
        }
        public void limpiar()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtPlaca.Text = "";
            txtColor.Text = "";
            txtAño.Text = "";
            txtCondicion.Text = "";
            txtCapacidad.Text = "";

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    objEntidad.Marca = txtMarca.Text.ToUpper();
                    objEntidad.Modelo = txtModelo.Text.ToUpper();
                    objEntidad.Placa = txtPlaca.Text.ToUpper();
                    objEntidad.Color = txtColor.Text.ToUpper();
                    objEntidad.Año = Convert.ToInt32(txtAño.Text);
                    objEntidad.Condicion = txtCondicion.Text.ToUpper();
                    objEntidad.Capacidad = txtCapacidad.Text.ToUpper();

                    objNegocio.InsertandoAutobus(objEntidad);

                    MessageBox.Show("Registro guardado.");
                    limpiar();
                    Buscar("");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro." + ex);
                }
            }
            if (Edit == true)
            {
                try
                {
                    objEntidad.IdAutobus = Convert.ToInt32(IdAutobus);
                    objEntidad.Marca = txtMarca.Text.ToUpper();
                    objEntidad.Modelo = txtModelo.Text.ToUpper();
                    objEntidad.Placa = txtPlaca.Text.ToUpper();
                    objEntidad.Color = txtColor.Text.ToUpper();
                    objEntidad.Año = Convert.ToInt32(txtAño.Text);
                    objEntidad.Condicion = txtCondicion.Text.ToUpper();
                    objEntidad.Capacidad = txtCapacidad.Text.ToUpper();

                    objNegocio.EditandoAutobus(objEntidad);

                    MessageBox.Show("Registro editado exitosamente.");
                    Buscar("");
                    limpiar();
                    Edit = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro." + ex);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void Buscar(string buscar)
        {
            N_Autobuses objNegocio = new N_Autobuses();
            tablaAutobuses.DataSource = objNegocio.ListarAutobuses(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaAutobuses.SelectedRows.Count > 0)
            {
                objEntidad.IdAutobus = Convert.ToInt32(tablaAutobuses.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoAutobus(objEntidad);

                MessageBox.Show("El registro ha sido eliminado.");
                Buscar("");
            }
            else
            {
                MessageBox.Show("Seleccione un registro a eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaAutobuses.SelectedRows.Count > 0)
            {
                Edit = true;
                IdAutobus = tablaAutobuses.CurrentRow.Cells[0].Value.ToString();
                txtMarca.Text = tablaAutobuses.CurrentRow.Cells[1].Value.ToString();
                txtModelo.Text = tablaAutobuses.CurrentRow.Cells[2].Value.ToString();
                txtPlaca.Text = tablaAutobuses.CurrentRow.Cells[3].Value.ToString();
                txtColor.Text = tablaAutobuses.CurrentRow.Cells[4].Value.ToString();
                txtAño.Text = tablaAutobuses.CurrentRow.Cells[5].Value.ToString();
                txtCondicion.Text = tablaAutobuses.CurrentRow.Cells[6].Value.ToString();
                txtCapacidad.Text = tablaAutobuses.CurrentRow.Cells[7].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar.");
            }
        }
    }
}
