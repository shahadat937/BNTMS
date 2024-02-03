using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.CourseName;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class FileCourseUrlResolver : IValueResolver<CourseName, CourseNameDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}
        private readonly IConfiguration _config;
        public FileCourseUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(CourseName source, CourseNameDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CourseSyllabus))
            {
                return _config["ApiUrl"] + source.CourseSyllabus;
            }

            return null;
        }
    }
}
