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
    [HarmonyPatch(typeof(Weapon), "SpawnProjectile")]
    public class WeaponSpawnProjectile
    {
        [HarmonyPrefix]
        public static bool Prefix(ref Weapon __instance)
        {
            WeaponChanges.CommitChanges(ref __instance);
            return true;
        }

        //[HarmonyPostfix]
        //public static void Postfix(ref Weapon __instance, ref Quaternion quaternion2)
        //{
            //ModifierFixes.BoomerangBoolFix2(ref __instance, ref quaternion2);

        //}
    }
}