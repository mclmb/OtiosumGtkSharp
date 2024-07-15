using Gtk;
using Newtonsoft.Json;


namespace Otiosum
{
    class GameLogic
    {
        private static int level = 1;
        private static int souls = 0;
        private static double soulsPerMinute = 0;

        public static void ButtonSaveGame(ProgressBar experienceBar)
        {
            SaveState saveState = new SaveState
            {
                PlayerState = new PlayerState
                {
                    Experience = Math.Round(experienceBar.Fraction, 2),
                    Level = level,
                    Souls = souls,
                    SoulsPerMinute = soulsPerMinute
                }
            };

            string json = JsonConvert.SerializeObject(saveState, Formatting.Indented);
            File.WriteAllText("gameData.json", json);

            MessageDialog dialog = new MessageDialog(
                null,
                DialogFlags.Modal,
                MessageType.Info,
                ButtonsType.Ok,
                "Game saved successfully!");
            dialog.Run();
            dialog.Destroy();
        }


        public static void ButtonExitGame(object? sender, System.EventArgs e)
        {
            MessageDialog dialog = new MessageDialog(
                null,
                DialogFlags.Modal,
                MessageType.Info,
                ButtonsType.YesNo,
                "Do you want to quit and save the game?"
            );

            dialog.Response += (o, args) =>
            {
                if (args.ResponseId == ResponseType.Yes)
                {
                    Application.Quit();
                }
                else
                {
                    dialog.Destroy();
                }
            };

            dialog.Run();
            dialog.Destroy();
        }

        public static void ButtonHarvestSoul(ProgressBar experienceBar, Entry soulsEntry, Entry spmEntry, Entry levelEntry)
        {
            // Increase experience bar by 0.1
            if (experienceBar.Fraction < 1.0)
            {
                experienceBar.Fraction += 0.1;
            }
            else
            {
                // Level up when experience bar is full
                experienceBar.Fraction = 0.0;
                level++;
                levelEntry.Text = level.ToString();
            }

            // Update souls and souls per minute
            souls += 10;
            soulsPerMinute += 0.5; // Example value for souls per minute

            // Update the Entry widgets
            soulsEntry.Text = souls.ToString();
            spmEntry.Text = soulsPerMinute.ToString("F2");
        }
    }
}
