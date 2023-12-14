using System;
using System.Collections.Generic;
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

    public List<Dialogue> dialogues = new List<Dialogue>();

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

    public static List<CharacterDataSO> GetAllSO() => new List<CharacterDataSO>(Resources.LoadAll<CharacterDataSO>("Character/ScriptableObject"));

    public TextAsset GetDialogueJSONOf(TaskInformation taskInformation)
    {
        foreach (Dialogue item in dialogues)
        {
            if (item.task.code == taskInformation.code && item.task.status == taskInformation.status) return item.dialogueJSON;
        }
        return null;
    }
}

[Serializable]
public class Dialogue
{
    public TaskInformation task;
    public TextAsset dialogueJSON;
}