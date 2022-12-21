using MelonLoader;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using TMPro;
using UnityEngine.UI;
using MarchingBytes;
using System;
using UnityEngine.Events;
using static MelonLoader.MelonLogger;


[assembly: MelonInfo(typeof(AllBuckshot.AllBuckshot), "All Buckshot", "1.0.0", "EpicGamer")]
[assembly: MelonGame("Sayan", "Apes vs Helium")]

namespace AllBuckshot
{

    public class AllBuckshot : MelonMod
    {
        public static int ChangedPrimary;
        public static int ChangedSecondary;
        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            LoggerInstance.Msg("All Buckshot loaded.");
        }

        [HarmonyPatch(typeof(Weapon), "SpawnProjectile")]
        public class WeaponSpawnProjectile
        {
            [HarmonyPrefix]
            public static void Prefix(ref Weapon __instance)
            {
                __instance.projectileNumber = Weapon.ProjectileNumber.oneShot;
                __instance.projectilesPerShot = 6;
                __instance.spread = 0.04f;
            }
        }
    }
}