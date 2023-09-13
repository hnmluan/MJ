using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObject/Animal")]
public class AnimalDataSO : ScriptableObject
{
    public AnimalCode damageObjectCode = AnimalCode.NoAnimal;
    public Sprite visual;
    public Animator animator;
}