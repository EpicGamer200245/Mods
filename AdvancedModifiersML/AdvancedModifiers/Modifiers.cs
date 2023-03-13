using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace AdvancedModifiers
{
    public class Modifiers
    {
        public static string modFolderPath = (Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/Mods/AdvancedModifiers/");

        public static string currentFileVersion = "1.0";

        public static string modifierFile = "Do NOT change the version of the version of the modifier file!\n" +
                                            "Modifier file version: " + currentFileVersion + "\n\n\n" +
                                            "When you modify anything in this file the stat will be replaced by it, For example, if you change damage to 2 everything in the game will do 2 damage.\n" +
                                            "If you want to disable something being changed use -1.\n\n" +

                                            "Close when done editing.\n\n" +

                                            "WEAPONS\n\n" +
                                            "Weapon attack cooldown: -1\n\n\n" +

                                            "PROJECTILES\n\n" +
                                            "Projectile damage: -1\n" +
                                            "Projectile ceramic damage: -1\n" +
                                            "Projectile MOAB damage: -1\n" +
                                            "Projectile pierce: -1\n\n" +

                                            "Projectile amount changes how the projectiles are shot out, if you want a triple dart change amount to 3 and amount per shot to 3.\n" +
                                            "Projectile amount (Can only be 1, 2, 3, 5, 8, 9 or -1 to disable): -1\n" +
                                            "Projectile amount per shot: -1\n" +
                                            "Projectile spread should always be a very low number, for example buckshot's spread is 0.04 which is already a decently big spread.\n" +
                                            "Projectile spread: -1\n\n" +

                                            "Projectile blowback amount: -1\n" +
                                            "Projectile MOAB stun amount: -1\n" +
                                            "Projectile bloon stun amount: -1\n" +
                                            "Projectile velocity: -1\n\n\n" +

                                            "PLAYER\n\n" +
                                            "Player jump height: -1\n" +
                                            "Player speed: -1\n\n\n" +

                                            "BLOONS\n\n" +
                                            "Bloon health is the amount of damage it takes to pop a bloon, affects MOABs.\n" +
                                            "Bloon health: -1\n" +
                                            "Bloon speed: -1\n" +
                                            "Bloon damage: -1\n" +
                                            "Bloon money on death: -1\n" +
                                            "Bloon RBE: -1\n\n\n" +

                                            "BANANA FARM\n\n" +
                                            "Banana farm amount of bananas: -1\n" +
                                            "Banana money: -1\n" +
                                            "Banana lifetime: -1";


        //Weapon
        public static int weaponChange = 1;
        public static int wPierceChange = -1;
        public static int wDamageChange = -1;
        public static int wProjectileAmountChange = -1;
        public static int wProjectilesPerShotChange = -1;
        public static int wAttackCooldownChange = -1;
        public static int wBlowback = -1; //Bool
        public static float wBlowbackMultChange = -1;
        public static int wDamageCeramicChange = -1;
        public static int wDamageMoabChange = -1;
        public static int wMoabStunChange = -1;
        public static float wVelocityChange = -1;
        public static float wSpreadChange = -1f;
        public static int wStunDurationChange = -1;

        //Enemy
        public static int eHealthChange = -1;
        public static float eSpeedChange = -1;
        public static int eDamageChange = -1;
        public static int eCurrencyOnDeathChange = -1;
        public static int eRBEChange = -1;

        //Player
        public static int pSpeedChange = -1;
        public static int pJumpChange = -1;

        //BananaScript
        public static int bsCashChange = -1;
        public static float bsLifeTimeChange = -1;

        //BananaFarmScript
        public static int bfNumberOfBananasToSpawn = -1;
    }
  
}