using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService _fareService;

        public FareController()
        {
            _operatorService = new OperatorService();
            _fareService = new FareService();
        }

        public string CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            if (selectedOperator == null)
            {
                Operator operador = new Operator();
                operador.Id = Guid.NewGuid();
                operador.Code = operatorCode;

                _operatorService.Create(operador);
                selectedOperator = operador;
            }
            fare.OperatorId = selectedOperator.Id;
            fare.DataCriacao = DateTime.Now;
            fare.Status = 1;

            if (!_fareService.ValidaFare(fare))
                return "Já existe uma tarifa ativa com esse valor";

            if (!_fareService.Create(fare))
                return "Falha ao salvar ";

            return "Tarifa criada con sucesso";
        }
    }
}