using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    public virtual bool OpenInventory() => Input.GetKeyDown(KeyCode.I);
    public virtual bool OpenSetting() => Input.GetKeyDown(KeyCode.K);
    public virtual bool OpenGuide() => Input.GetKeyDown(KeyCode.G);
    public virtual bool OpenPause() => Input.GetKeyDown(KeyCode.P);
    public virtual bool OpenArmory() => Input.GetKeyDown(KeyCode.M);
    public virtual bool OpenDictionary() => Input.GetKeyDown(KeyCode.L);
    public virtual bool OpenShop() => Input.GetKeyDown(KeyCode.H);
    public virtual bool InteractDialogue() => Input.GetKeyDown(KeyCode.Z);
    public virtual bool StartConversation() => Input.GetKeyDown(KeyCode.Z);
    public virtual bool Close() => Input.GetKeyDown(KeyCode.Escape);
}
