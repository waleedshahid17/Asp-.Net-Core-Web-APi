using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public class EmployeeParameters : RequestParamaters
    {
        public EmployeeParameters()
        {
            OrderBy = "name";
        }
        public uint minAge { get; set; }
        public uint maxAge { get; set; } = int.MaxValue;

        public bool validAgeRange => maxAge > minAge;
        public string searchTerm { get; set; }
    }
}
