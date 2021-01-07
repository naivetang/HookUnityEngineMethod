using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Hook
{
    public class Hook_GameObject_SetActive
    {
        protected static MethodHook MethodHooker;
        protected static GameObject HookedGameObject;
        
        public static void Hook()
        {
            Utility.SelectionHook(ref HookedGameObject, SetActive_Hook);
        }

        private static void SetActive_Hook()
        {
            if (MethodHooker != null)
                return;

            Type type = typeof(GameObject);

            MethodInfo targetMethod = type.GetMethod("SetActive", (BindingFlags)(0x0fffffff));

            type = typeof(Hook_GameObject_SetActive);

            MethodInfo replaceMethod = type.GetMethod("SetActive_Replace", (BindingFlags)(0x0fffffff));

            MethodInfo proxyMethod = type.GetMethod("SetActive_Proxy", (BindingFlags)(0x0fffffff));

            Debug.Assert(targetMethod != null);
            Debug.Assert(replaceMethod != null);
            Debug.Assert(proxyMethod != null);

            MethodHooker = new MethodHook(targetMethod, replaceMethod, proxyMethod);
            MethodHooker.Install();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void SetActive_Replace(bool value)
        {

            GameObject gameObject = (this as object) as GameObject;

            if (HookedGameObject.Equals(gameObject))
            {
                HookLog.LogFormat($" SetActive \"{gameObject}\", old:{gameObject.activeSelf} , new:{value}");
            }

            SetActive_Proxy(value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void SetActive_Proxy(bool value)
        {
            HookLog.LogFormat("Dummy");
        }
    }
}