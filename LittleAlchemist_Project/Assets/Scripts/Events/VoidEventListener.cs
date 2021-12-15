using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour {
	[SerializeField] private VoidEvent[] events;
	private int eventIndex;
	
	private void OnEnable() {
		foreach (VoidEvent e in events) {
			if (e.channel != null) {
				e.channel.OnEventRaised += e.OnEventRaised.Invoke;
			}
		}
	}

	private void OnDisable() {
		foreach (VoidEvent e in events) {
			if (e.channel != null) {
				e.channel.OnEventRaised -= e.OnEventRaised.Invoke;
			}
		}
	}
}

[System.Serializable]
public class VoidEvent {
	public VoidEventChannelSO channel = default;
	public UnityEvent OnEventRaised;
}
