using UnityEngine;

public class test : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float circleRadius = 2f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Lấy Vector3 từ vị trí chuột trên màn hình
        Vector3 mousePosition = Input.mousePosition;

        // Gán giá trị Z cho vị trí chuột để xoay quanh trục Z
        mousePosition.z = -Camera.main.transform.position.z;

        // Chuyển đổi vị trí chuột từ màn hình sang không gian thế giới
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);

        // Tính vector hướng từ vũ khí đến vị trí chuột
        Vector3 direction = target - initialPosition;

        // Lấy góc xoay quanh trục Z từ vector hướng
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Tạo Quaternion mới để xoay vũ khí
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Di chuyển vũ khí trên hình tròn
        Vector3 circularPosition = initialPosition + Quaternion.Euler(0, 0, angle) * Vector3.right * circleRadius;
        transform.position = circularPosition;
    }
}
