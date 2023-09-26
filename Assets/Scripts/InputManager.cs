using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public bool StartInteract() => Input.GetKeyDown(KeyCode.I);
    public bool ContinueInteract() => Input.GetKeyDown(KeyCode.Space);

    private bool submitPressed = false;

    public bool GetSubmitPressed()
    {
        if (submitPressed && Input.GetKeyDown(KeyCode.Space))
        {
            submitPressed = false;
            return false;
        };

        return Input.GetKeyDown(KeyCode.Space);
    }

    public void RegisterSubmitPressed() => submitPressed = true;

    public virtual bool OpenInventory() => false;
    public virtual bool OpenSetting() => false;
    public virtual bool OpenGuide() => false;
    public virtual bool OpenPause() => false;
    public virtual bool OpenArmory() => false;
    public virtual bool OpenDictionary() => false;
    public virtual bool OpenShop() => false;
    public virtual bool Close() => false;
}
