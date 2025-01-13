using MediatR;
using OfficeOpenXml;
using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.User;
using SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Handlers.Commands
{
    public class UploadServiceInstructorCommandHandler : IRequestHandler<UploadServiceInstructorCommand, BaseCommandResponse>
    {
        private readonly ISchoolManagementRepository<AspNetUsers> _aspUserRepository;
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _traineeBioDataGeneralInfo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UploadServiceInstructorCommandHandler(ISchoolManagementRepository<AspNetUsers> aspUserRepository, IUnitOfWork unitOfWork, ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfo, IUserService userService)
        {
            _aspUserRepository = aspUserRepository;
            _unitOfWork = unitOfWork;
            _traineeBioDataGeneralInfo = traineeBioDataGeneralInfo;
            _userService = userService;
        }
        public async Task<BaseCommandResponse> Handle(UploadServiceInstructorCommand request, CancellationToken cancellationToken)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var response = new BaseCommandResponse();
            var successCount = 0;
            var errorCount = 0;
            var errorLogs = new List<string>();


            using (var stream = new MemoryStream())
            {
                await request.ServiceInstructorFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
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

                        TraineeBioDataGeneralInfo traineeBioData = await _traineeBioDataGeneralInfo.FindOneAsync(x => x.Pno == pno);

                        if (traineeBioData != null)
                        {
                            var user = await _aspUserRepository.FindOneAsync(x => x.PNo == traineeBioData.TraineeId.ToString());
                            if (user != null)
                            {
                                if (user.BranchId == null || user.BranchId == "")
                                {

                                    CreateUserDto userDto = new CreateUserDto
                                    {
                                        TraineeId = user.PNo,
                                        RoleName = "Instructor",
                                    };

                                    await _userService.UpdateUserAsAServiceInstructor(user.Id, userDto, request.BranchId);
                                    successCount++;

                                }
                                else
                                {
                                    errorCount++;
                                    errorLogs.Add($"PNo: {user.PNo} already Assignd in other school.");
                                }

                            }
                            else
                            {
                                errorCount++;
                                errorLogs.Add($"PNo: {user.PNo} User Not Found");
                            }

                        }
                        else
                        {
                            errorCount++;
                            errorLogs.Add($"PNo: {pno} No Biodata found on system.");
                        }

                    }
                }
            }

            if(errorCount > 0)
            {
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var logFilePath = Path.Combine(desktopPath, "FailureLog.txt");
                await File.WriteAllLinesAsync(logFilePath, errorLogs);
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
