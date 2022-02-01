using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class FareService
    {
        private Repository _repository = new Repository();

        public bool Create(Fare fare)
        {
            try
            {
                _repository.Insert(fare);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }
        public List<Fare> GetFaresByIdOperator(Guid id)
        {
            var fares = GetFares();
            List<Fare> Resposta = new List<Fare>();

            foreach(Fare item in fares)
            {
                if (item.OperatorId == id)
                    Resposta.Add(item);
            }
            return Resposta;
        }
        public bool ValidaFare(Fare fare)
        {
            List<Fare> List = GetFaresByIdOperator(fare.OperatorId);

            foreach(Fare item in List)
            {
                if (item.Status == 1 && item.DataCriacao.AddMonths(6) > DateTime.Now && item.Value == fare.Value)
                    return false;
            }

            return true;

        }

    }
}
