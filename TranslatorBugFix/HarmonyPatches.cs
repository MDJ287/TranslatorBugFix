using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorBugFix
{
    [HarmonyPatch]
    internal class HarmonyPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(NomaiTranslatorProp), nameof(NomaiTranslatorProp.DisplayTextNode))]
        private static void NomaiTranslatorProp_DisplayTextNode(NomaiTranslatorProp __instance)
        {
            if (__instance._nomaiTextComponent.IsTranslated(__instance._currentTextID))
            {
                return;
            }
            if (__instance._translationTimeElapsed == 0f && !__instance._nomaiTextComponent.IsTranslated(__instance._currentTextID))
            {
                return;
            }
            while (__instance._translationTimeElapsed > (float)(__instance._numTranslatedWords + 1) * __instance._perWordTranslationTime && __instance._numTranslatedWords < __instance._listDisplayWords.Count)
            {
                __instance._listDisplayWordsByLength[__instance._numTranslatedWords].BeginTranslation(__instance._perWordTranslationTime);
                __instance._numTranslatedWords++;
            }
        }
    }
}
