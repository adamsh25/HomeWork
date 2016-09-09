using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTestExamAdamCheriki
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo f = new FileInfo(@"~/jav_logs.xml");
            var list = Parser.Parse<Event>(f);
            list.ToList().ForEach(e => Console.WriteLine(e));
            Console.Read();
        }
    }
}
