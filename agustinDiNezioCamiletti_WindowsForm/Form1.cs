using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace agustinDiNezioCamiletti_WindowsForm
{
    public partial class Form1 : Form
    {
        string nombre="";
        string apellido="";
        double sueldo=0;
        string puesto="";
        int[] horas;
        string[] dias = new string[5] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            nombre = txtName.Text.ToUpper();
            apellido = txtApellido.Text.ToUpper();
            sueldo = Convert.ToDouble(txtSueldo.Text);
            puesto = txtPuesto.Text.ToUpper();

            if (ValidaNombre(nombre)==0) MessageBox.Show("Nombre invalido, intente nuevamente.");
            if (ValidaApellido(apellido) == 0) MessageBox.Show("Apellido invalido, intente nuevamente");
            if (ValidarSueldo(sueldo) == 0) MessageBox.Show("Sueldo incorrecto, intente nuevamente.");
            if (ValidarPuesto(puesto)==0) MessageBox.Show("Puesto no existente, intente nuevamente.");
            
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarInfo(nombre, apellido, puesto);
        }

        private void btnHoras_Click(object sender, EventArgs e)
        {
            horas = new int[5];
            int horasTotales = 0;
            double promedioHoras;
            int menorHoras;
            CargaHoras(horas);
            horasTotales=TotalHoras(horas);
            promedioHoras = PromedioHoras(horas);
            menorHoras = DiaMenosHoras(horas);

            MessageBox.Show($"El total de horas trabajadas es : {horasTotales}");
            MessageBox.Show($"El promedio de horas trabajadas es : {promedioHoras}");
            MessageBox.Show($"El dia de menor horas trabajadas es : {dias[menorHoras]}");


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        //-----------------------------------------------------------------------------------------------
        //-----------------------------------------METODOS-----------------------------------------------
        //-----------------------------------------------------------------------------------------------

        private int ValidarPuesto(string puesto) // Valida el Puesto
        {
            int flag = 0;
            switch (puesto)
            {
                case "SOPORTE TECNICO":
                case "DBA":
                case "DESARROLLADOR":
                    flag += 1;
                    return flag;
            }
            return flag;
        }
        private int ValidarSueldo(double sueldo) //Valida el sueldo
        {
            int flag = 0;
            if (sueldo > 0) flag = 1;
            return flag;
        }

        private void MostrarInfo(string nombre, string apellido, string puesto)  //Muestra Nombre, Apellido y Puesto
        {
            MessageBox.Show($"Nombre : {nombre}\nApellido : {apellido}\nPuesto : {puesto}");
        }

        private void CargaHoras(int[] horas)    //Carga horas trabajadas
        {
            for (int i = 0; i < horas.Length; i++)
            {
                horas[i] = Convert.ToInt32(Interaction.InputBox($"{i + 1}. Ingresa horas trabajadas","Horas Diarias"));
            }
        }

        private int TotalHoras(int[] horas) // Calcula el total de horas trabajadas.
        {
            int total = 0;
            for (int i = 0; i < horas.Length; i++)
            {
                total += horas[i];
            }
            return total;
        }
        
        private void LimpiarTxt() // Limpia contenido de los textBox
        {
            txtName.Clear();
            txtApellido.Clear();
            txtSueldo.Clear();
            txtPuesto.Clear();
        }

        private int ValidaNombre(string nombre) //Valida Nombre
        {
            int flag = 0;
            if (nombre.Length > 2 && nombre.Length < 50) flag=1;
            return flag;
        }

        private int ValidaApellido(string apellido) //Valida Apellido
        {
            int flag = 0;
            if (apellido.Length > 2 && nombre.Length < 50) flag = 1;
            return flag;
        }

        private double PromedioHoras(int[] horas) // Calcula Promedio horas trabajadas
        {
            double suma = 0;
            for (int i = 0; i < horas.Length; i++)
            {
                suma += horas[i];
            }
            return suma/horas.Count();
        }

        private int DiaMenosHoras(int[] horas)
        {
            int pos = 0;
            int menor = 99;
            for (int i = 0; i < horas.Length; i++)
            {
                if (horas[i] < menor)
                {
                    menor = horas[i];
                    pos = i;
                }
            }
            return pos;
        }
    }
}
