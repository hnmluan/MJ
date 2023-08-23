using UnityEngine;

public class CameraMovement : CameraAbstract
{
    [SerializeField] private Transform tagert;

    public float speed = 1f;

    float map_height = 6f;
    float map_wight = 10.5f;

    public int map_x;
    public int map_y;

    public Vector3 cameraPosition;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected override void Start() => ResetPositionCamera();

    protected virtual void LoadPlayer()
    {
        if (this.tagert != null) return;
        tagert = GameObject.Find("Player").gameObject.transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    private void FixedUpdate()
    {
        computeCameraPosition();
        transform.parent.position = Vector3.Lerp(transform.parent.position, cameraPosition, Time.deltaTime * speed);
    }

    void computeMapCoordinateFromPlayerPosition()
    {
        int x = (int)(Mathf.Sign(tagert.position.x)) * Mathf.CeilToInt(Mathf.Abs(Mathf.Abs(tagert.position.x) - map_wight) / (2 * map_wight));
        int y = (int)(Mathf.Sign(tagert.position.y)) * Mathf.CeilToInt(Mathf.Abs(Mathf.Abs(tagert.position.y) - map_height) / (2 * map_height));

        map_x = Mathf.Abs(tagert.position.x) < map_wight ? 0 : x;
        map_y = Mathf.Abs(tagert.position.y) < map_height ? 0 : y;
    }

    void computeCameraPosition()
    {
        computeMapCoordinateFromPlayerPosition();
        cameraPosition = new Vector3(map_x * map_wight * 2, map_y * map_height * 2, transform.parent.position.z);
    }

    public void ResetPositionCamera()
    {
        computeCameraPosition();
        transform.parent.position = cameraPosition;
    }
}
