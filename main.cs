using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cesar_code
{
    class cesar_main
    {

        public class cesar_class
        {
            private string s_word;
            private char[] word = new char[50];
            private int step;
            List<char> b_Alphabet = new List<char>();
            List<char> s_Alphabet = new List<char>();
            private char[] result = new char[50];


            public cesar_class()
            {
             
                for (int i = 1040; i < 1072; i++)
                {
                   b_Alphabet.Add((char)i);
                    if (i == 1045)
                        b_Alphabet.Add((char)1025);
                }
                for (int i = 1072; i < 1104; i++)
                {
                    s_Alphabet.Add((char)i);
                    if (i == 1077)
                        s_Alphabet.Add((char)1105);
                }
            }

            public void set()
            {
                Console.Clear();
                Console.WriteLine("Ввведите строку");
                s_word = Console.ReadLine();
                word = s_word.ToCharArray();
                Console.WriteLine("Введите шаг");
                step = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }


            public void encrypt()
            {
                int i = 0;
                foreach(char item in word)
                {
                    if (word[i] != ' ')
                    {                   
                        if ((int)word[i] >=30 && (int)word[i] <=63)
                        {
                            result[i] = word[i];
                            i++;
                        }
                        else
                        {
                            if ((int)word[i] >= 1072)
                            {
                                int index = s_Alphabet.IndexOf(word[i]) + step;
                                if (index >= s_Alphabet.Count)
                                {
                                    index = index - s_Alphabet.Count;
                                }
                                result[i] = s_Alphabet[index];
                                i++;
                            }
                            else
                            {
                                int index = b_Alphabet.IndexOf(word[i]) + step;
                                if (index >= b_Alphabet.Count)
                                {
                                    index = index - b_Alphabet.Count;
                                }
                                result[i] = b_Alphabet[index];
                                i++;
                            }
                        }
                    }
                    else
                    {
                        word[i] = ' ';
                        i++;
                    }
                }
            }

            public void isNULL()
            {
                if(result[0] == '\0')
                {
                    Console.WriteLine("Введите строку для дешифровки");
                    string add_word = Console.ReadLine();
                    result = add_word.ToCharArray();
                }
            }

            public void decrypt()
            {
                Console.Clear();
                string result_str = new string(result);    
                    for(int step = 0; step < b_Alphabet.Count; step++)
                    {
                        char[] dec_result = result_str.ToCharArray();
                        int i = 0;
                        foreach (char item in dec_result)
                        {
                            if (item != '\0')
                            {
                                if (dec_result[i] != ' ')
                                {
                                if ((int)word[i] >= 30 && (int)word[i] <= 63)
                                {
                                    result[i] = word[i];
                                    i++;
                                }
                                else
                                {
                                    if ((int)dec_result[i] >= 1072)
                                    {
                                        int index = s_Alphabet.IndexOf(dec_result[i]) + step;
                                        if (index >= s_Alphabet.Count)
                                        {
                                            index = index - s_Alphabet.Count;
                                        }
                                        dec_result[i] = s_Alphabet[index];
                                        i++;
                                    }
                                    else
                                    {
                                        int index = b_Alphabet.IndexOf(dec_result[i]) + step;
                                        if (index >= b_Alphabet.Count)
                                        {
                                            index = index - b_Alphabet.Count;
                                        }
                                        dec_result[i] = b_Alphabet[index];
                                        i++;
                                    }
                                }
                                }
                                else
                                {
                                    dec_result[i] = ' ';
                                    i++;
                                }
                            }
                        else
                        {
                            i++;
                        }
                        }
                        string decrypt_result_string = new string(dec_result);
                        Console.WriteLine(step+")"+decrypt_result_string);
                    }            
                Console.ReadKey();
                Console.Clear();
            }

            public void get()
            {
                string result_str = new string(result);
                Console.WriteLine("Шифрованная строка:" + result_str);
                Console.ReadKey();
                Console.Clear();
            }

        }

       static void Main()
        {
            int menu=0;
           cesar_class code = new cesar_class();
            while (menu != 3)
            {
                Console.WriteLine("Выберите пункт меню\n");
                Console.WriteLine("1)Зашифровать строку\n2)Расшифровать строку\n3)Выход\n");         
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        code.set();
                        code.encrypt();
                        Console.Clear();
                        code.get();
                        break;
                    case 2:
                        code.isNULL();
                        code.decrypt();
                        break;                  
                }
            }
            Console.ReadKey();
        }

    }
}
