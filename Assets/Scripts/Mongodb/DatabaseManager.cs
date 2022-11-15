using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;

public class DatabaseManager : MonoBehaviour
{
    private const string MONGO_URI = "mongodb+srv://admin:uiXQhRYHEpbXQO0o@pokemonvr.wxfm8vr.mongodb.net/test";
    private const string DATABASE_NAME = "PokemonVR_DB";
    private MongoClient client;
    private IMongoDatabase db;

    void Start()
    {
        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);
    }

    public List<ModelPokemon> GetPokemonSortByDescendingCapturedAt()
    {
        return db.GetCollection<ModelPokemon>("Pokemon").Find(pokemon => true).SortByDescending(i => i.capturedAt).ToList();;
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
        List<ModelPokemon> listPokemon = FindObjectsOfType<PokemonManager>()[0].GetRamPokemon();
        foreach (ModelPokemon modelPokemon in listPokemon)
        {
            pokemonCollection.InsertOne(modelPokemon);
        }
    }
}
