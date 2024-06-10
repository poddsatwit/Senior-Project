using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

//Events are to be quick changes effecting all players
public class Event
{
    public int id;
    public string eventName;
    public string eventDescription;


    public Event(int id, string eventName, string eventDescription)
    {
        this.id = id;
        this.eventName = eventName;
        this.eventDescription = eventDescription;
    }
}