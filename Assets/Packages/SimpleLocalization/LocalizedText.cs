using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization
{
    /// <summary>
    /// Localize text component.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        public string LocalizationKey;

        public virtual void Start()
        {
            Localize();
            LocalizationManager.LocalizationChanged += Localize;
        }

        public void OnDestroy()
        {
            LocalizationManager.LocalizationChanged -= Localize;
        }

        protected virtual void Localize()
        {
            GetComponent<Text>().text = LocalizationManager.Localize(LocalizationKey);
        }
    }
}