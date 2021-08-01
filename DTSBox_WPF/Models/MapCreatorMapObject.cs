using DTSBox_WPF.Common;

namespace DTSBox_WPF.Models
{
    class MapCreatorMapObject : ViewModelBase
    {
        private string source = "";
        public string ImageSource
        {
            get { return source; }
            set
            {
                source = value;
                OnPropertyChanged();
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }

        private bool isPassable;

        public bool IsPassable
        {
            get { return isPassable; }
            set
            {
                isPassable = value;
                OnPropertyChanged();
            }
        }

        private int goToMapID;

        public int GoToMapID
        {
            get { return goToMapID; }
            set
            {
                goToMapID = value;
                OnPropertyChanged();
            }
        }

        public MapCreatorMapObject(string sorces, bool ispassableproperty, int gotoMapID)
        {
            this.source = sorces;
            this.isPassable = ispassableproperty;
            this.goToMapID = gotoMapID;
        }
    }
}
