using UnityEngine;

public class CameraCtrl : Singleton<CameraCtrl>
{

    private static CameraCtrl instance;
    public static CameraCtrl Instance { get => instance; }


    [SerializeField] protected CameraMovement cameraMovement;
    public CameraMovement CameraMovement { get => cameraMovement; }

    protected override void Awake()
    {
        base.Awake();
        if (CameraCtrl.instance != null) Debug.Log("Only 1 CameraCtrl allow to exist");
        CameraCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCameraMovement();
    }

    private void LoadCameraMovement()
    {
        if (this.cameraMovement != null) return;
        this.cameraMovement = transform.GetComponentInChildren<CameraMovement>();
        Debug.Log(transform.name + ": LoadCameraMovement", gameObject);
    }
}
