using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehaviour : MonoBehaviour {
    [SerializeField] private UnityEvent triggerEvent;

    public void OnTriggerEnter(Collider other) {
        triggerEvent?.Invoke();
    }
}
