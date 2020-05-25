﻿namespace CSProject
{
    public class Manager : Staff
    {
        private const float managerHourlyRate = 50;

        public int Allowance { get; private set; }

        public Manager(string name) : base(name: name, rate: managerHourlyRate) { }
        public override void CalculatePay()
        {
            base.CalculatePay(); // Calls method in the parent class in order to set values to BasicPay and TotalPay
            Allowance = 1000;

            if (HoursWorked > 160)
                TotalPay += Allowance;
        }

        public override string ToString()
        {
            return "\nName of Staff: " + NameOfStaff + "\nmanagerHourlyRate: " + managerHourlyRate + "HoursWorked: " +
                   HoursWorked + "\nBasicPay: " + BasicPay + "\nAllowance: " + Allowance + "\nTotalPay: " + TotalPay;
        }
    }
}