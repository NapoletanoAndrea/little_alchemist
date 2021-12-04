using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour {
	public static UIInventory Instance;
	[SerializeField] private Inventory inventory;
	[SerializeField] private GameObject inventoryContainer;
	[SerializeField] private ItemContainer itemContainer;
	[SerializeField] private float deltaX;
	[SerializeField] private float deltaY;

	private RectTransform itemContainerRect;
	private List<GameObject> itemContainers = new List<GameObject>();

	[SerializeField] private InputReaderSO inputReader;
	[SerializeField] private InventoryEventChannelSO inventoryEventChannel;

	private void Awake() {
		Instance = this;
		itemContainerRect = itemContainer.GetComponent<RectTransform>();
		inputReader.inventoryEvent += ToggleInventory;
		inventoryEventChannel.OnInventoryChanged += RefreshInventory;
	}

	private void ToggleInventory() {
		inventoryContainer.SetActive(!inventoryContainer.activeSelf);
	}

	public void SetInventory(Inventory inventory) {
		this.inventory = inventory;
	}

	private void RefreshInventory(Inventory inventory) {
		Debug.Log("Refreshed");
		if (itemContainers.Count > 0) {
			foreach (var container in itemContainers) {
				if (itemContainers.Count <= 0) {
					break;
				}
				Destroy(container);
			}
		}
		itemContainers.Clear();
		
		for (int i = 0; i < inventory.items.Count; i++) {
			RectTransform containerInstance = Instantiate(itemContainer.gameObject, inventoryContainer.transform).GetComponent<RectTransform>();
			var containerAnchoredPosition = itemContainerRect.anchoredPosition;
			containerInstance.anchoredPosition = new Vector2(containerAnchoredPosition.x + deltaX * (i + 1), containerAnchoredPosition.y - deltaY * i);
			var itemContainerInstance = containerInstance.GetComponent<ItemContainer>();
			itemContainerInstance.itemNameText.text = inventory.items[i].item.itemName;
			itemContainerInstance.itemDescriptionText.text = inventory.items[i].item.description;
			itemContainerInstance.itemIcon.sprite = inventory.items[i].item.sprite;
			GameObject containerGO;
			(containerGO = containerInstance.gameObject).SetActive(true);
			itemContainers.Add(containerGO);
		}
	}

	private void OnDisable() {
		inputReader.inventoryEvent -= ToggleInventory;
		inventoryEventChannel.OnInventoryChanged -= RefreshInventory;
	}
}
