using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour {
	[SerializeField] private VoidEvent[] events;
	
	private void OnEnable() {
		foreach (VoidEvent e in events) {
			if (e.channel != null) {
				e.channel.OnEventRaised += Respond;
			}
		}
	}

	private void OnDisable()
	{
		foreach (VoidEvent e in events) {
			if (e.channel != null) {
				e.channel.OnEventRaised -= Respond;
			}
		}
	}

	private void Respond()
	{
		foreach (VoidEvent e in events) {
			if (e.OnEventRaised != null) {
				e.OnEventRaised.Invoke();
			}
		}
	}
}

[System.Serializable]
public class VoidEvent {
	public VoidEventChannelSO channel = default;
	public UnityEvent OnEventRaised;
}
