using A_TestForm.Properties;
using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A_TestForm
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize("c:\\xulrunner");
            geckoWebBrowser.Navigate("http://www.trophymanager.com/players/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeckoElement scriptEl = geckoWebBrowser.Document.CreateElement("script");

            scriptEl.TextContent = Resources.players_loader;
            GeckoNode res = geckoWebBrowser.Document.Head.AppendChild(scriptEl);

            using (var java = new AutoJSContext(geckoWebBrowser.Window.JSContext))
            {
                JsVal result = java.EvaluateScript("get_players()", geckoWebBrowser.Window.DomWindow);
                MessageBox.Show(result.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GeckoElement scriptEl = geckoWebBrowser.Document.CreateElement("script");

            scriptEl.TextContent = Resources.RatingR2_user;
            GeckoNode res = geckoWebBrowser.Document.Head.AppendChild(scriptEl);

            using (var java = new AutoJSContext(geckoWebBrowser.Window.JSContext))
            {
                JsVal result = java.EvaluateScript("ApplyRatingR2()", geckoWebBrowser.Window.DomWindow);
                MessageBox.Show(result.ToString());
            }
        }
    }
}
