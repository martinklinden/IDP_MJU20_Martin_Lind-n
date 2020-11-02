using System;

namespace IDP_MJU20_Martin_Lindén
{
    class Program
    {
        static void Main(string[] args)
        {
            //try-catch error handling
            try
            {
                //declare variables
                string userInput = "", gender = "", shorterPersonalNumber = "", divider = "";
                int year, month, day, birthNumber, length;
                bool dividerCheck, yearCheck, correctDay, correctLastNumber, numberCheck;
                //programloop
                int i = 0;
                while (i == 0)
                {
                    //print instructions for user
                    UserInstructions();
                    //user input
                    userInput = Console.ReadLine();
                    //count length of userInput string
                    length = LengthMethod(userInput);
                    //check if userInput is the correct length
                    if (length == 12 || length == 11)
                    {
                        //if userInput length is 11 save the place of the divider in divider string (returns true if length 12)
                        divider = SaveDivider(userInput, length);
                        //check if the divider is correct (- or +) (returns true if length 12)
                        dividerCheck = CheckDivider(divider, length);
                        if(dividerCheck == true)
                        {
                            //create shorterPersonalNumber string from userInput, with the length 10 
                            shorterPersonalNumber = MakeShorterPersonalNumber(userInput, length);
                            //check if the userInput or shorterPersonalNumber contains numbers
                            numberCheck = CheckIfNumbers(shorterPersonalNumber, userInput, length);
                            if(numberCheck == true)
                            {
                                //create year int from userinput string
                                year = ConvertYear(userInput, length);
                                //check if year int is correct
                                yearCheck = YearCheck(year, length);
                                if (yearCheck == true)
                                {
                                    //create month int number from shorterPersonalNumber string
                                    month = ConvertMonth(shorterPersonalNumber);
                                    //check if month int is correct
                                    if (month >= 1 && month <= 12)
                                    {
                                        //create day int from shorterPersonalNumber string
                                        day = ConvertDay(shorterPersonalNumber);
                                        //check if day int is correct according to month and check if it's leap year
                                        correctDay = DayCheck(day, month, year, length, divider);
                                        if (correctDay == true)
                                        {
                                            //create birthNumber int from shorterPersonalNumber string
                                            birthNumber = ConvertBirthNumber(shorterPersonalNumber);
                                            //check if the gender is male or female
                                            gender = CheckGender(birthNumber);
                                            //create correctLastNumber int from shorterPersonalNumber string
                                            correctLastNumber = CheckLastNumber(shorterPersonalNumber);
                                            //check if correctLastNumber correct
                                            if (correctLastNumber == true)
                                            {
                                                //print message to user if their input belongs to male/female and that it's a correct personalnumber
                                                EndMessage(gender);
                                                //exit programloop
                                                i++;
                                            }
                                            else
                                            {
                                                //print error message to user and restart loop
                                                ErrorMessage();
                                            }
                                        }
                                        else
                                        {
                                            //print error message to user and restart loop
                                            ErrorMessage();
                                        }
                                    }
                                    else
                                    {
                                        //print error message to user and restart loop
                                        ErrorMessage();
                                    }
                                }
                                else
                                {
                                    //print error message to user and restart loop
                                    ErrorMessage();
                                }
                            }
                            else
                            {
                                //print error message to user and restart loop
                                ErrorMessage();
                            }
                        }
                        else
                        {
                            //print error message to user and restart loop
                            ErrorMessage();
                        }
                    }
                    else
                    {
                        //print error message to user and restart loop
                        ErrorMessage();
                    }
                }
                //stop (exit from programloop)
                Console.ReadKey();
                //end of program
            }
            //try-catch error handling
            catch (Exception e)
            {
                //print error message
                ErrorMessage();
                //stop
                Console.ReadKey();
            }
        }
        //print error message
        static void ErrorMessage()
        {
            Console.WriteLine("Inkorrekt personnummer, försök igen!");
            Console.WriteLine();
        }
        //print instructions to user
        static void UserInstructions()
        {
            Console.Write("Skriv in ett 12-siffrigt personnummer eller ett 10-siffrigt personnummer (med - eller + som avskilljare): ");
        }
        //method to add value to length int from userInput string
        static int LengthMethod(string userInput)
        {
            //return the length of userInput string in length int
            int length = userInput.Length;
            return length;
        }
        //method to save the divider string if the length of the user input string is 11
        static string SaveDivider(string userInput, int length)
        {
            string divider;
            //returns the value of the 7th place of userInput string if it has the length of 11
            if(length == 11)
            {
                divider = userInput.Substring(6, 1);
                return divider;
            }
            //return an "empty value" if the length of the userInput is 12 (not 11)
            else
            {
                return divider = "";
            }
        }
        //method bool to check if the divider string is correct
        static bool CheckDivider(string divider, int length)
        {
            if(length == 11)
            {
                //return true if the divider string contains + or -, else return false
                if(divider == "+" || divider == "-")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //return true if the length of the userInput isn't 11
            else
            {
                return true;
            }
        }
        //method to convert part of userInput string to year int
        static int ConvertYear(string userInput, int length)
        {
            if(length == 12)
            {
                //save the first 4 numbers from userInput in yearString 
                string yearString = userInput.Substring(0, 4);
                //convert yearString string to year int
                int year = int.Parse(yearString);
                return year;
            }
            else
            {
                //save the first 2 numbers from userInput in yearString
                string yearString = userInput.Substring(0, 2);
                //convert yearString string to year int
                int year = int.Parse(yearString); 
                return year;
            }
        }
        //method bool to check if the year int is correct
        static bool YearCheck(int year, int length)
        {
            if(length == 12)
            {
                if(year >= 1753 && year <= 2020)
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
        //method to make shorterPersonalNumber string
        static string MakeShorterPersonalNumber(string userInput, int length)
        {
            //declare new string
            string shorterPersonalNumber;
            if(length == 12)
            {
                //save the numbers from the userInput, except the first 2, in shorterPersonalNumber 
                shorterPersonalNumber = userInput.Substring(2, 10);
                return shorterPersonalNumber;
            }
            else
            {
                //save the first 6 numbers from the userInput string in "a" string
                string a = userInput.Substring(0, 6);
                //save the numbers occupying the last 4 places from the user input string in "b"string
                string b = userInput.Substring(7, 4);
                //save and return the numbers from "a" and "b" in shorterPersonalNumber 
                return shorterPersonalNumber = a + b;
            }
        }
        //method bool to check if userInput and shorterPersonalNumber contains numbers
        static bool CheckIfNumbers(string shorterPersonalNumber, string userInput, int length)
        {
            //declare variables
            long number;
            bool numberCheck;
            if(length == 12)
            {
                //convert userInput string to typelong, if successful return true else return false
                return numberCheck = long.TryParse(userInput, out number);
            }
            else
            {
                //convert shorterPersonalNumber string to typelong, if successful return true else return false
                return numberCheck = long.TryParse(shorterPersonalNumber, out number);
            }
        }
        //method to convert userInput string to month int
        static int ConvertMonth(string shorterPersonalNumber)
        {
            //save the 3rd and 4th number in shorterPersonalNumber string in monthString
            string monthString = shorterPersonalNumber.Substring(2, 2);
            //convert monthString string to month int
            int month = int.Parse(monthString);
            //return month int
            return month;
        }
        //method to convert userInput string to day int
        static int ConvertDay(string shorterPersonalnumber)
        {
            //save the 5th and 6th number in shorterPersonalnumber in dayString
            string dayString = shorterPersonalnumber.Substring(4, 2);
            //convert dayString string to day int
            int day = int.Parse(dayString);
            //return day int
            return day;
        }
        //method to check if the day int is correct and if it's a leap year
        static bool DayCheck(int day, int month, int year, int length, string divider)
        {
            //declare bool variable
            bool checkLeapYear;
            //check if day is correct in the months containing maximum 31 days 
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
            //check if day belongs to the months containing maximum 30 days 
            else if (month == 4 || month == 6 || month == 9 || month == 11)
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
            //check if the day int is correct if month int is 2 (feb)
            else if(month == 2)
            {
                if (day >= 1 && day <= 28)
                {
                    return true;
                }
                else if(day == 29)
                {
                    //if day int is 29 call on LeapYearCheck method to check if the year int was a leap year
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
        //method bool to check if the year int was a leap year
        static bool LeapYearCheck(int year, int length, string divider)
        {
            //if length is 12 send year to LeapYearCalc method
            if (length == 12)
            {
               return LeapYearCalc(year);
            }
            else if(length == 11)
            {  
                if(divider == "-")
                {
                    //if divider string contains - and year int value is between 0 and 20 add 2000 to year int
                    if(year >= 0 && year <= 20)
                    {
                        year = year + 2000;
                        //send year to LeapYearCalc method
                        return LeapYearCalc(year);
                    }
                    //if divider string contains - and year int value is between 21 and 99 add 1900 to year int
                    else if (year >= 21 && year <= 99)
                    {
                        year = year + 1900;
                        //send year to LeapYearCalc method
                        return LeapYearCalc(year);
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (divider == "+")
                {
                    //if divider string contains + and year int value is between 0 and 20 add 1900 to year int
                    if (year >= 0 && year <= 20)
                    {
                        year = year + 1900;
                        //send year to LeapYearCalc method
                        return LeapYearCalc(year);
                    }
                    //if divider string contains + and year int value is between 21 and 99 add 1800 to year int
                    else if (year >= 21 && year <= 99)
                    {
                        year = year + 1800;
                        //send year to LeapYearCalc method
                        return LeapYearCalc(year);
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
        //method bool with calculations to check if year int was a leap year
        static bool LeapYearCalc(int year)
        {
            //if the year int is divisible with 400 return true    
            if (year % 400 == 0)
            {
                return true;
            }
            //if the year int is divisible with 100, but not 400 return false    
            else if (year % 100 == 0)
            {
                return false;
            }
            //if the year int is divisible with 4, but not 100 nor 400 return true    
            else if (year % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //method to convert userInput string to birthNumber int
        static int ConvertBirthNumber(string shorterPersonalNumber)
        {
            //save the 7th, 8th and 9th numbers in shorterPersonalNumber string in birthNumberString
            string birthNumberString = shorterPersonalNumber.Substring(6, 3);
            //convert birthNumberString string to birthNumber int
            int birthNumber = int.Parse(birthNumberString);
            //return birthNumber
            return birthNumber;
        }
        //method to save whether the gender is male or female ïn a string
        static string CheckGender(int birthNumber)
        {
            //declare variables
            string gender;
            //if birthNumber is divisible with 2 return gender string "kvinna" 
            if (birthNumber % 2 == 0)
            {
                return gender = "kvinna";
            }
            //return gender string "man" if the birthNumber isn't divisible by 2
            else
            {
                return gender = "man";
            }
        }
        //method bool to check if the last number in shorterPersonalnumber is correct
        static bool CheckLastNumber(string shorterPersonalnumber)
        {
            //save the last number in shorterPersonalnumber in lastNumberString
            string lastNumberString = shorterPersonalnumber.Substring(9, 1);
            //convert lastNumberString string to lastNumber int
            int lastNumber = int.Parse(lastNumberString);
            //use LuhnAlgorithm method and save result to collectNumbers int
            int collectNumbers = LuhnAlgorithm(shorterPersonalnumber);
            //add collectNumbers and lastNumber to luhnNumber
            int luhnNumber = collectNumbers + lastNumber;
            //return true if luhnNumber is divisible by 10, else return false
            if (luhnNumber % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //method int to calculate luhn algorithm (without the last number from the personal number)
        static int LuhnAlgorithm(string userInput)
        {
            //declare and initialize variable
            int collectNumbers = 0;
            //for loop
            for (int i = 0; i <= 8; i++)
            {
                //save the "i"th number in shorterPersonalnumber in numberString
                string numberString = userInput.Substring(i, 1);
                //convert numberString string to currentNumber int
                int currentNumber = int.Parse(numberString);
                if (i % 2 == 0)
                {
                    //if currentNumber is divisible by 2, multiply it by 2 and add the value to multipliedByTwo
                    int multipliedByTwo = currentNumber * 2;
                    //if the product of the multiplication contains more than 1 number (0-9)
                    if (multipliedByTwo >= 10)
                    {
                        //convert the multipliesByTwo int to the productsLuhnString string
                        string productsLuhnString = multipliedByTwo.ToString();
                        //add the 1st number in the productsLuhnString to the product1String
                        string product1String = productsLuhnString.Substring(0, 1);
                        //convert the product1String to the product1Int
                        int product1Int = int.Parse(product1String);
                        //add product1Int to collectNumbers
                        collectNumbers = collectNumbers + product1Int;
                        //add the 2nd number in the productsLuhnString to the product1String
                        string product2String = productsLuhnString.Substring(1, 1);
                        //convert the product2String string to the product2Int int
                        int product2Int = int.Parse(product2String);
                        //add product2Int to collectNumbers
                        collectNumbers = collectNumbers + product2Int;
                    }
                    else
                    {
                        //add multipliedByTwo to collectNumbers
                        collectNumbers = collectNumbers + multipliedByTwo;
                    }
                }
                else
                {
                    //if currentNumber isn't divisible by 2 add to collectNumbers
                    collectNumbers = collectNumbers + currentNumber;
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
