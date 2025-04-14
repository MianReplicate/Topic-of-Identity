
namespace Better_Loving.Mian.CustomAssets
{
    public class Happiness
    {
        public static void Init()
        {
            Add(new HappinessAsset
            {
                id = "insulted_for_identity",
                value = -35,
                pot_task_id = "crying",
                path_icon = "ui/Icons/iconCrying",
                ignored_by_psychopaths = true,
                pot_amount = 5,
                show_change_happiness_effect = true,
                dialogs_amount = 4
            });
        }

        private static void Add(HappinessAsset asset)
        {
            AssetManager.happiness_library.add(asset);
            if(asset.path_icon == null)
                asset.path_icon = "ui/Icons/status"+asset.id;
            asset.index = AssetManager.happiness_library.list.Count-1;
        }
    }
}