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
    public class EnemyChanges
    {
        public static void CommitChanges(ref Enemy __instance)
        {
            if (eHealthChange is not -1)
                __instance.health = eHealthChange;
            if (eSpeedChange is not -1)
                __instance.nav.speed = eSpeedChange;
            if (eDamageChange is not -1)
                __instance.damage = eDamageChange;
            if (eCurrencyOnDeathChange is not -1)
                __instance.currencyOnDeath = eCurrencyOnDeathChange;
            if (eRBEChange is not -1)
                __instance.rbe = eRBEChange;
        }
    }
}