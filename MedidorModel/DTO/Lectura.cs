using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DTO
{
    public class Lectura
    {
        private string nummedidor;
        private string fecha;
        private string consumo;

        public string Nummedidor { get => nummedidor; set => nummedidor = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Consumo { get => consumo; set => consumo = value; }


    }
}
