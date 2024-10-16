using EF6Testing;
using EF6Testing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF6Testing
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (var ctx = new SchoolContext())
			{
				var student = new EmployeeMaster() { EmpName = "sdfsdf" };
				ctx.Set<EmployeeMaster>().Add(student);
				ctx.Set<Student>().Add(new Student() { StudentName = "Angle"});
				ctx.SaveChanges();
			}
			Console.WriteLine("Demo completed.");
		}
	}
}
