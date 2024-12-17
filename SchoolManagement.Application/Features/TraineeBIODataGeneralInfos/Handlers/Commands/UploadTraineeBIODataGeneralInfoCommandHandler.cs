using MediatR;
using OfficeOpenXml;
using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Application.Contracts.Persistence;
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
    public class UploadTraineeBIODataGeneralInfoCommandHandler : IRequestHandler<UploadTraineeBIODataGeneralInfoCommand, BaseCommandResponse>
    {
        private readonly ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public UploadTraineeBIODataGeneralInfoCommandHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfo, IUnitOfWork unitOfWork, IUserService userService)
        {
            _TraineeBioDataGeneralInfo = traineeBioDataGeneralInfo;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        public async Task<BaseCommandResponse> Handle(UploadTraineeBIODataGeneralInfoCommand request, CancellationToken cancellationToken)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var response = new BaseCommandResponse();
            int successCount = 0;
            int errorCount = 0;

            using (var stream = new MemoryStream())
            {
                await request.TraineeBIODataGeneralInfoFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {

                        var pno = worksheet.Cells[row, 2].Text;

                        var bioData = new TraineeBioDataGeneralInfo();
                        bioData.Pno = worksheet.Cells[row, 3].Text;
                        bioData.Name = worksheet.Cells[row, 4].Text;

                        var PnoExits = _TraineeBioDataGeneralInfo.FindOne(x=> x.Pno == bioData.Pno);
                        if(PnoExits != null)
                        {
                            response.Success = false;
                            response.Message = "Creation Failed, Pno already exist";
                            //response.Id = bioData.Pno;
                            errorCount++;
                        }
                        else
                        {
                            await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Add(bioData);

                            try
                            {
                                await _unitOfWork.Save();
                                //_userService.CreateUser("",bioData.TraineeId.ToString(), bioData);
                                successCount++;
                            }
                            catch (Exception ex)
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
    }

