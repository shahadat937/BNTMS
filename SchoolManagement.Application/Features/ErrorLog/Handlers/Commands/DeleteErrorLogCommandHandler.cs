using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ErrorLogs.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ErrorLog.Handlers.Commands
{
    public class DeleteErrorLogCommandHandler : IRequestHandler<DeleteErrorLogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteErrorLogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteErrorLogCommand request, CancellationToken cancellationToken)
        {
            var errorLog = await _unitOfWork.Repository<SchoolManagement.Domain.ErrorLog>().Get(request.ErrorLogId);

            if (errorLog == null)
                throw new NotFoundException(nameof(ErrorLog), request.ErrorLogId);

            // Convert relative path to absolute path
            string filePath = Path.Combine("wwwroot/Content", errorLog.FileUpload);

            // Delete file if it exists
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Delete the error log entry from the database
            await _unitOfWork.Repository<SchoolManagement.Domain.ErrorLog>().Delete(errorLog);

            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Unit.Value;
        }


    }
}
