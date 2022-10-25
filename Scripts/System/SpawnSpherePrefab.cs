using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Core;

public partial class SpawnSpherePrefab : SystemBase
{
    private Entity _spherePrefab;

    //private SpawnTimer spawnTimer;
    private float _timer = 2;
    private float _timePassed = 0f;


    protected override void OnStartRunning()
    {
        _spherePrefab = GetSingleton<SpherePrefab>().Value;
        //_timer = spawnTimer.GetSpawnTimer();
    }
    protected override void OnUpdate()
    {
        _timePassed += Time.DeltaTime;
        Debug.Log(_timePassed);
        if (_timePassed > _timer)
        {
            var newSphere = EntityManager.Instantiate(_spherePrefab);
            _timePassed = 0f;
        }
        
        // Ignore
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var newCapsule = EntityManager.Instantiate(_spherePrefab);
        }
        
    }
}
