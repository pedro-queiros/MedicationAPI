namespace Data.Tests
{
    /// <summary>
    /// The MockData class with the mock data for the unit tests.
    /// </summary>
    public static class MockData
    {
        #region Public Methods

        /// <summary>
        /// Gets the mock list of medications.
        /// </summary>
        /// <returns>
        /// The mock list of medications.
        /// </returns>
        public static List<Medication> GetMockMedications()
        {
            return new List<Medication>()
            {
                new Medication { Id = 1, Name = "Ben-u-ron", Quantity = 1, CreatedOn = new DateTime(2023, 10, 17) },
                new Medication { Id = 2, Name = "Brufen", Quantity = 5, CreatedOn = new DateTime(2023, 10, 12) },
                new Medication { Id = 3, Name = "Dermovate", Quantity = 10, CreatedOn = new DateTime(2023, 10, 10) },
            };
        }

        #endregion
    }
}
