using UnityEngine;

public class SpawnEvent : GameEvent
{
    Vector3 spawnPosition;
    string pool;
    float[] arguments;

    public SpawnEvent(Vector3 spawnPosition, string pool, float[] arguments)
    {
        this.spawnPosition = spawnPosition;
        this.pool = pool;
        
        this.arguments = arguments;
    }

    public override void doEvent()
    {
        GameObject obj = ObjectPooler.GetInstance().SpawnObject(pool, spawnPosition, Quaternion.identity);
        obj.GetComponent<IEnemySpawn>().SetInfo(arguments);
    }
}