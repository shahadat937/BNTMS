using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.DTOs.Bulletin.Validators;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Commands
{
    public class CreateBulletinBulkDtoCommandHandler: IRequestHandler<CreateBulletinBulkCommand,BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBulletinBulkDtoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBulletinBulkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if(request.bulletinBulkDto.BaseSchoolNameId==null||request.bulletinBulkDto.BaseSchoolNameId.Count<=0)
            {
                throw new BadRequestException("No School is selected");
            }

            List<CreateBulletinDto> bulletinDtos = new List<CreateBulletinDto>();



            if(request.bulletinBulkDto.BaseSchoolNameId.Count<2)
            {
                if (request.bulletinBulkDto.CourseName == null || request.bulletinBulkDto.CourseName.Count <= 0)
                {
                    throw new BadRequestException("No Course is selected");
                }
                foreach (var courseName in request.bulletinBulkDto.CourseName)
                {
                    var bulletinDto = new CreateBulletinDto();
                    bulletinDto.BaseSchoolNameId = (int) (long) request.bulletinBulkDto.BaseSchoolNameId[0].Value;
                    string[] courseIdAndDuration = courseName.Split('_');

                    //Add Bulletin courseNameId and courseDurationId
                    if (courseIdAndDuration.Length != 2)
                    {
                        continue;
                        //throw new BadRequestException("Invalid Course");
                    }

                    if (int.TryParse(courseIdAndDuration[1], out var courseId))
                    {
                        bulletinDto.CourseNameId = courseId;
                    } else
                    {
                        throw new BadRequestException("Invalid Course");
                    }

                    if (int.TryParse(courseIdAndDuration[0], out var courseDurationId))
                    {
                        bulletinDto.CourseDurationId = courseDurationId;
                    } else
                    {
                        throw new BadRequestException("Invalid Course");
                    }

                    //
                    bulletinDto.Status = request.bulletinBulkDto.Status;
                    bulletinDto.BuletinDetails = request.bulletinBulkDto.BuletinDetails;
                    bulletinDto.IsActive = request.bulletinBulkDto.IsActive;
                    bulletinDto.MenuPosition = request.bulletinBulkDto.MenuPosition;

                    var validator = new CreateBulletinDtoValidator();
                    var validationResult = await validator.ValidateAsync(bulletinDto);

                    if (!validationResult.IsValid)
                    {
                        throw new ValidationException(validationResult);
                    }

                    bulletinDtos.Add(bulletinDto);
                }


            } else
            {

                foreach(var schoolNameId in request.bulletinBulkDto.BaseSchoolNameId)
                {
                    var bulletinDto = new CreateBulletinDto();
                    bulletinDto.BaseSchoolNameId = (int)(long)schoolNameId.Value;
                    bulletinDto.Status = request.bulletinBulkDto.Status;
                    bulletinDto.IsActive = request.bulletinBulkDto.IsActive;
                    bulletinDto.BuletinDetails = request.bulletinBulkDto.BuletinDetails;
                    bulletinDto.MenuPosition = request.bulletinBulkDto.MenuPosition;
                    bulletinDto.Status = request.bulletinBulkDto.Status;

                    var validator = new CreateBulletinDtoValidator();
                    var validationResult = await validator.ValidateAsync(bulletinDto);

                    if(!validationResult.IsValid)
                    {
                        throw new ValidationException(validationResult);
                    }

                    bulletinDtos.Add(bulletinDto);
                }
            }

            if(bulletinDtos.Count<=0)
            {
                throw new Exception("No Data is provided");
            }

            var bulletins = _mapper.Map<List<Domain.Bulletin>>(bulletinDtos);

            await _unitOfWork.Repository<Domain.Bulletin>().AddRangeAsync(bulletins);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
