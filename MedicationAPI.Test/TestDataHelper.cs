using MedicationAPI_DAL.Models;

namespace MedicationAPI.Tests
{
    /// <summary>
    /// Test Data Helper with the fake data for the tests.
    /// </summary>
    public static class TestDataHelper
    {
        #region Public Methods

        /// <summary>
        /// Gets the fake medication list.
        /// </summary>
        /// <returns>
        /// List of Medication.
        /// </returns>
        public static List<Medication> GetFakeMedicationList()
        {
            return new List<Medication>()
            {
                new Medication { Id = 1, Name = "Test1", Quantity = 1, CreationDate = new DateTime(2023, 10, 17) },
                new Medication { Id = 2, Name = "Test2", Quantity = 5, CreationDate = new DateTime(2023, 10, 12) },
                new Medication { Id = 3, Name = "Test3", Quantity = 10, CreationDate = new DateTime(2023, 10, 10) },
            };
        }

        #endregion
    }
}
