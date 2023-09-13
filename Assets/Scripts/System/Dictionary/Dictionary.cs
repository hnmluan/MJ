using System.Collections.Generic;
using UnityEngine;

public class Dictionary : Singleton<Dictionary>
{
    [SerializeField] protected List<IActionDictionaryObserver> observers = new List<IActionDictionaryObserver>();

    [SerializeField] List<WeaponDataSO> damageObjectSOsAvailableSeen;
    public List<WeaponDataSO> DamageObjectSOsAvailableSeen { get => damageObjectSOsAvailableSeen; }

    [SerializeField] List<WeaponDataSO> damageObjectSOsAvailableButNotSeen;
    public List<WeaponDataSO> DamageObjectSOsAvailableButNotSeen { get => damageObjectSOsAvailableButNotSeen; }

    [SerializeField] List<CharacterDataSO> npcSOsAvailableSeen;
    public List<CharacterDataSO> NpcsAvailableSeen { get => npcSOsAvailableSeen; }

    [SerializeField] List<CharacterDataSO> npcSOsAvailableButNotSeen;
    public List<CharacterDataSO> NpcsAvailableButNotSeen { get => npcSOsAvailableButNotSeen; }

    [SerializeField] List<EnemyDataSO> enemySOsAvailableSeen;
    public List<EnemyDataSO> EnemiesSOsAvailableSeen { get => enemySOsAvailableSeen; }

    [SerializeField] List<EnemyDataSO> enemySOsAvailableButNotSeen;
    public List<EnemyDataSO> EnemiesAvailableButNotSeen { get => enemySOsAvailableButNotSeen; }

    private void AddDictionary(WeaponDataSO damageObjectSO)
    {
        if (damageObjectSOsAvailableSeen.Contains(damageObjectSO) || damageObjectSOsAvailableButNotSeen.Contains(damageObjectSO)) return;
        damageObjectSOsAvailableButNotSeen.Add(damageObjectSO);
    }

    private void AddDictionary(CharacterDataSO npcProfileSO)
    {
        if (npcSOsAvailableSeen.Contains(npcProfileSO) || npcSOsAvailableButNotSeen.Contains(npcProfileSO)) return;
        npcSOsAvailableButNotSeen.Add(npcProfileSO);
    }

    private void AddDictionary(EnemyDataSO enemyProfileSO)
    {
        if (enemySOsAvailableSeen.Contains(enemyProfileSO) || enemySOsAvailableButNotSeen.Contains(enemyProfileSO)) return;
        enemySOsAvailableButNotSeen.Add(enemyProfileSO);
    }

    public void AddDictionary(ScriptableObject profileSO)
    {
        if (profileSO is EnemyDataSO) AddDictionary(profileSO as EnemyDataSO);
        if (profileSO is CharacterDataSO) AddDictionary(profileSO as CharacterDataSO);
        if (profileSO is WeaponDataSO) AddDictionary(profileSO as WeaponDataSO);
        OnAddItem();
    }

    private void SeenItemDictionary(EnemyDataSO enemyProfileSO)
    {
        if (enemySOsAvailableButNotSeen.Contains(enemyProfileSO))
        {
            enemySOsAvailableSeen.Add(enemyProfileSO);
            enemySOsAvailableButNotSeen.Remove(enemyProfileSO);
        }
    }

    private void SeenItemDictionary(CharacterDataSO npcProfileSO)
    {
        if (npcSOsAvailableButNotSeen.Contains(npcProfileSO))
        {
            npcSOsAvailableSeen.Add(npcProfileSO);
            npcSOsAvailableButNotSeen.Remove(npcProfileSO);
        }
    }

    private void SeenItemDictionary(WeaponDataSO damageObjectSO)
    {
        if (damageObjectSOsAvailableButNotSeen.Contains(damageObjectSO))
        {
            DamageObjectSOsAvailableSeen.Add(damageObjectSO);
            damageObjectSOsAvailableButNotSeen.Remove(damageObjectSO);
        }
    }

    public void SeenItemDictionary(ScriptableObject profileSO)
    {
        if (profileSO is EnemyDataSO) SeenItemDictionary(profileSO as EnemyDataSO);
        if (profileSO is CharacterDataSO) SeenItemDictionary(profileSO as CharacterDataSO);
        if (profileSO is WeaponDataSO) SeenItemDictionary(profileSO as WeaponDataSO);
        this.OnAddItem();
    }

    public bool CheckAvailableItemInDictonary(ScriptableObject profileSO)
        => damageObjectSOsAvailableSeen.Contains(profileSO as WeaponDataSO)
        || damageObjectSOsAvailableButNotSeen.Contains(profileSO as WeaponDataSO)
        || npcSOsAvailableSeen.Contains(profileSO as CharacterDataSO)
        || npcSOsAvailableButNotSeen.Contains(profileSO as CharacterDataSO)
        || enemySOsAvailableSeen.Contains(profileSO as EnemyDataSO)
        || enemySOsAvailableButNotSeen.Contains(profileSO as EnemyDataSO);

    public int GetNumberOfItemInNotSeen() =>
    Dictionary.Instance.EnemiesAvailableButNotSeen.Count
    + Dictionary.Instance.NpcsAvailableButNotSeen.Count
    + Dictionary.Instance.DamageObjectSOsAvailableButNotSeen.Count;

    public int GetNumberOfNpcsInNotSeen() => Dictionary.Instance.NpcsAvailableButNotSeen.Count;

    public int GetNumberOfEnemiesInNotSeen() => Dictionary.Instance.enemySOsAvailableButNotSeen.Count;

    public int GetNumberOfWeaponsInNotSeen() => Dictionary.Instance.damageObjectSOsAvailableButNotSeen.Count;

    public virtual void AddObserver(IActionDictionaryObserver observer) => this.observers.Add(observer);

    protected virtual void OnAddItem()
    {
        foreach (IActionDictionaryObserver observer in this.observers) observer.OnAddItem();
    }

    protected virtual void OnDeductItem()
    {
        foreach (IActionDictionaryObserver observer in this.observers) observer.OnSeenItem();
    }
}
