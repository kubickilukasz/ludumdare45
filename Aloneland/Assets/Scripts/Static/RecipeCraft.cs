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
       recipes.Add(new Recipe(5,4) , new Result(6, 3)); // stick + sharp_rock = spear
       recipes.Add(new Recipe(4,5) , new Result(6, 3)); // sharp_rock + stick = spear
       recipes.Add(new Recipe(7,7) , new Result(8, 3)); // leaf + leaf = sleeping bag

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
