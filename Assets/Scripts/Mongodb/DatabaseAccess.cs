using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;

public class DatabaseAccess : MonoBehaviour
{
    private const string MONGO_URI = "mongodb+srv://admin:uiXQhRYHEpbXQO0o@pokemonvr.wxfm8vr.mongodb.net/test";
    private const string DATABASE_NAME = "PokemonVR_DB";
    private MongoClient client;
    private IMongoDatabase db;

    void Start()
    {
        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);
        // QUERY POKÉMON MÁS RECIENTES
        // List<ModelPokemon> res  = db.GetCollection<ModelPokemon>("Pokemon").Find(pokemon => true).SortByDescending(i => i.capturedAt).ToList();
        // foreach (ModelPokemon e in res)
        //     Debug.Log(e.capturedAt);
    }

    void OnApplicationQuit()
    {
        IMongoCollection<ModelPlayer> userCollection = db.GetCollection<ModelPlayer>("Player");
        ModelPlayer modelPlayer = new ModelPlayer();
        modelPlayer.oculusId = "OCULUS14";
        modelPlayer.name = "prueba";
        try {
            userCollection.InsertOne(modelPlayer);
        }
        catch {}

        IMongoCollection<ModelPokemon> pokemonCollection = db.GetCollection<ModelPokemon>("Pokemon");
        List<PokemonVariables> listPokemon = FindObjectsOfType<PokemonManager>()[0].GetPokemon();
        foreach (PokemonVariables pokemon in listPokemon)
        {
            ModelPokemon modelPokemon = new ModelPokemon();
            modelPokemon.name = pokemon.name;
            modelPokemon.level = pokemon.level;
            modelPokemon.capturedAt = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            pokemonCollection.InsertOne(modelPokemon);
        }
    }
}
