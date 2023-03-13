using MelonLoader;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using System;
using HarmonyLib;
using static MelonLoader.MelonLogger;
using AdvancedModifiers.Menu;
using static AdvancedModifiers.Modifiers;
using static AdvancedModifiers.ModifierFixes;
using System.Net;

namespace AdvancedModifiers.Changes
{
    public class BananaFarmScriptChanges
    {
        public static void CommitChanges(ref BananaFarmScript __instance)
        {
            if (bfNumberOfBananasToSpawn != -1)
                __instance.numberOfBananasToSpawn = bfNumberOfBananasToSpawn;
        }
    }
}