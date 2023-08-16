using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "SO/NPC")]
public class NPCProfileSO : ScriptableObject
{
    public NPCCode damageObjectCode = NPCCode.NoNPC;
    public string keyName;
    public string keyDescription;
    public Sprite faceset;
    public Sprite sprite;
    public NPCDialog npcDialog;
}