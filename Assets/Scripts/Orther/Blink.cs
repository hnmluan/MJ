using UnityEngine;

public class Blink : InitMonoBehaviour
{
    public float toggleInterval;

    [SerializeField] private bool isToggled = false;

    [SerializeField] private float timer = 0f;

    [SerializeField] private Renderer model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRainOnFloor();
    }

    private void LoadRainOnFloor()
    {
        if (this.model != null) return;
        model = transform.parent.GetComponentInChildren<Renderer>();
        Debug.Log(transform.name + ": LoadRainOnFloor", gameObject);

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= toggleInterval)
        {
            isToggled = !isToggled;
            model.enabled = isToggled;
            timer = 0f;
        }
    }
}
