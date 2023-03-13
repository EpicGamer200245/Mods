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
using UnityStandardAssets.Characters.FirstPerson;

namespace AdvancedModifiers.Patches
{
    [HarmonyPatch(typeof(FirstPersonController), "GetInput")]
    public class FirstPersonControllerGetInput
    {
        [HarmonyPrefix]
        public static bool Prefix(ref FirstPersonController __instance, ref float speed)
        {
            FirstPersonControllerChanges.CommitChanges(ref __instance, ref speed);
            return true;
        }
    }
}