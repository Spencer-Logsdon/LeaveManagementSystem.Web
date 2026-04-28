using System;
using Humanizer;

namespace LeaveManagementSystem.Web.Data;

public class LeaveType
{
   public int Id { get; set; } // Primary key by convention;
   public string Name { get; set; }
   public int NumberOfDays { get; set; }

}
