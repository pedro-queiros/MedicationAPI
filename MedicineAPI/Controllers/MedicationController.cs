using Asp.Versioning;
using MedicationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.OData.Routing.Controllers.ODataController" />
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MedicationController : ODataController
    {
        #region Members

        private readonly IMedicationDb _db;

        #endregion

        #region Constructor

        public MedicationController(IMedicationDb db)
        {
            _db = db;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the medications.
        /// </summary>
        /// <returns>
        /// The enumerable of Medication.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications() 
        {
            
            return await _db.Medications.ToListAsync();

        }

        /// <summary>
        /// Gets the medication.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [EnableQuery()]
        public async Task<ActionResult<Medication>> GetMedication (int id)
        {

            if ( await _db.Medications.FindAsync(id) is Medication medication)
                return medication;

            return NotFound();   
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateMedication (Medication medication)
        {
            if (medication is null)
                return BadRequest();

            _db.Medications.Add(medication);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedication), new { id = medication.Id }, medication);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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

        #endregion
    }
}
