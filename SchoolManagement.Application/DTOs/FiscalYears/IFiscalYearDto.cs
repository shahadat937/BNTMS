using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FiscalYears 
{
    public interface IFiscalYearDto
    {
        public string FiscalYearName { get; set; }
        public string ShortName { get; set; }
    }
}
