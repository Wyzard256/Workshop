﻿namespace Workshop
{
    using System;
    using UnityEngine;

    using Workshop.KIS;
    using Workshop.Recipes;

    [KSPScenario(ScenarioCreationOptions.AddToAllGames, new [] {
			GameScenes.SPACECENTER,
			GameScenes.EDITOR,
			GameScenes.FLIGHT,
			GameScenes.TRACKSTATION
		})]
    public class WorkshopSettings : ScenarioModule
    {
        public static bool IsKISAvailable
        {
            get;
            private set;
        }

        public override void OnAwake()
        {
            base.OnAwake();
            try
            {
                IsKISAvailable = KISWrapper.Initialize();

            }
            catch (Exception ex)
            {
                IsKISAvailable = false;
                Debug.LogError("[OSE] - Error while checking for KIS. Workshop will be disabled");
                Debug.LogException(ex);
            }
        }
    }
}
