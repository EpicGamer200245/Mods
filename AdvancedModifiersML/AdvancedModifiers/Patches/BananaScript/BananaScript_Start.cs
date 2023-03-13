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
    [HarmonyPatch(typeof(BananaScript), "Start")]
    public class BananaScriptStart
    {
        [HarmonyPrefix]
        public static bool Prefix(ref BananaScript __instance)
        {
            BananaScriptChanges.CommitChanges(ref __instance);
            return true;
        }
    }
}