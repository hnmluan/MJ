using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField] List<string> localizationKeys;

    public List<string> LocalizationKeys { get => localizationKeys; }
}
