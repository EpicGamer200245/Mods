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
    [HarmonyPatch(typeof(Enemy), "OnCreate")]
    public class EnemyOnCreate
    {
        [HarmonyPrefix]
        public static bool Prefix(ref Enemy __instance)
        {
            EnemyChanges.CommitChanges(ref __instance);
            return true;
        }
    }
}