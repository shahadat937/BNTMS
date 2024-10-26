using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using MediatR;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Domain;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetTraineeListForUserCreateRequestHandler : IRequestHandler<GetTraineeListForUserCreateRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _traineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;

        public GetTraineeListForUserCreateRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _traineeBioDataGeneralInfoRepository = traineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeListForUserCreateRequest request, CancellationToken cancellationToken)
        {

            //var spQuery = String.Format("exec [spGetTraineeListForUserCreate] '{0}', {1}",request.Pno);
            string pno = string.IsNullOrWhiteSpace(request.Pno) ? "''" : $"'{request.Pno}'";
            string spQuery = $"EXEC [dbo].[spGetTraineeListForUserCreate] @pno={pno}, @pageSize={request.PageSize}, @pageNumber={request.PageNumber}";


            var totalCount = 0;

            DataTable dataTable = _traineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

            //if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TotalCount"] != DBNull.Value)
            //{
            //    totalCount = Convert.ToInt32(dataTable.Rows[0]["TotalCount"]);
            //}






            //List<TraineeBioDataGeneralInfo> rows = dataTable.AsEnumerable()
            //    .Select(row => dataTable.Columns.Cast<DataColumn>()
            //    .ToDictionary(col => col.ColumnName, col => row[col]))
            //    .ToList().Select(x => new TraineeBioDataGeneralInfo
            //    {
            //        TraineeId = Convert.ToInt32(x["TraineeId"]),
            //        BnaBatchId = x.ContainsKey("BanBatchId") ? Convert.ToInt32(x["BanBatchId"]) : default(int),
            //        RankId = Convert.ToInt32(x["RankId"]),
            //        BranchId = Convert.ToInt32(x["BranchId"]),
            //        DivisionId = Convert.ToInt32(x["DivisionId"]),
            //        DistrictId = Convert.ToInt32(x["DistrictId"]),
            //        ThanaId = Convert.ToInt32(x["ThanaId"]),
            //        HeightId = Convert.ToInt32(x["HeightId"]),
            //        WeightId = Convert.ToInt32(x["WeightId"]),
            //        ColorOfEyeId = Convert.ToInt32(x["ColorOfEyeId"]),
            //        GenderId = Convert.ToInt32(x["GenderId"]),
            //        BloodGroupId = Convert.ToInt32(x["BloodGroupId"]),
            //        CountryId = Convert.ToInt32(x["CountryId"]),
            //        NationalityId = Convert.ToInt32(x["NationalityId"]),
            //        ReligionId = Convert.ToInt32(x["ReligionId"]),
            //        CasteId = Convert.ToInt32(x["CasteId"]),
            //        MaritalStatusId = Convert.ToInt32(x["MaritalStatusId"]),
            //        HairColorId = Convert.ToInt32(x["HairColorId"]),
            //        OfficerTypeId = Convert.ToInt32(x["OfficerTypeId"]),
            //        TraineeStatusId = Convert.ToInt32(x["TraineeStatusId"]),
            //        SaylorBranchId = Convert.ToInt32(x["SaylorBranchId"]),
            //        SaylorSubBranchId = Convert.ToInt32(x["SaylorSubBranchId"]),
            //        SaylorRankId = Convert.ToInt32(x["SaylorRankId"]),
            //        Name = Convert.ToString(x["Name"]),
            //        NickName = Convert.ToString(x["NickName"]),
            //        NameBangla = Convert.ToString(x["NameBangla"]),
            //        ChestNo = Convert.ToString(x["ChestNo"]),
            //        LocalNo = Convert.ToString(x["LocalNo"]),
            //        IdCardNo = Convert.ToString(x["IdCardNo"]),
            //        ShoeSize = Convert.ToString(x["ShoeSize"]),
            //        PantSize = Convert.ToString(x["PantSize"]),
            //        Nominee = Convert.ToString(x["Nominee"]),
            //        CloseRelative = Convert.ToString(x["CloseRelative"]),
            //        RelativeRelation = Convert.ToString(x["RelativeRelation"]),
            //        Mobile = Convert.ToString(x["Mobile"]),
            //        Email = Convert.ToString(x["Email"]),
            //        BnaPhotoUrl = Convert.ToString(x["BnaPhotoUrl"]),
            //        BnaNo = Convert.ToString(x["BnaNo"]),
            //        Pno = Convert.ToString(x["Pno"]),
            //        ShortCode = Convert.ToString(x["ShortCode"]),
            //        PresentBillet = Convert.ToString(x["PresentBillet"]),
            //        DateOfBirth = Convert.ToDateTime(x["DateOfBirth"]),
            //        JoiningDate = Convert.ToDateTime(x["JoiningDate"]),
            //        IdentificationMark = Convert.ToString(x["IdentificationMark"]),
            //        PresentAddress = Convert.ToString(x["PresentAddress"]),
            //        PermanentAddress = Convert.ToString(x["PermanentAddress"]),
            //        PassportNo = Convert.ToString(x["PassportNo"]),
            //        Nid = Convert.ToString(x["Nid"]),
            //        Remarks = Convert.ToString(x["Remarks"]),
            //        MenuPosition = Convert.ToInt32(x["MenuPosition"]),
            //        CreatedBy = Convert.ToString(x["CreatedBy"]),
            //        DateCreated = Convert.ToDateTime(x["DateCreated"]),
            //        LastModifiedBy = Convert.ToString(x["LastModifiedBy"]),
            //        LastModifiedDate = Convert.ToDateTime(x["LastModifiedDate"]),
            //        IsActive = Convert.ToBoolean(x["IsActive"]),
            //        LocalNominationStatus = Convert.ToInt32(x["LocalNominationStatus"]),
            //        Seniority = Convert.ToString(x["Seniority"]),
            //        Place = Convert.ToString(x["Place"]),
            //        MedicalCategory = Convert.ToString(x["MedicalCategory"]),
            //        MarriedDate = Convert.ToDateTime(x["MarriedDate"]),
            //        FamilyLocation = Convert.ToString(x["FamilyLocation"]),
            //        NameofWife = Convert.ToString(x["NameofWife"]),
            //        BankAccount = Convert.ToString(x["BankAccount"]),
            //        EmergencyCommunicatePerson = Convert.ToString(x["EmergencyCommunicatePerson"]),
            //        Sports = Convert.ToString(x["Sports"]),
            //        Hobbies = Convert.ToString(x["Hobbies"]),
            //        Likeness = Convert.ToString(x["Likeness"]),
            //        Dislikeness = Convert.ToString(x["Dislikeness"]),
            //        CountryVisited = Convert.ToString(x["CountryVisited"])

            //    }).ToList();

            //        List<TraineeBioDataGeneralInfo> rows = dataTable.AsEnumerable()
            //.Select(row => dataTable.Columns.Cast<DataColumn>()
            //.ToDictionary(col => col.ColumnName, col => row[col]))
            //.ToList().Select(x => new TraineeBioDataGeneralInfo
            //{
            //    TraineeId = x["TraineeId"] != DBNull.Value ? Convert.ToInt32(x["TraineeId"]) : default(int),
            //    BnaBatchId = x.ContainsKey("BanBatchId") && x["BanBatchId"] != DBNull.Value ? Convert.ToInt32(x["BanBatchId"]) : default(int),
            //    RankId = x["RankId"] != DBNull.Value ? Convert.ToInt32(x["RankId"]) : default(int),
            //    BranchId = x["BranchId"] != DBNull.Value ? Convert.ToInt32(x["BranchId"]) : default(int),
            //    DivisionId = x["DivisionId"] != DBNull.Value ? Convert.ToInt32(x["DivisionId"]) : default(int),
            //    DistrictId = x["DistrictId"] != DBNull.Value ? Convert.ToInt32(x["DistrictId"]) : default(int),
            //    ThanaId = x["ThanaId"] != DBNull.Value ? Convert.ToInt32(x["ThanaId"]) : default(int),
            //    HeightId = x["HeightId"] != DBNull.Value ? Convert.ToString(x["HeightId"]) : null,
            //    WeightId = x["WeightId"] != DBNull.Value ? Convert.ToString(x["WeightId"]) : null,
            //    ColorOfEyeId = x["ColorOfEyeId"] != DBNull.Value ? Convert.ToInt32(x["ColorOfEyeId"]) : default(int),
            //    GenderId = x["GenderId"] != DBNull.Value ? Convert.ToInt32(x["GenderId"]) : default(int),
            //    BloodGroupId = x["BloodGroupId"] != DBNull.Value ? Convert.ToInt32(x["BloodGroupId"]) : default(int),
            //    CountryId = x["CountryId"] != DBNull.Value ? Convert.ToInt32(x["CountryId"]) : default(int),
            //    NationalityId = x["NationalityId"] != DBNull.Value ? Convert.ToInt32(x["NationalityId"]) : default(int),
            //    ReligionId = x["ReligionId"] != DBNull.Value ? Convert.ToInt32(x["ReligionId"]) : default(int),
            //    CasteId = x["CasteId"] != DBNull.Value ? Convert.ToInt32(x["CasteId"]) : default(int),
            //    MaritalStatusId = x["MaritalStatusId"] != DBNull.Value ? Convert.ToInt32(x["MaritalStatusId"]) : default(int),
            //    HairColorId = x["HairColorId"] != DBNull.Value ? Convert.ToInt32(x["HairColorId"]) : default(int),
            //    OfficerTypeId = x["OfficerTypeId"] != DBNull.Value ? Convert.ToInt32(x["OfficerTypeId"]) : default(int),
            //    TraineeStatusId = x["TraineeStatusId"] != DBNull.Value ? Convert.ToInt32(x["TraineeStatusId"]) : default(int),
            //    SaylorBranchId = x["SaylorBranchId"] != DBNull.Value ? Convert.ToInt32(x["SaylorBranchId"]) : default(int),
            //    SaylorSubBranchId = x["SaylorSubBranchId"] != DBNull.Value ? Convert.ToInt32(x["SaylorSubBranchId"]) : default(int),
            //    SaylorRankId = x["SaylorRankId"] != DBNull.Value ? Convert.ToInt32(x["SaylorRankId"]) : default(int),
            //    Name = x["Name"] != DBNull.Value ? Convert.ToString(x["Name"]) : null,
            //    NickName = x["NickName"] != DBNull.Value ? Convert.ToString(x["NickName"]) : null,
            //    NameBangla = x["NameBangla"] != DBNull.Value ? Convert.ToString(x["NameBangla"]) : null,
            //    ChestNo = x["ChestNo"] != DBNull.Value ? Convert.ToString(x["ChestNo"]) : null,
            //    LocalNo = x["LocalNo"] != DBNull.Value ? Convert.ToString(x["LocalNo"]) : null,
            //    IdCardNo = x["IdCardNo"] != DBNull.Value ? Convert.ToString(x["IdCardNo"]) : null,
            //    ShoeSize = x["ShoeSize"] != DBNull.Value ? Convert.ToString(x["ShoeSize"]) : null,
            //    PantSize = x["PantSize"] != DBNull.Value ? Convert.ToString(x["PantSize"]) : null,
            //    Nominee = x["Nominee"] != DBNull.Value ? Convert.ToString(x["Nominee"]) : null,
            //    CloseRelative = x["CloseRelative"] != DBNull.Value ? Convert.ToString(x["CloseRelative"]) : null,
            //    RelativeRelation = x["RelativeRelation"] != DBNull.Value ? Convert.ToString(x["RelativeRelation"]) : null,
            //    Mobile = x["Mobile"] != DBNull.Value ? Convert.ToString(x["Mobile"]) : null,
            //    Email = x["Email"] != DBNull.Value ? Convert.ToString(x["Email"]) : null,
            //    BnaPhotoUrl = x["BnaPhotoUrl"] != DBNull.Value ? Convert.ToString(x["BnaPhotoUrl"]) : null,
            //    BnaNo = x["BnaNo"] != DBNull.Value ? Convert.ToString(x["BnaNo"]) : null,
            //    Pno = x["Pno"] != DBNull.Value ? Convert.ToString(x["Pno"]) : null,
            //    ShortCode = x["ShortCode"] != DBNull.Value ? Convert.ToString(x["ShortCode"]) : null,
            //    PresentBillet = x["PresentBillet"] != DBNull.Value ? Convert.ToString(x["PresentBillet"]) : null,
            //    DateOfBirth = x["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(x["DateOfBirth"]) : default(DateTime),
            //    JoiningDate = x["JoiningDate"] != DBNull.Value ? Convert.ToDateTime(x["JoiningDate"]) : default(DateTime),
            //    IdentificationMark = x["IdentificationMark"] != DBNull.Value ? Convert.ToString(x["IdentificationMark"]) : null,
            //    PresentAddress = x["PresentAddress"] != DBNull.Value ? Convert.ToString(x["PresentAddress"]) : null,
            //    PermanentAddress = x["PermanentAddress"] != DBNull.Value ? Convert.ToString(x["PermanentAddress"]) : null,
            //    PassportNo = x["PassportNo"] != DBNull.Value ? Convert.ToString(x["PassportNo"]) : null,
            //    Nid = x["Nid"] != DBNull.Value ? Convert.ToString(x["Nid"]) : null,
            //    Remarks = x["Remarks"] != DBNull.Value ? Convert.ToString(x["Remarks"]) : null,
            //    MenuPosition = x["MenuPosition"] != DBNull.Value ? Convert.ToInt32(x["MenuPosition"]) : default(int),
            //    CreatedBy = x["CreatedBy"] != DBNull.Value ? Convert.ToString(x["CreatedBy"]) : null,
            //    DateCreated = x["DateCreated"] != DBNull.Value ? Convert.ToDateTime(x["DateCreated"]) : default(DateTime),
            //    LastModifiedBy = x["LastModifiedBy"] != DBNull.Value ? Convert.ToString(x["LastModifiedBy"]) : null,
            //    LastModifiedDate = x["LastModifiedDate"] != DBNull.Value ? Convert.ToDateTime(x["LastModifiedDate"]) : default(DateTime),
            //    IsActive = x["IsActive"] != DBNull.Value ? Convert.ToBoolean(x["IsActive"]) : default(bool),
            //    LocalNominationStatus = x["LocalNominationStatus"] != DBNull.Value ? Convert.ToInt32(x["LocalNominationStatus"]) : default(int),
            //    Seniority = x["Seniority"] != DBNull.Value ? Convert.ToString(x["Seniority"]) : null,
            //    Place = x["Place"] != DBNull.Value ? Convert.ToString(x["Place"]) : null,
            //    MedicalCategory = x["MedicalCategory"] != DBNull.Value ? Convert.ToString(x["MedicalCategory"]) : null,
            //    MarriedDate = x["MarriedDate"] != DBNull.Value ? Convert.ToDateTime(x["MarriedDate"]) : default(DateTime),
            //    FamilyLocation = x["FamilyLocation"] != DBNull.Value ? Convert.ToString(x["FamilyLocation"]) : null,
            //    NameofWife = x["NameofWife"] != DBNull.Value ? Convert.ToString(x["NameofWife"]) : null,
            //    BankAccount = x["BankAccount"] != DBNull.Value ? Convert.ToString(x["BankAccount"]) : null,
            //    EmergencyCommunicatePerson = x["EmergencyCommunicatePerson"] != DBNull.Value ? Convert.ToString(x["EmergencyCommunicatePerson"]) : null,
            //    Sports = x["Sports"] != DBNull.Value ? Convert.ToString(x["Sports"]) : null,
            //    Hobbies = x["Hobbies"] != DBNull.Value ? Convert.ToString(x["Hobbies"]) : null,
            //    Likeness = x["Likeness"] != DBNull.Value ? Convert.ToString(x["Likeness"]) : null,
            //    Dislikeness = x["Dislikeness"] != DBNull.Value ? Convert.ToString(x["Dislikeness"]) : null,
            //    CountryVisited = x["CountryVisited"] != DBNull.Value ? Convert.ToString(x["CountryVisited"]) : null
            //}).ToList();

            //        var TraineeBioDataGeneralInfoDtos = _mapper.Map<List<TraineeBioDataGeneralInfoDto>>(rows);
            //        var result = new PagedResult<TraineeBioDataGeneralInfoDto>(TraineeBioDataGeneralInfoDtos, totalCount, request.PageNumber, request.PageSize);

            //        return result;


        }
    }
}
