using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayes
{
    public class NaiveBayes
    {
        private List<string> spamMails;
        private List<string> notSpamMails;
        private int countSpamMails;
        private int countNotSpamMails;

        public NaiveBayes()
        {
            EmailReader emailReader = new EmailReader();
            spamMails = emailReader.Read(@"\Mails\Spam\");
            notSpamMails = emailReader.Read(@"\Mails\NotSpam\");
            countSpamMails = spamMails.Count();
            countNotSpamMails = notSpamMails.Count();
        }

        public bool CheckEmail(string text)
        {            
            Parser parser = new Parser();
            foreach(var spamMail in spamMails)
            {
                parser.Parse(spamMail);
            }
            var spamWords = parser.WordCounter;
            parser = new Parser();
            foreach (var notSpamMail in notSpamMails)
            {
                parser.Parse(notSpamMail);
            }
            var notSpamWords = parser.WordCounter;
            return CheckIfSpam(text, countSpamMails, spamWords, countNotSpamMails, notSpamWords);
        }

        private bool CheckIfSpam(string text, 
            int countSpamMails, Dictionary<string,int> spamWordList,
            int countNotSpamMails, Dictionary<string,int> notSpamWordList)
        {
            var stringArray = text.Split(' ');
            var sumQ = 0.0;
            var wordCounter = 0;
            foreach (var item in stringArray)
            {
                var q = CalculateQ(item.ToLower(), 
                    countSpamMails, spamWordList, 
                    countNotSpamMails, notSpamWordList);
                sumQ += q;
                wordCounter++;
            }
            if (sumQ / wordCounter > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double CalculateQ(string word, 
            int countSpamMails, Dictionary<string,int> spamWordList,
            int countNotSpamMails, Dictionary<string,int> notSpamWordList)
        {
            double wordCountSpam = 1;
            if (spamWordList.ContainsKey(word))
            {
                wordCountSpam = spamWordList[word];
            }
            double Ph1e = 0.5 * wordCountSpam / countSpamMails;
            double wordCountNotSpam = 1;
            if (notSpamWordList.ContainsKey(word))
            {
                wordCountNotSpam = notSpamWordList[word];
            }
            double Ph2e = 0.5 * wordCountNotSpam / countNotSpamMails;
            double q = Ph1e / Ph2e;
            return q;
        }
    }
}
