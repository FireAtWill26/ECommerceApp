﻿using PromotionsMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IPromotionRepositoryAsync: IRepositoryAsync<Promotion>
    {
        Task<Promotion> GetByName(string name);
        Task<IEnumerable<Promotion>> GetActive();
    }
}
