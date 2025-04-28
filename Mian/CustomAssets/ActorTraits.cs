
namespace Topic_of_Identity.Mian.CustomAssets
{
    public class ActorTraits
    {
        public static void Init()
        {
            Add(new ActorTrait
            {
                id = "transgender",
                group_id = "mind",
                type = TraitType.Other,
                unlocked_with_achievement = false,
                rarity = Rarity.R3_Legendary,
                needs_to_be_explored = true,
                affects_mind = true,
                action_on_add = (target, trait) =>
                {
                    if (target == null)
                        return false;
                    var actor = (Actor) target;
                    TOIUtil.SwapIdentity(actor);
                    return true;
                },
                action_on_remove = (target, trait) =>
                {
                    if (target == null)
                        return false;
                    var actor = (Actor) target;
                    TOIUtil.SwapIdentity(actor);
                    return true;
                }
            });
        }

        private static void Add(ActorTrait trait)
        {
            trait.path_icon = "ui/Icons/actor_traits/"+trait.id;
            TOIUtil.AddActorTrait(trait);
        }
    }
}