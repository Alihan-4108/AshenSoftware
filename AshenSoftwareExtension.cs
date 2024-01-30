using UnityEngine;
using DG.Tweening;

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

        #region LoadActiveScene
        public static void LoadActiveScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
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

        #region DoSoundVolume
        public static Tween DoSoundVolume(this AudioSource music, float endValue, float duration, Ease ease = Ease.InOutQuad)
        {
            return DOTween.To(() => music.volume, x => music.volume = x, endValue, duration).SetEase(ease);
        }
        #endregion
    }
}
