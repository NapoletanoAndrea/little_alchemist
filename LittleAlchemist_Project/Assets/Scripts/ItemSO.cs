using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject {
    public string itemName;
    [TextArea] public string description;
    public GameObject prefab;

    public void OnPickedUp() {
        Debug.Log(itemName + " has been picked up!");
    }
}
