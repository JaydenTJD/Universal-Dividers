using MelonLoader;
using HarmonyLib;
using Il2CppNcp.Game;

[assembly: MelonInfo(typeof(Universal_Dividers.Core), "Universal Dividers", "2.0.0", "Jayden", null)]
[assembly: MelonGame("Notional Games", "Beltmatic")]

namespace Universal_Dividers
{
    public class Core : MelonMod { }

    [HarmonyPatch(typeof(Building), "Update")]
    public static class Patch_Building_Update
    {
        public static void Postfix(Building __instance, bool updateInputs, bool updateOutputs)
        {
            if (__instance.CachedType == BuildingType.Divider && __instance.currentProductionItem2 == BeltItem.Empty)
            {
                __instance.currentProductionItem2 = BeltItem.Create(0);
            }
        }
    }
}