using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.parent.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
    }
}
