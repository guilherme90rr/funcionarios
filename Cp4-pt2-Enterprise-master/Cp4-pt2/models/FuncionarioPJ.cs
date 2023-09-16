using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp4_pt2.models
{
    class FuncionarioPJ : Funcionario
    {
        public decimal ValorHora { get; set; }
        public int HorasContratadas { get; set; }
        public string CNPJ { get; set; }

        public override decimal CalcularCustoMensal()
        {
            return ValorHora * HorasContratadas;
        }
    }
}
