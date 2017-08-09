using System;
using System.Collections.Generic;

namespace FindAndReplace.Models
{
  public class FAP
  {
    private string _originalString;
    private string _modifiedString;
    private string _wordToFind;
    private string _replacementWord;
    private int _replacementStartIndex;

    public FAP (string originalString, string wordToFind, string replacementWord)
    {
      _originalString = originalString;
      _wordToFind = wordToFind;
      _replacementWord = replacementWord;

      _modifiedString = _originalString;
    }

    public string FindReplacePartials()
    {
      if(_originalString.ToUpper().Contains(_wordToFind.ToUpper()))
      {
         char[] originalStringChars = _originalString.ToCharArray();

         for (int i = 0; i < originalStringChars.Length; i++)
         {
            // Does the character in the originalStringChars match the first letter of the word to find?
            if (originalStringChars[i] == Char.ToLower(_wordToFind[0]) || originalStringChars[i] == Char.ToUpper(_wordToFind[0]))
            {
              bool matches = false;
              int k = i;
              for (int j = 0; j < _wordToFind.Length; j++) // loop through each subsequent character that matches, break and set "matches" bool to false if word stops matching
              {
                if (originalStringChars[k] == Char.ToLower(_wordToFind[j]) || originalStringChars[k] ==  Char.ToUpper(_wordToFind[j])) // does each character match?
                {
                  matches = true;
                  k++; //go to next character
                }
                else
                {
                  matches = false; //character does not match, and break
                  break;
                }
              }
                if (matches == true) //so if the entire word matches, then call replace all partials and set the start index for that function to i
                {
                  _replacementStartIndex = i;
                  ReplaceAllPartials();
                  //Console.WriteLine("Replacement start index: " + _replacementStartIndex);
                }
            }
         }
         Console.WriteLine("Your original string was: " + _originalString + ", and your new string is: " + _modifiedString);
         return _modifiedString;
      }
      else
      {
        return "Word not found in string.";
      }
    }

    public void ReplaceAllPartials()
    {
      int j = 0;
      char[] originalStringChars = _modifiedString.ToCharArray(); //make character array from original string

      for (int i = _replacementStartIndex; i< (_replacementStartIndex+ _wordToFind.Length); i++) //loop through original string starting at _replacementStartIndex, go for the length of replacement word, and replace letters in char array with replacement word
      {
        originalStringChars[i] = _replacementWord[j++];
      }

      _modifiedString = String.Join("",originalStringChars); //join back to string and update _originalString to include replacementWord
      //Console.WriteLine("New string: " + _modifiedString);
    }

    // Method that replaces whole words seperated by spaces
    public string FindReplace()
    {
      if(_originalString.Contains(_wordToFind))
      {
         string[] originalStringArray = _originalString.Split(' '); // seperate by spaces into string array

         for (int i = 0; i < originalStringArray.Length; i ++)
         {
            if (originalStringArray[i] == _wordToFind)
            {
              originalStringArray[i] = _replacementWord;
            }
            _modifiedString = String.Join(" ",originalStringArray);
          //  Console.WriteLine(originalStringArray[i]);
         }
         return _modifiedString;
      }
      else
      {
        return "Word not found in string.";
      }
    }
  }
}
