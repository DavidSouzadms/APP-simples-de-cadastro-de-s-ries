using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X" )
            {
              
              switch (opcaoUsuario)
              {
                  case "1":
                  ListarSerie();
                  break;

                  case "2":
                  InserirSerie();
                  break;
                  
                  case "3":
                  //AtualizarSerie();
                  break;

                  case "4":
                  //ExcluirSerie();
                  break;

                  case "5":
                  //VisualizarSerie();
                  break;

                  case "C":
                  Console.Clear();
                  break;

                  default:
                  throw new ArgumentOutOfRangeException();
              }
opcaoUsuario = obterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSerie()
        {

            Console.WriteLine("Listar Serie");
            var Lista = repositorio.Lista();
            if (Lista.Count == 0)
            {
                Console.WriteLine ("nenhhum série cadastrada");
                return;
            }
            foreach (var serie in Lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }


        private static void InserirSerie()
        {

            Console.WriteLine("Inserir nova Serie");
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero), i));

            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
            
        }

        private static string obterOpcaoUsuario() 
        {
          
            Console.WriteLine();
            Console.WriteLine("Dio Series a seu dispor!!");
            Console.WriteLine("Informe a opção desejada");
            
            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserie nova Series");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Ecluir Series");
            Console.WriteLine("5 - Visualizar Series");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("x - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
