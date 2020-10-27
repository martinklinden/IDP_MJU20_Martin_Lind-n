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
            string userInput = "";
            int userNumber = 0;
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
                    i++;
                }
                else
                {
                    ErrorMessage();
                }
                //check if correct year (1753 - 2020)
                //check if correct month
                //check if correct day (according to month)
                //check if leap year (only if february)
                //check birthnumber
                //check if male or female (third birthnumber)
            }
            //print message to user if userinput is correct or not
            //print message to user if number belongs to male/female
            //stop
            Console.ReadKey();
            //end
        }
        //methods
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
        //convert userinput
        //check year
        //check month
        //check day
        //check leap year if feb 29
        //check birthnumber
        //check if male or female
        //print result message
    }
}
