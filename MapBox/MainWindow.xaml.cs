using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list = txtInput.Text.Split("\t\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => s.Replace(" ", ""));
            //txtOutput.Text = string.Join(Environment.NewLine, list);
            txtOutput.Text = string.Join(Environment.NewLine, list.GroupBy(i => i).OrderByDescending(g => g.Count()).ThenBy(g => g.Key).Select(g => (g.Key.Length < 4 ? g.Key + "\t" : g.Key) + "\t" + g.Count()));

        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = string.Join(Environment.NewLine, txtInput.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(s => string.Join("\t", s.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => { var r = i.Replace(" ", ""); return i.Length < 4 ? r + "\t" : r; }))));
            if (text != txtInput.Text)
                txtInput.Text = text;
        }
    }
}
