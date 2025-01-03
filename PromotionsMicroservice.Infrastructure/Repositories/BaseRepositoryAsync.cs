﻿
using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repositories;
using PromotionsMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Repositories
{


    public class BaseRepositoryAsync<T>: IRepositoryAsync<T> where T : class
    {

        private readonly ECommerceDbContext context;

        public BaseRepositoryAsync(ECommerceDbContext context)
        {
            this.context = context;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            context.Set<T>().Remove(result);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            context.Set<T>().Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
    }
}
