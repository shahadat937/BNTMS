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
            List<string> failedPnos = new List<string>(); // List to store failed PNOs

            using (var stream = new MemoryStream())
            {
                await request.TraineeNominationFile.CopyToAsync(stream);
                using(var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
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
                                failedPnos.Add(pno);
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
                                    failedPnos.Add(pno);
                                }

                            }
                        }
                        else
                        {
                            errorCount++;
                            failedPnos.Add(pno);
                        }
                    }
                }
            }

            // Save failed PNOs to a text file
            if (failedPnos.Count > 0)
            {
                string errorDirectory = Path.Combine("wwwroot", "Content", "files", "errorLog");
                string fileName = $"ErrorLog_{DateTime.Now:yyyyMMddHHmmss}.txt";
                string errorFilePath = Path.Combine(errorDirectory, fileName);
                string dbFilePath = $"files/errorLog/{fileName}"; // Ensures forward slashes for web paths

                // Ensure the directory exists before writing the file
                if (!Directory.Exists(errorDirectory))
                {
                    Directory.CreateDirectory(errorDirectory);
                }

                await File.WriteAllLinesAsync(errorFilePath, failedPnos);

                // Save error log in the database with relative path
                var errorLog = new SchoolManagement.Domain.ErrorLog
                {
                    Subject = "Trainee Nomination",
                    FailureCount = failedPnos.Count,
                    FileUpload = dbFilePath, // Store relative path in DB with correct slashes
                    CreatedDate = DateTime.Now
                };

                await _unitOfWork.Repository<SchoolManagement.Domain.ErrorLog>().Add(errorLog);
                await _unitOfWork.Save();
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