using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DTSBox_WPF.Controller
{
    public static class SoundController
    {
        private static MediaPlayer mediaPlayer = new MediaPlayer();
        private static bool imPlayingMusic = false;

        /// <param name="musicPath">full path</param>
        /// <param name="volume">0 - 1</param>
        public static void Play(string musicPath, double volumeLvl, bool loop = false)
        {
            if (imPlayingMusic)
                Stop();

            try
            {
                mediaPlayer.Open(new Uri(musicPath));
                mediaPlayer.Volume = volumeLvl;

                if (loop)
                    mediaPlayer.MediaEnded += musicIsEndedEventHandler;

                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void Stop()
        {
            if (imPlayingMusic)
            {
                imPlayingMusic = false;
                mediaPlayer.Stop();
            }
        }

        public static void Pause()
        {
            if (imPlayingMusic)
            {
                imPlayingMusic = false;
                mediaPlayer.Pause();
            }
        }

        public static void Sleep(int milSeconds)
        {
            if(imPlayingMusic)
            {
                Task sleepTask = Task.Run(() => sleepForXSecondsAsync(milSeconds));
            }
        }

        public static string WriteResourceToFile(string resourceFileName, bool saveFileAsMp3 = false)
        {
            // Ressorce File has to be saved as embedded Ressource to the project
            string filename = resourceFileName.Split('.')[0] + (saveFileAsMp3 ? ".mp3" : ".wav");
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("DTSBox_WPF.Resources." + resourceFileName))
            {
                using (var file = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }

            return Path.GetFullPath(filename);
        }

        #region Private Methods
        private static void musicIsEndedEventHandler(object sender, EventArgs e)
        {
            // loop
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }

        private static async Task sleepForXSecondsAsync(int value)
        {
            await sleepThreadAsync(value);
        }

        private static async Task sleepThreadAsync(int value)
        {
            Thread.Sleep(value);
        }
        #endregion
    }
}
