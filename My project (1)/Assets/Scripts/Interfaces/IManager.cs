using System.Collections;
using System.Security.Cryptography;

public interface IManager
{
    IEnumerator Init();
}

public interface ISystemManager : IManager
{
    void StartSystemInit();
}

public interface ICombatManager : IManager
{
    void StartCombatInit();
}

public interface ISquadManager : IManager
{
    void StartSquadInit();
}