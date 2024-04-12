using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }
    
    private Dictionary<GameEvent, UnityEvent<object>> eventDictionary = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddListener(GameEvent gameEvent, UnityAction<object> listener)
    {
        if (!eventDictionary.ContainsKey(gameEvent))
            eventDictionary[gameEvent] = new UnityEvent<object>();
        eventDictionary[gameEvent].AddListener(listener);
    }
    
    public void AddListener(GameEvent gameEvent, UnityAction listener)
    {
        AddListener(gameEvent, _ => listener.Invoke());
    }

    public void RemoveListener(GameEvent gameEvent, UnityAction<object> listener)
    {
        if (eventDictionary.ContainsKey(gameEvent))
            eventDictionary[gameEvent].RemoveListener(listener);
    }
    
    public void RemoveListener(GameEvent gameEvent, UnityAction listener)
    {
        RemoveListener(gameEvent, _ => listener.Invoke());
    }

    public void TriggerEvent(GameEvent gameEvent, object eventData = null)
    {
        if (eventDictionary.ContainsKey(gameEvent))
            eventDictionary[gameEvent].Invoke(eventData);
    }
    
    private void ClearAllListeners()
    {
        foreach (var unityEvent in eventDictionary.Values)
        {
            unityEvent.RemoveAllListeners();
        }
        eventDictionary.Clear();
    }
}