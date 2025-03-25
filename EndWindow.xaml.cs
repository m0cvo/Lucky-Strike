using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bandit
{
    /// <summary>
    /// Interaction logic for EndWindow.xaml
    /// </summary>
    public partial class EndWindow : Window
    {
        public EndWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create a thread object.
            Thread speechThread = new Thread(() => Speak("Goodbye!"));
            SystemSounds.Asterisk.Play();
            this.Close();
        }


        static void Speak(string text)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak(text);
        }
    }
}
