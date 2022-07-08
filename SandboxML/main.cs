using MelonLoader;
using HarmonyLib;

[assembly: MelonInfo(typeof(SandBox.Sandbox), "Sandbox", "0.5.0", "EpicGamer")]
[assembly: MelonGame("Sayan", "Apes vs Helium")]

namespace SandBox
{
    public class Sandbox : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Sandbox loaded...");
        }

        [HarmonyPatch(typeof(Currency), "UpdateCurrency")]
        public class CurrencyUpdateCurrency_Patch
        {
            public static bool PrefixRan = false;
            [HarmonyPrefix]
            public static void Prefix(ref int amount)
            {
                if (PrefixRan == true)
                {
                    amount = 0;

                }
                PrefixRan = true;
            }
        }

        [HarmonyPatch(typeof(Currency), "Start")]
        public class CurrencyStart_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(ref Currency __instance)
            {
                __instance.currency = int.MaxValue;
                __instance.UpdateCurrency(0, false);
                return false;
            }
        }

        [HarmonyPatch(typeof(PlayerHealth), "UpdateHealth")]
        public class PlayerHealthUpdateHealth_Patch
        {
            public static bool PrefixRan2 = false;
            [HarmonyPrefix]
            public static void Prefix(ref int amount)
            {
                if (PrefixRan2 == true)
                {
                    amount = 0;

                }
                PrefixRan2 = true;
            }
        }
        [HarmonyPatch(typeof(PlayerHealth), "Start")]
        public class PlayerHealthStart_Patch
        {
            public static GameManagerScript gameManagerScript;
            
            [HarmonyPrefix]
            public static bool Prefix(PlayerHealth __instance)
            {
                __instance.health = int.MaxValue;
                __instance.UpdateHealth(0);
                return false;
            }
        }
    }
}