using System.Collections.Generic;
using System.Text;

public static class MorseUtility
{
    // Normal harf → Morse kodu
    public static Dictionary<char, string> LetterToMorse = new Dictionary<char, string>()
    {
        {'A', ".-"},   {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
        {'E', "."},    {'F', "..-."}, {'G', "--."},  {'H', "...."},
        {'I', ".."},   {'J', ".---"}, {'K', "-.-"},  {'L', ".-.."},
        {'M', "--"},   {'N', "-."},   {'O', "---"},  {'P', ".--."},
        {'R', ".-."},  {'S', "..."},  {'T', "-"},    {'U', "..-"},
        {'V', "...-"}, {'W', ".--"},  {'X', "-..-"}, {'Y', "-.--"},
        {'Z', "--.."},

        {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
        {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."},
        {'9', "----."}, {'0', "-----"},
    };

    // Kısa / Uzun dönüştürme (. = 0 , - = 1 , boşluk = 2)
    public static string EncodeToDigits(string morse)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in morse)
        {
            if (c == '.') sb.Append("0");
            else if (c == '-') sb.Append("1");
            else if (c == ' ') sb.Append("2");
        }

        return sb.ToString();
    }

    // Digit → Morse
    public static string DecodeDigits(string digits)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in digits)
        {
            if (c == '0') sb.Append('.');
            else if (c == '1') sb.Append('-');
            else if (c == '2') sb.Append(' ');
        }

        return sb.ToString();
    }

    // Normal metni → digit formatına çevirme
    public static string TextToDigits(string text)
    {
        StringBuilder result = new StringBuilder();

        text = text.ToUpper();

        foreach (char c in text)
        {
            if (!LetterToMorse.ContainsKey(c)) continue;

            string morse = LetterToMorse[c];
            string digit = EncodeToDigits(morse);

            result.Append(digit);
            result.Append("2"); // harf arası boşluk
        }

        return result.ToString();
    }

    // Digit formatını → normal harfe çevirme
    public static string DigitsToText(string digits)
    {
        string morse = DecodeDigits(digits);
        string[] letters = morse.Split(' ');

        StringBuilder result = new StringBuilder();

        foreach (string letter in letters)
        {
            foreach (var pair in LetterToMorse)
            {
                if (pair.Value == letter)
                {
                    result.Append(pair.Key);
                    break;
                }
            }
        }

        return result.ToString();
    }
}