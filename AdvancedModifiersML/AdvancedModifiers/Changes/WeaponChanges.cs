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
    public class WeaponChanges
    {
        public static void CommitChanges(ref Weapon __instance)
        {
            if (weaponChange == 1)
            {
                if (wPierceChange is not -1)
                    __instance.pierce = wPierceChange;
                if (wDamageChange is not -1)
                    __instance.damage = wDamageChange;
                ProjectileNumberFix(ref __instance);
                if (wProjectilesPerShotChange is not -1)
                    __instance.projectilesPerShot = wProjectilesPerShotChange;
                if (wAttackCooldownChange is not -1)
                    __instance.attackCooldown = wAttackCooldownChange;
                BlowbackBoolFix(ref __instance);
                if (wBlowbackMultChange is not -1)
                    __instance.blowBackMult = wBlowbackMultChange;
                if (wDamageCeramicChange is not -1)
                    __instance.damageCeramic = wDamageCeramicChange;
                if (wDamageMoabChange is not -1)
                    __instance.damageMoab = wDamageMoabChange;
                if (wMoabStunChange is not -1)
                    __instance.moabStunDur = wMoabStunChange;
                if (wVelocityChange is not -1)
                    __instance.projectileVelocity = wVelocityChange;
                if (wSpreadChange is not -1f)
                    __instance.spread = wSpreadChange;
                if (wStunDurationChange is not -1)
                    __instance.stunDur = wStunDurationChange;
                Modifiers.weaponChange = 0;
            }
        }
    }
}