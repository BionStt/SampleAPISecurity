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

        public async Task Delete(Barang obj)
        {
            var model = await GetById(obj.KodeBarang);
            try
            {
                if (model == null)
                    throw new Exception($"Data {obj.NamaBarang} tidak ditemukan");
                _db.Remove(model);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public async Task Update(Barang obj)
        {
            var model = await GetById(obj.KodeBarang);
            try
            {
                if (model == null)
                    throw new Exception($"Data {obj.NamaBarang} tidak ditemukan");
                model.NamaBarang = obj.NamaBarang;
                model.Jumlah = obj.Jumlah;
                model.HargaBeli = obj.HargaBeli;
                model.HargaJual = obj.HargaJual;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
