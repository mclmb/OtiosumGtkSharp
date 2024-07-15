using System;
using Gtk;

namespace Otiosum
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            Window window = new Window("Otiosum");
            GuiSetup.SetupWindow(window);

            window.ShowAll();
            Application.Run();
        }
    }
}
