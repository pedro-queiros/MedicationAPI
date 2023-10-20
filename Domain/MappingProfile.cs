using AutoMapper;
using Data;

namespace Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MedicationDTO, Medication>();
        }
    }
}
