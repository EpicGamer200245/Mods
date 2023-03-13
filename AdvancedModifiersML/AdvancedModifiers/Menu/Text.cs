using System;
using System.Globalization;
using MelonLoader;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

namespace AdvancedModifiers.Menu
{
    public class Text
    {
        public static void NotepadText(GameObject parent)
        {
            if (GameManagerScript.instance.mainMenu.transform.Find("Notepad Notification Text") is not null)
                return;
            var notepadNotif = UnityEngine.Object.Instantiate(GameManagerScript.instance.mainMenu.transform.Find("Version Text"),
                parent.transform);
            notepadNotif.name = "Notepad Notification Text";
            var tmp = notepadNotif.GetComponent<TextMeshProUGUI>();
            var rect = notepadNotif.GetComponent<RectTransform>();
            tmp.text = "Change the modifiers in the text file just opened.";
            tmp.fontSize = 60;
            rect.sizeDelta = new Vector2(1800, rect.sizeDelta.y);
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.autoSizeTextContainer = true;
            tmp.characterSpacing = -5;
            rect.position = Camera.main.ViewportToScreenPoint(new Vector3(0.6f, 0.5f, 0));
            tmp.raycastTarget = true;
        }
    }
}