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

            // Create a CSS provider
            var cssProvider = new CssProvider();
            cssProvider.LoadFromData(
                "button { background-color: #ff0000; color: #ffffff; }" +
                "button:hover { background-color: #ff6666; }"
            );

            // Create a Fixed container
            Fixed fixedContainer = new Fixed();

            // Images
            Image image = new Image("./assets/dummyAvatar.png");
            fixedContainer.Put(image, 10, 10);

            // Experience bar
            ProgressBar experienceBar = new ProgressBar();
            experienceBar.Fraction = 0.0;
            experienceBar.SetSizeRequest(1280, 20);
            experienceBar.StyleContext.AddProvider(cssProvider, uint.MaxValue);
            fixedContainer.Put(experienceBar, 0, 700);

            // Top bar buttons
            Button buttonSaveGame = new Button("Save Game");
            buttonSaveGame.SetSizeRequest(100, 50);
            buttonSaveGame.Clicked += (sender, e) => GameLogic.ButtonSaveGame(experienceBar);
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
            buttonSaveAndExit.StyleContext.AddProvider(cssProvider, uint.MaxValue);
            buttonSaveAndExit.SetSizeRequest(100, 50);
            buttonSaveAndExit.Clicked += GameLogic.ButtonExitGame;
            fixedContainer.Put(buttonSaveAndExit, 1160, 10);

            // Bottom bar buttons
            Button buttonClicker = new Button("Harvest Soul");
            buttonClicker.SetSizeRequest(1040, 80);
            buttonClicker.Clicked += (sender, e) => GameLogic.ButtonHarvestSoul(experienceBar);
            fixedContainer.Put(buttonClicker, 220, 620);


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
