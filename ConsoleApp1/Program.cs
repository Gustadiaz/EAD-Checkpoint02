using ConsoleApp1.Entidades.Enums;
using ConsoleApp1.Entidades;



List<Produto> produtos = new List<Produto>();
List<Funcionario> funcionarios = new List<Funcionario>();
List<Pedido> pedidos = new List<Pedido>();

int opcao = 0;

do
{
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Cadastrar Funcionário");
    Console.WriteLine("3 - Efetuar Venda");
    Console.WriteLine("4 - Listar Produtos");
    Console.WriteLine("5 - Listar Funcionários");
    Console.WriteLine("6 - Listar Pedidos");
    Console.WriteLine("7 - Calcular Pagamento de Funcionário");
    Console.WriteLine("8 - Sair");
    Console.Write("Opcao: ");

    opcao = int.Parse(Console.ReadLine());

    Console.Clear();

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Cadastrar Produto");
            Produto produto = new Produto();

            Console.Write("Id: ");
            produto.Id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Valor: ");
            produto.Valor = double.Parse(Console.ReadLine());

            produtos.Add(produto);
            break;

        case 2:
            Console.WriteLine("Cadastrar Funcionário");


            Console.WriteLine("Qual é o tipo de funcionário? (V) para Vendedor ou (G) para Gerente");
            string Func = Console.ReadLine();
            if (Func == "V")
            {
                Vendedor vendedor = new Vendedor();

                Console.Write("Id: ");
                vendedor.Id = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                vendedor.Nome = Console.ReadLine();

                Console.Write("Matricula: ");
                vendedor.Matricula = Console.ReadLine();

                Console.Write("Salario: ");
                vendedor.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(vendedor);

                break;
            }
            else if (Func == "G")
            {
                Gerente gerente = new Gerente();

                Console.Write("Id: ");
                gerente.Id = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                gerente.Nome = Console.ReadLine();

                Console.Write("Matricula: ");
                gerente.Matricula = Console.ReadLine();

                Console.Write("Salario: ");
                gerente.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(gerente);

                break;
            }
            else
            {
                Console.WriteLine("Digite uma opção válida");
                break;
            }

        case 3:
            Console.WriteLine("Efetuar Venda");
            Pedido pedido = new Pedido();

            Console.Write("Matricula do Funcionario: ");
            string matriculaFunc = Console.ReadLine();

            pedido.Funcionario = funcionarios.Find(funcionario => funcionario.Matricula == matriculaFunc);

            Console.Write("Quantidade do Produto? ");
            int qtdItens = int.Parse(Console.ReadLine());

            for (int i=0; i<qtdItens; i++)
            {
                ItemPedido item = new ItemPedido();

                Console.Write($"Id do Produto {i + 1}: ");
                int idProduto = int.Parse(Console.ReadLine());

                item.Produto = produtos.Find(produto => produto.Id == idProduto);
                item.Valor = item.Produto.Valor;

                Console.Write($"Quantidade do Produto {i+1}: ");
                item.Quantidade = int.Parse(Console.ReadLine());

                item.SubTotal();
                pedido.AdicionarItem(item);
            }

            pedido.DataPedido = DateTime.Now;
            pedido.Status = StatusPedido.Processando;

            pedidos.Add(pedido);

            break;

        case 4:
            Console.WriteLine("Listar Produtos");

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto);
            });

            break;

        case 5:
            Console.WriteLine("Listar Funcionarios");

            funcionarios.ForEach(funcionario =>
            {
                Console.WriteLine(funcionario);
            });

            break;

        case 6:
            Console.WriteLine("Listar Pedidos");

            pedidos.ForEach(pedido =>
            {
                Console.WriteLine(pedido);
            });

            break;

        case 7:
            Console.WriteLine("Calcular Pagamento do Funcionário");
            Console.Write("Digite a matrícula do Funcionário: ");
            string matricula = Console.ReadLine();

            Funcionario funcionario = funcionarios.Find(func => func.Matricula == matricula);

            Console.WriteLine(funcionario.CalcularPagamento(pedidos));
            break;

    Console.ReadKey();
    Console.Clear();
    }
       
} while (opcao != 8);