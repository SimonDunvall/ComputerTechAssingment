using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnRate;

    private class SpawnerBaker : Baker<SpawnAuthoring>
    {
        public override void Bake(SpawnAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Spawner
            {
                Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic), SpawnPosition = float2.zero,
                NextSpawnTime = 0, SpawnRate = authoring.SpawnRate
            });
        }
    }
}