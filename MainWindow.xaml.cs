
using System.Media;
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
    Random r = new();
    int credit = 100;

    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //PlaySimpleSound();
        credit -= 10;

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
            }
            else if (a == b)
            {
                credit += 50;
                WinningsLbl.Content = "You won 50 Credits!";
            }
            
        }
        
    }

    private void End()
    {
        this.Close();
    }

    private void StopBtn_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void PlaySimpleSound()
    {
        SoundPlayer simpleSound = new SoundPlayer(@"/Sounds/buttonPing.wav");
        simpleSound.Play();
    }
}