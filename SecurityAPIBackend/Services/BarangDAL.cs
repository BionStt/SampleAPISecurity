using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityAPIBackend.Data;
using SecurityAPIBackend.Models;

namespace SecurityAPIBackend.Services
{
    public class BarangDAL : IBarang
    {
        private ApplicationDbContext _db;
        public BarangDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Barang obj)
        {
            try
            {
                _db.Barang.Add(obj);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Delete(Barang obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Barang>> GetAll()
        {
            var models = await (from b in _db.Barang
                          orderby b.NamaBarang ascending
                          select b).AsNoTracking().ToListAsync();
            return models;
        }

        public async Task<Barang> GetById(string id)
        {
            var model = await (from b in _db.Barang
                               where b.KodeBarang == id
                               select b).AsNoTracking().SingleOrDefaultAsync();
            if (model == null)
                throw new Exception($"Data {id} tidak ditemukan");
            return model;
        }

        public Task Update(Barang obj)
        {
            throw new NotImplementedException();
        }
    }
}
