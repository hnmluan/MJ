using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    private bool submitPressed = true;

    void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    public static InputManager GetInstance() => instance;

    public bool StartInteract() => Input.GetKeyDown(KeyCode.I);

    public void RegisterInteractPressed() => submitPressed = !submitPressed;

    // public bool ContinueInteract() => Input.GetKeyDown(KeyCode.Space) && submitPressed;

    public bool ContinueInteract()
    {
        if (Input.GetKeyDown(KeyCode.Space) && submitPressed)
        {
            submitPressed = false;
            return false;
        }
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
    public virtual bool StartConversation() => false;
    public virtual bool CountinueConversation() => false;
    public virtual bool Close() => false;
}