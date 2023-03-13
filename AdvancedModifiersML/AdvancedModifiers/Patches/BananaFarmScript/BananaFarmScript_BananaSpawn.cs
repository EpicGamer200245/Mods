using MelonLoader;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using System;
using HarmonyLib;
using static MelonLoader.MelonLogger;
using AdvancedModifiers.Menu;
using AdvancedModifiers.Changes;

namespace AdvancedModifiers.Patches
{
    [HarmonyPatch(typeof(BananaFarmScript), "BananaSpawn")]
    public class BananaFarmScriptBananaSpawn
    {
        [HarmonyPrefix]
        public static bool Prefix(ref BananaFarmScript __instance)
        {
            BananaFarmScriptChanges.CommitChanges(ref __instance);
            return true;
        }
    }
}