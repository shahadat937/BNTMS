﻿using System;
using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo
{
    public class CreateTraineeBioDataGeneralInfoDto : ITraineeBioDataGeneralInfoDto
    {
        public int TraineeId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? RankId { get; set; }
        public int? BranchId { get; set; }
        public int? DivisionId { get; set; }
        public int? DistrictId { get; set; }
        public int? ThanaId { get; set; }
        public string? HeightId { get; set; }
        public string? WeightId { get; set; }
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
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }
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

        public string? Seniority { get; set; }
        public string? Place { get; set; }
        public string? MedicalCategory { get; set; }
        public DateTime? MarriedDate { get; set; }
        public string? FamilyLocation { get; set; }
        public string? NameofWife { get; set; }
        public string? BankAccount { get; set; }
        public string? EmergencyCommunicatePerson { get; set; }
        public string? CountryVisited { get; set; }
        public string? Dislikeness { get; set; }
        public string? Likeness { get; set; }
        public string? Hobbies { get; set; }
        public string? Sports { get; set; }
        //
        public IFormFile? Image { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? FirstName { get; set; }
        public string?  LastName { get; set; }
        public string? FirstLevel { get; set; }
        public string? SecondLevel { get; set; }
        public string? ThirdLevel { get; set; }
        public string? FourthLevel { get; set; }


    }
}
