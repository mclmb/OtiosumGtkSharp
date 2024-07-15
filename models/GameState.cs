namespace Otiosum
{
    public class SaveState
    {
        public PlayerState PlayerState { get; set; }
    }
    public class PlayerState
    {
        public double Experience { get; set; }
        public int Level { get; set; }
        public int Souls { get; set; }
        public double SoulsPerMinute { get; set; }
    }

}
