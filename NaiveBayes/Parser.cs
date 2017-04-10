using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayes
{
    public class Parser
    {
        private Dictionary<string, int> wordCounter = new Dictionary<string,int>();

        public Dictionary<string, int> WordCounter
        {
          get { return wordCounter; }
          set { wordCounter = value; }
        }

        public void Parse(string textToParse)
        {
            var stringArray = textToParse.Split(' ');
            foreach (var str in stringArray)
            {
                if (wordCounter.ContainsKey(str.ToLower()))
                {
                    wordCounter[str.ToLower()] += 1;
                }
                else
                {
                    wordCounter.Add(str.ToLower(), 1);
                }
            }
        }
    }
}
