using System;

namespace IDP_MJU20_Martin_Lindén
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //declare variables
                string userInput = "", gender = "", shorterPersonalNumber = "", divider = "";
                int year, month, day, birthNumber, length;
                bool dividerCheck, yearCheck, correctDay, correctLastNumber, numberCheck;
                //user instructions/ask for input
                int i = 0;
                //loop
                while (i == 0)
                {
                    UserInstructions();
                    //user input
                    userInput = Console.ReadLine();
                    //check if correct amount of numbers
                    length = LengthMethod(userInput);
                    if (length == 12 || length == 11)
                    {
                        Console.WriteLine(userInput);
                        divider = SaveDivider(userInput, length);
                        dividerCheck = CheckDivider(divider, length);
                        if(dividerCheck == true)
                        {
                            shorterPersonalNumber = MakeShorterPersonalNumber(userInput, length);
                            numberCheck = CheckIfNumbers(shorterPersonalNumber, userInput, length);
                            if(numberCheck == true)
                            {
                                //check if correct year
                                year = ConvertYear(userInput, length);
                                yearCheck = YearCheck(year, length);
                                if (yearCheck == true)
                                {
                                    Console.WriteLine(year);
                                    //check if correct month
                                    month = ConvertMonth(shorterPersonalNumber);
                                    if (month >= 1 && month <= 12)
                                    {
                                        Console.WriteLine(month);
                                        //check if correct day (according to month) and check if leap year (only if february)
                                        day = ConvertDay(shorterPersonalNumber);
                                        correctDay = DayCheck(day, month, year, length, divider);
                                        if (correctDay == true)
                                        {
                                            Console.WriteLine(day);
                                            //check birthnumber
                                            birthNumber = ConvertBirthNumber(shorterPersonalNumber);
                                            Console.WriteLine(birthNumber);
                                            //check if male or female
                                            gender = CheckGender(birthNumber);
                                            Console.WriteLine(gender);
                                            correctLastNumber = CheckLastNumber(shorterPersonalNumber);
                                            if (correctLastNumber == true)
                                            {
                                                //print message to user if number belongs to male/female and that it is a correct personalnumber
                                                EndMessage(gender);
                                                i++;
                                            }
                                            else
                                            {
                                                ErrorMessage();
                                            }
                                        }
                                        else
                                        {
                                            ErrorMessage();
                                        }
                                    }
                                    else
                                    {
                                        ErrorMessage();
                                    }
                                }
                                else
                                {
                                    ErrorMessage();
                                }
                            }
                            else
                            {
                                ErrorMessage();
                            }
                        }
                        else
                        {
                            ErrorMessage();
                        }
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                //stop
                Console.ReadKey();
                //end
            }
            catch(Exception e)
            {
                ErrorMessage();
                Console.ReadKey();
            }
        }
        //methods:
        //error message
        static void ErrorMessage()
        {
            Console.WriteLine("Inkorrekt personnummer, försök igen!");
        }
        //print instructions to user
        static void UserInstructions()
        {
            Console.Write("Skriv in ett 12-siffrigt personnummer eller ett 10-siffrigt personnummer (med - eller + som avskilljare till de 4 sista siffrorna): ");
        }
        //mthod for array-/stringlength
        static int LengthMethod(string userInput)
        {
            int length = userInput.Length;
            return length;
        }
        //divider check
        static string SaveDivider(string userInput, int length)
        {
            string dividerSign;
            if(length == 11)
            {
                dividerSign = userInput.Substring(6, 1);
                return dividerSign;
            }
            else
            {
                return dividerSign = "";
            }
        }
        static bool CheckDivider(string divider, int length)
        {
            if(length == 11)
            {
                if(divider == "+" || divider == "-")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        //convert userinput to year
        static int ConvertYear(string userInput, int length)
        {
            if(length == 12)
            {
                string yearString = userInput.Substring(0, 4);
                int yearNumber = int.Parse(yearString);
                return yearNumber;
            }
            else
            {
                string yearString = userInput.Substring(0, 2);
                int yearNumber = int.Parse(yearString);
                return yearNumber;
            }
        }
        static bool YearCheck(int year, int length)
        {
            if(length == 12)
            {
                if (year >= 1753 && year <= 2020)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(length == 11)
            {
                if(year >= 0 && year <= 99)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //make shorter personal number
        static string MakeShorterPersonalNumber(string userInput, int length)
        {
            string shorterPersonalNumber;
            if(length == 12)
            {
                shorterPersonalNumber = userInput.Substring(2, 10);
                return shorterPersonalNumber;
            }
            else
            {
                string a = userInput.Substring(0, 6);
                string b = userInput.Substring(7, 4);
                return shorterPersonalNumber = a + b;
            }
        }
        //check if numbers
        static bool CheckIfNumbers(string shorterPersonalNumber, string userInput, int length)
        {
            long number;
            bool numberCheck;
            if(length == 12)
            {
                return numberCheck = long.TryParse(userInput, out number);
            }
            else
            {
                return numberCheck = long.TryParse(shorterPersonalNumber, out number);
            }
        }
        //convert userinput to month
        static int ConvertMonth(string shorterPersonalNumber)
        {
            string monthString = shorterPersonalNumber.Substring(2, 2);
            int monthNumber = int.Parse(monthString);
            return monthNumber;
        }
        //convert userinput to day
        static int ConvertDay(string shorterPersonalnumber)
        {
            string dayString = shorterPersonalnumber.Substring(4, 2);
            int dayNumber = int.Parse(dayString);
            return dayNumber;
        }
        //check if correct day and/or leap year if feb 29
        static bool DayCheck(int day, int month, int year, int length, string divider)
        {
            bool checkLeapYear;
            if(month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day >= 1 && day <= 31)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day >= 1 && day <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(month == 2)
            {
                if (day >= 1 && day <= 28)
                {
                    return true;
                }
                else if(day == 29)
                {
                    checkLeapYear = LeapYearCheck(year, length, divider);
                    if(checkLeapYear == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static bool LeapYearCheck(int year, int length, string divider)
        {
            if(length == 12)
            {
                if (year % 400 == 0)
                {
                    return true;
                }
                else if (year % 100 == 0)
                {
                    return false;
                }
                else if (year % 4 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(length == 11)
            {

                return false;
            }
            else
            {
                return false;
            }

        }
        //conver userinput to birthnumber
        static int ConvertBirthNumber(string shorterPersonalNumber)
        {
            string birthNumberString = shorterPersonalNumber.Substring(6, 3);
            int birthNumberNumber = int.Parse(birthNumberString);
            return birthNumberNumber;
        }
        //check if male or female
        static string CheckGender(int birthNumber)
        {
            string gender;
            int genderNumber = birthNumber;
            if (genderNumber % 2 == 0)
            {
                return gender = "kvinna";
            }
            else
            {
                return gender = "man";
            }
        }
        //check if last number is correct
        static bool CheckLastNumber(string shorterPersonalnumber)
        {
            //convert last number to int
            string lastNumberString = shorterPersonalnumber.Substring(9, 1);
            int lastNumber = int.Parse(lastNumberString);
            int collectNumbers = LuhnAlgorithm(shorterPersonalnumber);
            int seeIfCorrect = collectNumbers + lastNumber;
            if (seeIfCorrect % 10 == 0)
            {
                Console.WriteLine("Summan av Luhn {0} och det är korrekt!", seeIfCorrect);
                return true;
            }
            else
            {
                Console.WriteLine("Summan av Luhn är {0} och det är fel!", seeIfCorrect);
                return false;
            }
        }
        //luhn algorithm (last number)
        static int LuhnAlgorithm(string userInput)
        {
            int collectNumbers = 0;
            //for loop
            for (int i = 0; i <= 8; i++)
            {
                //Console.WriteLine(userInput[i]);
                //convert current number to int
                string numberString = userInput.Substring(i, 1);
                int number = int.Parse(numberString);
                //if place in array (i) is dividable with 2
                if (i % 2 == 0)
                {
                    int number2 = number * 2;
                    if (number2 >= 10)
                    {
                        string string2 = number2.ToString();
                        string string3 = string2.Substring(0, 1);
                        int number3 = int.Parse(string3);
                        collectNumbers = collectNumbers + number3;
                        string string4 = string2.Substring(1, 1);
                        int number4 = int.Parse(string4);
                        collectNumbers = collectNumbers + number4;

                    }
                    else
                    {
                        collectNumbers = collectNumbers + number2;
                    }
                }
                else
                {
                    collectNumbers = collectNumbers + number;
                }
            }
            return collectNumbers;
        }
        //print result message
        static void EndMessage (string gender)
        {
            Console.WriteLine("Personnummret du har anget är ett korrekt personnummer och tillhör en {0}", gender);
            Console.WriteLine("Hejdå!");
        }
    }
}
