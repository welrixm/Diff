using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DifPlaksin.Components
{
    class Navigation
    {
        public static MainWindow main;
        public static User user = null;
        public static bool isAuth = false;
        public static List<Nav> navs = new List<Nav>();

        public static void NextPage(Nav nav)
        {
            navs.Add(nav);
            Update(nav);
        }
        private static void Update(Nav nav)
        {
            main.TitlePage.Text = nav.Title;
            main.MyFrame.Navigate(nav.Page);
        }
        public static void BackPage()
        {
            if (navs.Count > 1)
                navs.RemoveAt(navs.Count - 1);
            Update(navs[navs.Count - 1]);
        }
        
    }
    
    class Nav
    {
        public string Title { get; set; }
        public Page Page { get; set; }
        public Nav(string title, Page page)
        {
            Title = title;
            Page = page;
        }
    }
       
        

}
