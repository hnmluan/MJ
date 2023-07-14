using UnityEngine;

public class RainDropMove : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.parent.Translate(new Vector2(-1, -1) * speed * Time.deltaTime);
    }
}
