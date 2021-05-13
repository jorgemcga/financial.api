using System.Linq;
using System.Collections.Generic;
using Financial.API.Common.Services;
using Financial.API.Common.Repositories;
using Financial.API.Common.Entities;
using Financial.API.Common.ViewModel;

namespace Financial.API.Core.Services
{
    public class ExpiredTitleService : IExpiredTitleService
    {
        private readonly IExpiredTitleRepository _repository;
        
        public ExpiredTitleService(IExpiredTitleRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns all 
        /// </summary>
        /// <returns></returns>
        public ICollection<ExpiredTitleViewModel> Get()
        {
            var response = new List<ExpiredTitleViewModel>();
            var vehicles = _repository.Get(); ;
            
            if (vehicles != null && vehicles.Any())
            {
                foreach (var item in vehicles)
                {
                    response.Add(new ExpiredTitleViewModel(item));
                }
            }

            return response;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ExpiredTitleViewModel Insert(ExpiredTitleViewModel request)
        {
            var entity = new ExpiredTitleEntity
            {
                DebtorName = request.DebtorName,
                FinePercent = request.FinePercent,
                FeesPercent = request.FeesPercent,
                Portions = (from portionRequest in request.Portions
                            select new ExpiredTitlePortionEntity
                            {
                                Value = portionRequest.Value,
                                DueDate = portionRequest.DueDate
                            }).ToHashSet()
            };

            _repository.Insert(ref entity);

            return new ExpiredTitleViewModel(entity);
        }
    }
}