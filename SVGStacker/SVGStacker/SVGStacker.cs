using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SVGStacker
{
    class SVGStacker
    {
        static void Main(string[] args)
        {
            try
            {
                String path;
                if (args.Length == 0) //Checking if folder was dragged onto exe or path provided as args
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
                    throw new DirectoryNotFoundException("Invalid directory provided"); //Will break out of try
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
                    throw new FileNotFoundException("Directory did not contain .svg files"); //Will break out of try
                }
            }
            catch (Exception e)
            {
                File.WriteAllText("log_" + DateTime.Now.ToString("yyyyMMddTHHmmss"), e.ToString());
                
            }
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }

        private static List<String> getSVGFiles (String[] files)
        {
            List<String> svgs = new List<String>();
            foreach(String file in files)
            {
                if(Path.GetExtension(file).ToLower() == ".svg")
                {
                    svgs.Add(file);
                }
            }
            return svgs;
        }

        private static void buildFile(List<String> svgs)
        {
            //Creating the XmlWriter w/out the xml declaration
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlWriter writer = XmlWriter.Create("symbol-defs.svg", settings);

            //Creating the base SVG declaration with appropriate attributes. Includes <svg> and <defs>
            writer.WriteStartElement("svg", "http://www.w3.org/2000/svg");
            writer.WriteAttributeString("style", "display: none");
            writer.WriteAttributeString("aria-hidden", "true");
            writer.WriteStartElement("defs");

            //Looping through the list of SVG files
            int progress = 0;
            foreach (String file in svgs)
            {
                using (var reader = XmlReader.Create(file))
                {
                    //Building <symbol> tag & attributing it
                    reader.Read();
                    reader.MoveToAttribute("viewBox");
                    writer.WriteStartElement("symbol");
                    writer.WriteAttributeString("id", Path.GetFileNameWithoutExtension(file));
                    writer.WriteAttributeString("viewBox", reader.ReadContentAsString());

                    

                    //Getting the path data and copying it inside the symbol tag
                    reader.Read();
                    if (reader.Name != "g"){ //depending on the file, there might be a <g> tag we want to avoid
                        XmlReader inner = reader.ReadSubtree();

                        //duplicating all path elements by creating new nodes in the output
                        while (inner.Read())
                        {
                            writer.WriteStartElement(inner.Name); 
                            while (inner.MoveToNextAttribute())
                            {
                                writer.WriteAttributeString(inner.Name, inner.Value);
                            }
                            writer.WriteEndElement();
                        }

                    } 
                    else
                    {
                        //duplicating all path elements by creating new nodes in the output
                        while (reader.Read() && reader.Name != "g") //checking for closing </g> tag
                        {
                            writer.WriteStartElement(reader.Name);
                            while (reader.MoveToNextAttribute())
                            {
                                writer.WriteAttributeString(reader.Name, reader.Value);
                            }
                            writer.WriteEndElement();
                        }
                    }

                    //Closing </symbol>
                    writer.WriteEndElement();

                    progress++;
                    Console.WriteLine("{0} processed. {1}/{2} completed.", Path.GetFileName(file), progress, svgs.Count);
                }
            }

            //Closing the </svg> and </defs> tags and the XmlWriter allowing it to save the file.
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
