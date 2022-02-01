using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fleg = true;
            var fareController = new FareController();
            do
            {
                var fare = new Fare();
                fare.Id = Guid.NewGuid();

                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                var fareValueInput = Console.ReadLine();
                fare.Value = decimal.Parse(fareValueInput);
                //fare.Value = decimal.Parse("2,50");

                Console.WriteLine("Informe o código da operadora para a tarifa:");
                Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                var operatorCodeInput = Console.ReadLine();
                //var operatorCodeInput = "OP01";

                Console.WriteLine(fareController.CreateFare(fare, operatorCodeInput));

                Console.WriteLine("Deseja cadastra outra tarifa ?");
                Console.WriteLine("<1> para Sim qualquer tecla para Não");
                var valor = Console.ReadLine();

                if (valor != "1")
                    fleg = false;   
                
            } while (fleg);
        }
    }
}