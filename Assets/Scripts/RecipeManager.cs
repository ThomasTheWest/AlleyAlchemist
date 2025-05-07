using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<PotionRecipe> recipes = new List<PotionRecipe>();

    void Start()
    {
        // Example: Adding a recipe for a healing potion
        recipes.Add(new PotionRecipe("Love potion", new Dictionary<string, int>
        {
            { "heartblossom", 3 },
            { "glowsprout", 1 },
            { "hair", 1 }
        }, "#EF8CCF"));
        recipes.Add(new PotionRecipe("Dwale potion", new Dictionary<string, int>
        {
            { "mandrake", 1 },
            { "moonlace", 1 },
            { "moonwater", 1 }
        }, "#E7DDFF"));
        recipes.Add(new PotionRecipe("Vermin pact", new Dictionary<string, int>
        {
            { "ratstooth", 2 },
            { "sewer water", 1 },
            { "spidersilk", 1 }
        }, "#70A55B"));
        recipes.Add(new PotionRecipe("Silver tongue potion", new Dictionary<string, int>
        {
            { "snakeskin", 1 },
            { "sage", 2 },
            { "glimmerleaf flower", 1 }
        }, "#E9E9E9"));
        recipes.Add(new PotionRecipe("Thieves elixir", new Dictionary<string, int>
        {
            { "ratstooth", 1 },
            { "ghostwater", 1 },
            { "glimmerleaf flower", 1 }
        }, "#272626"));
        recipes.Add(new PotionRecipe("Clarity brew", new Dictionary<string, int>
        {
            { "moonlace", 1 },
            { "glowsprout", 1 },
            { "ghostwater", 1 }
        }, "#FAD1D6"));
        recipes.Add(new PotionRecipe("Confession tonic", new Dictionary<string, int>
        {
            { "witchSalt", 1 },
            { "sage", 1 },
            { "snakeskin", 1 }
        }, "#5DE2E7"));
        recipes.Add(new PotionRecipe("Numb tonic", new Dictionary<string, int>
        {
            { "toad spit drop", 1 },
            { "moonlace", 1 },
            { "mandrake", 1 }
        }, "#FEBC59"));
        recipes.Add(new PotionRecipe("Grime brew", new Dictionary<string, int>
        {
            { "heartblossom", 3 },
            { "moonlace", 2 },
            { "moonwater", 1 }
        }, "#FFECA1"));
        recipes.Add(new PotionRecipe("Surge serum", new Dictionary<string, int>
        {
            { "snakeskin", 1 },
            { "impshroom", 1 },
            { "ghostwater", 1 }
        }, "#D62D2D"));
        recipes.Add(new PotionRecipe("Hiccup tonic", new Dictionary<string, int>
        {
            { "glowsprout", 1 },
            { "sage", 2 },
            { "witchSalt", 1 }
        }, "#CA90DA"));
    }

    public PotionRecipe GetRecipe(string potionName)
    {
        return recipes.Find(recipe => recipe.potionName == potionName);
    }
}
