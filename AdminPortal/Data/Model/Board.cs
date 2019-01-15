using System;

namespace AdminPortal.Data.Model
{
    public class Board : ITypeWithId
    {
        public int Id { get; set; }

        public DateTime BoardDate { get; set; }

        public int DepartmentId { get; set; }

        public bool IsLock { get; set; }

        public string LockBy { get; set; }
    }
}
