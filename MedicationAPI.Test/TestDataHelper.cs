using MedicationAPI_DAL.Models;

namespace MedicationAPI_DAL.Tests
{
    public static class TestDataHelper
    {
        #region Public Methods

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
