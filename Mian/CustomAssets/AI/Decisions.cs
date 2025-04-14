using System.Collections.Generic;
using HarmonyLib;
using Topic_of_Identity.Mian;

namespace Better_Loving.Mian.CustomAssets.AI;

public class Decisions
{
    private static List<DecisionAsset> _decisionAssets = new List<DecisionAsset>();

    public static void Init()
    {
        Add(new DecisionAsset
        {
            id = "insult_identity",
            priority = NeuroLayer.Layer_2_Moderate,
            path_icon = "ui/Icons/culture_traits/transphobic",
            cooldown = 30,
            action_check_launch = actor => actor.hasCultureTrait("transphobic") && !Util.IsTrans(actor),
            weight = 0.5f,
            list_civ = true,
            only_safe = true
        });
        AssetManager.subspecies_traits.get("wernicke_area").addDecision("insult_identity");

        Finish();
    }
    
    private static void Finish()
    {
            
        for(int i = 0; i < _decisionAssets.Count; i++)
        {
            var decisionAsset = _decisionAssets[i];
            decisionAsset.priority_int_cached = (int) decisionAsset.priority;
            decisionAsset.has_weight_custom = decisionAsset.weight_calculate_custom != null;
            if (!decisionAsset.unique)
            {
                if (decisionAsset.list_baby)
                    AssetManager.decisions_library.list_only_children = AssetManager.decisions_library.list_only_children.AddToArray(decisionAsset);
                else if (decisionAsset.list_animal)
                    AssetManager.decisions_library.list_only_animal = AssetManager.decisions_library.list_only_animal.AddToArray(decisionAsset);
                else if (decisionAsset.list_civ)
                    AssetManager.decisions_library.list_only_civ = AssetManager.decisions_library.list_only_civ.AddToArray(decisionAsset);
                else
                    AssetManager.decisions_library.list_only_city = AssetManager.decisions_library.list_only_city.AddToArray(decisionAsset);
            }
        }
    }

    
    private static void Add(DecisionAsset asset)
    {
        AssetManager.decisions_library.add(asset);
        asset.decision_index = AssetManager.decisions_library.list.Count-1;
        _decisionAssets.Add(asset);
    }
}