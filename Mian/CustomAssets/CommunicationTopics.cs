
namespace Topic_of_Identity.Mian.CustomAssets
{
    public class CommunicationTopics
    {
        public static void Init()
        {
            Add(new CommunicationAsset
            {
                id = "identity",
                rate = 0.5f,
                check = actor => Util.IsTrans(actor) && (actor.hasCultureTrait("transphobic") || actor.hasCultureTrait("transphile")),
                pot_fill = (actor, sprites) =>
                {
                    sprites.Add(AssetManager.traits.get("transgender").getSprite());
                    if (actor.hasCultureTrait("transphobic"))
                    {
                        sprites.Add(AssetManager.culture_traits.get("transphobic").getSprite());
                        actor.changeHappiness("identity_does_not_fit");
                    }
                    else if (actor.hasCultureTrait("transphile"))
                    {
                        sprites.Add(AssetManager.culture_traits.get("transphile").getSprite());
                        actor.changeHappiness("identity_fits");
                    }
                } 
            });
        }

        private static void Add(CommunicationAsset asset)
        {
            AssetManager.communication_topic_library.add(asset);
        }
    }
}