using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FiscalYears 
{
    public class FiscalYearDto : IFiscalYearDto
    {
        public int FiscalYearId { get; set; }
        public string FiscalYearName { get; set; }
        public string ShortName { get; set; }
        public Nullable<int> MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
