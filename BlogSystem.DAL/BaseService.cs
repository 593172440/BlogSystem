using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace BlogSystem.DAL
{
    public class BaseService<T> : IDAL.IBaseService<T> where T : Models.BaseEntity,new()
    {
        private readonly Models.BlogContext _db;
        public BaseService(Models.BlogContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(T model, bool saved = true)
        {
            _db.Set<T>().Add(model);
            if (saved)
            {
                await _db.SaveChangesAsync();
            }
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().Where(m => !m.IsRemove).AsNoTracking();
        }

        public IQueryable<T> GetAllByPage(int pageSize = 10, int pageIndex = 0)
        {
            return GetAll().Skip(pageSize * pageIndex).Take(pageSize).AsNoTracking();
        }

        public IQueryable<T> GetAllByPageOrder(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            return GetAllOrder(asc).Skip(pageIndex * pageSize).Take(pageSize).AsNoTracking();
        }

        public IQueryable<T> GetAllOrder(bool asc = true)
        {
            if (asc)
            {
                return GetAll().OrderBy(m => m.CreateTime);
            }
            else
            {
                return GetAll().OrderByDescending(m => m.CreateTime);
            }
        }

        public async Task<T> GetOneByIdAsync(int id)
        {
            return await GetAll().FirstAsync(m => m.Id == id);
        }

        public async Task RemoveAsync(int id, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            var t = new T();
            t.Id = id;
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemove = true;
            if(saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public async Task RemoveAsync(T model, bool saved = true)
        {
            await RemoveAsync(model.Id, saved);
            //_db.Entry(model).State = EntityState.Unchanged;
            //model.IsRemove = true;
            //if(saved)
            //{
            //    await _db.SaveChangesAsync();
            //}
        }

        public async Task SavedAsync()
        {
            await _db.SaveChangesAsync();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }



    }
}
