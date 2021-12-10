using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/On Picked Up Event Channel")]
public class PickedUpEventChannelSO : ScriptableObject {
    public UnityAction OnPickedUp;
    public UnityAction<ItemSO, int, ItemInstance> OnPickedUpItem;

    public void RaiseEvent(ItemSO item, int amount, ItemInstance itemInstance) {
        OnPickedUpItem?.Invoke(item, amount, itemInstance);
        OnPickedUp?.Invoke();
    }
}
