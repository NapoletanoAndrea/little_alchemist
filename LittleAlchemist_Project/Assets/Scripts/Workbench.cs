using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour, IInteractable {
	[SerializeField] private VoidEventChannelSO workbenchEventChannel;

	public void Interact() {
		workbenchEventChannel?.RaiseEvent();
	}
}
