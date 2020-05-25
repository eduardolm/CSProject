﻿using System.Collections.Generic;
 using System.IO;
 using System.Linq;

 namespace CSProject
{
    public class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12
        }

        public PaySlip(int payMonth, int payYear)
        {
            this.month = payMonth;
            this.year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;
            foreach (var f in myStaff)
            {
                path = "E:\\Eduardo\\Documents\\RiderProjects\\CSProject\\CSProject\\bin\\Debug\\" + f.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("===================================");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                    if(f.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                    if(f.GetType() == typeof(Admin))
                        sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);
                    sw.WriteLine("");
                    sw.WriteLine("===================================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("===================================");
                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from f in myStaff
                where f.HoursWorked < 10
                orderby f.NameOfStaff ascending 
                select new {f.NameOfStaff, f.HoursWorked};

            string path = "E:\\Eduardo\\Documents\\RiderProjects\\CSProject\\CSProject\\bin\\Debug\\summary.txt";

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var item in result)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", item.NameOfStaff, item.HoursWorked);
                }
                sw.Close();
            }
        }
        public override string ToString()
        {
            return "month: " + month + "year: " + year;
        }
    }
}