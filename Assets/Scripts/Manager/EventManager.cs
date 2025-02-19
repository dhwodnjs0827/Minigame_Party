using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    public Action onPlayerInteract;

    public static EventManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }
}
