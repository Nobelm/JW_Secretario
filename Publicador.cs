using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW_Secretario
{
    public class Publicador
    {
        public string Nombre { get; set; }
        public int Publicaciones { get; set; }
        public int Videos { get; set; }
        public int Horas { get; set; }
        public int Revisitas { get; set; }
        public int Estudios { get; set; }
        public int Grupo { get; set; }
        public Main_Form.Categoria Categoria { get; set; }

        public void Clear()
        {
            Nombre = "";
            Publicaciones = 0;
            Videos = 0;
            Horas = 0;
            Revisitas = 0;
            Estudios = 0;
            Grupo = 0;
            Categoria = Main_Form.Categoria.Ref_Void;
        }
    }

}
