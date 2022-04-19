using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    class Menu
    {
        DAO dao;
        public int opcao;
        public int opcaoB;

        public Menu()
        {
            opcao = 0;
            dao = new DAO("Livraria"); //Chamado a classe DAO
        }//Fim do Construtor

        public void MostrarOpcoes() 
        { 
            Console.WriteLine("Escolha uma das opções abaixo: \n\n" +
            "\n1. Cadastrar" +
            "\n2. Consultar Tudos Livros" +
            "\n3. Consultar Individual" +
            "\n4. Atualizar " +
            "\n5. Desativar Livros" +
            "\n0. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do metodo mostrar Opções

        public void MenuIndividual()
        {
            Console.WriteLine("Escolha umas das opções abaixo: \n\n" +
                "\n3.1 Consultar Categoria" +
                "\n3.2 consultar ISBN" +
                "\n3.3 Consultar Titulo" +
                "\n3.4 Consultar Ano " +
                "\n3.4 Consultar Editora" +
                "\n3.5 Consultar Valor");
            opcaoB = Convert.ToInt32(Console.ReadLine());
        }//Fim do método para mostra o menu Individual

        public void ExecutarMenu()
        {
            do
            {
                MostrarOpcoes();//Chamado o menu para o usuario
                switch (opcao)
                {
                    case 1:
                        //Coletando dados e validando
                        Console.WriteLine("Cadastre o ISBN do Livro: ");
                        int ISBN = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Cadastre o título do Livro:  ");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Informe o Ano de Lançamento do Livro: ");
                        string ano = Console.ReadLine();
                        Console.WriteLine("Cadastre o nome da Editora: ");
                        string editora = Console.ReadLine();
                        Console.WriteLine("Informe o Valor do Livro: ");
                        double valor = Convert.ToDouble(Console.ReadLine());
                        //Chamar o mettodo para inserir Livros
                        dao.InserirLivros(ISBN, titulo, ano, editora, valor);
                        break;
                    case 2:
                        Console.WriteLine(dao.ConsultarTudo());                                           
                        break;
                    case 3:
                        MenuIndividual();
                        ExecutarMenuB();
                        break;



                }

            } while (opcao != 0);                      
        }//Fim do ExecutarMenu

        public void ExecutarMenuB()
        {
            do
            {
                switch(opcaoB)
                {
                    case 1:
                        Console.WriteLine("Informe o código da Categoria que deseja consultar: ");
                        int codigo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Categoria: " + dao.ConsultarCate(codigo));
                        break;
                    case 2:
                        Console.WriteLine("Informe o ISBN do Livro que deseja consultar: ");
                        int ISBN = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Categoria: " + dao.ConsultarISBN(ISBN));
                        break;
                    case 3:
                        Console.WriteLine("Informe o ISBN do Livro para consultar o titulo: ");
                        int ISB = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Categoria: " + dao.ConsultarTitulo(ISB));                        
                        break;
                    case 4:
                        break;
                }

            }
            while (opcaoB != 0);
        }//Fim do método para o Executar Menu B


    }//Fim da Classe
}//Fim do projeto
