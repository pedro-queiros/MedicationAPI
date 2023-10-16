using MedicationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly MedicationDb _db;

        public MedicationController(MedicationDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications() 
        { 
            return await _db.Medications.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication (int id)
        {
            if ( await _db.Medications.FindAsync(id) is Medication medication)
                return medication;

            return NotFound();   
        }

        [HttpPost]
        public async Task<ActionResult> CreateMedication (Medication medication)
        {
            if (medication is null)
                return BadRequest();

            _db.Medications.Add(medication);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedication), new { id = medication.Id }, medication);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMedication (int id, Medication updatedMedication)
        {
            var medication = await _db.Medications.FindAsync(id);

            if (medication is null)
                return NotFound();

            medication.Name = updatedMedication.Name;
            medication.Quantity = updatedMedication.Quantity;
            medication.CreationDate = updatedMedication.CreationDate;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedication (int id)
        {
            if (await _db.Medications.FindAsync(id) is Medication medication)
            {
                _db.Medications.Remove(medication);
                await _db.SaveChangesAsync();
                return NoContent();
            }


            return NotFound();
        }
    }
}
