using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace pr_22._106_konuk_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Regex regex = new Regex(@"\W+");
                bool res = int.TryParse(tb1.Text, out var number);
                if (res == false)
                {
                    tb2.Clear();
                    string sentence = tb1.Text;
                    while (sentence.Contains("  "))
                    {
                        sentence = sentence.Replace("  ", " это_пробел ");
                    }
                    string[] words = sentence.Split();
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] != "это_пробел" && words[i] != "")
                        {
                            char[] let = words[i].ToCharArray();
                            let[0] = char.ToUpper(let[0]);
                            let[let.Length - 1] = char.ToUpper(let[let.Length - 1]);
                            words[i] = new string(let);
                        }
                        tb2.Text += words[i];
                    }
                }
                else
                { tb1.Text = "Введите строку!"; }
            }
            catch (Exception ex)
            {
                    tb1.Text = ex.Message;
            }
        }
    }
}
