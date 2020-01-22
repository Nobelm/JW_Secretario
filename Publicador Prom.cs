using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW_Secretario
{
    public class Publicador_Prom
    {
        public string Nombre { get; set; }
        public double Informan { get; set; }
        public double Publicaciones { get; set; }
        public double Videos { get; set; }
        public double Horas { get; set; }
        public double Revisitas { get; set; }
        public double Estudios { get; set; }
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
    }

}
