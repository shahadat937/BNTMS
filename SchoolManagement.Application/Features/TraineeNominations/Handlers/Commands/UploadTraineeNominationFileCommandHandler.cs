using AutoMapper;
using MediatR;
using OfficeOpenXml;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;
using SchoolManagement.Application.Models.Identity;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Commands
{
    public class UploadTraineeNominationFileCommandHandler : IRequestHandler<UploadTraineeNominationFileCommand, BaseCommandResponse>
    {

        private readonly ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfo;
        private readonly IUnitOfWork _unitOfWork;
        public UploadTraineeNominationFileCommandHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfo, IUnitOfWork unitOfWork)
        {
            _TraineeBioDataGeneralInfo = traineeBioDataGeneralInfo;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UploadTraineeNominationFileCommand request, CancellationToken cancellationToken)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var response = new BaseCommandResponse();
            int successCount = 0;
            int errorCount = 0;

            using (var stream = new MemoryStream())
            {
                await request.TraineeNominationFile.CopyToAsync(stream);
                using(var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row < rowCount; row++)
                    {
                        var cellValue = worksheet.Cells[row, 2].Text;

                        if (string.IsNullOrWhiteSpace(cellValue))
                        {
                            break;
                        }
                        var pno = worksheet.Cells[row, 2].Text;

                        var traineeInformation = _TraineeBioDataGeneralInfo.Where(x => x.Pno == pno).FirstOrDefault();
                        if (traineeInformation != null)
                        {
                            var traineeNomination = new TraineeNomination();

                            traineeNomination.CourseAttendState = 0;
                            traineeNomination.BranchId = traineeInformation.BranchId;
                            traineeNomination.CourseDurationId = request.CourseDurationId;
                            traineeNomination.CourseNameId = request.CourseNameId;
                            traineeNomination.SaylorBranchId = traineeInformation.SaylorBranchId;
                            traineeNomination.SaylorRankId = traineeInformation.SaylorRankId;
                            traineeNomination.SaylorSubBranchId = traineeInformation.SaylorSubBranchId;
                            traineeNomination.TraineeId = traineeInformation.TraineeId;

                            var getTraineeNomination = _unitOfWork.Repository<TraineeNomination>().Where(x => x.CourseDurationId == traineeNomination.CourseDurationId && x.TraineeId == traineeNomination.TraineeId).FirstOrDefault();

                            if (getTraineeNomination != null)
                            {
                                response.Success = false;
                                response.Message = "Creation Failed, Trainee already exist";
                                response.Id = traineeNomination.TraineeNominationId;
                                errorCount++;
                            }
                            else
                            {
                                await _unitOfWork.Repository<TraineeNomination>().Add(traineeNomination);

                                try
                                {
                                    await _unitOfWork.Save();
                                    successCount++;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    errorCount++;
                                }

                            }
                        }
                        else
                        {
                            errorCount++;
                        }
                    }
                }
            }

            if (successCount > 0)
            {
                response.Success = true;
                response.Message = $"{successCount} Successful & {errorCount} Unsuccessful";
            }
            else
            {
                response.Success = false;
                response.Message = $"{successCount} Successful & {errorCount} Unsuccessful";
            }

            return response;
        }
    }
}