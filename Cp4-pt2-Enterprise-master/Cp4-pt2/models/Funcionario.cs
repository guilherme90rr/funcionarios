using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp4_pt2.models
{
    abstract class Funcionario
    {
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }

        public abstract decimal CalcularCustoMensal();
    }
}
