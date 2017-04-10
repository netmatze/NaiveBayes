using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NaiveBayes
{
public class EmailReader
{
    public List<string> Read(string pathToFiles)
    {
        List<string> list = new List<string>();
        DirectoryInfo currentdirectoryInfo = 
            new DirectoryInfo(Environment.CurrentDirectory);
        DirectoryInfo parent = 
            currentdirectoryInfo.Parent.Parent.Parent;
        DirectoryInfo directoryInfo = 
            new DirectoryInfo(parent.FullName + @"\NaiveBayes" + pathToFiles);
        if (directoryInfo.Exists)
        {
            foreach (var file in directoryInfo.EnumerateFiles())
            {
                var text = String.Empty;
                using(FileStream filestream = file.OpenRead())
                {
                    System.IO.StreamReader streamReader = new System.IO.StreamReader(filestream);
                    text = streamReader.ReadToEnd();
                }
                list.Add(text);
            }
        }
        return list;
    }
}
}
