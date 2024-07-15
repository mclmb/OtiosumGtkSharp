using Gtk;
using Newtonsoft.Json;


namespace Otiosum
{
    class GameLogic
    {
        public static void ButtonSaveGame(ProgressBar experienceBar)
        {
            SaveState saveState = new SaveState
            {
                PlayerState = new PlayerState
                {
                    Souls = 0.0,
                    Experience = Math.Round(experienceBar.Fraction, 2)
                }
            };

            string json = JsonConvert.SerializeObject(saveState, Formatting.Indented);
            File.WriteAllText("game_state.json", json);

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

        public static void ButtonHarvestSoul(ProgressBar experienceBar)
        {
            if (experienceBar.Fraction < 1.0)
            {
                experienceBar.Fraction += 0.01;
            }

            if (experienceBar.Fraction >= 0.999)
            {
                MessageDialog dialog = new MessageDialog(
                    null,
                    DialogFlags.Modal,
                    MessageType.Info,
                    ButtonsType.Ok,
                    "You leveled up!"
                );

                dialog.Run();
                dialog.Destroy();

                experienceBar.Fraction = 0.0;
            }
        }
    }
}
