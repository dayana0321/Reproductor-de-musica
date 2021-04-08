using Reproductor_de_Musica2.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor_de_Musica2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Objeto para manipular inserción por cabeza
        clsLista lista = new clsLista();
        //Arreglos para obtener las canciones de la lista general
        string[] archivo, ruta;
        private void Form1_Load(object sender, System.EventArgs e)
        {
            listBox2.DataSource = lista;
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = ruta[listBox1.SelectedIndex];
        }

        private void btnAgregar_playlist_Click(object sender, EventArgs e)
        {
            Form2 ventanita = new Form2();
            ventanita.Show();
        }

        private void btnAgregarCabeza_Click(object sender, EventArgs e)
        {
            string cancion = listBox1.SelectedItem.ToString();
            lista.insertarCabeza1(cancion);
            listBox2.Items.Clear();
            lista.visualizar1(listBox2);
            //listBox2.Items.Add(cancion);   
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarCola_Click(object sender, EventArgs e)
        {
            string cancion1 = listBox1.SelectedItem.ToString();
            lista.insertarCola1(cancion1);
            listBox2.Items.Clear();
            lista.visualizar1(listBox2);
           // listBox2.Items.Add(cancion1);
            
        }

        private void btnEliminarCabeza_Click(object sender, EventArgs e)
        {
            string cancion2 = listBox2.SelectedItem.ToString();
            lista.eliminar(cancion2);
            listBox2.Items.Clear();
            lista.visualizar1(listBox2);   
        }

        private void btnElegir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK);
            {
                archivo = openFileDialog1.SafeFileNames;
                ruta = openFileDialog1.FileNames;

                for(int i = 0; i < archivo.Length; i++) 
                {
                    listBox1.Items.Add(archivo[i]);
                }
            }  
        }//end private
    }
}
