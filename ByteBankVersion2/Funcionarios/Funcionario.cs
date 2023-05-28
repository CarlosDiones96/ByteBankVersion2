using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankVersion2.Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
        public double Salario { get; protected set; }

        public static int TotalDeFuncionarios { get; private set; }

        public abstract double GetBonificacao();

        public abstract void AumentarSalario();

        public Funcionario(string cpf, double salario)
        {
            Cpf = cpf;
            Salario = salario;
            TotalDeFuncionarios++;
        }

        public Funcionario(string cpf, double salario, string nome) : this(cpf, salario)
        {
            Nome = nome;
        }
    }
}
