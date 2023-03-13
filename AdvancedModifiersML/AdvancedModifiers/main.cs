using MelonLoader;
using UnityEngine;
using System.Reflection;
using System.Diagnostics;
using TMPro;
using UnityEngine.UI;
using System;
using static MelonLoader.MelonLogger;
using AdvancedModifiers.Menu;

[assembly: MelonInfo(typeof(AdvancedModifiers.Main), "Advanced Modifiers", "1.0.0", "EpicGamer")]
[assembly: MelonGame("Sayan", "Apes vs Helium")]
[assembly: MelonColor(ConsoleColor.DarkRed)]

namespace AdvancedModifiers
{
    public static class Private
    {
        public static void SetPrivateValue<T>(this T type, string field, object value)
        {
            type.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(type, value);
        }
    }

    public static class Update
    {
        public static void UpdateModifiers(string textFile, bool messages)
        {
            if (messages == true)
                Msg("Updating modifiers...");
            
            Modifiers.weaponChange = 1;

            Modifiers.wAttackCooldownChange = int.Parse(textFile.Split(new char[] { ':' })[2].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wDamageChange = int.Parse(textFile.Split(':')[3].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wDamageCeramicChange = int.Parse(textFile.Split(':')[4].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wDamageMoabChange = int.Parse(textFile.Split(':')[5].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wPierceChange = int.Parse(textFile.Split(':')[6].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wProjectileAmountChange = int.Parse(textFile.Split(':')[7].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wProjectilesPerShotChange = int.Parse(textFile.Split(':')[8].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wSpreadChange = float.Parse(textFile.Split(':')[9].Split(new char[] { '\n' })[0].Trim());

            Modifiers.wBlowbackMultChange = float.Parse(textFile.Split(':')[10].Split(new char[] { '\n' })[0].Trim());
            if (Modifiers.wBlowbackMultChange != -1)
                Modifiers.wBlowback = 1;
                    
            Modifiers.wMoabStunChange = int.Parse(textFile.Split(':')[11].Split(new char[] { '\n' })[0].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wStunDurationChange = int.Parse(textFile.Split(':')[12].Split(new char[] { '\n' })[0].Trim());
            Modifiers.wVelocityChange = float.Parse(textFile.Split(':')[13].Split(new char[] { '\n' })[0].Trim());
                    
            Modifiers.pJumpChange = int.Parse(textFile.Split(':')[14].Split(new char[] { '\n' })[0].Trim());
            Modifiers.pSpeedChange = int.Parse(textFile.Split(':')[15].Split(new char[] { '\n' })[0].Trim());
                    
            Modifiers.eHealthChange = int.Parse(textFile.Split(':')[16].Split(new char[] { '\n' })[0].Trim());
            Modifiers.eSpeedChange = float.Parse(textFile.Split(':')[17].Split(new char[] { '\n' })[0].Trim());
            Modifiers.eDamageChange = int.Parse(textFile.Split(':')[18].Split(new char[] { '\n' })[0].Trim());
            Modifiers.eCurrencyOnDeathChange = int.Parse(textFile.Split(':')[19].Split(new char[] { '\n' })[0].Trim());
            Modifiers.eRBEChange = int.Parse(textFile.Split(':')[20].Split(new char[] { '\n' })[0].Trim());
                    
            Modifiers.bfNumberOfBananasToSpawn = int.Parse(textFile.Split(':')[21].Split(new char[] { '\n' })[0].Trim());
            Modifiers.bsCashChange = int.Parse(textFile.Split(':')[22].Split(new char[] { '\n' })[0].Trim());
            Modifiers.bsLifeTimeChange = float.Parse(textFile.Split(':')[23].Split(new char[] { '\n' })[0].Trim());

            if (messages == true)
                Msg("Updated modifiers...");
        }
    }

    internal class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            if (!System.IO.Directory.Exists("Mods/AdvancedModifiers"))
            {
                System.IO.Directory.CreateDirectory("Mods/AdvancedModifiers");
            }

            if (!System.IO.File.Exists(Modifiers.modFolderPath + "Modifiers.txt"))
            {
                System.IO.File.WriteAllText(Modifiers.modFolderPath + "Modifiers.txt", Modifiers.modifierFile);
            }
            
            if (System.IO.File.Exists(Modifiers.modFolderPath + "Modifiers.txt"))
            {
                Msg("Checking modifiers file version...");
                string textFile = System.IO.File.ReadAllText(Modifiers.modFolderPath + "Modifiers.txt");
                string fileVersion = textFile.Split(new char[] { ':' })[1].Split(new char[] { '\n' })[0].Trim();

                if (fileVersion != Modifiers.currentFileVersion)
                {
                    if (System.IO.File.Exists(Modifiers.modFolderPath + "Modifiers-Old.txt"))
                    {
                        System.IO.File.Delete(Modifiers.modFolderPath + "Modifiers-Old.txt");
                    }
                    System.IO.File.Copy(Modifiers.modFolderPath + "Modifiers.txt", Modifiers.modFolderPath + "Modifiers-Old.txt");
                    System.IO.File.Delete(Modifiers.modFolderPath + "Modifiers.txt");
                    System.IO.File.WriteAllText(Modifiers.modFolderPath + "Modifiers.txt", Modifiers.modifierFile);
                    
                    Msg("Modifiers file is being updated, old version renamed to 'Modifiers-Old.txt'");
                }
                
                if (fileVersion == Modifiers.currentFileVersion)
                {
                    Msg("Modifiers file is up to date...");
                }
            }
            
            Msg("Advanced Modifiers loaded");
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            base.OnSceneWasInitialized(buildIndex, sceneName);
            if (sceneName == "MainMenu")
            {
                Update.UpdateModifiers(System.IO.File.ReadAllText(Modifiers.modFolderPath + "Modifiers.txt"), false);
                if (GameManagerScript.instance.mainMenu.transform.Find("Modifiers Text") is not null)
                    return;
                var modifiersText = UnityEngine.Object.Instantiate(GameManagerScript.instance.mainMenu.transform.Find("Version Text"),
                    GameManagerScript.instance.mainMenu.transform);
                modifiersText.name = "Modifiers Text";
                var tmp = modifiersText.GetComponent<TextMeshProUGUI>();
                tmp.text = "MODIFIERS";
                tmp.fontSize = 90;
                tmp.autoSizeTextContainer = true;
                tmp.characterSpacing = -5;
                modifiersText.localPosition = new Vector3(1100, -600, 0);
                tmp.raycastTarget = true;


                /*var parent = GameManagerScript.instance.mainMenu.transform.parent;
                var modifiersPanel = new GameObject("Modifiers Menu")
                {
                    transform =
                    {
                        parent = parent,
                        localPosition = new Vector3(0, 0, 0),
                    }
                };
                modifiersPanel.AddComponent<RectTransform>();
                modifiersPanel.SetActive(false);

                var backButton = UnityEngine.Object.Instantiate(
                    parent.Find("LevelSelect").Find("Levels").Find("BackButton").gameObject,
                    modifiersPanel.transform);

                backButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    modifiersPanel.SetActive(false);
                    GameManagerScript.instance.mainMenu.SetActive(true);
                });
                backButton.name = "BackButton";
                backButton.transform.position = new Vector3(129.75f, 959.25f, 0);
                backButton.transform.localScale = new Vector3(-0.75f, 0.75f, 1);
                backButton.SetActive(true);


                ModifiersMenu.GenerateMenu(modifiersPanel);*/


                var textButton = modifiersText.gameObject.AddComponent<Button>();
                textButton.onClick.AddListener(() =>
                {
                    /*GameManagerScript.instance.mainMenu.SetActive(false);
                    modifiersPanel.SetActive(true);*/
                    

                    Process notepad = Process.Start(Modifiers.modFolderPath + "Modifiers.txt");
                    notepad.WaitForExit();
                    string textFile = System.IO.File.ReadAllText(Modifiers.modFolderPath + "Modifiers.txt");
                    
                    Update.UpdateModifiers(textFile, true);
                });
            }
        }
    }
}