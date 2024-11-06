using AutoMapper;
using PromotionsMicroservice.ApplicationCore.Contracts.Repositories;
using PromotionsMicroservice.ApplicationCore.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Services
{
    public class BaseServiceAsync<TClass, TRequst, TResponse> : IServiceAsync<TClass, TRequst, TResponse>
        where TRequst : class where TResponse : class where TClass : class
    {

        //private readonly IRepositoryAsync<TClass> _repo;
        //private readonly IMapper mapper;

        //public BaseServiceAsync(IRepositoryAsync<TClass> repo, IMapper mapper)
        //{
        //    _repo = repo;
        //    this.mapper = mapper;
        //}

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(TRequst model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(TRequst model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
