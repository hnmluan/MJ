using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuCtrl : InitMonoBehaviour
{
    private static UIMenuCtrl instance;
    public static UIMenuCtrl Instance { get => instance; }

    [SerializeField] protected Slider _musicSlider, _sfxSlider;

    [SerializeField] protected bool panelActive = false;

    [SerializeField] protected GameObject panelGuide;

    [SerializeField] protected GameObject panelPause;

    [SerializeField] protected GameObject panelSetting;

    public event Action OnShowSetting, OnHideSetting;

    protected override void Awake()
    {
        base.Awake();

        if (UIMenuCtrl.instance != null) Debug.LogError("Only 1 UIMenuCtrl allow to exist");

        UIMenuCtrl.instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) Toggle(panelGuide);

        if (Input.GetKeyDown(KeyCode.P)) Toggle(panelPause);

        if (Input.GetKeyDown(KeyCode.X)) Toggle(panelSetting);
    }

    public void Toggle(GameObject panel)
    {

        if (!panelActive)
        {
            OnShowSetting?.Invoke();
            panel.SetActive(true);
            Time.timeScale = 0f;
            panelActive = true;
        }
        else if (panelActive && panel.activeSelf)
        {
            OnHideSetting?.Invoke();
            panel.SetActive(false);
            Time.timeScale = 1f;
            panelActive = false;
        }

        AudioController.Instance.PlayVFX("sfx_button_press");
    }
}
