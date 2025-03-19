using UnityEngine;
using SimpleJSON;
using MattsAwesomeGame;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine.Serialization;

namespace MattsAwesomeGame
{


    public class SavePlayerScript : MonoBehaviour
    {
        
        // Sample JSON string for jsonArrayString
        // [
        // {
        //     "name": "Matt", 
        //     "age":25,
        //     "parents": 
        //     [
        //     {
        //         "name": "Terry",
        //         "age": 84
        //     },
        //     {
        //         "name": "Frida",
        //         "age": "79"
        //     }
        //     ]
        // },
        // {
        //     "name": "Ramiro",
        //     "age": 103
        // },
        // {
        //     "name": "Sarah",
        //     "age": 34
        // }
        // ]
        
        
        //TextArea lets you expand the text area in the inspector
        [FormerlySerializedAs("jsonArray")] [TextArea (5, 20)] public string jsonArrayString;
        
        [TextArea(5, 20)] public string displayOurJsonArray;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ParseJsonArray();
            PopulateJsonArray();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //Parse the JSON array
        void ParseJsonArray()
        {
            //Parse the string into a JSONNode
            JSONNode jNode = JSON.Parse(jsonArrayString);

            //Get a JSONArray from the JSONNode
            JSONArray jArray = jNode.AsArray;

            string result = "";
            
            //Iterate through the JSONArray
            foreach (JSONObject person in jArray)
            {
                result += "\nPerson:\n";

                //Get the name and age of the person
                result += person["name"].Value;
                result += "\nAge: " + person["age"].AsInt;
                
                //Get the parents of the person
                JSONArray parents = person["parents"].AsArray;
                
                result += "\nparent names: ";
                
                //Iterate through the parents
                foreach (JSONObject parent in parents)
                {
                    result += parent["name"].Value + " ";
                }
            
            }
            
            Debug.Log(result);
            
        }

        //Populate a JSON array
        void PopulateJsonArray()
        {
            //Create a new JSONArray
            JSONArray jDisplayArray = new JSONArray();

            //Create a JSONObject for the brand Kellogs
            JSONObject kellogs = new JSONObject();
            kellogs["name"] = "kellogs";
            kellogs["founding year"] = 1906;

            
            //Create a JSONObject for the brand General Mills
            JSONObject gMills = new JSONObject();
            gMills["name"] = "General Mills";
            gMills["founding year"] = 1856;
            
            
            //Create a JSONObject for Rice Krispy
            JSONObject riceKripy = new JSONObject();
            riceKripy["name"] = "Rice Krispy";
            riceKripy["milkRatio"] = 2;
            riceKripy["brand"] = kellogs;
            
            //Add the JSONObject to the JSONArray
            jDisplayArray.Add(riceKripy);

            //Create a JSONObject for Kix
            JSONObject kix = new JSONObject();
            kix["name"] = "Kix";
            kix["milkRatio"] = 1.2;
            kix["brand"] = gMills;
            
            //Add the JSONObject to the JSONArray
            jDisplayArray.Add(kix);
            
            //Convert the JSONArray to a string, with pretty printing
            displayOurJsonArray = jDisplayArray.ToString(2);
        }
    }
}