using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class DictionaryData
{
    public List<String> weaponSOsAvailSeen;
    public List<String> weaponSOsAvailNotSeen;

    public List<String> npcSOsAvailSeen;
    public List<String> npcSOsAvailNotSeen;

    public List<String> enemySOsAvailSeen;
    public List<String> enemySOsAvailNotSeen;

    public DictionaryData(Dictionary dictionary)
    {
        this.enemySOsAvailSeen = dictionary.EnemySOsAvailSeen
            .Select(item => item.enemyCode.ToString()).ToList();
        this.enemySOsAvailNotSeen = dictionary.EnemySOsAvailNotSeen
            .Select(item => item.enemyCode.ToString()).ToList();

        this.weaponSOsAvailSeen = dictionary.WeaponSOsAvailSeen
            .Select(item => item.damageObjectCode.ToString()).ToList();
        this.weaponSOsAvailNotSeen = dictionary.WeaponSOsAvailNotSeen
            .Select(item => item.damageObjectCode.ToString()).ToList();

        this.npcSOsAvailSeen = dictionary.NpcSOsAvailSeen
            .Select(item => item.characterCode.ToString()).ToList();
        this.npcSOsAvailNotSeen = dictionary.NpcSOsAvailNotSeen
            .Select(item => item.characterCode.ToString()).ToList();
    }
}
