using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// Medication entity model representing a medication.
    /// </summary>
    public class MedicationDTO
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MinLength(1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        #endregion
    }
}
