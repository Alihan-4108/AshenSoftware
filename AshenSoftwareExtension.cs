using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AshenSoftware.Helpers;

namespace AshenSoftware.Extension
{
    public static class AshenSoftwareExtension
    {
        #region Normal Debug
        public static void Debug(this object obj)
        {
            UnityEngine.Debug.Log(obj);
        }

        public static void Debug(this Object obj)
        {
            UnityEngine.Debug.Log(obj, obj);
        }
        #endregion

        #region Warning Debug
        public static void DebugWarning(this object obj)
        {
            UnityEngine.Debug.LogWarning(obj);
        }

        public static void DebugWarning(this Object obj)
        {
            UnityEngine.Debug.LogWarning(obj, obj);
        }
        #endregion

        #region Error Debug
        public static void DebugError(this object obj)
        {
            UnityEngine.Debug.LogError(obj);
        }

        public static void DebugError(this Object obj)
        {
            UnityEngine.Debug.LogError(obj, obj);
        }
        #endregion

        #region SetActiveCollider
        public static void SetActiveCollider(this Collider2D collider, bool isActive)
        {
            collider.enabled = isActive;
        }
        #endregion

        #region SetActiveSprite
        public static void SetActiveSprite(this SpriteRenderer sprite, bool isActive)
        {
            sprite.enabled = isActive;
        }
        #endregion

        #region SetActiveColliderAndSprite
        public static void SetActiveColliderAndSprite(this GameObject gameObject, bool isActive)
        {
            gameObject.GetComponent<Collider2D>().enabled = isActive;
            gameObject.GetComponent<SpriteRenderer>().enabled = isActive;
        }
        #endregion

        #region FindChildByName
        public static Transform FindChildByName(this GameObject parent, string name)
        {
            Transform[] children = parent.GetComponentsInChildren<Transform>(true);

            for (int i = 0; i < children.Length; i++)
            {
                Transform child = children[i];

                if (child.name == name)
                {
                    return child;
                }
            }
            return null;
        }
        #endregion

        #region DoMusicSoundReduction
        public static Tween DoMusicSoundReduction(this AudioSource music, float endValue, float duration)
        {
            return DOTween.To(() => music.volume, x => music.volume = x, endValue, duration);
        }
        #endregion

        #region CameraShake
        public static void CameraShake(this Camera mainCamera, float duration = 0.1f, float strength = 0.15f, int vibrato = 2, float randomness = 5, bool fadeOut = true, ShakeRandomnessMode shakeRandomnessMode = ShakeRandomnessMode.Harmonic)
        {
            mainCamera.DOShakePosition(duration, strength, vibrato, randomness, fadeOut, shakeRandomnessMode).OnComplete(() => mainCamera.transform.position = new Vector3(0f, 0f, -10));
        }
        #endregion

        #region Sleep
        public static IEnumerator Sleep(this MonoBehaviour monoBehaviour, float duration)
        {
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(duration);
            Time.timeScale = 1;
        }
        #endregion

        #region Flash
        public static void Flash(this MonoBehaviour monoBehaviour, GameObject gameObject, SpriteRenderer sprite, Material flashMaterial, float duration, Coroutine flashCoroutine = null)
        {
            Material originalMaterial;

            sprite = gameObject.GetComponent<SpriteRenderer>();

            originalMaterial = sprite.material;

            if (flashCoroutine != null)
            {
                monoBehaviour.StopCoroutine(flashCoroutine);
            }

            flashCoroutine = monoBehaviour.StartCoroutine(AshenSoftwareHelpers.FlashRoutine(sprite, flashMaterial, originalMaterial, flashCoroutine, duration));
        }
        #endregion

        #region EnemyKnockBack
        public static void EnemyKnockBack(this GameObject gameObject, Rigidbody2D rb, PlayerController player, float strength)
        {
            Vector3 direction = new Vector2(player.movementDirectionX, gameObject.transform.position.y);

            rb.velocity = Vector2.zero;

            Vector2 knockback = direction * strength;

            rb.velocity = new Vector2(knockback.x, 15f);
        }
        #endregion
    }
}