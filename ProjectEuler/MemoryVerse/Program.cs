using System.ComponentModel.DataAnnotations;
// using System.Security.Cryptography;
using MemoryVerse;

namespace ProjectEuler.MemoryVerse
{
    class Program
    {
        static List<Verse> verses = [
            new Verse("In the beginning, God created the heavens and the earth.", "Genesis", 1, 1),
            new Verse("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.", "John", 3, 16),
            new Verse("Jesus answered and said unto him, Verily, verily, I say unto thee, Except a man be born again, he cannot see the kingdom of God.", "John", 3, 3),
            new Verse("And she shall bring forth a son, and thou shalt call his name Jesus: for he shall save his people from their sins.", "Matthew", 1, 21),
            new Verse("as it is written, There is none righteous, no, not one:", "Romans", 3, 10),
            new Verse("for all have sinned, and come short of the glory of God;", "Romans", 3, 23),
            new Verse("For the wages of sin is death; but the gift of God is eternal life through Jesus Christ our Lord.", "Romans", 6, 23),
        ];

        static void Main()
        {
            Console.WriteLine("Welcome to the Memory Verse Challenge!\nPress any key to start...");
            Console.ReadKey();
            Console.WriteLine("");

            SetupQuiz();
        }

        public static void SetupQuiz()
        {
            string reply;
            Console.WriteLine("Do you want a random verse? (Default answer: Yes)");
            reply = Console.ReadLine().ToString();
            Random r = new Random();
            if (reply.ToLower() == "No")
            {
                
            }
            else Quiz(verses[r.Next(verses.Count)]);
            

            Console.WriteLine("Do you want to try another verse?");
            reply = Console.ReadLine().ToString();
            if (reply.ToLower() == "yes") SetupQuiz();
        }

        private static void Quiz(Verse verse)
        {
            Console.WriteLine("{0} {1}:{2}", verse.book, verse.chapter, verse.verse);

            string setence = "";
            List<string> word_bank = [];
            List<string> word_list = verse.WordList();
            int attempts = 0;

            while (setence != verse.text)
            {
                attempts++;
                /* set word bank */
                {
                    word_bank = [];
                    Random random = new Random();
                    int pos = Convert.ToInt32(Math.Floor(Convert.ToDecimal(random.Next(Math.Min(5, word_list.Count)))));

                    if (word_list.Count <= 5)
                    {
                        List<int> word_ref = [];

                        for (int i = 0; i < word_list.Count; i++)
                        {
                            int p = random.Next(word_list.Count);
                            while (word_ref.Contains(p))
                            {
                                p = random.Next(word_list.Count);
                            }
                            word_ref.Add(p);
                        }

                        for (int i = 0; i < word_list.Count; i++)
                        {
                            int p = word_ref.IndexOf(i);
                            word_bank.Add(word_list[p]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (i == pos && !word_bank.Contains(word_list[0])) word_bank.Add(word_list[0]);
                            else
                            {
                                int n;
                                do
                                {
                                    n = Convert.ToInt32(random.Next(word_list.Count));
                                } while (word_bank.Contains(word_list[n]));

                                word_bank.Add(word_list[n]);
                            }
                        }
                    }
                }

                /* display word bank */
                {
                    Console.WriteLine("Setence: {0}", setence);
                    Console.WriteLine("Word Bank:");
                    for (int i = 0; i < word_bank.Count; i++)
                    {
                        Console.Write("{0}. {1}    ", (i + 1), word_bank[i]);
                    }
                    Console.WriteLine("");
                }

                /* input answer */
                {
                    Console.WriteLine("Input the number of the next word (1 to 5):");
                    char input = Console.ReadKey().KeyChar;
                    List<char> numbers = ['1', '2', '3', '4', '5'];
                    numbers = numbers.Slice(0, word_bank.Count);

                    while (!numbers.Contains(input))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You gave an invalid number! {0}", input);
                        Console.WriteLine("Input the number of the next word (1 to 5):");
                        input = Console.ReadKey().KeyChar;
                    }

                    Console.WriteLine("");
                    int reply = Convert.ToInt32(Convert.ToString(input));
                    reply--;

                    if (verse.text.IndexOf(setence + word_bank[reply]) == 0)
                    {
                        setence += word_bank[reply];
                        if (setence.Length < verse.text.Length) setence += " ";
                        Console.WriteLine("Correct!!!");

                        int p = word_list.IndexOf(word_bank[reply]);
                        word_list.RemoveRange(p, 1);
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!!");
                    }
                    Console.WriteLine("");
                }
            }


            Console.WriteLine("You completed {0} {1}:{2} in {3} attempts! Accuracy: {4}%", verse.book, verse.chapter, verse.verse, attempts, Convert.ToDecimal(verse.WordList().Count*1000/attempts)/10);
        }
    }
}