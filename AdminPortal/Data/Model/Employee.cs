using System;
using System.Collections.Generic;
using System.Text;

namespace AdminPortal.Data.Model
{
    class Employee : ITypeWithId
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserId { get; set; }

        public int DepartmentId { get; set; }
    }
}
