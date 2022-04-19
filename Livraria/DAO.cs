using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco



namespace Livraria
{

    class DAO
    {
        //Variaves
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //Declarando os Vetores
        public int[] ISBN;
        public string[] titulo;
        public string[] ano;
        public string[] editora;
        public double[] valor;
        public string[] descricao;        
        public double[] valorTotal;
        public int[] cod;
        public int i;
        public int contador = 0;
        public string msg;
        public string consuLi = "Livros";
        public string consuCa = "Catergoria";



        //Construtor
        public DAO(string Livraria)
        {
            i = 0;
            conexao = new MySqlConnection("server=localhost;DataBase=" + Livraria + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando entrada ao banco de dados
                Console.WriteLine("Entramos");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + e);
                conexao.Close();// Fechando a conexão com BD
            }// Fim da tentativa de entrada no banco de dados
        }//Fim do Construtor     
        public void InserirLivros(int ISBN, string titulo, string ano, string editora, double valor)
        {
            try
            {
            
                dados = "('" + ISBN + "','" + titulo + "','" + ano + "','" + editora + "','" + valor + "')";
                resultado = "Insert into Livros( ISBN, titulo, ano, editora, valor) values" + dados;
                //Exceutar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linhas(s) Afetada(s)!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + e);
            }//Fim do catch
        }//Fim do método para Inserir

        public void InserirCompra(double valorTotal)
        {
            try
            {
                dados = "('', '" + valorTotal + "')";
                resultado = "Insert into Compra (codigo, valorTotal) values" + dados;
                //Executaro  comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado +  "Linha(s) Afetadas(s)");
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu Errado\n\n" + e);
            }//Fim do catch
        }//Fim do métdo para Inserir Compras 

        public void InserirCategorias(string descricao)
        {
            try
            {
                dados = "('', '" + descricao + "' )";
                resultado = "Insert into Categoria (codigo, descricao) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linha(s) Afetada(s)!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + e);
            }//Fim do catch
        }//Fim do método para Inserir Cateogiras

        public void PreencherVCompras()
        {
            string query = "select * from Compra";
            //Definindo tamanho dos vetores
            valorTotal = new double[100];
            //Instanciando
            for (i = 0; i < 100; i++)
            {
                valorTotal[i] = 0;
            }//Estamos instanciando o Vetor ao Mesmo tempo que percoremos ele
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //usar o camando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();
            i = 0;
            while (leitura.Read())
            {
                descricao[i] = leitura["valorTotal"] + "";
                i++;
                contador++;
            }//Fim do While
            leitura.Close();
        }//Fim do método para preencher Compras

        public void PreencherVCategorias()
        {
            string query = "select * from Categoria";//Conectando o dado a Tebela de Categoria

            //Definindo tamanho dos vetores
            descricao = new string[100];
            //Instanciando 
            for (i=0; i<100; i++)
            {
                descricao[i] = "";
            }//Estamos instanciando o Vetor ao mesmo tempo que percoremos ele

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while(leitura.Read())
            {
                descricao[i] = leitura["descricao"] + "";
                i++;
                contador++;
            }//Fim do While
            leitura.Close();
        }

        public void PreencherVetor()
        {
            string query = "select * from livros"  ;//Coletando o dado a Tabela de Livros

            //Defininfo tamanho dos vetores

            ISBN = new int[100];
            titulo = new string[100];
            ano = new string[100];
            editora = new string[100];
            valor = new double[100];
            //Instanciando os Vetores
            for(i=0; i< 100; i++)
            {
                ISBN[i] = 0;
                titulo[i] = "";
                ano[i] = "";
                editora[i] = "";
                valor[i] = 0;
            }//Estamos percorrendo o vetor       
        //Criar o comando para coleta de dados

        MySqlCommand coletar = new MySqlCommand(query, conexao);
        //usar o comando lendo os dados do banco
        MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while(leitura.Read())
            {
                ISBN[i] = Convert.ToInt32(leitura["ISBN"]);
                titulo[i] = leitura["titulo"] + "";
                ano[i] = leitura["ano"] + "";
                editora[i] = leitura["editora"] + "";
                valor[i] = Convert.ToDouble("" + leitura["valor"]);
                i++;
                contador++;
            }//Fim do While
            leitura.Close();
        
        }//Fim do método preencher Vetor

        public string ConsultarTudo()
        {
            PreencherVetor();
            msg = "";
            for (int i=0; i < contador; i++)
            {
                msg += "\n\nISBN: " + ISBN[i] + ", Titulo: " + titulo[i] + ", Ano: " + ano[i] + ", Editora: " + editora[i] + ", valor: " + valor[i] + 
                    "Categoria: " + descricao[i]; 
            }//Fim do For
            return msg;
        }//Fim do Consultar Tudo

        public string ConsultarCate(int codigo)
        {
            PreencherVCategorias();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return descricao[i];
                }
            }//Fim do For
            return msg;
        }//Fim do consultar Categoria

        public int ConsultarISBN(int ISB)
        {            
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (ISB == ISBN[i])
                {
                    return ISBN[i];
                }
            }//Fim do For
            return Convert.ToInt32("ISBN não encontrado!");
        }//FIm do método para consular ISBN

        public string ConsultarTitulo(int ISB)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (ISB == ISBN[i])
                {
                    return titulo[i];
                }//Fim do For
            }
            return "ISBN não encontrado!";
        }//Fim do métdo para Consultar ISBN

        public string ConsultarAno(int ISB)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (ISB == ISBN[i])
                {
                    return ano[i];
                }//Fim do For
            }
            return "ISBN não encontrado!";
        }//Fim do métdo para Consultar ISBN

        public string ConsultarEditora(int ISB)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (ISB == ISBN[i])
                {
                    return editora[i];
                }//Fim do For
            }
            return "ISBN não encontrado!";
        }//Fim do métdo para Consultar ISBN

        public Double ConsultarValor(int ISB)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (ISB == ISBN[i])
                {
                    return valor[i];
                }//Fim do For
            }
            return Convert.ToDouble("ISBN não encontrado!");
        }//Fim do métdo para Consultar ISBN

        public void AtualizarLivro(string campo, string novoDado, int ISBN)
        {
            try
            {
                resultado = "update Livros set" + campo + "+'" + novoDado + "' where ISBN ='" + ISBN + "'";
                //Executar Script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!" + e);
            }
        }//Fim do método atualizar Livro

        public void AtualizarCate(string campo, string novoDado, int cod)
        {
            try
            {
                resultado = "update Categoria set" + campo + "+'" + novoDado + "' where cod='" + cod + "'";
                //Executar Script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dados Atualizados com sucesso");
            }
            catch(Exception e)
            {
                Console.WriteLine("Aldo deu Errado" + e);
            }
        }//Fim do método atualizar Categoria

        public void Desativar( int ISBN)
        {
            resultado = "delete fro Livros where'" + ISBN + "'";
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            //Executar o comando
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem....
            Console.WriteLine("Dados Excluidos com sucesso!");
        }//Fim do método deletar

    }//Fim da classe
}//Fim do projeto
