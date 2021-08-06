using System.Collections.Generic;

namespace DTSBox_Core.Xmind
{
    public class RequestXMind
    {
        public string Text { get; set; }
        public RequestStyle Style { get; set; }
        public string Label { get; set; }
        public string Hyperlink { get; set; }
        public string Note { get; set; }
        public List<string> Callouts { get; set; }
        /// <summary>
        /// Set either Base64Image OR NetworkPathImage
        /// </summary>
        public string Base64Image { get; set; }
        /// <summary>
        /// Set either Base64Image OR NetworkPathImage
        /// </summary>
        public string NetworkPathImage { get; set; }
        public string ImageAlignment { get; set; }
        public bool Folded { get; set; }

        public List<RequestXMind> Children { get; set; }
    }
}
