using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour, IInteractable {
	[SerializeField] private VoidEventChannelSO boardInteractEvent;
	[SerializeField] private VoidEventChannelSO boardExitEvent;
	private bool isInteracting;
	
	public void Interact() {
		if (isInteracting) {
			boardExitEvent?.RaiseEvent();
			isInteracting = false;
			return;
		}
		boardInteractEvent?.RaiseEvent();
		isInteracting = true;
	}
}
