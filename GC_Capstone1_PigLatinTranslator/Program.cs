using System;

namespace GC_Capstone1_PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            Console.WriteLine("Elcomeway to the Pig Latin Translator!");

            while (continueProgram) //full string array loop
            {
                string message = "Please enter a sentence you'd like to translate to Pig Latin";
                string[] words = PromptForString(message); //prompts user for word using message from line above
                TranslateToPigLatinFullLine(words);
                continueProgram = ContinueProgramYesNoPrompt("Would you like to translate another word?");
            }

        }

        public static string[] PromptForString(string message)
        {
            Console.Write($"{message} : ");
            string word = Console.ReadLine();//.ToLower();

            while (word.Trim() == "")
            {
                Console.Write("Nothing entered.  Please try again. ");
                word = Console.ReadLine();//.ToLower();
            }

            string[] separator = { " " };
            string[] words = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        public static bool StartsWithVowel(string word)
        {
            if (word.StartsWith('a') || word.StartsWith('e') || word.StartsWith('i') || word.StartsWith('o') || word.StartsWith('u'))
                return true;
            else
                return false;
        }

        public static void TranslateToPigLatinFullLine(string[] words)
        {
            string linePigLatin = "";

            foreach (var word in words)
            {
                bool vowelStart = StartsWithVowel(word);
                bool containsSymbol = ContainsSymbol(word);
                bool isNumber = IsNumber(word);
                int wordLength = word.Length;
                int splitPoint = 0;
                string letterCheck = "";
                string lastChar = "";

                

                for (int i = 0; i <= wordLength; i++)
                {
                    letterCheck = word.Substring(i);
                    if (StartsWithVowel(letterCheck) == true)
                    {
                        splitPoint = i;
                        break;
                    }
                }

                lastChar = word.Substring(wordLength - 1);

                bool endsWithPunc = true;
                if (lastChar == "." || lastChar == "!" || lastChar == "?" || lastChar == ",")
                    endsWithPunc = true;
                else
                    endsWithPunc = false;

                if (containsSymbol || isNumber)
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

            Console.WriteLine(linePigLatin.Trim());

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

        public static bool ContainsSymbol(string word)
        {
            char[] symbols = {'@','#','$','%','^','&','*','(',')'};

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

        public static bool IsNumber(string word)
        {
            int n = 0;
            return int.TryParse(word, out n);
        }
    }
}
