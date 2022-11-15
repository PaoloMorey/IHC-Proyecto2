using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class ModelPlayer
{
    [BsonId]
    public string oculusId { set; get; }
    public string name { set; get; }
}