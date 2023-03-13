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
using UnityStandardAssets.Characters.FirstPerson;

namespace AdvancedModifiers.Changes
{
    public class FirstPersonControllerChanges
    {
        public static void CommitChanges(ref FirstPersonController __instance, ref float speed)
        {
            if (pSpeedChange is not -1)
                speed = pSpeedChange;
            if (pJumpChange is not -1)
                __instance.SetPrivateValue("m_JumpSpeed", pJumpChange);
        }
    }
}