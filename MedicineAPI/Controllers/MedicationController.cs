using Asp.Versioning;
using MedicationAPI_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using MedicationAPI_BAL.Contracts;

namespace MedicationAPI.Controllers
{

    /// <summary>
    /// MedicationController class to manage the controllers for each endpoint
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.OData.Routing.Controllers.ODataController" />
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MedicationController : ODataController
    {
        #region Members

        /// <summary>
        /// The service medication
        /// </summary>
        private readonly IServiceMedication _serviceMedication;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationController"/> class.
        /// </summary>
        /// <param name="serviceMedication">The service medication.</param>
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
        /// <returns>
        /// The Ok response with the Medication with the respective id or Not Found response if id does not exists.
        /// </returns>
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

        /// <summary>
        /// Creates the medication.
        /// </summary>
        /// <param name="medication">The medication.</param>
        /// <returns>
        /// The created Medication or Bad Request if medications is null.
        /// </returns>
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

        /// <summary>
        /// Updates the medication.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="medication">The medication.</param>
        /// <returns>
        /// No Content response.
        /// </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateMedication (int id, Medication medication)
        {

            await _serviceMedication.UpdateAsync(id, medication);

            return NoContent();

        }

        /// <summary>
        /// Deletes the medication.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// No Content response.
        /// </returns>
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
