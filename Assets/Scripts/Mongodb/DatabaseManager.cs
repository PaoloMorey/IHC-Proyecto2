using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;

// public class MongoClientSettings : IEquatable<MongoClientSettings> {}

public class DatabaseManager : MonoBehaviour
{
    // private const string MONGO_URI = "mongodb+srv://admin:uiXQhRYHEpbXQO0o@pokemonvr.wxfm8vr.mongodb.net/test";
    // private const string MONGO_URI = "mongodb//admin:uiXQhRYHEpbXQO0o@pokemonvr.wxfm8vr.mongodb.net/?retryWrites=true&w=majority";
    private const string MONGO_URI = "mongodb://admin:uiXQhRYHEpbXQO0o@ac-lxjzoz7-shard-00-00.wxfm8vr.mongodb.net:27017,ac-lxjzoz7-shard-00-01.wxfm8vr.mongodb.net:27017,ac-lxjzoz7-shard-00-02.wxfm8vr.mongodb.net:27017/?ssl=true&replicaSet=atlas-d0wuk1-shard-0&authSource=admin&retryWrites=true&w=majority";
    private const string DATABASE_NAME = "PokemonVR_DB";
    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<ModelPokemon> pokemonCollection;
    private IMongoCollection<ModelPlayer> playerCollection;

    void Awake()
    {
        MongoClientSettings settings = MongoClientSettings.FromUrl(MongoUrl.Create(MONGO_URI));
        // settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        client = new MongoClient(settings);
        db = client.GetDatabase(DATABASE_NAME);
        pokemonCollection = db.GetCollection<ModelPokemon>("Pokemon");
        playerCollection = db.GetCollection<ModelPlayer>("Player");
    }

    public List<ModelPokemon> GetPokemonSortByDescendingCapturedAt()
    {
        return pokemonCollection.Find(pokemon => true).SortByDescending(i => i.capturedAt).ToList();;
    }

    public List<ModelPokemon> GetPokemonInTeam()
    {
        return pokemonCollection.Find(pokemon => pokemon.teamPos != -1).SortBy(i => i.teamPos).ToList();
    }

    public ModelPlayer GetPlayer(string name)
    {
        return playerCollection.Find(player => player.name.Equals(name)).SingleOrDefault();
    }

    public void InsertPlayer(string name)
    {
        playerCollection.InsertOne(new ModelPlayer(name));
    }

    void OnApplicationQuit()
    {
        // ModelPlayer modelPlayer = new ModelPlayer();
        // modelPlayer.name = "prueba";
        // try {
        //     playerCollection.InsertOne(modelPlayer);
        // }
        // catch {}

        PokemonManager[] pokemonManagers = FindObjectsOfType<PokemonManager>();
        if (pokemonManagers.Length != 0)
        {
            // List<ModelPokemon> listPokemon = pokemonManagers[0].GetRamPokemon();
            // foreach (ModelPokemon modelPokemon in listPokemon)
            // {
            //     modelPokemon.playerId = modelPlayer.name;
            //     pokemonCollection.InsertOne(modelPokemon);
            // }
        }
    }
}
