using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace CreateDataSet
{
    public class structure
    {
        public String text = "";
        public int index = 0;

        public structure(String _text, int _index)
        {
            this.text = _text;
            this.index = _index;
        }
    }

    class Program
    {

        static int Num_Of_Classes = 1500;

        String[] XmlFiles;
        String[] JpgFiles;

        //String[] Classes = new String[183];
        List<String> Classes = new List<String>(Num_Of_Classes);
        List<structure> ImportantClasses = new List<structure>();
        Int16[][] LabelMatrix = new Int16[Num_Of_Classes][];

        Int32 FileCount;

        static void Main(string[] args)
        {
            Program thispro = new Program();
            thispro.FileCount = thispro.CountFiles();
            thispro.CreateDir();
            thispro.CopyAndLabel();
            thispro.SaveCSV();
            System.Console.ReadKey();
        }


        public void init_list()
        {
            ImportantClasses.Add(new structure(" person ", 1));
            ImportantClasses.Add(new structure(" woman person occluded ", 1));
            ImportantClasses.Add(new structure(" person occuded ", 1));
            ImportantClasses.Add(new structure(" person in window ", 1));
            ImportantClasses.Add(new structure(" person back sitting ", 1));
            ImportantClasses.Add(new structure(" person lying ", 1));
            ImportantClasses.Add(new structure(" person lying occluded ", 1));
            ImportantClasses.Add(new structure(" person sitting crop ", 1));
            ImportantClasses.Add(new structure(" person walking az210deg ", 1));
            ImportantClasses.Add(new structure(" person occluded walking ", 1));
            ImportantClasses.Add(new structure(" person man standing walking ", 1));
            ImportantClasses.Add(new structure(" person person walking az150deg ", 1));
            ImportantClasses.Add(new structure(" person walking person az150deg ", 1));
            ImportantClasses.Add(new structure(" person standing walking ", 1));
            ImportantClasses.Add(new structure(" man person walking ", 1));
            ImportantClasses.Add(new structure(" person squatting ", 1));
            ImportantClasses.Add(new structure(" cycling person ", 1));
            ImportantClasses.Add(new structure(" pedestrian person walking ", 1));
            ImportantClasses.Add(new structure(" pedestrian walking person ", 1));
            ImportantClasses.Add(new structure(" madam person woman ", 1));
            ImportantClasses.Add(new structure(" person stanidng ", 1));
            ImportantClasses.Add(new structure(" female person walking ", 1));
            ImportantClasses.Add(new structure(" person crop occluded ", 1));
            ImportantClasses.Add(new structure(" person waling occluded ", 1));
            ImportantClasses.Add(new structure(" human running person walking ", 1));
            ImportantClasses.Add(new structure(" lady walker person walking crop ", 1));
            ImportantClasses.Add(new structure(" lady walker person walking ", 1));
            ImportantClasses.Add(new structure(" person sittign ", 1));
            ImportantClasses.Add(new structure(" person leg crop ", 1));
            ImportantClasses.Add(new structure(" personstanding person walking az240deg ", 1));
            ImportantClasses.Add(new structure(" personstanding person walking az0deg ", 1));
            ImportantClasses.Add(new structure("  person az180deg walking ", 1));

            ImportantClasses.Add(new structure(" cafe sign ", 2));
            ImportantClasses.Add(new structure(" sidewalk cafe ", 2));
            ImportantClasses.Add(new structure(" hotel sign ", 2));
            ImportantClasses.Add(new structure(" monument occluded ", 3));
            ImportantClasses.Add(new structure(" monument ", 3));
            ImportantClasses.Add(new structure(" monument crop ", 3));

            ImportantClasses.Add(new structure(" chair ", 4));
            ImportantClasses.Add(new structure(" benches ", 4));
            ImportantClasses.Add(new structure(" bench occlude ", 4));
            ImportantClasses.Add(new structure(" bench ", 4));

            ImportantClasses.Add(new structure(" building under constuction ", 5));
            ImportantClasses.Add(new structure(" building column ", 5));
            ImportantClasses.Add(new structure(" buildings occludedd ", 5));
            ImportantClasses.Add(new structure(" ivy covered building ", 5));
            ImportantClasses.Add(new structure(" building ", 5));
            ImportantClasses.Add(new structure(" buildig ", 5));
            ImportantClasses.Add(new structure(" buildin ", 5));
            ImportantClasses.Add(new structure(" buildins ", 5));
            ImportantClasses.Add(new structure(" sky-scraper  ", 5));

            ImportantClasses.Add(new structure(" greenery ", 6));
            ImportantClasses.Add(new structure(" grass patch ", 6));
            ImportantClasses.Add(new structure(" patch of grass ", 6));
            ImportantClasses.Add(new structure(" grass ", 6));

            ImportantClasses.Add(new structure(" car ", 7));
            ImportantClasses.Add(new structure(" car frontal crop ", 7));
            ImportantClasses.Add(new structure(" car side occlluded ", 7));
            ImportantClasses.Add(new structure(" car_back ", 7));
            ImportantClasses.Add(new structure(" car_top_back ", 7));
            ImportantClasses.Add(new structure(" car_top_front ", 7));
            ImportantClasses.Add(new structure(" car_right ", 7));
            ImportantClasses.Add(new structure(" car-window ", 7));
            ImportantClasses.Add(new structure(" car_left ", 7));
            ImportantClasses.Add(new structure(" car_top_fornt ", 7));
            ImportantClasses.Add(new structure(" car  occluded ", 7));
            ImportantClasses.Add(new structure(" car fron ", 7));
            ImportantClasses.Add(new structure(" car (occluded) ", 7));
            ImportantClasses.Add(new structure(" car side occlided ", 7));
            ImportantClasses.Add(new structure(" rear of car ", 7));
            ImportantClasses.Add(new structure(" car van side ", 7));
            ImportantClasses.Add(new structure(" bus ", 7));
            ImportantClasses.Add(new structure(" van ", 7));

            ImportantClasses.Add(new structure(" staircas ", 8));
            ImportantClasses.Add(new structure(" stair ", 8));
            ImportantClasses.Add(new structure(" fire escape stairs ", 8));
            ImportantClasses.Add(new structure(" staircase crop ", 8));

            ImportantClasses.Add(new structure(" sidewalk ", 9));
            ImportantClasses.Add(new structure(" crosswalk ", 9));
            ImportantClasses.Add(new structure(" person walking az210deg ", 9));
            ImportantClasses.Add(new structure(" walk sign ", 9));
            ImportantClasses.Add(new structure(" walk signal ", 9));
            ImportantClasses.Add(new structure(" person occluded walking ", 9));
            ImportantClasses.Add(new structure(" person man standing walking ", 9));
            ImportantClasses.Add(new structure(" person person walking az150deg ", 9));
            ImportantClasses.Add(new structure(" person walking person az150deg ", 9));
            ImportantClasses.Add(new structure(" person standing walking ", 9));
            ImportantClasses.Add(new structure(" man person walking ", 9));
            ImportantClasses.Add(new structure(" lady walking ", 9));
            ImportantClasses.Add(new structure(" pedestrian person walking ", 9));
            ImportantClasses.Add(new structure(" pedestrian walking person ", 9));
            ImportantClasses.Add(new structure(" walkway ", 9));
            ImportantClasses.Add(new structure(" side walk ", 9));
            ImportantClasses.Add(new structure(" peson walking ", 9));
            ImportantClasses.Add(new structure(" female person walking ", 9));
            ImportantClasses.Add(new structure(" human running person walking ", 9));
            ImportantClasses.Add(new structure(" lady walker person walking crop ", 9));
            ImportantClasses.Add(new structure(" lady walker person walking ", 9));
            ImportantClasses.Add(new structure(" personstanding person walking az240deg ", 9));
            ImportantClasses.Add(new structure(" personstanding person walking az0deg ", 9));
            ImportantClasses.Add(new structure("  person az180deg walking ", 9));

            ImportantClasses.Add(new structure(" fence ", 10));
            ImportantClasses.Add(new structure(" iron fence ", 10));
            ImportantClasses.Add(new structure(" cyclone fence ", 10));
            ImportantClasses.Add(new structure(" wood fence ", 10));
            ImportantClasses.Add(new structure(" railing ", 10));
            ImportantClasses.Add(new structure(" handrail ", 10));
            ImportantClasses.Add(new structure(" railings ", 10));
            ImportantClasses.Add(new structure(" railigns ", 10));
            ImportantClasses.Add(new structure(" hand rails ", 10));
            ImportantClasses.Add(new structure(" hand rail ", 10));
            ImportantClasses.Add(new structure(" rail ", 10));
            ImportantClasses.Add(new structure(" iron rail ", 10));
            ImportantClasses.Add(new structure(" guard rail ", 10));
            ImportantClasses.Add(new structure(" side rail ", 10));
            ImportantClasses.Add(new structure(" porch rail ", 10));
            ImportantClasses.Add(new structure(" railin ", 10));
            ImportantClasses.Add(new structure(" wall_column ", 10));
            ImportantClasses.Add(new structure(" wall sconce ", 10));
            ImportantClasses.Add(new structure(" wall ", 10));

            ImportantClasses.Add(new structure(" tree ", 11));
            ImportantClasses.Add(new structure(" tree  trunk ", 11));
            ImportantClasses.Add(new structure(" tree tops ", 11));
            ImportantClasses.Add(new structure(" willow tree ", 11));
            ImportantClasses.Add(new structure(" potted tree ", 11));
            ImportantClasses.Add(new structure(" blossom tree ", 11));
            ImportantClasses.Add(new structure(" plant ", 11));
            ImportantClasses.Add(new structure(" hanging plant ", 11));

            ImportantClasses.Add(new structure(" litter bbin ", 12));
            ImportantClasses.Add(new structure(" litter  bin ", 12));
            ImportantClasses.Add(new structure(" littrer bin ", 12));
            ImportantClasses.Add(new structure(" trahs can ", 12));

            ImportantClasses.Add(new structure(" bus stop ", 13));
            ImportantClasses.Add(new structure(" bus stop sign ", 13));

            ImportantClasses.Add(new structure(" river ", 14));

            ImportantClasses.Add(new structure(" pole ", 15));
            ImportantClasses.Add(new structure(" pillars ", 15));
            ImportantClasses.Add(new structure(" building column ", 15));
            ImportantClasses.Add(new structure(" column ", 15));

            ImportantClasses.Add(new structure(" shop ", 16));
            ImportantClasses.Add(new structure(" shop  window crop ", 16));
            ImportantClasses.Add(new structure(" shop front ", 16));

            ImportantClasses.Add(new structure(" bridge ", 17));
            //ImportantClasses.Add(new structure(" underground entrance ", 1));
            //ImportantClasses.Add(new structure(" underground ", 1));
            //ImportantClasses.Add(new structure("", 1));
            //ImportantClasses.Add(new structure("", 1));
            //ImportantClasses.Add(new structure("", 1));
            //ImportantClasses.Add(new structure("", 1));
            //ImportantClasses.Add(new structure("", 1));
        }

        public int CountFiles()
        {
            int fileCountXML = 0;
            int fileCountJPG = 0;

            XmlFiles = Directory.GetFiles("I:\\NewData\\test\\Annotations\\", "*.xml", SearchOption.AllDirectories);
            JpgFiles = Directory.GetFiles("I:\\NewData\\test\\Images\\", "*.jpg", SearchOption.AllDirectories);

            fileCountXML = XmlFiles.Length;
            fileCountJPG = JpgFiles.Length;

            if (fileCountJPG != fileCountXML)
                System.Console.WriteLine("Error in counting files...");
            else
                System.Console.WriteLine("Xmls and Jpgs are equal. We are good to go...");

            return fileCountXML;
        }

        public void CreateDir()
        {
            Directory.CreateDirectory("I:\\NewData\\test\\NewImages\\");
            System.Console.WriteLine("Directory Created ....");
        }

        public void CopyAndLabel()
        {
            for (int i=0; i < Num_Of_Classes; i++)
            {
                LabelMatrix[i] = new Int16[JpgFiles.Length];
            }

            for (int i=0; i< Num_Of_Classes; i++)
            {
                for (int j = 0; j < JpgFiles.Length; j++)
                {
                    LabelMatrix[i][j] = 0;
                }
            }

            Classes.Add("people");
            Classes.Add("bar(s)");
            Classes.Add("Monument(s)");
            Classes.Add("chairs/benches");
            Classes.Add("Government /Church / other building(s) & apartment(s)");
            Classes.Add("green ground");
            Classes.Add("vehicle(s) / bus(es)");
            Classes.Add("stair(s)");
            Classes.Add("walk path / Side walk");
            Classes.Add("Fence / Wall");
            Classes.Add("Tree(s) / Plant(s)");
            Classes.Add("garbidge can(s)");
            Classes.Add("bus stop");
            Classes.Add("river");
            Classes.Add("pole(s) / Pillar(s)");
            Classes.Add("shop(s)");
            Classes.Add("bridge(t)");
            //Classes.Add();
            //Classes.Add();


            for (int i=0; i< JpgFiles.Length; i++)
            {
                
                //System.Console.WriteLine("New File...");
                String JpgOnlyName = JpgFiles[i].Substring(JpgFiles[i].LastIndexOf('\\') + 1);
                String OnlyNameForPic = JpgOnlyName.Split('.')[0];

                String XmlOnlyName = XmlFiles[i].Substring(XmlFiles[i].LastIndexOf('\\') + 1);
                String OnlyNameForXml = JpgOnlyName.Split('.')[0];

                if(OnlyNameForPic != OnlyNameForXml)
                {
                    System.Console.WriteLine("Error Matching Files....");
                }

                XmlDocument docXml = new XmlDocument();
                docXml.Load(XmlFiles[i]);

                XmlNodeList nodes = docXml.DocumentElement.SelectNodes("/annotation/object/name");

                foreach(XmlNode node in nodes)
                {
                    //System.Console.WriteLine(node.InnerText);
                    //System.Console.ReadKey();
                    int index = 0;

                    if (Classes.Contains(node.InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ').ToLower()) )
                    {
                        //int index = Classes.IndexOf(node.InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ').ToLower());
                        

                        foreach(structure s in ImportantClasses)
                        {
                            if ( s.text == node.InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ').ToLower())
                            {
                                index = s.index - 1;
                                break;
                            }
                            else
                            {
                                index = Classes.IndexOf(node.InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ').ToLower());
                            }
                        }

                        LabelMatrix[index][i] = 1;
                    }
                    else
                    {
                        //System.Console.WriteLine(node.InnerText);
                        Classes.Add(node.InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ').ToLower());
                        index = Classes.IndexOf(node.InnerText.Replace('\n', ' ').Replace('\r', ' ').Replace(',', ' ').ToLower());
                        LabelMatrix[index][i] = 1;
                    }
                }


                //File.Copy(JpgFiles[i], "I:\\NewData\\train\\NewImages\\" + Convert.ToString(i+1) + ".jpg");
                System.Console.WriteLine("File: " + Convert.ToString(i+1) + ".jpg" + " done, out of " + Convert.ToString(FileCount));
            }

        }

        public void SaveCSV()
        {
            StreamWriter sw = new StreamWriter("I:\\NewData\\test\\NewImages\\test_Labels_new.csv");
            String line = "";
            for (int i = 0; i< Classes.Count; i++)
            {
                line = "";
                for (int j = 0; j<FileCount; j++)
                {
                    if (j == 0)
                    {
                        line = Classes[i] + "," + LabelMatrix[i][j];
                    }
                    else
                    {
                        line = line + "," + LabelMatrix[i][j];
                    }
                }
                sw.WriteLine(line);
            }
            sw.Close();
            System.Console.WriteLine("All Ended...");
        }
    }
}
