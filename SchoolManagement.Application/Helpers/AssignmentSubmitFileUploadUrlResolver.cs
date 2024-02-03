using AutoMapper;
using SchoolManagement.Domain;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;

namespace SchoolManagement.Application.Helpers
{
    public class AssignmentSubmitFileUploadUrlResolver : IValueResolver<TraineeAssignmentSubmit, TraineeAssignmentSubmitDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public AssignmentSubmitFileUploadUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(TraineeAssignmentSubmit source, TraineeAssignmentSubmitDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUpload))
            {
                return _config["ApiUrl"]  + source.ImageUpload;
            }

            return null;
        }
    }
}
