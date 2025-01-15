using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public void GameControllerInit()
    {
        // Get all system managers
        IEnumerable<ISystemManager> systemManagers = ServiceLocator.Instance.GetServices<ISystemManager>();
        foreach (var systemManager in systemManagers)
        {
            systemManager.Init();
            systemManager.StartSystemInit();
        }

        // Get all combat managers
        IEnumerable<ICombatManager> combatManagers = ServiceLocator.Instance.GetServices<ICombatManager>();
        foreach (var combatManager in combatManagers)
        {
            combatManager.Init();
            combatManager.StartCombatInit();
        }

        // Get squad managers by index
        ISquadManager playerSquadManager = ServiceLocator.Instance.GetService<ISquadManager>(0);
        playerSquadManager?.Init();
        playerSquadManager?.StartSquadInit();

        ISquadManager aiSquadManager = ServiceLocator.Instance.GetService<ISquadManager>(1);
        aiSquadManager?.Init();
        aiSquadManager?.StartSquadInit();
    }
}
