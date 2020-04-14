using Games.LeagueOfLegends.ChampionModules.Common;
using Games.LeagueOfLegends.Model;
using LedDashboardCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games.LeagueOfLegends.ChampionModules
{
    [Champion(CHAMPION_NAME)]
    class AzirModule : ChampionModule
    {

        // Change to whatever champion you want to implement
        public const string CHAMPION_NAME = "Azir";

        // Variables

        // Champion-specific Variables


        /// <summary>
        /// Creates a new champion instance.
        /// </summary>
        /// <param name="ledCount">Number of LEDs in the strip</param>
        /// <param name="gameState">Game state data</param>
        /// <param name="preferredLightMode">Preferred light mode</param>
        /// <param name="preferredCastMode">Preferred ability cast mode (Normal, Quick Cast, Quick Cast with Indicator)</param>
        public static AzirModule Create(int ledCount, GameState gameState, LightingMode preferredLightMode, AbilityCastPreference preferredCastMode = AbilityCastPreference.Normal)
        {
            return new AzirModule(ledCount, gameState, preferredLightMode, preferredCastMode);
        }


        private AzirModule(int ledCount, GameState gameState, LightingMode preferredLightMode, AbilityCastPreference preferredCastMode)
            : base(ledCount, CHAMPION_NAME, gameState, preferredLightMode, preferredCastMode, true)
        {
            // Initialization for the champion module occurs here.
        }

        protected override AbilityCastMode GetQCastMode() => AbilityCastMode.PointAndClick();
        protected override AbilityCastMode GetWCastMode() => AbilityCastMode.Normal();
        protected override AbilityCastMode GetECastMode() => AbilityCastMode.Instant();
        protected override AbilityCastMode GetRCastMode() => AbilityCastMode.Normal();

        protected override async Task OnCastQ()
        {
            await RunAnimationOnce("q_cast", timeScale: 1.5f);
        }
        protected override async Task OnCastW()
        {
            await RunAnimationOnce("w_cast", timeScale: 0.5f);
        }
        protected override async Task OnCastE()
        {
            await RunAnimationOnce("e_cast", timeScale: 1.6f);
        }
        protected override async Task OnCastR()
        {
            await RunAnimationOnce("r_cast", timeScale: 0.3f);
        }
    }
}