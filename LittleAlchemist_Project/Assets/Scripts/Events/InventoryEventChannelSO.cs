using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/Inventory Event Channel")]
public class InventoryEventChannelSO : ScriptableObject {
    public UnityAction<Inventory> OnInventoryChanged;

    public void RaiseEvent(Inventory inventory) {
        OnInventoryChanged?.Invoke(inventory);
    }
}
