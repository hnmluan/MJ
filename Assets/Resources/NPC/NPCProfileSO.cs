using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "SO/NPC")]
public class NPCProfileSO : ScriptableObject
{
    public NPCCode damageObjectCode = NPCCode.NoNPC;
    public string keyName;
    public string keyDescription;
    public Sprite faceset;
    public Sprite sprite;
    public Dialog npcDialog;
    [field: SerializeReference] public List<NPCComponent> components;

    public void AddData(NPCComponent data)
    {
        if (components.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        components.Add(data);
    }
}