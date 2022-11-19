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
        this.capturedAt = System.DateTime.Now;
    }

    public ObjectId _id { set; get; }
    public int level { set; get; }
    public string name { set; get; }
    public DateTime capturedAt { set; get; }
    public string playerId { set; get; }
    /* 0 1 2 3 4 5 (equipo principal) y -1 para box */
    public int teamPos { set; get; }
}
