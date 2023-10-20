using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace Data.Tests
{
    /// <summary>
    /// The MedicationRespositoryTest class, having the unit test methods for the MedicationRepository class.
    /// </summary>
    public class MedicationRepositoryTest
    {
        #region Attributes

        private readonly Mock<MedicationDbContext> _dbContext;
        private readonly RepositoryMedication _repository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationRepositoryTest"/> class.
        /// </summary>
        public MedicationRepositoryTest()
        {
            _dbContext = new Mock<MedicationDbContext>();
            _repository = new RepositoryMedication(_dbContext.Object);
        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Tests the GetAllAsync method.
        /// </summary>
        [Fact]
        public async Task Test_GetAllAsync()
        {
            // Arrange
            Mock<DbSet<Medication>> dbSetMock = MockData.GetMockMedications().BuildMock().BuildMockDbSet();
            _dbContext.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            IEnumerable<Medication> medications = await _repository.GetAllAsync();

            // Assert
            Assert.NotNull(medications);
            Assert.Equal(3, medications.Count());
        }

        /// <summary>
        /// Tests the GetByIdAsync method with valid identifier.
        /// </summary>
        [Fact]
        public async Task Test_GetByIdAsync_With_Valid_Id()
        {
            // Arrange
            Mock<DbSet<Medication>> dbSetMock = MockData.GetMockMedications().BuildMock().BuildMockDbSet();
            dbSetMock.Setup(x => x.FindAsync(1)).ReturnsAsync(MockData.GetMockMedications().Find(m => m.Id == 1));
            _dbContext.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            Medication medication = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(medication);
            Assert.Equal(1, medication.Id);
        }

        /// <summary>
        /// Tests the GetByIdAsync method with invalid identifier.
        /// </summary>
        [Fact]
        public async Task Test_GetByIdAsync_With_Invalid_Id()
        {
            // Arrange
            Mock<DbSet<Medication>> dbSetMock = MockData.GetMockMedications().BuildMock().BuildMockDbSet();
            dbSetMock.Setup(x => x.FindAsync(4)).ReturnsAsync(MockData.GetMockMedications().Find(m => m.Id == 4));
            _dbContext.Setup(x => x.Medications).Returns(dbSetMock.Object);

            // Act
            Medication medication = await _repository.GetByIdAsync(4);

            // Assert
            Assert.Null(medication);
        }

        /// <summary>
        /// Tests the CreateAsync method.
        /// </summary>
        [Fact]
        public async Task Test_CreateAsync()
        {
            // Arrange
            Medication medication = new Medication() { Id = 4, Name = "Aspirina", Quantity = 15, CreatedOn = new DateTime(2023, 10, 17) };

            // Act
            await _repository.CreateAsync(medication);

            // Assert
            _dbContext.Verify(m => m.Add(It.IsAny<Medication>()), Times.Once());
            _dbContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

        }

        /// <summary>
        /// Tests the UpdateAsync method.
        /// </summary>
        [Fact]
        public async Task Test_UpdateAsync()
        {
            // Arrange
            Medication medication = new Medication { Id = 2, Name = "Brufen", Quantity = 7, CreatedOn = new DateTime(2023, 10, 12) };

            // Act
            await _repository.UpdateAsync(new Medication());

            // Assert
            _dbContext.Verify(m => m.Update(It.IsAny<Medication>()), Times.Once());
            _dbContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        /// <summary>
        /// Tests the DeleteAsync method.
        /// </summary>
        [Fact]
        public async Task Test_DeleteAsync()
        {
            // Arrange
            Medication medication = new Medication { Id = 2, Name = "Brufen", Quantity = 5, CreatedOn = new DateTime(2023, 10, 12) };

            // Act
            await _repository.DeleteAsync(new Medication());

            // Assert
            _dbContext.Verify(m => m.Remove(It.IsAny<Medication>()), Times.Once());
            _dbContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        #endregion
    }
}
