﻿using Eag.Jwt.Core.Application.Interfaces;
using Eag.Jwt.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Eag.Jwt.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext _context;

        public Repository(JwtContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
