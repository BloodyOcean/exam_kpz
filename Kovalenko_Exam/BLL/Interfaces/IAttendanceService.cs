using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAttendanceService
    {
        IEnumerable<AttendanceModel> GetAll();
    }
}
