using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW_Secretario
{
    public class Publicador_Total
    {
        public string Nombre { get; set; }
        public int Informan { get; set; }
        public int Publicaciones { get; set; }
        public int Videos { get; set; }
        public int Horas { get; set; }
        public int Revisitas { get; set; }
        public int Estudios { get; set; }
        public Main_Form.Categoria Categoria { get; set; }

        public void Clear()
        {
            Nombre = "";
            Publicaciones = 0;
            Videos = 0;
            Horas = 0;
            Revisitas = 0;
            Estudios = 0;
            Informan = 0;
            Categoria = Main_Form.Categoria.Null;
        }

        public double Prom(int switcher)
        {
            int value = 0;
            switch (switcher)
            {
                case 1:
                    {
                        value = Publicaciones;
                        break;
                    }
                case 2:
                    {
                        value = Videos;
                        break;
                    }
                case 3:
                    {
                        value = Horas;
                        break;
                    }
                case 4:
                    {
                        value = Revisitas;
                        break;
                    }
                case 5:
                    {
                        value = Estudios;
                        break;
                    }
            }
            if (Informan > 0)
            {
                float retval = (float)value / Informan;
                return Math.Round(retval, 2);
            }
            else
            {
                return 0;
            }
        }
    }

}
