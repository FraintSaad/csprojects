﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CakesAdvanced.Models
{
    internal class Storage
    {
        const string PATH = "ingredients.json";
        private List<Ingredient> _allIngredients;

        public void SaveIngredients()
        {
            var serializedIngredients = JsonConvert.SerializeObject(_allIngredients);
            File.WriteAllText(PATH, serializedIngredients);
        }
        public void LoadIngredients()
        {
            if(File.Exists(PATH))
            {
                var serializedIngredients = File.ReadAllText(PATH);
                var deserializedIngredients = JsonConvert.DeserializeObject<List<Ingredient>>(PATH);
                if(deserializedIngredients != null)
                {
                    _allIngredients= deserializedIngredients;
                }
            }
            else { throw new Exception("Такого файла не существует!"); }
        }
        public Storage()
        {
            LoadIngredients();
        }
        public Ingredient? FindIngredientByName(string nameOfIngredient)
        {
            return _allIngredients.Find(i => i.Name.ToLower() == nameOfIngredient.ToLower());
        }
        public Ingredient GetIngredientByName(string nameOfIngredient)
        {
            return _allIngredients.First(someWord =>someWord.Name.ToLower() == nameOfIngredient.ToLower());
        }
        public void AddIngredients(Ingredient ingredient)
        {
            var existingIngredient = FindIngredientByName(ingredient.Name);
            if(existingIngredient != null)
            {
                existingIngredient.Quantity += ingredient.Quantity;
            }
            else
            {
                _allIngredients.Add(ingredient);
            }
            SaveIngredients();
        }
        public void AddIngredient(List<Ingredient> ingredients)
        {
            foreach(var ingredient in ingredients)
            {
                AddIngredients(ingredient);
            }
        }
        public void VerifyIngredientsAvailability(Dictionary<string, int> neededIngredients)
        {
            
            foreach(var i in neededIngredients)
            {
                string ingredientName= i.Key;
                int neededQuantity= i.Value;
                Ingredient foundedIngredient = FindIngredientByName(ingredientName);

                if(foundedIngredient == null)
                {
                    throw new Exception("Ингредиент отсутствует на складке");
                }
                if(foundedIngredient.Quantity<neededQuantity)
                {
                    throw new Exception("недостаточное количество ингредиента на складе");
                }
            }
        }
        public List<Ingredient> TakeIngredients(Dictionary<string, int> neededIngredients)
        {
           VerifyIngredientsAvailability(neededIngredients);
            List<Ingredient> ingredientsToReturn = new List<Ingredient>();
            foreach (var i in neededIngredients)
            {
                string ingredientName= i.Key;
                int neededQuantity= i.Value;
                Ingredient gettingIngredient = GetIngredientByName(ingredientName);

                if(gettingIngredient != null) 
                {
                    gettingIngredient.Quantity -= neededQuantity;

                    Ingredient takenIngredient = new Ingredient
                    {
                        Name = gettingIngredient.Name,
                        Cost = gettingIngredient.Cost,
                        Quantity = gettingIngredient.Quantity,
                    };
                    ingredientsToReturn.Add(takenIngredient);
                    
                }

            }
            SaveIngredients();
            return ingredientsToReturn;
        }
    }
}
