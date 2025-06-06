using System;

[System.Serializable]
public class SaveState
{
    [NonSerialized] private const int HAT_COUNT = 12;
    public int Highscore {  get; set; } 
    public int Fish {  get; set; }
    public DateTime LastSaveTime { get; set; }
    public int CurrentHatIndex { get; set; }
    public byte[] UnlockedHatFlag { get; set; }
    public SaveState()
    {
        Highscore = 0;
        Fish = 10;
        LastSaveTime = DateTime.Now;
        CurrentHatIndex = 0;
        UnlockedHatFlag = new byte[HAT_COUNT];
        UnlockedHatFlag[0] = 1;
    }
}
