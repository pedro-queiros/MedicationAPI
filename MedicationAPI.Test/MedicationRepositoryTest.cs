using MedicationAPI_DAL.Data;
using MedicationAPI_DAL.Models;
using MedicationAPI_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Xunit;


namespace MedicationAPI_DAL.Tests
{
    public class MedicationRepositoryTest
    {
        #region Attributes

        private readonly Mock<MedicationDbContext> _dbContext;
        private readonly RepositoryMedication _repository;

        #endregion

        #region Constructors

        public MedicationRepositoryTest()
        {
            _dbContext = new Mock<MedicationDbContext>();
            _repository = new RepositoryMedication(_dbContext.Object);
        }

        #endregion

        #region Public Test Methods

        [Fact]
        public async Task TestGetMedications()
        {
            // Arrange
            Mock<DbSet<Medication>> dbSetMock = TestDataHelper.GetFakeMedicationList().BuildMock().BuildMockDbSet();
            _dbContext.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            IEnumerable<Medication> medications = await _repository.GetAllAsync();

            // Assert
            Assert.NotNull(medications);
            Assert.Equal(3, medications.Count());
        }

        [Fact]
        public async Task TestGetMedicationWithValidId()
        {
            // Arrange
            Mock<DbSet<Medication>> dbSetMock = TestDataHelper.GetFakeMedicationList().BuildMock().BuildMockDbSet();
            dbSetMock.Setup(x => x.FindAsync(1)).ReturnsAsync(TestDataHelper.GetFakeMedicationList().Find(m => m.Id == 1));
            _dbContext.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            Medication medication = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(medication);
            Assert.Equal(1, medication.Id);
        }

        [Fact]
        public async Task TestGetMedicationWithInvalidId()
        {
            // Arrange
            Mock<DbSet<Medication>> dbSetMock = TestDataHelper.GetFakeMedicationList().BuildMock().BuildMockDbSet();
            dbSetMock.Setup(x => x.FindAsync(4)).ReturnsAsync(TestDataHelper.GetFakeMedicationList().Find(m => m.Id == 4));
            _dbContext.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            Medication medication = await _repository.GetByIdAsync(4);

            // Assert
            Assert.Null(medication);
        }

        [Fact]
        public async Task TestCreateMedication()
        {
            // Arrange
            Medication medication = new Medication() { Id = 1, Name = "Test1", Quantity = 1, CreationDate = new DateTime(2023, 10, 17) };

            // Act
            await _repository.CreateAsync(medication);

            // Assert
            _dbContext.Verify(m => m.Add(It.IsAny<Medication>()), Times.Once());
            _dbContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

        }

        [Fact]
        public async Task TestUpdateMedication()
        {
            // Arrange

            // Act
            await _repository.UpdateAsync(new Medication());

            // Assert
            _dbContext.Verify(m => m.Update(It.IsAny<Medication>()), Times.Once());
            _dbContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task TestDeleteMedication()
        {
            // Arrange

            // Act
            await _repository.DeleteAsync(new Medication());

            // Assert
            _dbContext.Verify(m => m.Remove(It.IsAny<Medication>()), Times.Once());
            _dbContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        #endregion
    }
}