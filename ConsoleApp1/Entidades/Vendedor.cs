using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    internal class Vendedor : Funcionario
    {
        public Vendedor() { }
        public Vendedor(int id, string nome, string matricula, double salario) : base(id, nome, matricula, salario)
        {

        }
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double porcentagem = 0;

            foreach (var pedido in pedidos)
            {
                if (pedido.Funcionario.Matricula == Matricula)
                {
                    porcentagem += pedido.Valor * 0.10;
                }
            }

            return Salario + porcentagem;
        }

        
    }
}
