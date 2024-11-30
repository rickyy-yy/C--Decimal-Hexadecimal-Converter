using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;  // To use dictionaries

namespace DecimalToHexadecimal
{
    public class Program
    {
        public static int GetDecimalNumber()  // Gets the decimal number from user
        {
            int DecimalNumber;

            Console.Write("Enter an integer in decimal to convert to hexadecimal: ");
            DecimalNumber = Convert.ToInt32(Console.ReadLine());

            return DecimalNumber;
        }
        public static int FindHighestPower(int DecimalNumber)  // Finds the highest power needed
        {
            int Power = 0;
            while (true)
            {
                if (DecimalNumber / (Math.Pow(16, Power)) >= 15)
                {
                    Power++;
                }
                else
                {
                    break;
                }
            }
            return Power;
        }
        public static string ConvertToHex(int DecimalNumber, int Power)  // Converts
        {
            String Hexadecimal_Number = "";

            Dictionary<int, String> Hex_Values = new Dictionary<int, string>();
            Hex_Values.Add(0, "0");
            Hex_Values.Add(1, "1");
            Hex_Values.Add(2, "2");
            Hex_Values.Add(3, "3");
            Hex_Values.Add(4, "4");
            Hex_Values.Add(5, "5");
            Hex_Values.Add(6, "6");
            Hex_Values.Add(7, "7");
            Hex_Values.Add(8, "8");
            Hex_Values.Add(9, "9");
            Hex_Values.Add(10, "A");
            Hex_Values.Add(11, "B");
            Hex_Values.Add(12, "C");
            Hex_Values.Add(13, "D");
            Hex_Values.Add(14, "E");
            Hex_Values.Add(15, "F");

            int Quotient = DecimalNumber;
            for (int i = Power; i > -1; i--)
            {
                int Divisor = (int)Math.Pow(16, i);
                if (Power != 0)
                {
                    Quotient = Quotient/Divisor;
                    Hexadecimal_Number = Hexadecimal_Number + Hex_Values[Quotient];
                    Quotient = DecimalNumber % Divisor;
                }
                else
                {
                    Hexadecimal_Number = Hexadecimal_Number + Hex_Values[Quotient];
                }
            }
            return Hexadecimal_Number;
        }
        public static void Main(string[] args)
        {
            int Decimal_Number = GetDecimalNumber();
            int Power = FindHighestPower(Decimal_Number);
            String Hexa = ConvertToHex(Decimal_Number, Power);
            Console.WriteLine(Hexa);
        }
    }
}
