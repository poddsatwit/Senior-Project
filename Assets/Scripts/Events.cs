using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Event
{
    public int id;
    public string eventName;
    public string eventDescription;

}

    public Event(int id, string eventName, string eventDescription)
    {
        this.id = id;
        this.eventName = eventName;
        this.eventDescription = eventDescription;
    }
}
