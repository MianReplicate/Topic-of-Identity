using System.IO;
using Topic_of_Identity.Mian.CustomAssets;
using Topic_of_Identity.Mian.CustomAssets.AI;
using NeoModLoader.api;
using HarmonyLib;
using NeoModLoader.General;

// separate sex from gender (gender can pretty much be anything, catgender, woman, man, etc)
// feminity/masculinity in all units (cis/trans).
// ^^ Significantly affected by gender BUT will still be random. Most males will lean towards masculinity BUT SOME will end up feminine.
// majority of the game uses sex MORE as gender than sex. Example: a culture trait prioritizes women for leadership in a kingdom.
// As a result, I will patch the game to determine a unit if it's Male/Female based on femininity/masculinity ONLY if the unit is trans
// (it's not perfect representation but it will have to do if the game needs to determine if a unit is Male/Female for something)
// because of the above, pregnancies will have to be patched to use a unit's assigned sex at birth and not the current sex (magic may change this)

// questioning period for units that may become trans (may start randomly throughout period, through talking with other trans ppl, or reading books)
// (the closer they are to realizing, the more effect it has on happiness. Values may depend on culture)
// at end of questioning period, units get the trans trait which adds a new dysphoria bar.

// make dysphoria be its own assetlibrary like how traits, ai, and etc have one. (for the average person, u can ignore this line. just nerd terminology)

// When a new unit is created and is trans, they will be assigned 1-2 (or more) random dysphoria types.
// When a dysphoria type becomes active, it increases dysphoria in a trans person.
// Dysphoria types become less effective/active depending on what was done to help negate it. E.g. HRT to help mitigate body dysphoria
// The higher dysphoria bar is, the more likely a trans person is to gain negative status effects and lose happiness in the happiness meter
// The lower dysphoria bar is, trans ppl will gain happiness and gain likely positive status effects.

// dysphoria type: body (affected by many tasks, seeing other cis ppl with a feminity/masculinity look similar to what character wants)
// body can be affected by HRT (this will affect fertility rates but slightly help with body dysphoria)
// appearance can be changed via decision task (this will help with body dysphoria)

// dysphoria type: social (not really sure atm what this will be)

// dysphoria type: mind

// some dysphoria types will be randomized as permanent on an actor or will still flare up depending on conditions

// while units socialize, there is a chance for accidental misgender
// decision task to compliment someone based on looks. Misgendering can happen here and will increase dysphoria meter.
// decision task for a unit to change their name based on femininity/masculinity.
// ^ more likely to happen the higher dysphoria is (very low chance for cis people). The more times a name is changed, the weight lowers further.
// ^ will ONLY happen if the current name is mismatched with the unit's femininity/masculinity

// transphobic/transphile culture traits. (not really sure where this would all fit in at the moment)

// research more into pregnancies and how they should work

// refactor Topic of Love code to make it so queer traits are based on what sex a person likes

// the goal is to make it possible for a lesbian cisgender to date a trans person who was AMAB who is now non-binary feminine presenting

namespace Topic_of_Identity.Mian
{
    public class TopicOfIdentity : BasicMod<TopicOfIdentity>
    {
        public static BasicMod<TopicOfIdentity> Mod;
        
        protected override void OnModLoad()
        {
            Mod = this;
            TOIUtil.LogWithId("Giving identities to people!");
            
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

            // massive rework in bound!
            
            // ActorTraits.Init();
            // CultureTraits.Init();
            // Happiness.Init();
            // CommunicationTopics.Init();
            // ActorBehaviorTasks.Init();
            // Decisions.Init();
        }
        private void Awake()
        {
            var harmony = new Harmony("netdot.mian.topicofidentity");
            harmony.PatchAll();
        }
    }
}