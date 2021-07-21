using DTSBox_WPF.Common;
using DTSBox_WPF.Controller;
using System.IO;

namespace DTSBox_WPF.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Properties
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        private bool _buttonVisibility;

        public bool Button1Visibility
        {
            get { return _buttonVisibility; }
            set { _buttonVisibility = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands
        public RelayCommand ButtonClickCommand { get; private set; }
        #endregion

        #region Private Fields
        private string message1 = "Hey Wie Gehts ?";
        private string message2 = "Gut Wie Geht es dir ?";
        #endregion

        public MainWindowViewModel()
        {
            Message = message1;
            Button1Visibility = false;
            ButtonClickCommand = new RelayCommand(parm => ButtonClickEvent());

            // build musicfile from Ressources
            //string filePath = SoundController.WriteResourceToFile("sampleFile.wav", true);

            // play Music

            //SoundController.Play(filePath, 0.2, false);
            // load file from path
            SoundController.Play(Path.GetFullPath(@"sampleFile.mp3"), 0.2, false);
        }

        #region Private Methods
        private void ButtonClickEvent()
        {
            if (Message == message1)
                Message = message2;
            else
                Message = message1;
        }
        #endregion
    }
}
