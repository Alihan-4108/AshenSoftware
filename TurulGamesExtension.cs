using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

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

        #region SetActiveColliderAndSprite
        public static void SetActiveColliderAndSprite(this GameObject gameObject, bool isActive)
        {
            gameObject.GetComponent<Collider2D>().enabled = isActive;
            gameObject.GetComponent<SpriteRenderer>().enabled = isActive;
        }
        #endregion

        #region FindChildByName
        public static Transform FindChildrenByName(this GameObject parent, string name)
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

        #region FindChildrensWithTag
        public static List<GameObject> FindChildrensWithTag(this GameObject parent, string tag)
        {
            List<GameObject> children = new List<GameObject>();
            Transform[] childTransform = parent.GetComponentsInChildren<Transform>(true);

            for (int i = 0; i < childTransform.Length; i++)
            {
                Transform child = childTransform[i];

                if (child.CompareTag(tag))
                {
                    children.Add(child.gameObject);
                }
            }

            return children;
        }
        #endregion

        #region DoMusicSoundReduction
        public static Tween DoMusicSoundReduction(this AudioSource music, float endValue, float duration)
        {
            return DOTween.To(() => music.volume, x => music.volume = x, endValue, duration);
        }
        #endregion

        #region TimeFreeze
        public static async UniTaskVoid TimeFreeze(float time = .05f)
        {
            bool isTimeFrozen = false;

            if (isTimeFrozen)
                return;

            isTimeFrozen = true;
            Time.timeScale = 0;

            try
            {
                await UniTask.Delay((int)(time * 1000), ignoreTimeScale: true);
            }
            finally
            {
                Time.timeScale = 1;
                isTimeFrozen = false;
            }
        }
        #endregion
    }
}
