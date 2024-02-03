using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Commands
{
    public class DeleteCovidVaccineCommandHandler : IRequestHandler<DeleteCovidVaccineCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCovidVaccineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCovidVaccineCommand request, CancellationToken cancellationToken)
        {
            var CovidVaccine = await _unitOfWork.Repository<CovidVaccine>().Get(request.CovidVaccineId);

            if (CovidVaccine == null)
                throw new NotFoundException(nameof(CovidVaccine), request.CovidVaccineId);

            await _unitOfWork.Repository<CovidVaccine>().Delete(CovidVaccine);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
