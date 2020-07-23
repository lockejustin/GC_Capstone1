using System;

namespace GC_Capstone1_PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            Console.WriteLine("Elcomeway to the Pig Latin Translator!");

            while (continueProgram)
            {
                string message = "Please enter a word you'd like to translate to Pig Latin";
                string word = PromptForWord(message); //prompts user for word using message from line above
                TranslateToPigLatin(word);
                continueProgram = ContinueProgramYesNoPrompt("Would you like to translate another word?");
            }

        }

        public static string PromptForWord(string message)
        {
            Console.Write($"{message} : ");
            string word = Console.ReadLine().ToLower();

            while (word == "")
            {
                Console.WriteLine("Nothing entered.  Please try again.");
                word = Console.ReadLine().ToLower();
            }
            
            return word;

        }

        public static bool StartsWithVowel(string word)
        {
            if (word.StartsWith('a') || word.StartsWith('e') || word.StartsWith('i') || word.StartsWith('o') || word.StartsWith('u'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void TranslateToPigLatin(string word)
        {
            bool vowelStart = StartsWithVowel(word);
            string wordPigLatin = "";
            int wordLength = word.Length;
            int cutPoint = 0;
            string letterCheck = "";

            for (int i = 0; i <= wordLength; i++)
            {
                letterCheck = word.Substring(i);
                if (StartsWithVowel(letterCheck) == true)
                {
                    cutPoint = i;
                    break;
                }
            }

            if (vowelStart)
            {
                wordPigLatin = word + "way";
            }
            else
            {
                wordPigLatin = word.Substring(cutPoint, wordLength - cutPoint) + word.Substring(0,cutPoint) + "ay";
            }

            Console.WriteLine($"Your word translated to Pig Latin is: {wordPigLatin}");

        }

        public static bool ContinueProgramYesNoPrompt(string message)  //prompts user if they'd like to continue and verifies proper entry
        {
            Console.Write($"{message} (y/n) ");
            string response = Console.ReadLine().ToLower();

            while (response != "y" && response != "n")
            {
                Console.Write("Your entry was invalid.  Please respond (y/n) ");
                response = Console.ReadLine().ToLower();
            }

            if (response == "y")
            {
                Console.WriteLine("\n");
                return true;
            }
            else
            {
                Console.WriteLine("\nThanks for using this program.  Goodbye!");
                return false;
            }
        }










    }
}
