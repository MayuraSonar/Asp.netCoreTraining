using CandyOnlineShopping.Models.Entity;
using CandyOnlineShopping.Models.Interfaces;
using CandyOnlineShopping.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShopping.Models.Services
{
    public class CandyService:ICandyService
    {
        private readonly ICandyRepsoitory _candyRepository;

        public CandyService(ICandyRepsoitory candyRepository)
        {
            _candyRepository = candyRepository;
        }

        public IEnumerable<Candy> GetAll()
        {
            return _candyRepository.GetAll();
        }

        public Candy GetById(int candyId)
        {
            return _candyRepository.GetById(candyId);
        }

        public IEnumerable<Candy> GetOnSale()
        {
            return _candyRepository.GetOnSale();
        }
    }
}
