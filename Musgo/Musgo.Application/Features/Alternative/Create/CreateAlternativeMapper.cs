
using AutoMapper;
using Musgo.Domain.Models;

namespace Musgo.Application.Features.Alternative.Create;

public class CreateAlternativeMapper : Profile
{
    public CreateAlternativeapper()
    {
        CreateMap<CreateAlternativeRequest, Alternative>();
        CreateMap<Alternative, CreateAlternativeResponse>();
    }
}
