using HarmonyLib;
using NeoModLoader.services;

namespace Topic_of_Identity.Mian
{
    public class TOIUtil
    {
        public static bool IsSmart(Actor actor)
        {
            return actor.hasSubspeciesTrait("prefrontal_cortex")
                   && actor.hasSubspeciesTrait("advanced_hippocampus")
                   && actor.hasSubspeciesTrait("amygdala")
                   && actor.hasSubspeciesTrait("wernicke_area");
        }
        public static void AddActorTrait(ActorTrait trait)
        {
            for (int index = 0; index < trait.rate_birth; ++index)
                AssetManager.traits.pot_traits_birth.Add(trait);
            for (int index = 0; index < trait.rate_acquire_grow_up; ++index)
                AssetManager.traits.pot_traits_growup.Add(trait);
            if (trait.combat)
                AssetManager.traits.pot_traits_combat.Add(trait);

            AssetManager.traits.add(trait);
        }
        
        public static void SwapIdentity(Actor pActor)
        {
            pActor.data.sex = pActor.isSexFemale() ? ActorSex.Male : ActorSex.Female;
            if (Randy.randomChance(0.5f))
            {
                pActor.data.get("old_name", out string previousName);

                var currentName = pActor.getName();
                if (previousName != null)
                    pActor.data.setName(previousName);
                else
                    pActor.generateNewName();
                
                pActor.data.set("old_name", currentName);
            }

            pActor.changeHappiness("true_gender");
        }
        public static bool IsTrans(Actor pActor)
        {
            return pActor.hasTrait("transgender");
        }
        public static void LogWithId(string message)
        {
            LogService.LogInfo($"[{TopicOfIdentity.Mod.GetDeclaration().Name}]: "+message);
        }
        
        public static void Debug(string message)
        {
            var config = TopicOfIdentity.Mod.GetConfig();
            var slowOnLog = (bool)config["Misc"]["SlowOnLog"].GetValue();
            var debug = (bool)config["Misc"]["Debug"].GetValue();

            if (!debug)
                return;
            if(slowOnLog)
                Config.setWorldSpeed(AssetManager.time_scales.get("slow_mo"));
            LogWithId(message);
        }
    }
}