using MelonLoader;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using System;
using HarmonyLib;
using static MelonLoader.MelonLogger;
using AdvancedModifiers.Menu;

namespace AdvancedModifiers.Patches
{
    [HarmonyPatch(typeof(EquipmentScript), "ChangeWeapon")]
    public class EquipmentScriptChangeWeapon
    {
        [HarmonyPostfix]
        public static void Postfix(ref EquipmentScript __instance)
        {
            Modifiers.weaponChange = 1;
        }
    }
}