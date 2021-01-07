using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hook
{
    class Hook_Transform_Position 
    {
        
        protected static MethodHook MethodHooker;
        protected static GameObject HookedGameObject;
        
        public static void Hook()
        {
            Utility.SelectionHook(ref HookedGameObject, Position_Hook);
        }

        private static void Position_Hook()
        {
            if (MethodHooker != null)
                return;
            
            Type type = typeof(Transform);

            var targetPro = type.GetProperty("position", (BindingFlags)(0x0fffffff));

            var targetMethod = targetPro.SetMethod;

            type = typeof(Hook_Transform_Position);

            var replaceMethod = type.GetMethod("Position_Replace", (BindingFlags) (0x0fffffff));
            
            var proxyMethod = type.GetMethod("Position_Proxy", (BindingFlags) (0x0fffffff));
            
            Debug.Assert(targetMethod != null);
            Debug.Assert(replaceMethod != null);
            Debug.Assert(proxyMethod != null);

            MethodHooker = new MethodHook(targetMethod, replaceMethod, proxyMethod);
            MethodHooker.Install();
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Position_Replace(Vector3 vec)
        {
            var transform = (this as object) as Transform;

            var gameObject = transform.gameObject;
            
            if (HookedGameObject.Equals((gameObject)))
            {
                HookLog.LogFormat($"Position \"{gameObject.name}\", position:{vec.ToString("f3")}");
            }

            Position_Proxy(vec);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Position_Proxy(Vector3 vec)
        {
            HookLog.LogFormat("Dummy");
        }

    }
}
