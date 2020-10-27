using System;

namespace IDP_MJU20_Martin_Lindén
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Du ska utgå från att användaren anger tolv siffror så du behöver inte ha någon form av
             felhantering för detta.
             Programmet frågar användaren efter ett 12-siffrigt personnummer YYYYMMDDnnnc –
             användaren ska skriva in hela numret och får inte dela upp det – och kontroller om det är
             korrekt uppbyggt enligt följande:
             1. Rätt antal siffror dvs 12
             2. Årtalet ska vara från 1753 till och med 2020 (Sverige bytte kalender 1753)
             3. Månaden ska var giltig 1 – 12
             4. Dagen ska vara giltig och kontrolleras mot månaden (se nedan)
             5. Födelsenumret nnn ska vara 000 – 999
             6. Kontrollera kön. Födelsenumret är udda för män och jämnt för kvinnor
             (OBS! 0 betraktas i detta fall som jämn dvs kvinna)
             7. Programmet ska skriva ut på skärmen om personnumret är korrekt och om
             personen är man eller kvinna (juridisk).
             */
            //declare variables
            string userInput = "", gender;
            int userNumber = 0, year, month, day, birthNumber;
            bool numbercheck;
            //user instructions/ask for input
            int i = 0;
            //loop
            while (i == 0)
            {
                UserInstructions();
                //user input
                userInput = Console.ReadLine();
                //check if correct amount of numbers
                numbercheck = AmountOfNumbers(userInput);
                if (numbercheck == true)
                {
                    Console.WriteLine(userInput);
                    //check if correct year (1753 - 2020)
                    year = ConvertYear(userInput);
                    if (year >= 1753 && year <= 2020)
                    {
                        Console.WriteLine(year);
                        //check if correct month
                        month = ConvertMonth(userInput);
                        if (month >= 1 && month <= 12)
                        {
                            Console.WriteLine(month);
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
                //check if correct day (according to month) (todo)
                //check if leap year (only if february) (todo) (else if in feb)
                //check birthnumber (todo)
                //check if male or female (third birthnumber) (todo)
            }
            //print message to user if userinput is correct or not (todo)
            //print message to user if number belongs to male/female (todo)
            //stop
            Console.ReadKey();
            //end
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
            Console.Write("Skriv in ett 12-siffrigt personnummer: ");
        }
        //check amount of numbers
        static bool AmountOfNumbers(string userInput)
        {
            if (userInput.Length == 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //convert userinput to year
        static int ConvertYear(string userInput)
        {
            string yearString = userInput.Substring(0, 4);
            int yearNumber = int.Parse(yearString);
            return yearNumber;
        }
        //convert userinput to month
        static int ConvertMonth(string userInput)
        {
            string monthString = userInput.Substring(4, 2);
            int monthNumber = int.Parse(monthString);
            return monthNumber;
        }
        //convert userinput to day
        static int ConvertDay(string userInput)
        {
            string dayString = userInput.Substring(6, 2);
            int dayNumber = int.Parse(dayString);
            return dayNumber;
        }
        //check leap year if feb 29
        //convert userinput to personalnumber
        static int ConvertBirthNumber(string userInput)
        {
            string birthNumberString = userInput.Substring(8, 3);
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
                return gender = "Kvinna";
            }
            else
            {
                return gender = "Man";
            }
        }
        //print result message
    }
}
