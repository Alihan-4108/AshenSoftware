using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AshenSoftware
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

        public static void SetActiveCollider(this Collider2D collider, bool isActive)
        {
            collider.enabled = isActive;
        }


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


        public static Tween DoMusicSoundReduction(this AudioSource music, float endValue, float duration)
        {
            return DOTween.To(() => music.volume, x => music.volume = x, endValue, duration);
        }

    }
}