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
    public class BananaScriptChanges
    {
        public static void CommitChanges(ref BananaScript __instance)
        {
            if (bsCashChange is not -1)
                __instance.cash = bsCashChange;
            if (bsLifeTimeChange is not -1)
                __instance.lifeTime = bsLifeTimeChange;
        }
    }
}