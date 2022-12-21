using JetBrains.Annotations;
using System;
using System.CodeDom;
using System.Net;
using System.Reflection;
using UnityEngine;
using static MelonLoader.MelonLogger;
using static SandBox.Sandbox;
using Harmony;

namespace SandBox
{
    public class SandboxGUI : MonoBehaviour
    {
        public static bool ShowHideWindow0;
        public static Rect WindowUiRect0;
        public static string waveString;
        public static GameObject spawnerObject = GameObject.Find("Wave Spawner");
        public static WaveSpawner Instance = spawnerObject.GetComponent<WaveSpawner>();

    public void OnGUI()
        {
            ShowHideWindow0 = !ShowHideWindow0;
            if (ShowHideWindow0)
            {
                WindowUiRect0 = GUILayout.Window(0, WindowUiRect0, new GUI.WindowFunction(WindowUI0), "Doggy's Mod", new GUILayoutOption[]{
                    GUILayout.MaxWidth(300f),
                    GUILayout.MinWidth(200f)
                });
            }
        }

        public static void WindowUI0(int windowID)
        {
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            if (GUILayout.Button("Change Round to", Array.Empty<GUILayoutOption>()))
            {
                int number = 0;
                if (int.TryParse(waveString, out number))
                {
                    changeRound(number);
                }
            }
            waveString = GUILayout.TextField(waveString, Array.Empty<GUILayoutOption>());
            GUILayout.EndHorizontal();
            GUI.DragWindow();
        }

        public static void changeRound(int number)
        {
            Instance.SetPrivateValue("state", WaveSpawner.SpawnState.COUNTING);
            Instance.SetPrivateValue("waveCountDown", Instance.timeBetweenWaves);
            Instance.WaveFinishedEvent.Invoke();
            if (Instance.nextwave > number)
            {
                Instance.nextwave -= number;
            }
            if (Instance.nextwave < number)
            {
                Instance.nextwave += number;
            }
            Instance.waveNumberText.text = (Instance.nextwave + 1).ToString() + "/" + Instance.lastRound;
        }
    }
}