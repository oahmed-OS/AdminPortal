using AdminPortal.Data.Model;
using System.Collections.Generic;

namespace AdminPortal.Data.Repository.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Skill> GetSkillsById(int Id);

        Employee GetEmployeeByUserId(string UserId);
    }
}
