using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Hook
{
    class HookMenu
    {
        private const string Menu = "[Hook]/";

        [MenuItem(Menu + "HookPosition")]
        private static void MenuItem_HookPosition()
        {
           Hook_Transform_Position.Hook();
        }

    
        [MenuItem(Menu + "HookSetActive")]
        private static void MenuItem_SetActive()
        {
            Hook_GameObject_SetActive.Hook();
        }
    }
}
