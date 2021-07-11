﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Funcionarios
{
    public class Designer : Funcionario
    {
        public Designer(string cpf) : base(2000, cpf)
        {
        }
        public override void AumentarSalario()
        {
            Salario *= 1.11;
        }
        public override double GetBonificacao()
        {
            return Salario * 0.17;
        }
    }
}
