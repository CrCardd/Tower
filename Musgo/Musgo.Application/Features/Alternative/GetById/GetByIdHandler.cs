
using AutoMapper;
using Musgo.Application.Common.Exceptions;
using Musgo.Application.Repository;
using Musgo.Application.Repository.ModuleRepository;
using Musgo.Domain.Common.Messages;
using Musgo.Domain.Models;
using MediatR;

namespace Musgo.Application.Features.Alternative.GetById;

public class GetByIdAlternative(
    IUnitOfWork unitOfWork,
    IAlternativeRepository alternativeRepository,
    IMapper mapper
) : IRequestHandler<CreateAlternativeRequest, CreateAlternativeResponse>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IAlternativeRepository alternativeRepository = alternativeRepository;
    private readonly IMapper mapper = mapper;

    public async Task<CreateAlternativeResponse> Handle(CreateAlternativeRequest request, CancellationToken cancellationToken)
    {
        


        await unitOfWork.Save(cancellationToken);
        return mapper.Map<CreateAlternativeResponse>(alternative);
    }
}
