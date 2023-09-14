using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObject/Character")]
public class CharacterDataSO : ScriptableObject
{
    public CharacterCode characterCode = CharacterCode.NoActor;

    public string keyName;

    public string keyDescription;

    public Sprite portrait;

    public Sprite visual;

    public RuntimeAnimatorController animator;

    public static CharacterDataSO FindByItemCode(CharacterCode characterCode)
    {
        var datas = Resources.LoadAll("Character/ScriptableObject", typeof(CharacterDataSO));
        foreach (CharacterDataSO data in datas)
        {
            if (data.characterCode != characterCode) continue;
            return data;
        }
        return null;
    }

    public static CharacterDataSO FindByName(string name)
    {
        CharacterCode characterCode;
        Enum.TryParse(name, out characterCode);
        return FindByItemCode(characterCode);
    }
}