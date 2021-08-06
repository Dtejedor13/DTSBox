using System.Drawing;

namespace DTSBox_Core.Xmind
{
    public class RequestStyle
    {
        public Color BackgroundColor { get; set; }

        public Color ForegroundColor { get; set; }

        public bool Bold { get; set; }

        public EShapeClass? ShapeClass { get; set; }

        public int? FontSize { get; set; }
    }
}
