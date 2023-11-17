using UnityEngine;

public class InitMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents() { }

    protected virtual void ResetValue() { }

    protected virtual void OnEnable() { }

    protected virtual void OnDisable() { }
}
