using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionRecipe
{
    public string potionName;
    public Dictionary<string, int> ingredients; // Ingredient name (string) and required quantity (int)
    public Color potionColor; 

    public PotionRecipe(string potionName, Dictionary<string, int> ingredients, string hexColor)
    {
        this.potionName = potionName;
        this.ingredients = ingredients;
        this.potionColor = HexToColor(hexColor);
    }
    // Hex string to Color converter
    private Color HexToColor(string hex)
    {
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1); // Remove the '#' character
        }

        if (hex.Length != 6 && hex.Length != 8)
        {
            Debug.LogWarning($"Invalid hex color format: {hex}. Defaulting to black.");
            return Color.black; // Default to black if invalid
        }

        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        byte a = (hex.Length == 8) ? byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber) : (byte)255;

        return new Color32(r, g, b, a);
    }
    // Method to check if the recipe matches the current cauldron ingredient counts
    public bool Matches(Dictionary<string, int> currentCounts)
    {
        foreach (var ingredient in ingredients)
        {
            if (!currentCounts.ContainsKey(ingredient.Key) || currentCounts[ingredient.Key] < ingredient.Value)
            {
                return false;
            }
        }
        return true;
    }
}
