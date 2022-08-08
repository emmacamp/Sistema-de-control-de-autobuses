using Bunifu.Framework.UI;
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
    public partial class Choferes : Form
    {
        private string IdChofer;
        private bool Edit = false;

        E_Choferes objEntidad = new E_Choferes();
        N_Choferes objNegocio = new N_Choferes();
        public Choferes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar(txtBuscar.Text);
        }

        public void limpiar()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNacimiento.Text = "";
            txtCedula.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            cBSexo.Text = "";
            cBNacionalidad.Text = "";
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (Edit == false)
            {
                try
                {
                    objEntidad.Nombres = txtNombres.Text.ToUpper();
                    objEntidad.Apellidos = txtApellidos.Text.ToUpper();
                    objEntidad.FNacimiento = txtNacimiento.Text.ToUpper();
                    objEntidad.Cedula = txtCedula.Text.ToUpper();
                    objEntidad.Edad = Convert.ToInt32(txtEdad.Text);
                    objEntidad.Telefono = txtTelefono.Text.ToUpper();
                    objEntidad.Sexo = cBSexo.Text.ToUpper();
                    objEntidad.Nacionalidad = cBNacionalidad.Text.ToUpper();

                    objNegocio.InsertandoChofer(objEntidad);

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
                    objEntidad.IdChofer = Convert.ToInt32(IdChofer);
                    objEntidad.Nombres = txtNombres.Text.ToUpper();
                    objEntidad.Apellidos = txtApellidos.Text.ToUpper();
                    objEntidad.FNacimiento = txtNacimiento.Text.ToUpper();
                    objEntidad.Cedula = txtCedula.Text.ToUpper();
                    objEntidad.Edad = Convert.ToInt32(txtEdad.Text);
                    objEntidad.Telefono = txtTelefono.Text.ToUpper();
                    objEntidad.Sexo = cBSexo.Text.ToUpper();
                    objEntidad.Nacionalidad = cBNacionalidad.Text.ToUpper();

                    objNegocio.EditandoChofer(objEntidad);

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaChoferes.SelectedRows.Count > 0)
            {
                objEntidad.IdChofer = Convert.ToInt32(tablaChoferes.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoChofer(objEntidad);

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
            if (tablaChoferes.SelectedRows.Count > 0)
            {
                Edit = true;
                IdChofer = tablaChoferes.CurrentRow.Cells[0].Value.ToString();
                txtNombres.Text = tablaChoferes.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = tablaChoferes.CurrentRow.Cells[2].Value.ToString();
                txtNacimiento.Text = tablaChoferes.CurrentRow.Cells[3].Value.ToString();
                txtCedula.Text = tablaChoferes.CurrentRow.Cells[4].Value.ToString();
                txtEdad.Text = tablaChoferes.CurrentRow.Cells[5].Value.ToString();
                txtTelefono.Text = tablaChoferes.CurrentRow.Cells[6].Value.ToString();
                cBSexo.Text = tablaChoferes.CurrentRow.Cells[7].Value.ToString();
                cBNacionalidad.Text = tablaChoferes.CurrentRow.Cells[8].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Choferes_Load(object sender, EventArgs e)
        {
            Buscar("");
        }

        public void Buscar(string buscar)
        {
            N_Choferes objNegocio = new N_Choferes();
            tablaChoferes.DataSource = objNegocio.ListarChoferes(buscar);
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
