using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ac_cauldron : MonoBehaviour
{
    [Header("Ingredients")]
    [Header("Ingredients")]
    public Dictionary<string, int> ingredientCounts = new Dictionary<string, int>();

    //public int moonwater = 0;
    //public int moonlace = 0;
    //public int mandrake = 0;
    //public int heartblossom = 0;
    //public int growsprout = 0;
    //public int ivy = 0;
    //public int carrot = 0;
    //public int witchSalt = 0;
    //public int ratstooth = 0;
    //public int impshroom = 0;
    //public int moonlacebloom = 0; 

    //private int ingredCount = 0;

    [Header("Material")]
    [SerializeField] Material green;
    [SerializeField] Material red;
    [SerializeField] Material grey;
    private Renderer renderLiquid;
    private RecipeManager recipeManager;

    void Start()
    {
        renderLiquid = GetComponent<Renderer>();
        if (renderLiquid == null) Debug.LogError("Renderer not found!");

        recipeManager = FindObjectOfType<RecipeManager>();
        if (recipeManager == null) Debug.LogError("RecipeManager not found!");
        ingredientCounts.Add("moonwater",0);
        ingredientCounts.Add("mandrake",0);
        ingredientCounts.Add("moonlace",0);
        ingredientCounts.Add("heartblossom",0);
        ingredientCounts.Add("glowsprout",0);
        ingredientCounts.Add("ivy",0);
        ingredientCounts.Add("carrot", 0);
        ingredientCounts.Add("witchSalt", 0);
        ingredientCounts.Add("ratstooth", 0);
        ingredientCounts.Add("impshroom", 0);
        ingredientCounts.Add("ghostwater", 0);
        ingredientCounts.Add("glimmerleaf flower",0);
        ingredientCounts.Add("sewer water", 0);
        ingredientCounts.Add("sage", 0);
        ingredientCounts.Add("toad spit drop", 0);
        ingredientCounts.Add("snakeskin", 0);
        ingredientCounts.Add("hair",0);
        ingredientCounts.Add("spidersilk",0);

    }
    void Update()
    {
        // Check recipes
        if (recipeManager == null) return;

        foreach (var recipe in recipeManager.recipes)
        {
            if (recipe != null && recipe.Matches(ingredientCounts))
            {
                Debug.Log($"Potion Created: {recipe.potionName}");
                if (renderLiquid != null && renderLiquid.material != null)
                {
                    renderLiquid.material.color = recipe.potionColor;
                }
                return;
            }
        }

        if (renderLiquid != null && renderLiquid.material != null)
        {
            renderLiquid.material.color = Color.grey; // Default color
        }

        renderLiquid.material = grey; // Default color if no recipe matches
        //ingredCount = ivy + carrot;

        //if (ingredCount >= 3)
        //{
        //    if (ivy == 2 & carrot == 1)
        //    {
        //        renderLiquid.material = green;
        //    }
        //    else
        //    {
        //        renderLiquid.material = red;
        //    }
        //}
        //else
        //{
        //    renderLiquid.material = grey;
        //}
    }
    public void AddIngredient(string ingredientName)
    {
        if (ingredientCounts.ContainsKey(ingredientName))
        {
            ingredientCounts[ingredientName]++;
        }
        else
        {
            Debug.LogWarning($"Ingredient {ingredientName} is not registered in the cauldron!");
        }
    }
    // Handle liquid particle collisions
    void OnParticleCollision(GameObject other)
    {
        // Check if the particle belongs to a pouring bottle
        potionPour bottle = other.GetComponentInParent<potionPour>();
        if (bottle != null && bottle.IsPouring())
        {
            AddIngredient(bottle.GetIngredientName());
        }
    }
    void OnTriggerEnter(Collider col)
    {
        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null && interactable.code == 0)
        {
            //add sound code here wen we gots sounds
            interactable.Interact();
        }
        //need an elseif that makes the item bounce off if it isn't an ingredient
    }
}
