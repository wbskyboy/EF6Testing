using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Testing
{
	public class EmployeeMaster
	{
		[Key]
		public int ID { get; set; }

		public string EmpName { get; set; }

		public double Salary { get; set; }

		public string Designation { get; set; }

		public string Code { get; set; }
	}
}