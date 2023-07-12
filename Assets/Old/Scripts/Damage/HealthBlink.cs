using System.Collections;
using UnityEngine;

public class HealthBlink : MonoBehaviour
{
    [SerializeField] protected int blinkCount = 3;

    [SerializeField] protected float blinkDuration = 0.1f;

    [SerializeField] protected float blinkInterval = 0.1f;

    public void StartBinkCoroutine(SpriteRenderer spriteRenderer)
    {
        StartCoroutine(Bink(spriteRenderer));
    }

    private IEnumerator Bink(SpriteRenderer spriteRenderer)
    {
        for (int i = 0; i < blinkCount; i++)
        {
            spriteRenderer.enabled = true;

            yield return new WaitForSeconds(blinkDuration);

            spriteRenderer.enabled = false;

            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.enabled = true;
    }
}
