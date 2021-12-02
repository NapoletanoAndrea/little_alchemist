using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    CUBE,
    SPHERE
}

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject {
    public ItemType itemType;
    [TextArea] public string description;
    public GameObject prefab;

    public void OnPickedUp() {
        Debug.Log(itemType + " has been picked up!");
    }
}
