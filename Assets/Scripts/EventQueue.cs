using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EventQueue : MonoBehaviour
{
    [System.Serializable]
    struct EventPair
    {
        public GameEvent gameEvent;
        public float timeDelay;

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

    private void Start()
    {
        generateEvents();
        foreach (var levelEvent in events)
        {
            levelEvent.gameEvent.doEvent();
        }
    }

    [ContextMenu("GenerateLevel")]
    void generateEvents()
    {
        events.Clear();
        TextAsset file = Resources.Load("Level1") as TextAsset;
        JSONNode level = JSON.Parse(file.text);
        JSONNode jsonEvents = level["events"].AsArray;
        foreach (JSONNode levelEvent in jsonEvents)
        {
            string type = levelEvent["type"];
            if (type == "Spawn")
            {
                Vector3 position = new Vector3(levelEvent["position"][0].AsFloat, levelEvent["position"][1].AsFloat, levelEvent["position"][2].AsFloat);
                string obj = levelEvent["object"];
                JSONArray jsonArguments = levelEvent["parameters"].AsArray;
                print(jsonArguments.Count);
                float[] arguments = new float[jsonArguments.Count];
                for (int i = 0; i < arguments.Length; i++)
                {
                    arguments[i] = jsonArguments[i].AsFloat;
                }
                float timeDelay = levelEvent["timeDelay"].AsFloat;
                EventPair newEvent = new EventPair(new SpawnEvent(position, obj, arguments), timeDelay);
                events.Add(newEvent);
            }
            else if(type == "Wall")
            {
                JSONNode arguments = levelEvent["arguments"];
                Direction direction = (Direction)arguments["direction"].AsInt;
                bool open = arguments["open"].AsBool;
                float timeDelay = arguments["timeDelay"].AsFloat;
                EventPair newEvent = new EventPair(new WallEvent(direction, open, wallsController), timeDelay);
                events.Add(newEvent);
            }
        }
    }
}
