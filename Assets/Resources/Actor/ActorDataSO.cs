using UnityEngine;

[CreateAssetMenu(fileName = "Actor", menuName = "ScriptableObject/Actor")]
public class ActorDataSO : ScriptableObject
{
    public ActorCode damageObjectCode = ActorCode.NoActor;
    public string keyName;
    public string keyDescription;
    public Sprite faceset;
    public Sprite sprite;
}