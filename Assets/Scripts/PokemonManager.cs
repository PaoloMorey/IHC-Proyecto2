using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

public class PokemonManager : MonoBehaviour
{
    // private List<ModelPokemon> listMemoryPokemon; // disk in PlayerPrefs
    // private List<ModelPokemon> listRamPokemon; // RAM
    private List<ModelPokemon> pokemonTeam;
    private PokemonTeam pokemonTeamManager;
    private int N = 6;
    private int[] teamPositions;

    void Awake()
    {
        // PlayerPrefs.DeleteAll();
        pokemonTeamManager = FindObjectsOfType<PokemonTeam>()[0];
        teamPositions = new int[N];
        for (int i = 0; i < N; i++)
            teamPositions[i] = i;
        pokemonTeam = new List<ModelPokemon>();
        for (int i = 0; i < N; i++) {
            XmlSerializer serializer = new XmlSerializer(typeof(ModelPokemon));
            string text = PlayerPrefs.GetString(GameManager.Instance.playerName+"_"+i.ToString());
            if (text != "") {
                using (var reader = new System.IO.StringReader(text))
                {
                    pokemonTeam.Add(serializer.Deserialize(reader) as ModelPokemon);
                }
            }
        }
    }

    public List<ModelPokemon> GetListPokemonTeam()
    {
        return pokemonTeam;
    }

    public void AddPokemon(ModelPokemon pokemon)
    {
        int contPokemonTeam = pokemonTeam.Count;
        if (contPokemonTeam <= 6) {
            pokemon.teamPos = contPokemonTeam;
            pokemonTeamManager.AddNewPokemonTeam(pokemon);
            pokemonTeam.Add(pokemon);
        }
    }

    public void SaveTeam()
    {
        foreach (ModelPokemon pokemon in pokemonTeam) {
            XmlSerializer serializer = new XmlSerializer(typeof(ModelPokemon));
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, pokemon);
                PlayerPrefs.SetString(GameManager.Instance.playerName+"_"+
                                    pokemon.teamPos.ToString(), sw.ToString());
            }
        }
    }

    void OnApplicationQuit()
    {
        SaveTeam();
    }
}