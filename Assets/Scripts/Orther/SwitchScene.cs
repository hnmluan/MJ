using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SwitchScene : InitMonoBehaviour
{
    protected BoxCollider2D boxCollider2D;

    public string loadToScence;

    public Vector3 loadToPositionOnSence;

    protected override void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene mới đã được tải!");
        PlayerCtrl.Instance.Movement.MoveToPoint(loadToPositionOnSence);
        CameraCtrl.Instance.CameraMovement.ResetPositionCamera();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadToScence);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider2D();
    }

    private void LoadCollider2D()
    {
        if (boxCollider2D != null) return;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider2D", gameObject);
    }
}
