using Cp4_pt2.models;

class Program
{ 
    static List<Funcionario> funcionarios = new List<Funcionario>();

    static void AdicionarFuncionarioCLT()
    {
        FuncionarioCLT funcionarioCLT = new FuncionarioCLT();

        Console.Write("Digite o código de registro: ");
        funcionarioCLT.Registro = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o nome: ");
        funcionarioCLT.Nome = Console.ReadLine();

        Console.Write("Digite o gênero: ");
        funcionarioCLT.Genero = Console.ReadLine();

        Console.Write("Digite o salário: ");
        funcionarioCLT.Salario = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Possui cargo de confiança? (S/N): ");
        funcionarioCLT.CargoConfianca = Console.ReadLine().ToUpper() == "S";

        funcionarios.Add(funcionarioCLT);
        Console.WriteLine("Funcionário CLT adicionado com sucesso!");
    }

    static void AdicionarFuncionarioPJ()
    {
        FuncionarioPJ funcionarioPJ = new FuncionarioPJ();

        Console.Write("Digite o código de registro: ");
        funcionarioPJ.Registro = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o nome: ");
        funcionarioPJ.Nome = Console.ReadLine();

        Console.Write("Digite o gênero: ");
        funcionarioPJ.Genero = Console.ReadLine();

        Console.Write("Digite o valor da hora: ");
        funcionarioPJ.ValorHora = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a quantidade de horas contratadas: ");
        funcionarioPJ.HorasContratadas = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o CNPJ da empresa: ");
        funcionarioPJ.CNPJ = Console.ReadLine();

        funcionarios.Add(funcionarioPJ);
        Console.WriteLine("Funcionário PJ adicionado com sucesso!");
    }

    static void ExibirFuncionariosCLT()
    {
        Console.WriteLine("Funcionários CLT:");
        foreach (var funcionario in funcionarios.OfType<FuncionarioCLT>())
        {
            Console.WriteLine($"Registro: {funcionario.Registro}, Nome: {funcionario.Nome}, Salário: {funcionario.Salario}");
        }
    }

    static void ExibirFuncionariosPJ()
    {
        Console.WriteLine("Funcionários PJ:");
        foreach (var funcionario in funcionarios.OfType<FuncionarioPJ>())
        {
            Console.WriteLine($"Registro: {funcionario.Registro}, Nome: {funcionario.Nome}, CNPJ: {funcionario.CNPJ}");
        }
    }

    static void ExibirCustoTotalMensal()
    {
        decimal custoTotal = funcionarios.Sum(funcionario => funcionario.CalcularCustoMensal());
        Console.WriteLine($"Custo total mensal de todos os funcionários: {custoTotal:C}");
    }

    static void AumentarSalarioCLT()
    {
        Console.Write("Digite o número de registro do funcionário CLT: ");
        int registro = Convert.ToInt32(Console.ReadLine());

        FuncionarioCLT funcionarioCLT = funcionarios.OfType<FuncionarioCLT>().FirstOrDefault(f => f.Registro == registro);

        if (funcionarioCLT != null)
        {
            Console.Write("Digite o percentual de aumento: ");
            decimal percentualAumento = Convert.ToDecimal(Console.ReadLine());

            if (percentualAumento >= 0)
            {
                funcionarioCLT.Salario *= (1 + (percentualAumento / 100));
                Console.WriteLine($"Salário atualizado: {funcionarioCLT.Salario:C}");
            }
            else
            {
                Console.WriteLine("O percentual de aumento não pode ser negativo.");
            }
        }
        else
        {
            Console.WriteLine("Funcionário CLT não encontrado.");
        }
    }

    static void AumentarValorHoraPJ()
    {
        Console.Write("Digite o número de registro do funcionário PJ: ");
        int registro = Convert.ToInt32(Console.ReadLine());

        FuncionarioPJ funcionarioPJ = funcionarios.OfType<FuncionarioPJ>().FirstOrDefault(f => f.Registro == registro);

        if (funcionarioPJ != null)
        {
            Console.Write("Digite o valor de aumento por hora: ");
            decimal aumentoPorHora = Convert.ToDecimal(Console.ReadLine());

            if (aumentoPorHora >= 0)
            {
                funcionarioPJ.ValorHora += aumentoPorHora;
                Console.WriteLine($"Valor da hora atualizado: {funcionarioPJ.ValorHora:C}");
            }
            else
            {
                Console.WriteLine("O aumento por hora não pode ser negativo.");
            }
        }
        else
        {
            Console.WriteLine("Funcionário PJ não encontrado.");
        }
    }

    static void PesquisarFuncionarioPorRegistro()
    {
        Console.Write("Digite o número de registro do funcionário: ");
        int registro = Convert.ToInt32(Console.ReadLine());

        Funcionario funcionario = funcionarios.FirstOrDefault(f => f.Registro == registro);

        if (funcionario != null)
        {
            Console.WriteLine("Dados do funcionário:");
            Console.WriteLine($"Registro: {funcionario.Registro}");
            Console.WriteLine($"Nome: {funcionario.Nome}");
            Console.WriteLine($"Gênero: {funcionario.Genero}");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
    }

    static void PesquisarCustoTotalMensalPorRegistro()
    {
        Console.Write("Digite o número de registro do funcionário: ");
        int registro = Convert.ToInt32(Console.ReadLine());

        Funcionario funcionario = funcionarios.FirstOrDefault(f => f.Registro == registro);

        if (funcionario != null)
        {
            decimal custoTotal = funcionario.CalcularCustoMensal();
            Console.WriteLine($"Custo total mensal do funcionário: {custoTotal:C}");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Digite a qtd de funcionários");
        int qtd = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= qtd; i++)
        {
            Console.WriteLine("Qual o tipo de funcionário cadsatrar?(0-CLT ou 1-PJ)");
            int tipo = Convert.ToInt32(Console.ReadLine());
            if(tipo == 0)
            {
                AdicionarFuncionarioCLT();

            }else if(tipo == 1){
                AdicionarFuncionarioPJ();
            }
            else
            {
                Console.WriteLine("Seleção inválida!");
                i--;
            }
        }
            while (true)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Exibir todos os funcionários CLT");
            Console.WriteLine("2 - Exibir todos os funcionários PJ");
            Console.WriteLine("3 - Exibir a soma do custo total mensal de todos os funcionários");
            Console.WriteLine("4 - Aumentar o salário de um funcionário CLT");
            Console.WriteLine("5 - Aumentar o valor hora de um funcionário PJ");
            Console.WriteLine("6 - Pesquisar um funcionário pelo registro e exibir seus dados");
            Console.WriteLine("7 - Pesquisar um funcionário pelo registro e exibir seu custo total mensal");
            Console.WriteLine("0 - Sair");

            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    ExibirFuncionariosCLT();
                    break;
                case 2:
                    ExibirFuncionariosPJ();
                    break;
                case 3:
                    ExibirCustoTotalMensal();
                    break;
                case 4:
                    AumentarSalarioCLT();
                    break;
                case 5:
                    AumentarValorHoraPJ();
                    break;
                case 6:
                    PesquisarFuncionarioPorRegistro();
                    break;
                case 7:
                    PesquisarCustoTotalMensalPorRegistro();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}