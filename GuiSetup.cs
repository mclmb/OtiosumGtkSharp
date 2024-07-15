using Gtk;

namespace Otiosum
{
    class GuiSetup
    {
        public static void SetupWindow(Window window)
        {
            window.DeleteEvent += delegate { Application.Quit(); };
            window.SetDefaultSize(1280, 720);
            window.SetPosition(WindowPosition.Center);
            window.Resizable = false;

            // Create a Fixed container
            Fixed fixedContainer = new Fixed();

            // Buttons
            Button buttonSaveGame = new Button("Save Game");
            buttonSaveGame.SetSizeRequest(100, 50);
            buttonSaveGame.Clicked += OnButtonClicked;
            fixedContainer.Put(buttonSaveGame, 220, 10);

            Button buttonFullStats = new Button("Statistics");
            buttonFullStats.SetSizeRequest(100, 50);
            buttonFullStats.Clicked += OnButtonClicked;
            fixedContainer.Put(buttonFullStats, 330, 10);

            Button buttonSettings = new Button("Settings");
            buttonSettings.SetSizeRequest(100, 50);
            buttonSettings.Clicked += OnButtonClicked;
            fixedContainer.Put(buttonSettings, 440, 10);

            Button buttonSaveAndExit = new Button("Save & Exit");
            var styleSaveAndExit = new CssProvider();
            styleSaveAndExit.LoadFromData("button { background-color: #ff0000; color: #ffffff; } button:hover { background-color: #ff6666; }");
            buttonSaveAndExit.StyleContext.AddProvider(styleSaveAndExit, uint.MaxValue);
            buttonSaveAndExit.SetSizeRequest(100, 50);
            buttonSaveAndExit.Clicked += OnButtonClicked;
            fixedContainer.Put(buttonSaveAndExit, 1160, 10);


            // Images
            Image image = new Image("./assets/dummyAvatar.png");
            fixedContainer.Put(image, 10, 10);

            // Add the fixed container to the window
            window.Add(fixedContainer);
        }

        private static void OnButtonClicked(object? sender, EventArgs e)
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
}
