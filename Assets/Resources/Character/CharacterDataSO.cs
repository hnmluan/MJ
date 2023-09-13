using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObject/Character")]
public class CharacterDataSO : ScriptableObject
{
    public CharacterCode damageObjectCode = CharacterCode.NoActor;
    public string keyName;
    public string keyDescription;
    public Sprite portrait;
    public Sprite visual;
    public Animator animator;
}