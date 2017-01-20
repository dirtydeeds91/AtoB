using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStrings : MonoBehaviour {
    public Dictionary<string, List<string>> deathText;
    public TextAsset textAsset;

	// Use this for initialization
	void Start () {
        string allText = textAsset.text;
        string[] tempArray = allText.Split('\n');

        for (int i = 0; i < tempArray.Length; i++)
        {
            string[] finalSplit = tempArray[i].Split(',');

            if (deathText.ContainsKey(finalSplit[0]))
            {
                deathText[finalSplit[0]].Add(finalSplit[1]);
            }
            else
            {
                List<string> firstList = new List<string>();
                firstList.Add(finalSplit[1]); 
                deathText.Add(finalSplit[0], firstList); 
            }
        }
	}

    public string getFlavor(string deathType)
    {
        List<string> listToReturn = new List<string>();

        if (deathText.ContainsKey(deathType))
        {        
        listToReturn = deathText[deathType];

        int randomizer = Random.Range(0, listToReturn.Count - 1);

            return listToReturn[randomizer];
        }
        // in case deathType is not contained in the Dictionary, then returns null;
        return null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
