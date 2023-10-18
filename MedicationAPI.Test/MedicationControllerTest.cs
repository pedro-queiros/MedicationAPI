using MedicationAPI.Controllers;
using MedicationAPI.Models;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Xunit;


namespace MedicationAPI.Tests
{
    public class MedicationControllerTest
    {
        private readonly Mock<IMedicationDb> _db;
        private readonly MedicationController _controller;
        public MedicationControllerTest()
        {
            _db = new Mock<IMedicationDb>();
            _controller = new MedicationController(_db.Object);
        }

        [Fact]
        public async Task TestGetMedications()
        {
            // Arrange
            var dbSetMock = TestDataHelper.GetFakeMedicationList().BuildMock().BuildMockDbSet();
            _db.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            var medications = (await _controller.GetMedications()).Value;

            // Assert
            Assert.NotNull(medications);
            Assert.Equal(3, medications.Count());
        }

        [Fact]
        public async Task TestGetMedicationWithValidId()
        {
            // Arrange
            var dbSetMock = TestDataHelper.GetFakeMedicationList().BuildMock().BuildMockDbSet();
            dbSetMock.Setup(x => x.FindAsync(1)).ReturnsAsync(TestDataHelper.GetFakeMedicationList().Find(m => m.Id == 1));
            _db.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            var medication = (await _controller.GetMedication(1)).Value;

            // Assert
            Assert.NotNull(medication);
            Assert.Equal(1, medication.Id);
        }

        [Fact]
        public async Task TestGetMedicationWithInvalidId()
        {
            // Arrange
            var dbSetMock = TestDataHelper.GetFakeMedicationList().BuildMock().BuildMockDbSet();
            dbSetMock.Setup(x => x.FindAsync(4)).ReturnsAsync(TestDataHelper.GetFakeMedicationList().Find(m => m.Id == 4));
            _db.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            var medication = (await _controller.GetMedication(4)).Value;

            // Assert
            Assert.Null(medication);
        }

        [Fact]
        public async Task TestCreateMedication()
        {
            // Arrange
            var dbSetMock = new Mock<DbSet<Medication>>();
            var medication = new Medication() { Id = 1, Name = "Test1", Quantity = 1, CreationDate = new DateTime(2023, 10, 17) };
            _db.Setup(m => m.Medications).Returns(dbSetMock.Object);

            // Act
            await _controller.CreateMedication(medication);

            // Assert
            dbSetMock.Verify(m => m.Add(It.IsAny<Medication>()), Times.Once());
            _db.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

        }

        [Fact]
        public async Task TestUpdateMedication()
        {
            // Arrange
            var dbSetMock = new Mock<DbSet<Medication>>();
            _db.Setup(m => m.Medications).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.FindAsync(1)).ReturnsAsync(TestDataHelper.GetFakeMedicationList().Find(m => m.Id == 1));

            // Act
            await _controller.UpdateMedication(1, new Medication());

            // Assert
            _db.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task TestDeleteMedication()
        {
            // Arrange
            var dbSetMock = new Mock<DbSet<Medication>>();
            _db.Setup(m => m.Medications).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.FindAsync(1)).ReturnsAsync(TestDataHelper.GetFakeMedicationList().Find(m => m.Id == 1));

            // Act
            await _controller.DeleteMedication(1);

            // Assert
            dbSetMock.Verify(m => m.Remove(It.IsAny<Medication>()), Times.Once());
            _db.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}