using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventManager : MonoBehaviour {
    public int numOfTriggersRequired;
    private int numOfTriggers;
    public UnityEvent triggerEvent;
    [SerializeField] private PickedUpEventChannelSO pickedUpEventChannel;

    private void Awake() {
        pickedUpEventChannel.OnPickedUp += IncrementTrigger;
    }

    public void IncrementTrigger() {
        numOfTriggers++;
        if (numOfTriggers == numOfTriggersRequired) {
            triggerEvent?.Invoke();
        }
    }
}
