using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class DictionaryData
{
    public List<String> seenWeapons;
    public List<String> unseenWeapons;

    public List<String> seenNPCs;
    public List<String> unseenNPCs;

    public List<String> seenEnemies;
    public List<String> unseenEnemies;

    public DictionaryData(Dictionary dictionary)
    {
        this.seenEnemies = dictionary.SeenEnemies
            .Select(item => item.enemyCode.ToString()).ToList();
        this.unseenEnemies = dictionary.UnseenEnemies
            .Select(item => item.enemyCode.ToString()).ToList();

        this.seenWeapons = dictionary.SeenWeapons
            .Select(item => item.damageObjectCode.ToString()).ToList();
        this.unseenWeapons = dictionary.UnseenWeapons
            .Select(item => item.damageObjectCode.ToString()).ToList();

        this.seenNPCs = dictionary.SeenNPCs
            .Select(item => item.characterCode.ToString()).ToList();
        this.unseenNPCs = dictionary.UnseenNPCs
            .Select(item => item.characterCode.ToString()).ToList();
    }
}
