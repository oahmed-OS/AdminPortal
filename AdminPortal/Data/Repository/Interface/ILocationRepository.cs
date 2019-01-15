using AdminPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminPortal.Data.Repository.Interface
{
    public interface ILocationRepository
    {
        IEnumerable<Department> GetDepartments();

        //void GetDepartmentLocationsMap(int DepartmentId);

        //void GetLocationSkillsMap(IEnumerable<Location> Locations);
    }
}
