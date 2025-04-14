
using System.Collections.Generic;

namespace Better_Loving.Mian.CustomAssets
{
    public class CultureTraits
    {
        public static void Init()
        {
            var transphobic = new CultureTrait
            {
                id = "transphobic",
                group_id = "worldview",
                needs_to_be_explored = true,
                rarity = Rarity.R1_Rare,
                can_be_in_book = true,
                can_be_removed = true,
                can_be_given = true
            };

            var transphile = new CultureTrait
            {
                id = "transphile",
                group_id = "worldview",
                needs_to_be_explored = true,
                rarity = Rarity.R1_Rare,
                can_be_in_book = true,
                can_be_removed = true,
                can_be_given = true
            };

            transphobic.opposite_traits = new HashSet<CultureTrait>();
            transphobic.opposite_traits.Add(transphile);
            
            transphile.opposite_traits = new HashSet<CultureTrait>();
            transphile.opposite_traits.Add(transphobic);
            
            Add(transphile, new List<string>{"angle", "elf"}, new List<string>{"biome_crystal", "biome_enchanted"});
            Add(transphobic, new List<string>{"orc", "demon"}, new List<string>{"biome_corrupted"});
        }

        private static void Add(CultureTrait trait, List<string> actorAssets=null, List<string> biomeAssets=null)
        {
            trait.path_icon = "ui/Icons/culture_traits/" + trait.id;
            AssetManager.culture_traits.add(trait);
            if(actorAssets != null)
                foreach (var asset in actorAssets)
                {
                    var actorAsset = AssetManager.actor_library.get(asset);
                    if(actorAsset != null)
                        actorAsset.addCultureTrait(trait.id);
                }
            
            if(biomeAssets != null)
                foreach (var asset in biomeAssets)
                {
                    var biomeAsset = AssetManager.biome_library.get(asset);
                    if(biomeAsset != null)
                        biomeAsset.addCultureTrait(trait.id);
                }
        }
    }
}