using DTSBox_Core.Models;
using DTSBox_Core.Xmind;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSBox_Core.Classes
{
    public class XMindCreator
    {
        List<ExtractedXmindModel> topics = new List<ExtractedXmindModel>();

        public RequestStyle xMindStyle { get; set; }

        public XMindCreator(RequestStyle style)
        {
            xMindStyle = style;
        }

        public bool CreateXMindFromText(string content, string filename)
        {
            string[] lines = content.Split('\n');

            string title = lines[0];

            List<string> text = lines.ToList();

            text.RemoveAt(0);

            try
            {
                fillMainTopics(lines.ToList());

                RequestSheet xmind = new RequestSheet();
                //xmind.Title = "Meine Woche";
                xmind.MainRequestXMind = new RequestXMind()
                {
                    Style = xMindStyle,
                    Text = title
                };
                xmind.MainRequestXMind.Children = new List<RequestXMind>();


                List<RequestXMind> getChildRequestXminds(List<ExtractedXmindModel> models)
                {
                    List<RequestXMind> childrens = new List<RequestXMind>();
                    foreach (ExtractedXmindModel item in models)
                    {
                        RequestXMind childTopic = new RequestXMind();
                        childTopic.Text = item.ParentTopic;
                        childTopic.Style = xMindStyle;
                        childTopic.Children = getChildRequestXminds(item.ChildTopics);
                        childrens.Add(childTopic);
                    }
                    return childrens;
                }

                foreach (ExtractedXmindModel item in topics)
                {
                    xmind.MainRequestXMind.Children.Add(new RequestXMind()
                    {
                        Text = item.ParentTopic,
                        Style = xMindStyle,
                        Children = getChildRequestXminds(item.ChildTopics)
                    });
                }

                List<RequestSheet> xminds = new List<RequestSheet>()
            {
                xmind
            };

                var result = createXmindAsync(xminds, filename);
                return result.Result;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateSampleXmind()
        {
            // First Toppic
            RequestXMind firstTopic = new RequestXMind();
            firstTopic.Text = "First Toppic";
            firstTopic.Style = xMindStyle;
            // second Topic
            RequestXMind secondTopic = new RequestXMind();
            secondTopic.Text = "Second Topic";
            secondTopic.Style = xMindStyle;

            RequestXMind underTpoic = new RequestXMind();
            underTpoic.Text = "this is a nice Day!";
            underTpoic.Style = xMindStyle;

            secondTopic.Children = new List<RequestXMind>()
            {
                underTpoic
            };

            firstTopic.Children = new List<RequestXMind>()
            {
                secondTopic
            };
            // main Xmind
            RequestSheet xmind = new RequestSheet();
            xmind.Title = "test";
            xmind.MainRequestXMind = firstTopic;

            List<RequestSheet> xMinds = new List<RequestSheet>()
            {
                xmind
            };

            //saveXmindAsJson(xMinds);
            var result = createXmindAsync(xMinds, "test123");
            return result.Result;
        }

        private void fillMainTopics(List<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("\t") && !lines[i].StartsWith("\t\t")) // mainTopic
                {
                    // Toppic
                    ExtractedXmindModel maintopic = new ExtractedXmindModel();
                    maintopic.ParentTopic = lines[i].Replace("\t", String.Empty);
                    maintopic.ChildTopics = getChildrens(lines, "\t\t", (i + 1));

                    topics.Add(maintopic);
                }
            }
        }

        private List<ExtractedXmindModel> getChildrens(List<string> lines, string startCondition, int startAtIndex)
        {
            List<ExtractedXmindModel> result = new List<ExtractedXmindModel>();
            bool breakbyFalseCondition = false;
            StringBuilder sb = new StringBuilder();
            sb.Append(startCondition);
            sb.Append("\t");

            for (int i = startAtIndex; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(startCondition) && !lines[i].StartsWith(sb.ToString()))
                {
                    ExtractedXmindModel child = new ExtractedXmindModel();
                    child.ParentTopic = lines[i].Replace("\t", String.Empty);
                    child.ChildTopics = getChildrens(lines, sb.ToString(), (i + 1));
                    result.Add(child);
                    breakbyFalseCondition = true;
                }
                else
                    if (breakbyFalseCondition)
                    break;
            }

            return result;
        }

        private void saveXmindAsJson(List<RequestSheet> xMinds)
        {
            int counter = 1;
            foreach (RequestSheet xmind in xMinds)
            {
                string json = JsonConvert.SerializeObject(xmind, Formatting.Indented);

                string filePath =
                    WinEnviromentFolders.GetPath(WinEnviromentFolders.KnownFolder.Downloads) + "/" + counter.ToString() + "-xmind.json";
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(json);
                    sw.Close();
                    fs.Close();
                }
                counter++;
            }
        }

        private async Task<bool> createXmindAsync(List<RequestSheet> xMinds, string fileName)
        {
            XMindGeneratorClient client = new XMindGeneratorClient();
            byte[] bytes = await client.RequestXMindStream(xMinds, fileName);

            //MemoryStream ms = stream;

            if (bytes == null || bytes.Length == 0) return false;

            string file = WinEnviromentFolders.GetPath(WinEnviromentFolders.KnownFolder.Downloads) + $"/{fileName}.xmind";

            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                //byte[] byteArray = new byte[ms.Length];
                System.Console.WriteLine("recived byteArray with length of " + bytes.Length);
                fs.Write(bytes, 0, bytes.Length);
            }

            return true;
        }
    }
}
