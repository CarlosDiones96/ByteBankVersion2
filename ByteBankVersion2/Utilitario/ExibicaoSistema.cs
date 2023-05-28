using ByteBankVersion2.Funcionarios;
using ByteBankVersion2.Parceria;
using ByteBankVersion2.SistemaInterno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ByteBankVersion2.Utilitario
{
    public static class ExibicaoSistema
    {
        public static void MensgagemInicial()
        {
            Console.WriteLine("Bem-vindo(a) ao Sistema do ByteBank");
        }

        public static void MostrarNome(Funcionario funcionario)
        {
            Console.WriteLine($"Nome: {funcionario.Nome}");
        }

        public static void MostrarNome(ParceiroComercial parceiro)
        {
            MensagemPropriedadeInexistente();
        }

        public static void MostrarSalario(Funcionario funcionario)
        {
            Console.WriteLine($"Salário: {funcionario.Salario}");
        }

        public static void MostrarBonificacao(Funcionario funcionario)
        {
            Console.WriteLine($"Bonificação: {funcionario.GetBonificacao()}");
        }

        static void MensagemPropriedadeInexistente()
        {
            Console.WriteLine("propriedade inexistente".ToUpper());
        }

    }

    
}
