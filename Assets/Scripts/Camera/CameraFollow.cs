using UnityEngine;

public class CameraFollow : InitMonoBehaviour
{
    [SerializeField] private Transform tagert;

    [SerializeField] private Transform cam;

    public float speed = 1f;

    float map_height = 6f;
    float map_wight = 10.5f;

    public int map_x;
    public int map_y;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        this.LoadCamera();
    }

    protected virtual void LoadPlayer()
    {
        if (this.tagert != null) return;
        tagert = GameObject.Find("Player").gameObject.transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected virtual void LoadCamera()
    {
        if (this.cam != null) return;
        cam = GameObject.Find("Main Camera").gameObject.transform;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    private void FixedUpdate()
    {
        map_x = Mathf.Abs(tagert.position.x) < map_wight ? 0 : Rouned((tagert.position.x > 0 ? tagert.position.x + map_wight / (2 * map_wight) : tagert.position.x - map_wight) / (2 * map_wight));
        map_y = Mathf.Abs(tagert.position.y) < map_height ? 0 : Rouned((tagert.position.y > 0 ? tagert.position.y + map_height / (2 * map_wight) : tagert.position.y - map_height) / (2 * map_height));

        cam.transform.position = Vector3.Lerp(
            cam.transform.position,
            new Vector3(
                map_x * map_wight * 2,
                map_y * map_height * 2,
                cam.transform.position.z),
            Time.deltaTime * speed);
    }

    private int Rouned(float number) => number > 0 ? Mathf.CeilToInt(number) : Mathf.FloorToInt(number) + 1;


}
