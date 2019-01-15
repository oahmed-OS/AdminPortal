using AdminPortal.Data.Model;
using AdminPortal.Data.Repository.Interface;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdminPortal.Data.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly string _CONNECTIONSTRING;

        public EmployeeRepository(string connectionString)
            : base(connectionString, "Employees")
        {
            _CONNECTIONSTRING = connectionString;
        }

        public IEnumerable<Skill> GetSkillsById(int EmployeeId)
        {
            IEnumerable<Skill> result;

            var sql = "SELECT * FROM SKills WHERE Id IN (Select SkillId FROM EmployeeSkills WHERE EmployeeId = @Id)";

            using (IDbConnection con = new SqlConnection(_CONNECTIONSTRING))
            {
                result = con.Query<Skill>(sql, new { Id = EmployeeId });
            }

            return result;
        }
    }
}
