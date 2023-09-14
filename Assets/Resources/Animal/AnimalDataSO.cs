using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObject/Animal")]
public class AnimalDataSO : ScriptableObject
{
    public AnimalCode animalCode = AnimalCode.NoAnimal;

    public Sprite visual;

    public Sprite portrait;

    public RuntimeAnimatorController animator;

    public String soudName;

    public static AnimalDataSO FindByItemCode(AnimalCode animalCode)
    {
        var datas = Resources.LoadAll("Animal/ScriptableObject", typeof(AnimalDataSO));

        foreach (AnimalDataSO data in datas)
        {
            if (data.animalCode != animalCode) continue;
            return data;
        }

        return null;
    }

    public static AnimalDataSO FindByName(string name)
    {
        AnimalCode animalCode;
        Enum.TryParse(name, out animalCode);
        return FindByItemCode(animalCode);
    }
}