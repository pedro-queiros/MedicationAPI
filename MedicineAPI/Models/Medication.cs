using System.ComponentModel.DataAnnotations;

namespace MedicationAPI.Models
{
    public class Medication
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } 

        public DateTime CreationDate { get; set; }
    }
}
