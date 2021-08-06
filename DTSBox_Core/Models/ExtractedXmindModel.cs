using System.Collections.Generic;

namespace DTSBox_Core.Models
{
    public class ExtractedXmindModel
    {
        public string ParentTopic { get; set; }
        public List<ExtractedXmindModel> ChildTopics { get; set; } = new List<ExtractedXmindModel>();
    }
}
