using Gtk;

namespace Otiosum
{
    class GameLogic
    {
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
