using System;
using System.Globalization; // Permite acessar classes como CultureInfo, que permite definir configurações culturais específicas, como formatos de data e hora, separadores de número e moeda, entre outros.
using System.Collections.Generic; // Fornece classes e estruturas de dados genéricas que podem ser usadas para armazenar e manipular coleções de dados de forma eficiente.

class Bloco   // Definição da classe Bloco com propriedades para armazenar informações dos blocos.

{
    public int Codigo { get; set; }
    public string Numero { get; set; }
    public double Medidas { get; set; }
    public string Descricao { get; set; }
    public string TipoMaterial { get; set; }
    public double ValorCompra { get; set; }
    public double ValorVenda { get; set; }
    public string Pedreira { get; set; }
}

class Program
{
    static List<Bloco> blocos = new List<Bloco>();

    static CultureInfo Culture = CultureInfo.InvariantCulture; // Declaração de uma CultureInfo para usar o InvariantCulture como separador decimal.


    static void Main()
    {
        int escolha;

        do
        {
            Console.WriteLine(">>> Gestão de Blocos <<<");
            Console.WriteLine("1 - Cadastrar Bloco");
            Console.WriteLine("2 - Listar Blocos");
            Console.WriteLine("3 - Buscar Bloco por código");
            Console.WriteLine("4 - Listar Blocos por pedreira");
            Console.WriteLine("5 - SAIR");

            escolha = int.Parse(Console.ReadLine());

            switch (escolha) // Definição dos métodos para as operações principais do programa.

            {
                case 1:
                    CadastrarBloco();
                    break;
                case 2:
                    ListarBlocos();
                    break;
                case 3:
                    BuscarBlocoPorCodigo();
                    break;
                case 4:
                    ListarBlocosPorPedreira();
                    break;
                case 5:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        } while (escolha != 5);
    }

    static void CadastrarBloco() // CadastrarBloco: Solicita ao usuário informações sobre um bloco e armazena-as na lista de blocos.

    {
        Bloco bloco = new Bloco();

        Console.WriteLine("Digite o Código do Bloco:");
        bloco.Codigo = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o Número do Bloco:");
        bloco.Numero = Console.ReadLine();

        Console.WriteLine("Digite as Medidas (metros cúbicos):");
        bloco.Medidas = double.Parse(Console.ReadLine(), Culture);

        Console.WriteLine("Digite a Descrição:");
        bloco.Descricao = Console.ReadLine();

        Console.WriteLine("Digite o Tipo de Material (mármore ou granito):");
        bloco.TipoMaterial = Console.ReadLine();

        Console.WriteLine("Digite o Valor de Compra:");
        bloco.ValorCompra = double.Parse(Console.ReadLine(), Culture);

        Console.WriteLine("Digite o Valor de Venda:");
        bloco.ValorVenda = double.Parse(Console.ReadLine(), Culture);

        Console.WriteLine("Digite a Pedreira:");
        bloco.Pedreira = Console.ReadLine();

        blocos.Add(bloco);

        Console.WriteLine("Bloco cadastrado com sucesso!");
    }

    static void ListarBlocos()  // ListarBlocos: Exibe uma lista de todos os blocos cadastrados.

    {
        Console.WriteLine("Lista de Blocos:");

        foreach (var bloco in blocos)
        {
            Console.WriteLine($"Código: {bloco.Codigo}, Número: {bloco.Numero}, Medidas: {bloco.Medidas.ToString("F2", Culture)} metros cúbicos, Descrição: {bloco.Descricao}");
        }
    }

    static void BuscarBlocoPorCodigo() // BuscarBlocoPorCodigo: Permite buscar um bloco por seu código.

    {
        Console.WriteLine("Digite o Código do Bloco a ser buscado:");
        int codigo = int.Parse(Console.ReadLine());

        Bloco blocoEncontrado = blocos.Find(bloco => bloco.Codigo == codigo);

        if (blocoEncontrado != null)
        {
            Console.WriteLine($"Código: {blocoEncontrado.Codigo}, Número: {blocoEncontrado.Numero}, Medidas: {blocoEncontrado.Medidas.ToString("F2", Culture)} metros cúbicos, Descrição: {blocoEncontrado.Descricao}");
        }
        else
        {
            Console.WriteLine("Bloco não encontrado.");
        }
    }

    static void ListarBlocosPorPedreira() // ListarBlocosPorPedreira: Permite listar blocos de uma pedreira específica.

    {
        Console.WriteLine("Digite o nome da Pedreira:");
        string pedreira = Console.ReadLine();

        Console.WriteLine($"Blocos da Pedreira '{pedreira}':");

        foreach (var bloco in blocos)
        {
            if (bloco.Pedreira == pedreira)
            {
                Console.WriteLine($"Código: {bloco.Codigo}, Número: {bloco.Numero}, Medidas: {bloco.Medidas.ToString("F2", Culture)} metros cúbicos, Descrição: {bloco.Descricao}");
            }
        }
    }
}