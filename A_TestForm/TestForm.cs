using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using A_TestForm.Properties;
using Gecko;

namespace A_TestForm
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            Xpcom.Initialize("C:\\xulrunner");

            webBrowser.Navigate("http://www.trophymanager.com/players/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeckoElement scriptEl = webBrowser.Document.CreateElement("script");

            const string javascript =
                @"
                    function get_players()
                    {
                        strout = 'no data';
                        try
                        {
                            strout += ';clubname = ' + this.screenX;

                            if (players_ar == null)
                                return 'Javascript error: players_ar is null';
                            else
                                return players_ar[0]['fp'];
                        }
                        catch (err)
                        {
                            strout += ';Javascript error = ' + err;
                        }

                        return strout;
                    }                    
                    ";

            const string javascript2 =

            @"
                    function getGlobalProperties(prefix) 
                    {
                        var keyValues = []; // window for browser environments
                        for (var prop in this)
                        {
                        if (prop.indexOf(prefix) == 0) // check the prefix
                        keyValues.push(prop + "" = "" + this[prop]);
                        }
                        return keyValues.join('&'); // build the string
                    }
                    function test()
                    {
                        strout = 'no data';
                        try
                        {
                            strout += getGlobalProperties('');
                        }
                        catch (err)
                        {
                            strout += ';Javascript error = ' + err;
                        }

                        return strout;
                    }
                    test();
                    ";

            scriptEl.TextContent = javascript;

            var head = webBrowser.Document.GetElementsByTagName("head").First();
            head.AppendChild(scriptEl);

            // AutoJSContext java = new Gecko.AutoJSContext(webBrowser.Window.JSContext);
            AutoJSContext java = new Gecko.AutoJSContext();

            string outString;

            if (java.EvaluateScript(javascript2, out outString))
            {
                MessageBox.Show(outString);
            }

        }
    }
}
                //if (java.EvaluateScript(javascript, out result))



                //GeckoElement scriptEl = webBrowser.Document.CreateElement("script");

                //scriptEl.TextContent = Resources.players_loader;

                //webBrowser.Document.GetElementsByTagName("head").First().AppendChild(scriptEl);

                //string outString;
                //using (AutoJSContext java = new Gecko.AutoJSContext(webBrowser.Window.JSContext))
                //{
                //    if (java.EvaluateScript("get_players()", (nsISupports)webBrowser.Window.DomWindow, out outString))
                //    {
                //        MessageBox.Show(outString);
                //    }
                //}
