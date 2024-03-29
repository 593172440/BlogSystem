﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IDAL
{
    public interface IBaseService<T>:IDisposable where T:Models.BaseEntity
    {
        Task CreateAsync(T model,bool saved=true);
        Task EditAsync(T model, bool saved = true);
        Task RemoveAsync(int id, bool saved = true);
        Task RemoveAsync(T model, bool saved = true);
        Task SavedAsync();
        Task<T> GetOneByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllByPage(int pageSize = 10, int pageIndex = 0);
        IQueryable<T> GetAllByPageOrder(int pageSize = 10, int pageIndex = 0,bool asc=true);
        IQueryable<T> GetAllOrder(bool asc=true);

    }
}
