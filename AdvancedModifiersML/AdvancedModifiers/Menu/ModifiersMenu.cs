using System;
using System.Diagnostics;
using MelonLoader;
using Mono.Unix.Native;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using AdvancedModifiers;

namespace AdvancedModifiers.Menu
{
    static class ModifiersMenu
    {
        public static void GenerateMenu(GameObject parent)
        {
            Text.NotepadText(parent);
        }
    }
}