using ai.behaviours;
using Topic_of_Identity.Mian.CustomAssets.AI.CustomBehaviors.identity;

namespace Topic_of_Identity.Mian.CustomAssets.AI
{
    public class ActorBehaviorTasks
    {
        public static void Init()
        {
            BehaviourTaskActor insultIdentity = new BehaviourTaskActor
            {
                id = "insult_identity",
                locale_key = "task_insult_identity",
                path_icon = "ui/Icons/culture_traits/transphobic",
            };
            insultIdentity.addBeh(new BehFindTransgender());
            insultIdentity.addBeh(new BehGoToActorTarget(GoToActorTargetType.NearbyTileClosest, pCalibrateTargetPosition: true));
            insultIdentity.addBeh(new BehCheckNearActorTarget());
            insultIdentity.addBeh(new BehInsultIdentity());
            Add(insultIdentity);
        }

        private static void Add(BehaviourTaskActor behaviour)
        {
            AssetManager.tasks_actor.add(behaviour);
        }
        
    }
}