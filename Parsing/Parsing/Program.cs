using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://ua.linkedin.com/in/kirillmiroshnichenko");


            var name = doc.DocumentNode.SelectNodes("//span[@class='full-name']");
            Print(name);

            var summary = doc.DocumentNode.SelectNodes("//p[@class='description']");
            Print(summary);

            var skills = doc.DocumentNode.SelectNodes("//span[@class='skill-pill']");
            Print(skills);
            Console.WriteLine("-------------");

            string[] values = new string[] {"experience", "courses","projects","certifications", "languages", "education","interests",
            "patents","publications","honors","test-scores","organizations","volunteering"};

            foreach (var item in values)
            {
                Info(doc, item);
            }

            Console.ReadLine();
        }

        static void Info(HtmlDocument doc, string value)
        {
            string selector = String.Format("//div[@id='background-{0}']", value);
            var items = doc.DocumentNode.SelectNodes(selector).Nodes().Where(x => x.Name != "script");
            Print(items);
            Console.WriteLine("-------------");
        }

        static void Print(IEnumerable<HtmlNode> o)
        {
            //Console.WriteLine(o.FirstOrDefault().InnerText);
            if (o != null)
            {
                foreach (var node in o)
                {
                    Console.WriteLine(node.InnerText);//.InnerHtml.Remove());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("is null");
            }
        }

        static void Print(HtmlNodeCollection o)
        {
            if (o != null)
            {
                foreach (var node in o)
                {
                    Console.WriteLine(node.InnerText);
                }
            }
            else
            {
                Console.WriteLine("is null");
            }
        }
    }
}
