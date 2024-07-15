using System;
using Gtk;

class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        // Window properties
        Window window = new Window("Otiosum");
        window.DeleteEvent += delegate { Application.Quit(); };
        window.SetDefaultSize(1280, 720);
        window.SetPosition(WindowPosition.Center);
        window.Resizable = false;

        // Create a Fixed container
        Fixed fixedContainer = new Fixed();

        // Create a button and set its size
        Button button = new Button("Click Me");
        button.SetSizeRequest(100, 50);
        button.Clicked += OnButtonClicked;

        // Put the button at position (50, 50)
        fixedContainer.Put(button, 50, 50);

        // Add the fixed container to the window
        window.Add(fixedContainer);

        window.ShowAll();
        Application.Run();
    }

    static void OnButtonClicked(object? sender, EventArgs e)
    {
        MessageDialog dialog = new MessageDialog(
            null,
            DialogFlags.Modal,
            MessageType.Info,
            ButtonsType.Ok,
            "Button was clicked!");
        dialog.Run();
        dialog.Destroy();
    }
}
