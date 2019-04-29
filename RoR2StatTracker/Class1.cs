using BepInEx;
using RoR2;
using UnityEngine;

namespace RoR2StatTracker
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.leoneShamoth.RoR2StatTracker", "RoR2StatTracker", "1.0.0")]

    public class RoR2StatTracker : BaseUnityPlugin
    {
       public void Awake()
        {
            Chat.AddMessage("Loaded RoR2 Stat Tracker");
            On.EntityStates.Huntress.ArrowRain.OnEnter += (orig, self) =>
            {
                Chat.AddMessage("Cast Arrow Rain");
                orig(self);
            };

        }
    }
}
