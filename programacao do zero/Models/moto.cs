using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programacao_do_zero.Models
{
    public class moto:veiculo

    {
        public moto()
        {
            qntRodas = 2;
        }
        public int qntRodas { get; set; }
    }
}
