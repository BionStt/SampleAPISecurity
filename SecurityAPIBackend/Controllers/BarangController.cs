using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityAPIBackend.Models;
using SecurityAPIBackend.Services;

namespace SecurityAPIBackend.Controllers
{
    //
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private IBarang _barang;
        public BarangController(IBarang barang)
        {
            _barang = barang;
        }

        // GET: api/Barang
        [HttpGet]
        public async Task<IEnumerable<Barang>> Get()
        {
            var models = await _barang.GetAll();
            return models;
        }

        // GET: api/Barang/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Barang> Get(string id)
        {
            var model = await _barang.GetById(id);
            return model;
        }

        // POST: api/Barang
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Barang barang)
        {
            try
            {
                await _barang.Create(barang);
                return Ok(barang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Barang/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Barang barang)
        {
            try
            {
                await _barang.Update(barang);
                return Ok(barang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Barang barang)
        {
            try
            {
                await _barang.Delete(barang);
                return Ok(barang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
