using UnityEngine;

public class Fly : InitMonoBehaviour
{
    [SerializeField] protected float movespeed = 8;
    protected Vector3 direction = Vector3.right;

    void Update() => transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
}