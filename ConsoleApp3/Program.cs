using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://supermartas.cz/aplikace/online/prekladac-morseovky/
            // .-||-...||-.-.||-..||.||..-.||--.||....||----||..||.---||-.-||.-..||--||-.||---||.--.||--.-||.-.||...||-||..-||...-||-..-||-.--||--..|"

            string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "CH", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", " ", "." };
            string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "----", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "||", ".-.-.-." };
            string name = "";
           
            
            string text = "";
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Volby:");
            Console.ForegroundColor = ConsoleColor.White;

            int opt = 0;

            Console.WriteLine("Zadejte 1 pro převod textu do morseovky.");
            Console.WriteLine("Zadejte 2 pro převod morseovky do textu.");
            opt = int.Parse(Console.ReadLine());

            // convert text 2 morse
            if (opt == 1)
            {
                Console.WriteLine("Zadejte text, který chcete převést do morseovky.");
                text = Console.ReadLine();

                string res = "";
                char[] characters = text.ToCharArray();
                var stro = new String(characters);


                if (stro.Contains("."))
                {
                    stro.Replace(".", "Γ"); // .
                }

                if (stro.Contains(" "))
                {
                    stro.Replace(" ", "Δ"); //
                }


                for (var i = 0; i < stro.Length; i++)
                {
                    var ch = stro[i].ToString().ToUpper();
                    // get index of letter in Alphabet field
                    // add letter from morse array in morse field


                    if (alphabet.Length == morse.Length)
                    {
                        Console.WriteLine("Char " + ch);

                        var idx = Array.IndexOf(alphabet, ch);
                        // Console.WriteLine("Character is " + ch + " idx is " + idx);

                        if (idx > -1)
                        {
                            res += morse[idx] + "/";
                        }
                        else
                        {
                            if (ch == "Γ")
                            {
                                res += ".-.-.-.";
                            }
                            else if (ch == "Δ")
                            {
                                res += "||"; // 237 is space two ||
                            }
                            else
                            {
                                Console.WriteLine("SQUARE");
                                Console.WriteLine(ch);
                                res += "⬛";
                            }
                            //res += "■";
                        }

                    }
                    else
                    {
                        Console.WriteLine("Length is invalid");
                    }
                }
               
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text + " v morseovce " + res);
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }


            if (opt == 2)
            {

                string res = "";
                
                Console.WriteLine("Zadejte morseovku oddělenou / pro převedení na text.");
                res = Console.ReadLine();
                

                char[] reschar = res.ToCharArray();
                var everystr = "";
                for (var i = 0; i < reschar.Length; i++) // ..-.|..|.-..|..|.--.|
                {
                    var ch = reschar[i].ToString();
                    everystr += ch;
                }

                var resa = "";

                if (everystr.Contains(".-.-.-."))
                {
                    everystr.Replace(".-.-.-.", "Γ"); // .
                }
                // ../.-/--//
                if (everystr.Contains("/"))
                {
                    everystr.Replace("/", "Δ");

                }

                // ../.-/--//

                Console.WriteLine(everystr);

                string[] split = everystr.Split('/'); // Single quotes character

                for (var i = 0; i < split.Length; i++)
                {

                    var idx = Array.IndexOf(morse, split[i]);

                    if (idx != -1)
                    {
                        resa += alphabet[idx];
                    }
                    else
                    {
                        if (split[i] == "Γ")
                        {
                            resa += ".";
                        }
                        else if (split[i] == "Δ")
                        {
                            resa += " ";
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(everystr + " v textu " + resa);
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();

            }
        }
    }
}
