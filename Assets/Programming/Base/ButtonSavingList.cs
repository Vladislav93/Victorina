using System;

[Serializable]
public class ButtonSavingList
{
    public string ID;
    public int Need;

    public ButtonSavingList(string id, int arg1)
    {
        ID = id;
        Need = arg1;

    }
}
