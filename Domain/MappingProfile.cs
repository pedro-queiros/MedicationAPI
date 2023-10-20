using AutoMapper;
using Data;

namespace Domain
{
    /// <summary>
    /// Mapping profile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<MedicationDTO, Medication>();
        }
    }
}
