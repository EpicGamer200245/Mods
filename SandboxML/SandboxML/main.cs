using MelonLoader;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using MarchingBytes;
using System;
using UnityEngine.Events;


[assembly: MelonInfo(typeof(SandBox.Sandbox), "Sandbox", "1.0.0", "EpicGamer")]
[assembly: MelonGame("Sayan", "Apes vs Helium")]

namespace SandBox
{
    public static class Private
    {
        public static void SetPrivateValue<T>(this T type, string field, object value)
        {
            type.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(type, value);
        }
    }

    public class Sandbox : MelonMod
    {
        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            LoggerInstance.Msg("Sandbox loaded.");
        }

        [HarmonyPatch(typeof(WaveSpawner), "Update")]
        public class WaveSpawnerUpdate_Patch
        {
            [HarmonyPrefix]
            public static void OnUpdate(ref WaveSpawner __instance)
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    __instance.SetPrivateValue("state", WaveSpawner.SpawnState.COUNTING);
                    __instance.SetPrivateValue("waveCountDown", __instance.timeBetweenWaves);
                    __instance.WaveFinishedEvent.Invoke();
                    __instance.nextwave++;
                    __instance.waveNumberText.text = (__instance.nextwave + 1).ToString() + "/" + __instance.lastRound;
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    __instance.SetPrivateValue("state", WaveSpawner.SpawnState.COUNTING);
                    __instance.SetPrivateValue("waveCountDown", __instance.timeBetweenWaves);
                    __instance.WaveFinishedEvent.Invoke();
                    __instance.nextwave -= 1;
                    __instance.waveNumberText.text = (__instance.nextwave + 1).ToString() + "/" + __instance.lastRound;
                }
            }
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
            public static bool Prefix(Currency __instance)
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