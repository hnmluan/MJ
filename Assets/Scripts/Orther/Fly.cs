using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] protected int movespeed = 8;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void Update()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}