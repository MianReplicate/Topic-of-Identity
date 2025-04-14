using System.IO;
using Better_Loving.Mian.CustomAssets;
using Better_Loving.Mian.CustomAssets.AI;
using NeoModLoader.api;
using HarmonyLib;
using NeoModLoader.General;
using Topic_of_Identity.Mian.CustomAssets;

namespace Topic_of_Identity.Mian
{
    public class TopicOfLoving : BasicMod<TopicOfLoving>
    {
        public static BasicMod<TopicOfLoving> Mod;
        
        protected override void OnModLoad()
        {
            Mod = this;
            Util.LogWithId("Giving identities to people!");
            
            var localeDir = GetLocaleFilesDirectory(GetDeclaration());
            foreach (var file in Directory.GetFiles(localeDir))
            {
                if (file.EndsWith(".json"))
                {
                    LM.LoadLocale(Path.GetFileNameWithoutExtension(file), file);
                }
                else if (file.EndsWith(".csv"))
                {
                    LM.LoadLocales(file);
                }
            }

            LM.ApplyLocale();
            
            ActorTraits.Init();
            CultureTraits.Init();
            Happiness.Init();
            CommunicationTopics.Init();
            ActorBehaviorTasks.Init();
            Decisions.Init();
        }
        private void Awake()
        {
            var harmony = new Harmony("netdot.mian.topicofidentity");
            harmony.PatchAll();
        }
    }
}