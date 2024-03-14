using UnityEngine;
using System.Collections;
using CommonFramework.Runtime;
using Framework.Map;
using System.Collections.Generic;
using Framework;

public class EnemySystem : MonoSingleton<EnemySystem>
{
    private List<EnemySpawnConfigItem> enemySpawnConfigItems;

    private Coroutine spawnJobs;

    private float currentGameTime;


    public void Config(IMap currentMap)
    {
        currentMap.GetEnemySpawnConfig();
        // currentMap
    }

    protected override void OnCreate()
    {
        this.spawnJobs = this.StartCoroutine(UpdateEnemySystem());
    }


    protected override void OnDestroyInstance()
    {
        enemySpawnConfigItems = null;
        StopAllCoroutines();
        spawnJobs = null;
    }

    public void StopEnemySystem()
    {
        StopCoroutine(spawnJobs);
    }

    /// <summary>
    /// we should use game time to control enemy spawn
    /// </summary>
    /// <param name="gameTime"></param>
    public void UpdateEnemySystem(float gameTime)
    {
        currentGameTime = gameTime;
    }

    private IEnumerator UpdateEnemySystem()
    {
        yield return null;

    }

}
