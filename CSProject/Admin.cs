﻿namespace CSProject
{
    public class Admin : Staff
    {
        private const float overtimeRate =  15.5f;
        private const float adminHourlyRate = 30f;
        
        public float Overtime { get; private set; }

        public Admin(string name) : base(name: name, rate: adminHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }
        
        public override string ToString()
        {
            return "Name of Staff= " + NameOfStaff + ", hourlyRate= " + adminHourlyRate + ", HoursWorked= " + HoursWorked;
        }
    }
}