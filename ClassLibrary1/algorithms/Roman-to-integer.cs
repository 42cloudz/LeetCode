/// <summary>
/// Proposed solution for https://leetcode.com/problems/roman-to-integer/
/// </summary>

public class Solution
{
    public int RomanToInt(string s)
    {
        if (!HasValidCharacters(s))
            return 0;

        return IterateThroughRomanNumber(s);

    }

    public int IterateThroughRomanNumber(string s)
    {
        int decValue = 0;

        for (int i = 0; i < s.Length; ++i)
        {
            int val = 0;
            switch (s[i])
            {
                case 'I':
                    val = IsNextCharacterOfInterestGetValue(s, i, new List<char>() { 'V', 'X' });
                    if (val == 0)
                    {
                        decValue += 1;
                    }
                    else
                    {
                        decValue += val;
                        i++;
                    }
                    break;
                case 'X':
                    val = IsNextCharacterOfInterestGetValue(s, i, new List<char>() { 'L', 'C' });
                    if (val == 0)
                    {
                        decValue += 10;
                    }
                    else
                    {
                        decValue += val;
                        i++;
                    }
                    break;
                case 'C':
                    val = IsNextCharacterOfInterestGetValue(s, i, new List<char>() { 'D', 'M' });
                    if (val == 0)
                    {
                        decValue += 100;
                    }
                    else
                    {
                        decValue += val;
                        i++;
                    }
                    break;
                case 'V':
                    decValue += 5;
                    break;
                case 'L':
                    decValue += 50;
                    break;
                case 'D':
                    decValue += 500;
                    break;
                case 'M':
                    decValue += 1000;
                    break;
                default:
                    break;
            }
        }
        return decValue;
    }

    public int IsNextCharacterOfInterestGetValue(string s, int index, List<char> characterOfInterest)
    {
        if (s.Length - 1 == index)
        {
            return 0;
        }
        char next = s[++index];
        if (characterOfInterest.Contains(next))
        {
            switch (next)
            {
                case 'V':
                    return 4;
                case 'X':
                    return 9;
                case 'L':
                    return 40;
                case 'C':
                    return 90;
                case 'D':
                    return 400;
                case 'M':
                    return 900;
                default:
                    return 0;
            }
        }
        return 0;
    }

    public bool HasValidCharacters(string s)
    {
        List<char> validCharacters = new List<char>() { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        if (s.Length < 1 || s.Length > 15)
        {
            return false;
        }
        foreach (var character in s)
        {
            if (!validCharacters.Contains(character))
            {
                return false;
            }
        }
        return true;
    }
}
