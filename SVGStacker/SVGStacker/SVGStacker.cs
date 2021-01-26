using System;
using System.Collections.Generic;
using System.IO;

namespace SVGStacker
{
    class SVGStacker
    {
        static void Main(string[] args)
        {
            try
            {
                String path;
                if (args.Length == 0)
                {
                    Console.WriteLine("Please input the full path to the icon folder");
                    path = Console.ReadLine();
                } else
                {
                    path = args[0];
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("ERROR: {0} is not a valid directory.", path);
                    throw new DirectoryNotFoundException(); //Will break out of try
                } 

                string[] files = Directory.GetFiles(path);
                List<String> svgs = getSVGFiles(files);

                if(svgs.Count > 0)
                {
                    buildFile(svgs);
                }
                else
                {
                    Console.WriteLine("ERROR: {0} does not contain any SVG files", path);
                }
                
            }
            catch (Exception e)
            {
                File.WriteAllText("log_" + DateTime.Now.ToString("yyyyMMddTHHmmss"), e.ToString());
            }

        }

        private static List<String> getSVGFiles (String[] files)
        {
            List<String> svgs = new List<String>();
            foreach(String file in files)
            {
                if(Path.GetExtension(file).ToLower() != ".svg")
                {
                    svgs.Add(file);
                }
            }
            return svgs;
        }

        private static void buildFile(List<String> svgs)
        {

        }
    }
}
