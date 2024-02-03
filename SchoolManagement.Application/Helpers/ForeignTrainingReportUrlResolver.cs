using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class ForeignTrainingReportUrlResolver : IValueResolver<ForeignTrainingCourseReport, ForeignTrainingCourseReportDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public ForeignTrainingReportUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ForeignTrainingCourseReport source, ForeignTrainingCourseReportDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Doc))
            {
                return _config["ApiUrl"]  + source.Doc;
            }

            return null;
        }
    }
}
