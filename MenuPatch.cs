using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MelonLoader;

namespace MoonriseButtonAPI
{
    [HarmonyPatch(typeof(VRC.UI.Elements.QuickMenu), "Start")]
    public class MenuPatch
    {
        public static event Action OnVRCUi;
        private static bool initialized = false;
        static void Postfix()
        {
            if (initialized) return;
            initialized = true;
            MelonLogger.Msg("Fuck My life!");
            OnVRCUi?.Invoke();
        }
    }
}
