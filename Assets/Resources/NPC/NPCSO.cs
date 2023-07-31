using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "SO/NPC")]
public class NPCSO : ScriptableObject
{
    public NPCCode damageObjectCode = NPCCode.NoNPC;

    public string npcName;

    public Sprite faceset;

    public NPCDialog npcDialog;
}