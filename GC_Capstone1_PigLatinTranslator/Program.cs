using System;

namespace GC_Capstone1_PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            Console.WriteLine("Elcomeway to the Pig Latin Translator!");

            //while (continueProgram) //single word loop
            //{
            //    string message = "Please enter a word you'd like to translate to Pig Latin";
            //    string word = PromptForWord(message); //prompts user for word using message from line above
            //    TranslateToPigLatin(word);
            //    continueProgram = ContinueProgramYesNoPrompt("Would you like to translate another word?");
            //}

            while (continueProgram) //full sentence array loop
            {
                string message = "Please enter a sentence you'd like to translate to Pig Latin";
                string[] words = PromptForString(message); //prompts user for word using message from line above
                TranslateToPigLatinFullLine(words);
                continueProgram = ContinueProgramYesNoPrompt("Would you like to translate another word?");
            }

        }

        public static string PromptForWord(string message)
        {
            Console.Write($"{message} : ");
            string word = Console.ReadLine().ToLower();

            while (word == "")
            {
                Console.Write("Nothing entered.  Please try again. ");
                word = Console.ReadLine().ToLower();
            }

            return word;

        }

        public static string[] PromptForString(string message)
        {
            Console.Write($"{message} : ");
            string word = Console.ReadLine().ToLower();
            
            
            //creating array to handle multiple words using string split
            
            
            string[] separators = { " " };
            string[] words = word.Split(" ");
            
            
            //foreach (var word2 in words)
            //{
            //    Console.WriteLine(word2);
            //}

            return words;

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
                wordPigLatin = word + "way";
            else
                wordPigLatin = word.Substring(cutPoint, wordLength - cutPoint) + word.Substring(0,cutPoint) + "ay";

            Console.WriteLine($"Your word translated to Pig Latin is: {wordPigLatin}");

        }

        public static void TranslateToPigLatinFullLine(string[] words)
        {
            string linePigLatin = "";

            foreach (var word in words)
            {
                bool vowelStart = StartsWithVowel(word);
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
                    linePigLatin += word + "way ";
                else
                    linePigLatin += word.Substring(cutPoint, wordLength - cutPoint) + word.Substring(0, cutPoint) + "ay ";

            }

            Console.WriteLine(linePigLatin.Trim());

            //bool vowelStart = StartsWithVowel(word);
            //string wordPigLatin = "";
            //int wordLength = word.Length;
            //int cutPoint = 0;
            //string letterCheck = "";

            //for (int i = 0; i <= wordLength; i++)
            //{
            //    letterCheck = word.Substring(i);
            //    if (StartsWithVowel(letterCheck) == true)
            //    {
            //        cutPoint = i;
            //        break;
            //    }
            //}

            //if (vowelStart)
            //    wordPigLatin = word + "way";
            //else
            //    wordPigLatin = word.Substring(cutPoint, wordLength - cutPoint) + word.Substring(0, cutPoint) + "ay";

            //Console.WriteLine($"Your word translated to Pig Latin is: {wordPigLatin}");

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
