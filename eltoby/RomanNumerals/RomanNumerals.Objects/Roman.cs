using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.Objects
{
    public class Roman
    {
        string letter;
        int value;
        bool repeatable;

        public Roman(string letter, int value, bool repeatable)
        {
            this.letter = letter;
            this.value = value;
            this.repeatable = repeatable;
        }

        public string Letter
        {
            get { return letter; }
        }

        public int Value
        {
            get { return value; }
        }

        public bool Repeatable
        {
            get { return repeatable; }
        }

        public static bool operator >(int num1, Roman rom1)
        {
            return num1 > rom1.value;

        }

        public static bool operator <(int num1, Roman rom1)
        {
            return num1 < rom1.value;
        }
        
        public static bool operator >(Roman rom1, int num1)
        {
            return rom1.value > num1;
           
        }

        public static bool operator <(Roman rom1, int num1)
        {
            return rom1.value < num1;

        }

        public static bool operator ==(int num1, Roman rom1)
        {
            return rom1.value == num1;
        }

        public static bool operator !=(int num1, Roman rom1)
        {
            return rom1.value != num1;
        }
    }
}
