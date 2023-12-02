using System.Collections.Generic;
using UnityEngine;

public class DropdownResolutions : BaseDropdown
{
    Resolution[] resolutions;

    protected override void OnEnable()
    {
        resolutions = Screen.resolutions;

        dropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    protected override void OnChanged(int option)
    {
        Resolution resolution = resolutions[option];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
