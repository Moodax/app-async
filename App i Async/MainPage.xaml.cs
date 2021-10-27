using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App_i_Async
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            TEXTBOX.IsEnabled = false;
            TEXTBOX1.IsEnabled = false;
        }

        private void TextBox_OnBeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        async private void GUMB_Click(object sender, RoutedEventArgs e)
        {
            GUMB.IsEnabled = false;
            TEXTBOX.IsEnabled = true;
            TEXTBOX1.IsEnabled = true;
            Output.Text = "IMAŠ JEDNO 5 SEC DA UPIŠEŠ SVE";
            await Task.Delay(5000);
            while (TEXTBOX.Text.StartsWith("0"))
                TEXTBOX.Text = TEXTBOX.Text.Remove(0, 1);
            while (TEXTBOX1.Text.StartsWith("0"))
                TEXTBOX1.Text = TEXTBOX1.Text.Remove(0, 1);
            if (TEXTBOX.Text.Length > 0 && TEXTBOX1.Text.Length > 0)
                Output.Text = (Convert.ToInt32(TEXTBOX.Text) + Convert.ToInt32(TEXTBOX1.Text)).ToString();
            else Output.Text = "NAPIŠI BROJKE BOKTE";  
            TEXTBOX.IsEnabled = false;
            TEXTBOX1.IsEnabled = false;
            await Task.Delay(3000);
            Output.Text = "STISNI NA STISNI";
            GUMB.IsEnabled = true;
        }
    }
}
