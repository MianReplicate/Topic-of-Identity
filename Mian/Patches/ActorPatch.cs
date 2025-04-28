using System;
using HarmonyLib;

namespace Topic_of_Identity.Mian.Patches;

public class ActorPatch
{
    [HarmonyPatch(typeof(Actor), nameof(Actor.calcAgeStates))]
    class CalcAgeStatesPatch
    {
        static void Postfix(Actor __instance)
        {
            if (__instance.hasTrait("transgender"))
                return;
            
            var age = __instance.getAge();
            if (age >= 3)
            {
                var chance = Math.Max(0.001f, (3f - (age/10f)) / 100);
                if (Randy.randomChance(chance))
                {
                    __instance.addTrait("transgender");
                }
            }
        }
    }
}