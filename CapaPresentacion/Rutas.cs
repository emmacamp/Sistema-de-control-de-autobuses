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
    public partial class Rutas : Form
    {
        private string IdRuta;
        private bool Edit = false;

        E_Rutas objEntidad = new E_Rutas();
        N_Rutas objNegocio = new N_Rutas();

        public Rutas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    objEntidad.Nombre = txtNombre.Text.ToUpper();
                    objEntidad.Salida = txtSalida.Text.ToUpper();
                    objEntidad.Final = txtFinal.Text.ToUpper();
                    objEntidad.Horario = cbHorario.Text.ToUpper();

                    objNegocio.InsertandoRuta(objEntidad);

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
                    objEntidad.IdRuta = Convert.ToInt32(IdRuta);
                    objEntidad.Nombre = txtNombre.Text.ToUpper();
                    objEntidad.Salida = txtSalida.Text.ToUpper();
                    objEntidad.Final = txtFinal.Text.ToUpper();
                    objEntidad.Horario = cbHorario.Text.ToUpper();

                    objNegocio.EditandoRuta(objEntidad);

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

        private void Rutas_Load(object sender, EventArgs e)
        {
            Buscar("");
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        public void limpiar()
        {
            txtNombre.Text = "";
            txtSalida.Text = "";
            txtFinal.Text = "";
            cbHorario.Text = "";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaRutas.SelectedRows.Count > 0)
            {
                objEntidad.IdRuta = Convert.ToInt32(tablaRutas.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoRuta(objEntidad);

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
            if (tablaRutas.SelectedRows.Count > 0)
            {
                Edit = true;
                IdRuta = tablaRutas.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = tablaRutas.CurrentRow.Cells[1].Value.ToString();
                txtSalida.Text = tablaRutas.CurrentRow.Cells[2].Value.ToString();
                txtFinal.Text = tablaRutas.CurrentRow.Cells[3].Value.ToString();
                cbHorario.Text = tablaRutas.CurrentRow.Cells[4].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar.");
            }
        }

        public void Buscar(string buscar)
        {
            N_Rutas objNegocio = new N_Rutas();
            tablaRutas.DataSource = objNegocio.ListarRutas(buscar);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
