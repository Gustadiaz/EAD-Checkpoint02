using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    internal class Gerente : Funcionario
    {
        public Gerente() { }
        public Gerente(int id, string nome, string matricula, double salario) : base(id, nome, matricula, salario)
        {

        }
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double porcentagem = 0;

            foreach(var pedido in pedidos)
            {
                porcentagem += pedido.Valor * 0.05;
            }
            
            return Salario + porcentagem;
        }

        
    }
}
