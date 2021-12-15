using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Recipe")]
public class RecipeSO : ScriptableObject {
    public string potionName;
    public ItemSO[] baseIngredients;
    public ItemSO[] additionalIngredients;
    public Color potionColor;
}
