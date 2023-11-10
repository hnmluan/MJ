using System;
using UnityEngine;

public enum CharacterCode
{
    NoActor,
    AuCo,
    Doi,
    Gam,
    King,
    LacLongQuan,
    Lua,
    MissCam,
    MissTam,
    MrsKim,
    MrTinh,
    MrVe,
    RichMan,
    SonTinh,
    Tam,
    Teo,
    ThuyTinh,
    VillageElder,
    MorthersTam,
    Ty,
}

public class CharacterCodeParser
{
    public static CharacterCode FromString(string npcCode)
    {
        try
        {
            return (CharacterCode)System.Enum.Parse(typeof(CharacterCode), npcCode);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return CharacterCode.NoActor;
        }
    }
}

