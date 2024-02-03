using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo
{
    public interface ITraineeBioDataGeneralInfoDto
    {

        public int TraineeId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? RankId { get; set; }
        public int? BranchId { get; set; }
        public int? DivisionId { get; set; }
        public int? DistrictId { get; set; }
        public int? ThanaId { get; set; }
        public int? HeightId { get; set; }
        public int? WeightId { get; set; }
        public int? ColorOfEyeId { get; set; }
        public int? GenderId { get; set; }
        public int? BloodGroupId { get; set; }
        public int? NationalityId { get; set; }
        public int? CountryId { get; set; }
        public int? ReligionId { get; set; }
        public int? CasteId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? HairColorId { get; set; }
        public int? OfficerTypeId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorRankId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? NameBangla { get; set; }
        public string? ChestNo { get; set; }
        public string? LocalNo { get; set; }
        public string? IdCardNo { get; set; }
        public string? ShoeSize { get; set; }
        public string? PantSize { get; set; }
        public string? Nominee { get; set; }
        public string? CloseRelative { get; set; }
        public string? RelativeRelation { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? BnaPhotoUrl { get; set; }
        public string? BnaNo { get; set; }
        public string? Pno { get; set; }
        public string? ShortCode { get; set; }
        public string? PresentBillet { get; set; }

        public string? IdentificationMark { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public int? TraineeStatusId { get; set; }
        public string? PassportNo { get; set; }
        public string? Nid { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? LocalNominationStatus { get; set; }
    }
}
