
using AutoMapper;
using Musgo.Domain.Models;

namespace Musgo.Application.Features.Alternative.DeleteById;

public class DeleteByIdAlternativeMapper : Profile
{
    public CreateAlternativeapper()
    {
        CreateMap<CreateAlternativeRequest, Alternative>();
        CreateMap<Alternative, CreateAlternativeResponse>();
    }
}
