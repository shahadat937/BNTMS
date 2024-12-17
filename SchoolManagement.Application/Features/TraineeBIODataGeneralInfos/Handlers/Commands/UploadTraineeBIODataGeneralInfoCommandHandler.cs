using AutoMapper;
using MediatR;
using OfficeOpenXml;
using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
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
        private readonly ISchoolManagementRepository<Domain.SaylorRank> _sylorRank;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ColorOfEye> _colorOfEye;
        private readonly ISchoolManagementRepository<HairColor> _hairColor;
        private readonly ISchoolManagementRepository<MaritalStatus> _maritalStatus;
        private readonly ISchoolManagementRepository<Branch> _branch;
        private readonly ISchoolManagementRepository<Gender> _gender;
        private readonly ISchoolManagementRepository<Religion> _religion;
        private readonly ISchoolManagementRepository<BloodGroup> _bloodGroup;

        public UploadTraineeBIODataGeneralInfoCommandHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfo, IUnitOfWork unitOfWork, IUserService userService, ISchoolManagementRepository<SaylorRank> sylorRank, IMapper mapper, ISchoolManagementRepository<ColorOfEye> colorOfEye,
            ISchoolManagementRepository<BloodGroup> bloodGroup, ISchoolManagementRepository<HairColor> hairColor, ISchoolManagementRepository<MaritalStatus> maritalStatus
            , ISchoolManagementRepository<Gender> gender, ISchoolManagementRepository<Branch> branch, ISchoolManagementRepository<Religion> religion)
        {
            _TraineeBioDataGeneralInfo = traineeBioDataGeneralInfo;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _sylorRank = sylorRank;
            _mapper = mapper;
            _colorOfEye = colorOfEye;
            _bloodGroup = bloodGroup;
            _hairColor = hairColor;
            _gender = gender;
            _branch = branch;
            _maritalStatus = maritalStatus;
            _religion = religion;
        }
        public async Task<BaseCommandResponse> Handle(UploadTraineeBIODataGeneralInfoCommand request, CancellationToken cancellationToken)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var response = new BaseCommandResponse();
            int successCount = 0;
            int errorCount = 0;
            var failedPnoList = new List<string>();

            using (var stream = new MemoryStream())
            {
                await request.TraineeBIODataGeneralInfoFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 3; row <= rowCount; row++)
                    {

                        if (worksheet.Cells[row, 2].Text == null || worksheet.Cells[row, 2].Text == "")
                            break;

                        var bioData = new TraineeBioDataGeneralInfo();
                        bioData.Pno = worksheet.Cells[row, 2].Text;
                        bioData.Name = worksheet.Cells[row, 3].Text;
                        bioData.NameBangla = worksheet.Cells[row, 4].Text;
                        bioData.NickName = worksheet.Cells[row, 5].Text;
                        var rank = _sylorRank.FindOne(x => x.Name == worksheet.Cells[row, 6].Text);

                        if(rank != null)
                        bioData.SaylorRankId = rank.SaylorRankId;

                        var branch = _branch.FindOne(x => x.BranchName == worksheet.Cells[row, 7].Text);

                        if (branch != null)
                        {
                            bioData.BranchId = branch.BranchId;
                        }
                        bioData.LocalNo = worksheet.Cells[row, 8].Text;
                        bioData.Mobile = worksheet.Cells[row, 9].Text;
                        bioData.Nid = worksheet.Cells[row, 10].Text;

                        string dateString = worksheet.Cells[row, 11].Text;

                        try
                        {
                            bioData.DateOfBirth = DateTime.Parse(dateString);
                        }
                        catch (FormatException)
                        {
                            bioData.DateOfBirth = null;
                        }
                        bioData.Email = worksheet.Cells[row, 12].Text;
                        bioData.WeightId = worksheet.Cells[row, 13].Text;
                        bioData.HeightId = worksheet.Cells[row, 14].Text;

                        var eyeColor = _colorOfEye.FindOne(x => x.ColorOfEyeName == worksheet.Cells[row, 15].Text);
                        if(eyeColor != null)
                        bioData.ColorOfEyeId = eyeColor.ColorOfEyeId;

                        var heirColor = _hairColor.FindOne(x => x.HairColorName == worksheet.Cells[row, 16].Text);
                        if(heirColor !=null)
                        bioData.HairColorId = heirColor.HairColorId;

                        var bloodGroup = _bloodGroup.FindOne(x => x.BloodGroupName == worksheet.Cells[row, 17].Text);

                        if (bloodGroup != null)
                        {
                            bioData.BloodGroupId = bloodGroup.BloodGroupId;
                        }


                        bioData.IdentificationMark = worksheet.Cells[row, 18].Text;

                        var religion = _religion.FindOne(x => x.ReligionName == worksheet.Cells[row, 19].Text);
                        if (religion != null)
                            bioData.ReligionId = religion.ReligionId;

                        var maritalStatus = _maritalStatus.FindOne(x => x.MaritalStatusName == worksheet.Cells[row, 20].Text);
                        if (maritalStatus != null)
                            bioData.MaritalStatusId = maritalStatus.MaritalStatusId;
                        bioData.Nominee = worksheet.Cells[row, 21].Text;
                        bioData.RelativeRelation = worksheet.Cells[row, 22].Text;

                        var gender = _gender.FindOne(x => x.GenderName == worksheet.Cells[row, 23].Text);
                        if (gender != null)
                            bioData.GenderId = gender.GenderId;
                        bioData.PermanentAddress = worksheet.Cells[row, 24].Text;
                        bioData.Remarks = worksheet.Cells[row, 25].Text;
                        bioData.TraineeStatusId = 5;

                        var PnoExits = _TraineeBioDataGeneralInfo.FindOne(x => x.Pno == bioData.Pno);
                        if (PnoExits != null)
                        {
                            response.Success = false;
                            response.Message = "Creation Failed, Pno already exist";
                            //response.Id = bioData.Pno;
                            errorCount++;
                            failedPnoList.Add(worksheet.Cells[row, 2].Text);
                        }
                        else
                        {
                            await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Add(bioData);

                            try
                            {
                                await _unitOfWork.Save();
                                var traineeDto = _mapper.Map<CreateTraineeBioDataGeneralInfoDto>(bioData);
                                traineeDto.RoleName = "Student";
                                traineeDto.Password = "Admin@123";
                                traineeDto.ConfirmPassword = "Admin@123";
                                await _userService.CreateUser("", bioData.TraineeId.ToString(), traineeDto);
                                successCount++;
                            }
                            catch (Exception ex)
                            {
                                errorCount++;
                                failedPnoList.Add(worksheet.Cells[row, 2].Text);
                            }

                        }
                    }
                }
                // Save the failed Pno list to a text file on Desktop
                if (failedPnoList.Any())
                {
                    var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string todayDate = DateTime.Now.ToString("yyyyMMdd");
                    var failedPnoFilePath = Path.Combine(desktopPath, $"FailedPnoList_{todayDate}.txt");
                    await File.WriteAllLinesAsync(failedPnoFilePath, failedPnoList);
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

