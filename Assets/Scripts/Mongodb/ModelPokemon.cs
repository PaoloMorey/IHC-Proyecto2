using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ModelPokemon
{
    public ModelPokemon(PokemonVariables other)
    {
        this.name = other.name;
        this.level = other.level;
        this.capturedAt = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
    }

    
    public ObjectId _id { set; get; }
    public int level { set; get; }
    public string name { set; get; }
    public string capturedAt { set; get; }
}
