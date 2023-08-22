using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AshenSoftware.Helpers
{
    public class AshenSoftwareHelpers : MonoBehaviour
    {
        public static IEnumerator FlashRoutine(SpriteRenderer spriteRenderer, Material flashMaterial, Material originalMaterial, Coroutine flashRoutine, float duration)
        {
            spriteRenderer.material = flashMaterial;

            yield return new WaitForSeconds(duration);

            spriteRenderer.material = originalMaterial;

            flashRoutine = null;
        }
    }
}