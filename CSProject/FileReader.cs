﻿using System;
using System.Collections.Generic;
using System.IO;

namespace CSProject
{
    public class FileReader
    {

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>(); 
            string[] result = new string[2]; 
            string path = "E:\\Eduardo\\Documents\\RiderProjects\\CSProject\\CSProject\\bin\\Debug\\staff.txt"; 
            string[] separator = {", "};
            
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while(sr.EndOfStream != true)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.None);
                        switch (result[1])
                        {
                            case "Manager":
                                myStaff.Add(new Manager(result[0]));
                                break;
                            case "Admin":
                                myStaff.Add(new Admin(result[0]));
                                break;
                        }
                    }
                    sr.Close();
                };
            }
            else
            {
                Console.WriteLine("File not found!");
            }

            return myStaff;
        }
    }
}