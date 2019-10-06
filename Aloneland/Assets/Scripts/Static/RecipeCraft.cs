using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Result
{
    public int id;
    public int way; // 0 nothing , 1 picked Item , 2 second item , 3 all items

    public Result(int id, int way)
    {

        this.id = id;
        this.way = way;

    }

}

public class RecipeCraft
{
 
    public struct Recipe
    {
        public int id1;
        public int id2;

        public Recipe(int id1, int id2 )
        {

            this.id1 = id1;
            this.id2 = id2;

        }

    }

    Dictionary<Recipe , Result> recipes = new Dictionary<Recipe, Result>();

    public RecipeCraft()
    {
        //here all craft recipes

       recipes.Add(new Recipe(0, 8), new Result(-4, 0)); // use sleepingbag

       recipes.Add(new Recipe(1,2) , new Result(3 , 2)); // rock + coconut = coconut_open
       recipes.Add(new Recipe(2,1) , new Result(3 , 1)); // coconut + rock = coconut_open
       recipes.Add(new Recipe(4,2), new Result(3, 2)); // sharp_rock + coconut = coconut_open
       recipes.Add(new Recipe(2,4), new Result(3, 1)); // coconut + sharp_rock= coconut_open
       recipes.Add(new Recipe(1,1) , new Result(4, 2)); // rock + rock = sharp_rock
       recipes.Add(new Recipe(17,4) , new Result(6, 3)); // stick with line + sharp_rock = spear
       recipes.Add(new Recipe(5,5) , new Result(11, 3)); // stick + stick = fire
       recipes.Add(new Recipe(4,17) , new Result(6, 3)); // sharp_rock + stick with line = spear
       recipes.Add(new Recipe(7,7) , new Result(8, 3)); // leaf + leaf = sleeping bag
       recipes.Add(new Recipe(6,9) , new Result(10, 2)); // spear + fish = hunted fish
       recipes.Add(new Recipe(10,11) , new Result(12, 1)); // hunted fish + fire = cooked fish
       recipes.Add(new Recipe(7,4) , new Result(16, 1)); // leaf + sharp rock = line
       recipes.Add(new Recipe(4,7) , new Result(16, 2)); // sharp rock + leaf = line
       recipes.Add(new Recipe(5,11) , new Result(-1, 0)); // stick + fire = destory stick
       recipes.Add(new Recipe(5,16) , new Result(17, 3)); // stick + line = stick with line
       recipes.Add(new Recipe(16,5) , new Result(17, 3)); // line + stick = stick with line
       recipes.Add(new Recipe(17,11) , new Result(18, 1)); // stick with line + fire = torch
       recipes.Add(new Recipe(17, 20) , new Result(19, 3)); // stick with line + metal = pickaxe
       recipes.Add(new Recipe(20, 17) , new Result(19, 3)); // metal + stick with line = pickaxe
       recipes.Add(new Recipe(17, 14) , new Result(-1, 1)); // pickaxe + bigrock = nothing
       recipes.Add(new Recipe(19, 21) , new Result(4, 3)); // pickaxe + crushing rock = sharp rock
       recipes.Add(new Recipe(15, 14) , new Result(1, 3)); // dynamite + big rock = bum
       recipes.Add(new Recipe(22, 0) , new Result(-5, 0)); // use smartphone

    }


    // (1 - infinity) - id item
    // (0) - nothing do
    // (-1) - destroy first item
    // (-2) - destroy second item
    // (-infinity - -3) - destroy all items
    public Result GetIdItem(int idItem1 , int idItem2)
    {

        foreach (var recipe in recipes)
        {
            if(recipe.Key.id1 == idItem1 && recipe.Key.id2 == idItem2)
            {
                return recipe.Value;
            }

        }

        return new Result(0 , 0);
    }


}
