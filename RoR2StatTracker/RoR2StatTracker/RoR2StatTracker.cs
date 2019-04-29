using System;
using BepInEx;
using RoR2;

namespace RoR2StatTracker
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.LeoneShamoth.RoR2StatTracker", "Risk of Rain 2 Stat Tracker", "1.0.0")]

    public class RoR2StatTracker : BaseUnityPlugin
    {
        private int[] currentInventory = new int[78];
        public void Awake()
        {
            Chat.AddMessage("Loaded Risk of Rain 2 Stat Tracker!");
            On.RoR2.Inventory.GiveItem += CatchItemGained;
            On.RoR2.Inventory.RemoveItem += CatchItemRemoved;

        }

        private void CatchItemGained(On.RoR2.Inventory.orig_GiveItem orig, Inventory self, ItemIndex itemIndex, int count)
        {
            orig.Invoke(self, itemIndex, count);

            if ((int)itemIndex != 47 && (int)itemIndex != 48)
            {
                Chat.AddMessage("Item #: " + (int)itemIndex + " Item Count: " + count);
            }
        }

        private void CatchItemRemoved(On.RoR2.Inventory.orig_RemoveItem orig, Inventory self, ItemIndex itemIndex, int count)
        {
            orig.Invoke(self, itemIndex, count);

            if ((int)itemIndex != 47 && (int)itemIndex != 48)
            {
                Chat.AddMessage("Item #: " + (int)itemIndex + " Item Count: " + (-count));
            }
        }
    }
}
