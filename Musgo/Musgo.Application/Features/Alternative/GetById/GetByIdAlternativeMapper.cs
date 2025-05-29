
using AutoMapper;
using Musgo.Domain.Models;

namespace Musgo.Application.Features.Alternative.GetById;

public class GetByIdAlternativeMapper : Profile
{
    public CreateAlternativeapper()
    {
        CreateMap<CreateAlternativeRequest, Alternative>();
        CreateMap<Alternative, CreateAlternativeResponse>();
    }
}
