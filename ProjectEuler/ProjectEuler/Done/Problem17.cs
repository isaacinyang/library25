using System;

namespace ProjectEuler;

public class Problem17
{
    static Dictionary<int, string> words = setupWordList("1,one;2,two;3,three;4,four;5,five;6,six;7,seven;8,eight;9,nine;10,ten;11,eleven;12,twelve;13,thirteen;14,fourteen;15,fifteen;16,sixteen;17,seventeen;18,eighteen;19,nineteen;20,twenty;30,thirty;40,forty;50,fifty;60,sixty;70,seventy;80,eighty;90,ninety;100,hundred");
    public static void Solution()
    {
        int letter_count = 0;
        
        for (int n = 1; n <= 1000; n++)
        {
            string word = NumberToWord(n);

            letter_count += CountLetters(word);
        }

        Console.WriteLine(letter_count);
        // 21124
    }

    static int CountLetters(string number)
    {
        int count = 0;

        foreach (char letter in number)
        {
            if (letter != ' ') count++;
        }
        return count;
    }

    static Dictionary<int, string> setupWordList(string info)
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        foreach (string str in info.Split(";"))
        {
            List<string> words = str.Split(",").ToList();
            dict.Add(Convert.ToInt32(words[0]), words[1]);
        }

        return dict;
    }

    static string NumberToWord(int number)
    {
        if (number == 1000) return "one thousand";
        List<int> components = new List<int>();
        string word = "";

        if (number <= 20 || number < 100 && number % 10 == 0) components.Add(number);
        else if (number % 100 == 0)
        {
            components.Add(number/100);
            components.Add(100);
        }
        else if (number % 10 == 0)
        {
            components.Add(number/100);
            components.Add(100);
            components.Add(0);
            components.Add(((number/10) % 10)*10);
        }
        else if (number % 100 <= 20)
        {
            components.Add(number/100);
            components.Add(100);
            components.Add(0);
            components.Add(number % 100);
        }
        else
        {
            if (number > 100)
            {
                components.Add(number/100);
                components.Add(100);
                components.Add(0);
            }
            components.Add(((number/10) % 10)*10);
            components.Add(number % 10);
        }

        foreach (int component in components)
        {
            if (component == 0) word += "and";
            else word += words[component];
            word += " ";
        }

        return word;
    }
}
