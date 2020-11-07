using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TritonExpress.Models;

namespace TritonExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaybillsController : ControllerBase
    {
        private readonly TritonExpressContext _context;

        public WaybillsController(TritonExpressContext context)
        {
            _context = context;
        }

        // GET: api/Waybills
        [HttpGet]
        public IEnumerable<Waybill> GetWaybill()
        {
            return _context.Waybill;
        }

        // GET: api/Waybills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWaybill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var waybill = await _context.Waybill.Include(i => i.Vehicle).FirstOrDefaultAsync(i => i.WaybillId == id);


            if (waybill == null)
            {
                return NotFound();
            }

            return Ok(waybill);
        }

        // PUT: api/Waybills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaybill([FromRoute] int id, [FromBody] Waybill waybill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != waybill.WaybillId)
            {
                return BadRequest();
            }

            _context.Entry(waybill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaybillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Waybills
        [HttpPost]
        public async Task<IActionResult> PostWaybill([FromBody] Waybill waybill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numberPlate = (from x in _context.Vehicles
                               where x.Vehicle_Registration_Number == waybill.Vehicle_Registration_Number
                               select x.Vehicle_Number_Plate).Single();

            Waybill obj = new Waybill();

            obj.WaybillId = waybill.WaybillId;
            obj.Waybill_Total_weight = waybill.Waybill_Total_weight;
            obj.Waybil_Total_Parcels_Allocated = waybill.Waybil_Total_Parcels_Allocated;
            obj.Vehicle_Registration_Number = waybill.Vehicle_Registration_Number;
            obj.Vehicle_Number_Plate = numberPlate.ToString();


            _context.Waybill.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaybill", new { id = waybill.WaybillId }, waybill);
        }

        // DELETE: api/Waybills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaybill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var waybill = await _context.Waybill.FindAsync(id);
            if (waybill == null)
            {
                return NotFound();
            }

            _context.Waybill.Remove(waybill);
            await _context.SaveChangesAsync();

            return Ok(waybill);
        }

        private bool WaybillExists(int id)
        {
            return _context.Waybill.Any(e => e.WaybillId == id);
        }
    }
}