using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else 
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wHsg, int Param, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormHijo (object formhijo)
        {
            if(this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Inicio());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AbrirFormHijo(new Inicio());
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Choferes());
        }

        private void btnAutobuses_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Autobuses());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Rutas());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Asignaciones());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
