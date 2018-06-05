using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UseXPagedListMVC.Models;

namespace UseXPagedListMVC.Utils
{
    public static class UserPersonalDataGenerator
    {
        private static readonly Random random = new Random();

        private static readonly string[] names = new string[]
        {
            "Noah", "Liam", "Mason", "Jacob", "William",
            "Ethan", "Michael", "Alexander", "James", "Daniel",
            "Elijah", "Benjamin", "Logan", "Aiden", "Jayden",
            "Matthew", "Jackson", "David", "Lucas", "Joseph",
            "Anthony", "Andrew", "Samuel", "Gabriel", "Joshua",
            "Emma", "Olivia", "Sophia", "Isabella", "Ava",
            "Mia", "Emily", "Abigail", "Madison", "Charlotte",
            "Harper", "Sofia", "Avery", "Elizabeth", "Amelia",
            "Evelyn", "Ella", "Chloe", "Victoria", "Aubrey",
            "Grace", "Zoey", "Natalie", "Addison", "Lillian",
        };

        private static readonly string[] sNames = new string[] 
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones",
            "Miller", "Davis", "Garcia", "Rodriguez", "Wilson",
            "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez",
            "Moore", "Martin", "Jackson", "Thompson", "White",
            "Lopez", "Lee", "Gonzalez", "Harris", "Clark",
            "Lewis", "Robinson", "Walker", "Perez", "Hall",
            "Young", "Allen", "Sanchez", "Wright", "King",
            "Scott", "Green", "Baker", "Adams", "Nelson",
            "Hill", "Ramirez", "Campbell",  "Mitchell","Roberts",
            "Carter", "Phillips", "Evans", "Turner", "Torres",
            "Parker", "Collins", "Edwards", "Stewart", "Flores",
            "Morris", "Nguyen", "Murphy", "Rivera", "Cook",
            "Rogers", "Morgan", "Peterson", "Cooper",
            "Reed", "Bailey", "Bell", "Gomez", "Kelly",
            "Howard", "Ward", "Cox", "Diaz", "Richardson",
            "Wood", "Watson", "Brooks", "Bennett",
            "Gray", "James", "Reyes", "Cruz", "Hughes",
            "Price", "Myers", "Long", "Foster", "Sanders",
            "Ross", "Morales",
        };

        public static IEnumerable<User> GenerateDataSet(int count)
        {
            return Enumerable
                .Range(0, count)
                .Select(i => new User
                {
                    ID = i + 1,
                    Name = GetName(),
                    SName = GetSName(),
                    Age = GetAge(),
                    IsStudent = MakeStudent(i)
                }
            );
        }

        private static string GetName()
        {
            return names[random.Next(0, names.Length - 1)];
        }

        private static string GetSName()
        {
            return sNames[random.Next(0, sNames.Length - 1)];
        }

        private static int GetAge()
        {
            return random.Next(18, 65);
        }

        private static bool MakeStudent(int number)
        {
            return (number % 3 == 0) || (number % 7 == 0) ? true : false;
        }
    }
}