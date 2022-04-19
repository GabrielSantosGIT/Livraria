using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Livraria
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            DAO dao = new DAO("Livraria");
            Menu men = new Menu();
            men.ExecutarMenu();
            Console.ReadLine();
        }
    }//Fim da classe
}//Fim do projeto
