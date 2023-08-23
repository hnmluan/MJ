using UnityEngine;

public class NPCAbstract : InitMonoBehaviour
{
    [SerializeField] protected NPCCtrl npcCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadNPCCtrl();
    }

    protected virtual void LoadNPCCtrl()
    {
        if (npcCtrl != null) return;
        npcCtrl = transform.parent.GetComponent<NPCCtrl>();
        Debug.Log(transform.name + ": LoadNPCCtrl", gameObject);
    }
}
