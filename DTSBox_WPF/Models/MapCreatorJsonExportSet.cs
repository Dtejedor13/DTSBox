using System.Collections.Generic;

namespace DTSBox_WPF.Models
{
    class MapCreatorJsonExportSet
    {
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        public List<MapCreatorExport> MetaData { get; set; }
        public MapCreatorJsonExportSet(int rowCount, int columnCount, List<MapCreatorExport> metaData)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            this.MetaData = metaData;
        }
    }
}
