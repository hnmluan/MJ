using UnityEngine;

public class CameraAbstract : InitMonoBehaviour
{
    [SerializeField] protected CameraCtrl cameraCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCameraCtrl();
    }

    protected virtual void LoadCameraCtrl()
    {
        if (cameraCtrl != null) return;
        cameraCtrl = transform.parent.GetComponent<CameraCtrl>();
        Debug.Log(transform.name + ": LoadCameraCtrl", gameObject);
    }
}
