using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DTO
{
    public class Medidor
    {
        private string nummedidor;

        public string Nummedidor { get => nummedidor; set => nummedidor = value; }

        public override string ToString()
        {
            return Nummedidor + " ";
        }
    }
}
