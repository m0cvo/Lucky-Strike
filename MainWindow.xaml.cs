
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bandit;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Random number generator
    Random r = new();

    // Always start with 100 credits    
    int credit = 100;

    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SystemSounds.Beep.Play();

        // Each play costs 10 credits
        credit -= 10;

        // If no credits left, end the game
        if (credit == 0)
        {
            EndWindow endWindow = new();
            endWindow.Show();
            End();
        }
        else

        {
            WinningsLbl.Content = "";
            CreditLbl.Content = credit.ToString();

            int a, b, c;

            WindowA.Text = r.Next(1, 10).ToString();
            WindowB.Text = r.Next(1, 10).ToString();
            WindowC.Text = r.Next(1, 10).ToString();

            a = int.Parse(WindowA.Text);
            b = int.Parse(WindowB.Text);
            c = int.Parse(WindowC.Text);

            if (a == b && b == c)
            {
                credit += 100;
                WinningsLbl.Content = "Jackpot you won 100 Credits!";
                string text = "Jackpot! You won!";
                Speak(text);
            }
            else if (a == b)
            {
                credit += 50;
                WinningsLbl.Content = "You won 50 Credits!";
            }
            
        }
        
    }

    // End the game
    private void End()
    {
        SystemSounds.Asterisk.Play();
        this.Close();
    }

    private void StopBtn_Click(object sender, RoutedEventArgs e)
    {
        SystemSounds.Exclamation.Play();
        End();
        this.Close();
    }

    // Making use of the System.Speech.Synthesis namespace to announce the jackpot
    static void Speak(string text)
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        synth.Speak(text);
    }
}