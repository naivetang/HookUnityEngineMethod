using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Hook
{
    public static class Utility 
    {

        public static void SelectionHook( ref GameObject hookedGameObject,Action hookAction)
        {
            GameObject[] gos = Selection.gameObjects;
            if (gos.Length > 0)
            {
                if (gos.Length > 1)
                {
                    EditorUtility.DisplayDialog("Hook失败", string.Format("只能选择一个GameObject Hook"), "确定");
                }
                else
                {
                    hookedGameObject = gos[0];
                    hookAction.Invoke();
                }
            }
        }
    }
}