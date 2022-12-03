[System.Serializable]
public class ModelPokemon
{
    public ModelPokemon() {}
    public ModelPokemon(PokemonVariables other)
    {
        this.name = other.name;
        this.level = other.level;
        this.teamPos = -1;
    }

    public int level { set; get; }
    public string name { set; get; }
    /* 0 1 2 3 4 5 (equipo principal) y -1 para box */
    public int teamPos { set; get; }
}