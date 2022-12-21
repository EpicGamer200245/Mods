using MelonLoader;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using MarchingBytes;
using System;
using UnityEngine.Events;
using static MelonLoader.MelonLogger;


[assembly: MelonInfo(typeof(RoundSkipper.RoundSkipper), "Round Skipper", "1.1.0", "EpicGamer")]
[assembly: MelonGame("Sayan", "Apes vs Helium")]

namespace RoundSkipper
{
    public static class Private
    {
        public static void SetPrivateValue<T>(this T type, string field, object value)
        {
            type.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(type, value);
        }
    }

    public class RoundSkipper : MelonMod
    {
        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            LoggerInstance.Msg("Round Skipper loaded.");
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
    }
}