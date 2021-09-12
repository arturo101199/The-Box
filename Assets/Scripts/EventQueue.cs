using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour
{
    [System.Serializable]
    struct EventPair
    {
        [SerializeField] GameEvent gameEvent;
        [SerializeField] float timeDelay;

        [SerializeField] string infoString;

        public EventPair(GameEvent gameEvent, float timeDelay)
        {
            this.gameEvent = gameEvent;
            this.timeDelay = timeDelay;
            infoString = gameEvent.GetType().ToString();
        }
    }

    [SerializeField] List<EventPair> events = new List<EventPair>();
    [SerializeField] WallsController wallsController = null;

    [ContextMenu("GenerateLevel")]
    void generateEvents()
    {
        events.Clear();
        string type = "Wall"; //Leer desde Json
        if (type == "Spawn")
        {
            Vector3 position = Vector3.zero; //Leer desde JSON
            string obj = "RS"; //Leer desde JSON
            float[] arguments = new float[] { 0, 5 }; //Leer desde JSON
            float timeDelay = 5f; //Leer desde JSON
            events.Add(new EventPair(new SpawnEvent(position, obj, arguments), timeDelay));
        }
        else if(type == "Wall")
        {
            Direction direction = 0; //Leer desde JSON
            bool open = false; //Leer desde JSON
            float timeDelay = 3f;
            events.Add(new EventPair(new WallEvent(direction, open, wallsController), timeDelay));
        }
    }
}
