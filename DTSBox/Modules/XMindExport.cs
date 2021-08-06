using DTSBox_Core.Classes;
using DTSBox_Core.Interfaces;
using DTSBox_Core.Xmind;
using System;
using System.Drawing;
using System.IO;

namespace DTSBox.Modules
{
    class XMindExport : IDTSModule
    {
        public bool ModuleMain()
        {
            string content = readContentFile();

            Console.WriteLine(content);

            RequestStyle xmindStyle = new RequestStyle();
            xmindStyle.BackgroundColor = Color.FromArgb(252, 236, 192);
            xmindStyle.ForegroundColor = Color.FromArgb(0, 0, 0);
            xmindStyle.Bold = false;
            xmindStyle.FontSize = 12;
            xmindStyle.ShapeClass = EShapeClass.roundedRectangle;

            XMindCreator xc = new XMindCreator(xmindStyle);

            bool result = xc.CreateXMindFromText(content, "Wochenbericht");

            return result;
        }

        private string readContentFile()
        {
            string content = "";
            string path = WinEnviromentFolders.GetPath(WinEnviromentFolders.KnownFolder.Downloads) + "/test.txt";
            using(FileStream fs = new FileStream(path, FileMode.Open))
            using(StreamReader sr = new StreamReader(fs))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }
    }
}
