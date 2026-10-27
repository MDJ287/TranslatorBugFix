using HarmonyLib;
using OWML.Common;
using OWML.ModHelper;
using System;
using System.Reflection;

namespace TranslatorBugFix
{
    public class TranslatorBugFix : ModBehaviour
    {
        public static TranslatorBugFix Instance;

        public void Awake()
        {
            Instance = this;
        }

        public void Start()
        {
            new Harmony("MDJ287.TranslatorBugFix").PatchAll(Assembly.GetExecutingAssembly());
        }
    }

}
