using UnityEngine;

public class CameraCtrl : Singleton<CameraCtrl>
{

    [SerializeField] protected CameraMovement cameraMovement;
    public CameraMovement CameraMovement { get => cameraMovement; }

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
