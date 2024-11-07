using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineLibrary.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Handlers.Commands
{
    public class DeleteOnlineLibraryMaterialRequestHandler : IRequestHandler<DeleteOnlineLibraryMaterialRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public DeleteOnlineLibraryMaterialRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteOnlineLibraryMaterialRequest request, CancellationToken cancellationToken)
        {
            var onlineLibraryMaterial = await _unitOfWork.Repository<SchoolManagement.Domain.OnlineLibrary>().Get(request.OnlineLibraryId);
            if(onlineLibraryMaterial == null)
                throw new NotFoundException(nameof(onlineLibraryMaterial), request.OnlineLibraryId);

            if (!string.IsNullOrEmpty(onlineLibraryMaterial.DocumentLink))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\", onlineLibraryMaterial.DocumentLink);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            await _unitOfWork.Repository<SchoolManagement.Domain.OnlineLibrary>().Delete(onlineLibraryMaterial);
            await _unitOfWork.Save();
            

            return Unit.Value;
        }
    }
}
