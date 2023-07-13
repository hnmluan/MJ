using UnityEngine;

public class CameraFollow : InitMonoBehaviour
{
    [SerializeField] private Transform tagert;
    public float speed = 1f;
    [SerializeField] private Transform cam;
    private float t = 0f;

    float hight = 6f;

    float wight = 10.5f;

    public int map_x;
    public int map_y;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        tagert = GameObject.Find("PlayerConverse").gameObject.transform;
    }

    private void FixedUpdate()
    {
        t += Time.deltaTime * speed;

        map_x = Mathf.Abs(tagert.position.x) < wight ? 0 : Rouned((tagert.position.x > 0 ? tagert.position.x + wight / (2 * wight) : tagert.position.x - wight) / (2 * wight));
        map_y = Mathf.Abs(tagert.position.y) < hight ? 0 : Rouned((tagert.position.y > 0 ? tagert.position.y + hight / (2 * wight) : tagert.position.y - hight) / (2 * hight));



        cam.transform.position = Vector3.Lerp(
            cam.transform.position,
            new Vector3(
                map_x * wight * 2,
                map_y * hight * 2,
                cam.transform.position.z),
            t);
        //Debug.Log("tagert.position.x" + tagert.position.x);
        //Debug.Log("round = " + Rouned((tagert.position.x - wight) / (2 * wight)));

    }

    private int Rouned(float number)
    {
        return number > 0 ? Mathf.CeilToInt(number) : Mathf.FloorToInt(number) + 1;
    }


}
