using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12.User_Controls.Models
{
    public class MenuOption
    {
        public MenuOption(string text, string url)
        {
            this.Text = text;
            this.Url = url;
        }

        public string Text { get; set; }

        public string Url { get; set; }

        public string FontColor { get; set; }
    }
}