﻿namespace PetPal_Business.Helpers
{
    public static class CalculateUserAge
    {
        public static int CalculateAge(this DateOnly dob)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var age = today.Year - dob.Year;

            if (dob > today.AddYears(-age)) age--;

            return age;
        }

        public static Int32 GetAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var currentYearMonthDay = (today.Year * 100 + today.Month) * 100 + today.Day;
            var birthYearMonthDay = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (currentYearMonthDay - birthYearMonthDay) / 10000;
        }
    }
}
