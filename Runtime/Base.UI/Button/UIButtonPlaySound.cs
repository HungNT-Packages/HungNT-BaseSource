﻿using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Base
{
    public class UIButtonPlaySound : UIButtonBase
    {
        [SerializeField] [ValueDropdown("GetAllSoundNames()")]
        private string sfxAddress;

        [SerializeField] [Range(0, 1)]
        private float volume = 1;

        protected override void OnClick()
        {
            // var audio = await ResourcesLoader.Instance.LoadAsync<AudioClip>(sfxAddress);
            // Sound.Controller.Instance.PlayOneShot(audio, volume);
        }

        // public static List<string> GetAllSoundNames()
        // {
        //     var soundNames = new List<string>();
        //     var fields = typeof(GameConfig.Sound).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        //
        //     foreach (var field in fields)
        //     {
        //         if (field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
        //         {
        //             soundNames.Add((string)field.GetValue(null));
        //         }
        //     }
        //
        //     return soundNames;
        // }
    }
}