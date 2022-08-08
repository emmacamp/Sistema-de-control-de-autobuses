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
    public partial class Asignaciones : Form
    {
        private string IdAsignacion;
        private bool Edit = false;

        E_Asignacion objEntidad = new E_Asignacion();
        N_Asignacion objNegocio = new N_Asignacion();
        public Asignaciones()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    objEntidad.NombreChofer = txtNombreChofer.Text.ToUpper();
                    objEntidad.AutobusAsignado = txtAutobus.Text.ToUpper();
                    objEntidad.RutaAsignada = txtRutaAsignada.Text.ToUpper();

                    objNegocio.InsertandoAsignacion(objEntidad);

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
                    objEntidad.IdAsignacion = Convert.ToInt32(IdAsignacion);
                    objEntidad.NombreChofer = txtNombreChofer.Text.ToUpper();
                    objEntidad.AutobusAsignado = txtAutobus.Text.ToUpper();
                    objEntidad.RutaAsignada = txtRutaAsignada.Text.ToUpper();

                    objNegocio.EditandoAsignacion(objEntidad);

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

        private void Asignaciones_Load(object sender, EventArgs e)
        {
            Buscar("");
        }
        public void limpiar()
        {
            txtNombreChofer.Text = "";
            txtAutobus.Text = "";
            txtRutaAsignada.Text = "";

        }

        public void Buscar(string buscar)
        {
            N_Asignacion objNegocio = new N_Asignacion();
            tablaAsignacion.DataSource = objNegocio.ListarAsignacion(buscar);
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
            if (tablaAsignacion.SelectedRows.Count > 0)
            {
                objEntidad.IdAsignacion = Convert.ToInt32(tablaAsignacion.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EditandoAsignacion(objEntidad);

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

            if (tablaAsignacion.SelectedRows.Count > 0)
            {
                Edit = true;
                IdAsignacion = tablaAsignacion.CurrentRow.Cells[0].Value.ToString();
                txtNombreChofer.Text = tablaAsignacion.CurrentRow.Cells[1].Value.ToString();
                txtAutobus.Text = tablaAsignacion.CurrentRow.Cells[2].Value.ToString();
                txtRutaAsignada.Text = tablaAsignacion.CurrentRow.Cells[3].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar.");
            }
        }
    }
}
