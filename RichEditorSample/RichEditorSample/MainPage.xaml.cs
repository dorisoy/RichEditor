using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RichEditor.Shared;
using Xamarin.Forms;

namespace RichEditorSample
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var mSource = new HtmlWebViewSource
            {
                Html = @"<html><body><h1>Test Code</h1><p>The code is working.</p></body></html>"
            };
            webview.Source = mSource;
        }

        private async void Webview_Focused(object sender, FocusEventArgs e)
        {
            var texto = await CrossRichEditor.Current.ShowAsync("Começe por aqui");
            if (texto.IsSave)
            {
                var html2 = $"<html><body>{texto.Html}</body></html>";
                //HtmlLabel.Text = html2;
                var mSource = new HtmlWebViewSource
                {
                    Html = html2
                };
                webview.Source = mSource;
            }
            webview.Unfocus();
        }
    }
}