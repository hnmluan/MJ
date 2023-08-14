using System.Collections.Generic;
using UnityEngine;

public class Dictionary : InitMonoBehaviour
{
    private static Dictionary instance;
    public static Dictionary Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (Dictionary.instance != null) Debug.LogError("Only 1 Dictionary allow to exist");
        Dictionary.instance = this;
    }

    [SerializeField] List<DamageObjectSO> damageObjectSOsAvailableSeen;
    public List<DamageObjectSO> DamageObjectSOsAvailableSeen { get => damageObjectSOsAvailableSeen; }

    [SerializeField] List<DamageObjectSO> damageObjectSOsAvailableButNotSeen;
    public List<DamageObjectSO> DamageObjectSOsAvailableButNotSeen { get => damageObjectSOsAvailableButNotSeen; }

    [SerializeField] List<NPCProfileSO> npcSOsAvailableSeen;
    public List<NPCProfileSO> NpcsAvailableSeen { get => npcSOsAvailableSeen; }

    [SerializeField] List<NPCProfileSO> npcSOsAvailableButNotSeen;
    public List<NPCProfileSO> NpcsAvailableButNotSeen { get => npcSOsAvailableButNotSeen; }

    [SerializeField] List<EnemyProfileSO> enemySOsAvailableSeen;
    public List<EnemyProfileSO> EnemiesSOsAvailableSeen { get => enemySOsAvailableSeen; }

    [SerializeField] List<EnemyProfileSO> enemySOsAvailableButNotSeen;
    public List<EnemyProfileSO> EnemiesAvailableButNotSeen { get => enemySOsAvailableButNotSeen; }

    private void AddDictionary(DamageObjectSO damageObjectSO)
    {
        if (damageObjectSOsAvailableSeen.Contains(damageObjectSO) || damageObjectSOsAvailableButNotSeen.Contains(damageObjectSO)) return;
        damageObjectSOsAvailableButNotSeen.Add(damageObjectSO);
    }

    private void AddDictionary(NPCProfileSO npcProfileSO)
    {
        if (npcSOsAvailableSeen.Contains(npcProfileSO) || npcSOsAvailableButNotSeen.Contains(npcProfileSO)) return;
        npcSOsAvailableButNotSeen.Add(npcProfileSO);
    }

    private void AddDictionary(EnemyProfileSO enemyProfileSO)
    {
        if (enemySOsAvailableSeen.Contains(enemyProfileSO) || enemySOsAvailableButNotSeen.Contains(enemyProfileSO)) return;
        enemySOsAvailableButNotSeen.Add(enemyProfileSO);
    }

    public void AddDictionary(ScriptableObject profileSO)
    {
        if (profileSO is EnemyProfileSO) AddDictionary(profileSO as EnemyProfileSO);
        if (profileSO is NPCProfileSO) AddDictionary(profileSO as NPCProfileSO);
        if (profileSO is DamageObjectSO) AddDictionary(profileSO as DamageObjectSO);
    }

    private void SeenItemDictionary(EnemyProfileSO enemyProfileSO)
    {
        if (enemySOsAvailableButNotSeen.Contains(enemyProfileSO))
        {
            enemySOsAvailableSeen.Add(enemyProfileSO);
            enemySOsAvailableButNotSeen.Remove(enemyProfileSO);
        }
    }

    private void SeenItemDictionary(NPCProfileSO npcProfileSO)
    {
        if (npcSOsAvailableButNotSeen.Contains(npcProfileSO))
        {
            npcSOsAvailableSeen.Add(npcProfileSO);
            npcSOsAvailableButNotSeen.Remove(npcProfileSO);
        }
    }

    private void SeenItemDictionary(DamageObjectSO damageObjectSO)
    {
        if (damageObjectSOsAvailableButNotSeen.Contains(damageObjectSO))
        {
            DamageObjectSOsAvailableSeen.Add(damageObjectSO);
            damageObjectSOsAvailableButNotSeen.Remove(damageObjectSO);
        }
    }

    public void SeenItemDictionary(ScriptableObject profileSO)
    {
        if (profileSO is EnemyProfileSO) SeenItemDictionary(profileSO as EnemyProfileSO);
        if (profileSO is NPCProfileSO) SeenItemDictionary(profileSO as NPCProfileSO);
        if (profileSO is DamageObjectSO) SeenItemDictionary(profileSO as DamageObjectSO);
    }

    public bool CheckAvailableItemInDictonary(ScriptableObject profileSO)
        => damageObjectSOsAvailableSeen.Contains(profileSO as DamageObjectSO)
        || damageObjectSOsAvailableButNotSeen.Contains(profileSO as DamageObjectSO)
        || npcSOsAvailableSeen.Contains(profileSO as NPCProfileSO)
        || npcSOsAvailableButNotSeen.Contains(profileSO as NPCProfileSO)
        || enemySOsAvailableSeen.Contains(profileSO as EnemyProfileSO)
        || enemySOsAvailableButNotSeen.Contains(profileSO as EnemyProfileSO);

    public int GetNumberOfItemInNotSeen() =>
    Dictionary.Instance.EnemiesAvailableButNotSeen.Count
    + Dictionary.Instance.NpcsAvailableButNotSeen.Count
    + Dictionary.Instance.DamageObjectSOsAvailableButNotSeen.Count;
}
