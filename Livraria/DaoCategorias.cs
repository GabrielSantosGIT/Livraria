using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace Livraria
{
    class DaoCategorias
    {
        //Variaveis
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Declarando vetores
        public string[] descricao;
        public int i;
        public int contador = 0;
        public string msg;

        public DaoCategorias( string Livraria)
        {
            i = 0;
            conexao = new MySqlConnection("server=localhost;DataBase=" + Livraria + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando entrada ao banco de dados               
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + e);
                conexao.Close();// Fechando a conexão com BD
            }// Fim da tentativa de entrada no banco de dados
        }//Fim do Construtor


    }//Fim da classe
}//Fim do projeto
