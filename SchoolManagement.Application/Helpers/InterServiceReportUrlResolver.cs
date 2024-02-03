using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class InterServiceReportUrlResolver : IValueResolver<InterServiceCourseReport, InterServiceCourseReportDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public InterServiceReportUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(InterServiceCourseReport source, InterServiceCourseReportDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Doc))
            {
                return _config["ApiUrl"]  + source.Doc;
            }

            return null;
        }
    }
}
