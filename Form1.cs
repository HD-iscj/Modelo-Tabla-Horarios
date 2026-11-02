using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        string[,] agendaTurnos = new string[5, 5]
           {
                // Lun         Mar         Mié         Jue         Vie
                { "ID-101",   "Libre",    "ID-105",   "ID-108",   "Libre"    }, // 09:00 Hs
                { "ID-102",   "ID-104",   "Libre",    "Libre",    "ID-110"   }, // 10:00 Hs
                { "Libre",    "ID-106",   "ID-107",   "ID-109",   "Libre"    }, // 11:00 Hs
                { "ID-103",   "Libre",    "Libre",    "Libre",    "ID-111"   }, // 14:00 Hs
                { "Libre",    "ID-112",   "ID-113",   "ID-114",   "ID-115"   }  // 15:00 Hs
           };
        // Array auxiliar para etiquetar los horarios
        string[] horas = { "09:00", "10:00", "11:00", "14:00", "15:00" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActualizarTabla();
        }

        void ActualizarTabla()
        {
            // Esto es la configuracion de fuente monoespaciada para alinear las columnas adecuadamente
            listBox1.Font = new Font("Consolas", 10F, FontStyle.Regular);
            listBox1.Items.Clear();

            // Encabezado de días
            string encabezado = string.Format("{0,-8} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10}",
                                              "Hora", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes");
            listBox1.Items.Add(encabezado);
            listBox1.Items.Add(new string('-', 75)); // Línea separadora

            // Cargar los turnos con el ID de Cliente
            for (int fila = 0; fila < 5; fila++)
            {
                string lineaFila = string.Format("{0,-8} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10}",
                                                  horas[fila],
                                                  agendaTurnos[fila, 0],
                                                  agendaTurnos[fila, 1],
                                                  agendaTurnos[fila, 2],
                                                  agendaTurnos[fila, 3],
                                                  agendaTurnos[fila, 4]);
                listBox1.Items.Add(lineaFila);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int d = 6;
            int h = 6;
            try
            {
                d = int.Parse(textBox3.Text);
                h = int.Parse(textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (d >= 0 && d <5 && h >= 0 && h < 5 && textBox1.Text != "") 
            {
                agendaTurnos[h,d] = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Campos incorrectos");
            }
            this.ActualizarTabla();
        }
    }
}
