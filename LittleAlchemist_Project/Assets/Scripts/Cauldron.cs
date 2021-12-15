using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour {
    [SerializeField] private Material potionMaterial;
    private Color startColor;

    [SerializeField] private RecipeSO[] recipes;
    private List<ItemSO> insertedItems = new List<ItemSO>();

    [SerializeField] private GameObject craftText;
    [SerializeField] private Text potionText;

    private string craftablePotionName;
    private bool canCraft;

    private void Awake() {
        startColor = potionMaterial.color;
    }

    private void OnTriggerEnter(Collider other) {
        ItemInstance itemInstance = other.GetComponent<ItemInstance>();
        if (itemInstance != null) {
            craftText.SetActive(false);
            potionText.gameObject.SetActive(false);
            ItemSO item = itemInstance.item;
            insertedItems.Add(item);
            Destroy(other.gameObject);
            foreach (var recipe in recipes) {
                List<ItemSO> requiredItems = new List<ItemSO>();
                foreach (var i in recipe.baseIngredients) {
                    requiredItems.Add(i);
                }
                foreach (var i in recipe.additionalIngredients) {
                    requiredItems.Add(i);
                }
                if (requiredItems.Count != insertedItems.Count) {
                    return;
                }
                for (int i = 0; i < insertedItems.Count; i++) {
                    if (insertedItems[i] != requiredItems[i]) {
                        break;
                    }
                    if (i == insertedItems.Count - 1) {
                        craftablePotionName = recipe.potionName;
                        canCraft = true;
                        potionMaterial.color = recipe.potionColor;
                    }
                }
            }
        }
    }

    public void Craft() {
        if (!canCraft) {
            return;
        }
        
        craftText.SetActive(true);
        potionText.gameObject.SetActive(true);
        potionText.text = craftablePotionName;
        
        insertedItems.Clear();
        potionMaterial.color = startColor;
        canCraft = false;
    }

    private void OnDisable() {
        potionMaterial.color = startColor;
    }
}
