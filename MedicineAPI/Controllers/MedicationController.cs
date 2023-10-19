using Asp.Versioning;
using MedicationAPI_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using MedicationAPI_BAL.Contracts;

namespace MedicationAPI.Controllers
{
    /// <summary>
    /// The Medication Controller to manage the medication actions.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.OData.Routing.Controllers.ODataController" />
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MedicationController : ODataController
    {
        #region Attributes

        private readonly IServiceMedication _serviceMedication;
        private readonly ILogger<MedicationController> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationController"/> class.
        /// </summary>
        /// <param name="serviceMedication">The service medication.</param>
        public MedicationController(IServiceMedication serviceMedication, ILogger<MedicationController> logger)
        {
            _serviceMedication = serviceMedication;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all medications asynchronous.
        /// </summary>
        /// <returns>
        /// The enumerable of medications.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<Medication>>> GetAllMedicationsAsync() 
        {
            try
            {
                return Ok(await _serviceMedication.GetAllAsync());
            }
            catch (Exception ex)
            {
                HandleUnexpectedError("GetAllMedicationsAsync", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,  "Internal Server Error");
            }            
        }

        /// <summary>
        /// Gets the medication asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The medication with the corresponding identifier.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [EnableQuery()]
        public async Task<ActionResult<Medication>> GetMedicationAsync(int id)
        {
            try
            {
                Medication medication = await _serviceMedication.GetByIdAsync(id);

                if (medication is null)
                    return NotFound();

                return Ok(medication);
            }
            catch (Exception ex)
            {
                HandleUnexpectedError("GetMedicationAsync", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        /// <summary>
        /// Creates the medication asynchronous.
        /// </summary>
        /// <param name="medication">The medication.</param>
        /// <returns>
        /// The medication created.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateMedicationAsync(Medication medication)
        {
            try
            {
                if (medication is null)
                    return BadRequest();

                Medication result = await _serviceMedication.CreateAsync(medication);

                return CreatedAtAction(nameof(GetMedicationAsync), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                HandleUnexpectedError("CreateMedicationAsync", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        /// <summary>
        /// Updates the medication asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="medication">The medication.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateMedicationAsync(int id, Medication medication)
        {
            try
            {
                if (medication is null)
                    return BadRequest();

                if (await _serviceMedication.UpdateAsync(id, medication) is null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                HandleUnexpectedError("UpdateMedicationAsync", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        /// <summary>
        /// Deletes the medication asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteMedicationAsync(int id)
        {
            try
            {
                if (await _serviceMedication.DeleteAsync(id) == 0)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                HandleUnexpectedError("DeleteMedicationAsync", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        #endregion

        #region Private Methods

        private void HandleUnexpectedError(string methodName, Exception ex)
        {
            _logger.LogError($"Unexpected error occurred on '{methodName}' method. Exception: {ex}.");
        }

        #endregion
    }
}
