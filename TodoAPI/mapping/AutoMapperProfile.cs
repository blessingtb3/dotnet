using AutoMapper;
using TodoAPI.Contracts;
using TodoAPI.Models;


namespace TodoAPI.MappingProfiles{

    // inherits from Profile (a class provided by AutoMapper), allows us to define mapping configurations.
    public class AutoMapperProfile : Profile{

        public AutoMapperProfile(){
        
            // CreateMap: creates a mapping between two objects
            CreateMap<CreateTodoRequest, Todo>()
                // ForMember: configures the mapping for a specific property. We're using it to ignore the id, CreatedAt, and UpdatedAt properties when mapping from the DTOs to the Todo model.
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<UpdateTodoRequest, Todo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}