using System.Collections;
using MelonLoader;
using Mono.Unix.Native;
using UnityEngine;
using static AdvancedModifiers.Modifiers;

namespace AdvancedModifiers
{
    public class ModifierFixes
    {
        private static GameObject currentWeapon = EquipmentScript.instance.currentWeapon;
        public static void BlowbackBoolFix(ref Weapon __instance)
        {
            if (wBlowback == -1)
            {
                return;
            }
            if (wBlowback == 0)
            {
                __instance.blowBack = false;
            }
            if (wBlowback == 1)
            {
                __instance.blowBack = true;
            }
        }

        public static void ProjectileNumberFix(ref Weapon __instance)
        {
            switch (wProjectileAmountChange)
            {
                case 1:
                {
                    __instance.projectileNumber = Weapon.ProjectileNumber.oneShot;
                } break;
                case 2:
                {
                    __instance.projectileNumber = Weapon.ProjectileNumber.twoShot;
                } break;
                case 3:
                {
                    __instance.projectileNumber = Weapon.ProjectileNumber.threeShot;
                }  break;
                case 5:
                {
                    __instance.projectileNumber = Weapon.ProjectileNumber.fiveShot;
                }  break;
                case 8:
                {
                    __instance.projectileNumber = Weapon.ProjectileNumber.eightShot;
                }  break;
                case 9:
                {
                    __instance.projectileNumber = Weapon.ProjectileNumber.nineShot;
                } break;
            }
        }
    }
}