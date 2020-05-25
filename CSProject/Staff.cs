﻿using System;
using System.Collections.Generic;

namespace CSProject
{
    public class Staff
    {
        private float hourlyRate;
        private int hWorked;
        public string NameOfStaff { get; private set; }
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        
        public int HoursWorked
            {
                get
                {
                    return hWorked;
                }
                set
                {
                    if (value > 0)
                        hWorked = value;
                    else
                        hWorked = 0;
                }
            }
        
        public Staff(string name, float rate)
        {
            this.NameOfStaff = name;
            this.hourlyRate = rate;
        }

        public Staff() { }
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating pay...");

            if (hWorked > 0)
                BasicPay = hourlyRate * hWorked;
            else
                BasicPay = 0;

            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "\nName of Staff: " + NameOfStaff + "\nhourlyRate: " + hourlyRate + "\nHoursWorked: " + HoursWorked +
                   "\nBasicPay: " + BasicPay + "\nTotalPay: " + TotalPay;
        }
    }
}