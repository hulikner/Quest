using System;
using System.Collections.Generic;

namespace Quest
{
    public class Prize
    {
        private string _text {get;set;} 
        public Prize(string text)
        {
            _text=text;
        }
        public string ShowPrize(Adventurer adventurer)
        {
            if(adventurer.Awesomeness > 0)
            {
                for(int i=0; i<adventurer.Awesomeness; i++)
                {
                    Console.WriteLine($"{i}{_text}");
                }
                return "";
            }
            else
            {
                return "Man you suck!";
            }
        }
    }
}    