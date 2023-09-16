using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp4_pt2.models
{
    class FuncionarioCLT : Funcionario
    {
        public decimal Salario { get; set; }
        public bool CargoConfianca { get; set; }

        public override decimal CalcularCustoMensal()
        {
            decimal custoTotal = Salario +
                (0.1111m * Salario) + 
                (0.0833m * Salario) + 
                (0.08m * Salario) + 
                (0.04m * Salario) + 
                (0.0793m * Salario); 

            if (CargoConfianca)
                custoTotal += 0.1m * Salario; 

            return custoTotal;
        }
    }
}
