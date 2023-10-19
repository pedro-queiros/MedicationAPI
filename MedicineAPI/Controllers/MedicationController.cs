using Asp.Versioning;
using MedicationAPI_DAL.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MedicationAPI_BAL.Contracts;

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

        private readonly IServiceMedication _serviceMedication;

        #endregion

        #region Constructor

        public MedicationController(IServiceMedication serviceMedication)
        {
            _serviceMedication = serviceMedication;
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

            return Ok(await _serviceMedication.GetAllAsync());

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

            var medication = await _serviceMedication.GetByIdAsync(id);
            if (medication != null)
                return Ok(medication);

            return NotFound();

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateMedication (Medication medication)
        {

            if (medication is null)
                return BadRequest();

            await _serviceMedication.CreateAsync(medication);

            return CreatedAtAction(nameof(GetMedication), new { id = medication.Id }, medication);
           
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateMedication (int id, Medication medication)
        {

            await _serviceMedication.UpdateAsync(id, medication);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteMedication (int id)
        {

            await _serviceMedication.DeleteAsync(id);

            return NoContent();

        }

        #endregion
    }
}
