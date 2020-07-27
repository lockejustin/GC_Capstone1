using System;

namespace GC_Capstone1_PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;  //initialized as true to enter the repeat loop upon initial run

            Console.WriteLine("Elcomeway to the Pig Latin Translator!");

            while (continueProgram) //loops program as long as user wants to continue
            {
                string message = "Please enter a sentence you'd like to translate to Pig Latin";
                string[] words = PromptForString(message); //prompts user for word using message from line above
                TranslateToPigLatinFullLine(words);
                continueProgram = ContinueProgramYesNoPrompt("Would you like to translate another word?");
            }

        }

        public static string[] PromptForString(string message)  //takes message from Main method and prompts user to in put a string to translate
        {
            Console.Write($"{message} : ");
            string word = Console.ReadLine().ToLower();  //reads user entered string and converts to all lower case

            while (word.Trim() == "")  //runs loop to enter a string if user enters nothing
            {
                Console.Write("Nothing entered.  Please try again. ");
                word = Console.ReadLine().ToLower();
            }

            string[] separator = { " " };
            string[] words = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);  //creates a string array of each word in the string and removes any entries that are empty space

            return words;
        }

        public static bool StartsWithVowel(string word)  //returns true if word starts with a vowel
        {
            if (word.StartsWith('a') || word.StartsWith('e') || word.StartsWith('i') || word.StartsWith('o') || word.StartsWith('u'))
                return true;
            else
                return false;
        }

        public static void TranslateToPigLatinFullLine(string[] words)  //translates string array to pig latin
        {
            string linePigLatin = "";

            foreach (var word in words)  //runs foreach loop that translates each word in the user entered string in order
            {
                bool vowelStart = StartsWithVowel(word);
                bool containsSymbol = ContainsSymbol(word);
                bool isNumber = IsNumber(word);
                int wordLength = word.Length;
                int splitPoint = 0;
                string letterCheck = "";
                string lastChar = "";

                for (int i = 0; i <= wordLength; i++)  //checks each word character by character to find the index of the first vowel occurence
                {
                    letterCheck = word.Substring(i);
                    if (StartsWithVowel(letterCheck) == true)
                    {
                        splitPoint = i;
                        break;  //breaks out of the loop after finding the first vowel
                    }
                }

                lastChar = word.Substring(wordLength - 1);  //assigns the last character of the word to the var lastChar

                bool endsWithPunc = true;  //checks to see if the word ends with punctuation
                if (lastChar == "." || lastChar == "!" || lastChar == "?" || lastChar == ",")
                    endsWithPunc = true;
                else
                    endsWithPunc = false;

                if (containsSymbol || isNumber)  //use if statements to apply correct pig latin translation based on criteria spelled out in build and extended exercises
                    linePigLatin += word + " ";
                else if (vowelStart && endsWithPunc)
                    linePigLatin += word.Substring(0,wordLength-1) + "way" + lastChar + " ";
                else if (vowelStart)
                    linePigLatin += word + "way ";
                else if (endsWithPunc)
                    linePigLatin += word.Substring(splitPoint, wordLength - splitPoint - 1) + word.Substring(0, splitPoint) + "ay" + lastChar + " ";
                else
                    linePigLatin += word.Substring(splitPoint, wordLength - splitPoint) + word.Substring(0, splitPoint) + "ay ";
            }

            Console.WriteLine(linePigLatin.Trim());  //writes entire translated string to the console

        }

        public static bool ContinueProgramYesNoPrompt(string message)  //prompts user if they'd like to continue and verifies proper entry
        {
            Console.Write($"{message} (y/n) ");
            string response = Console.ReadLine().ToLower();

            while (response != "y" && response != "n")  //checks to make sure the user enters either y or n
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

        public static bool ContainsSymbol(string word)  //checks the string to see if it contains symbols - per build, words/phrases that contain symbols are not to be translated
        {
            char[] symbols = {'@','#','$','%','^','&','*','(',')'};  //creates an array of symbols that are exempt from translation

            bool containsSymbol = false;

            foreach (var symbol in symbols)
            {
                if (word.Contains(symbol))
                {
                    containsSymbol = true;
                    return containsSymbol;
                }
            }

            return containsSymbol;
        }

        public static bool IsNumber(string word)  //checks if the string part is a number
        {
            int n = 0;
            return int.TryParse(word, out n);
        }
    }
}
