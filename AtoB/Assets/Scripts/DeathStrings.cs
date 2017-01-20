using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStrings : MonoBehaviour {
    public Dictionary<string, List<string>> deathText;
    public TextAsset textAsset;

	// Use this for initialization
	private void Start ()
    {
        deathText = new Dictionary<string, List<string>>();

        string allText = textAsset.text;
        string[] tempArray = allText.Split('\n');

        for (int i = 0; i < tempArray.Length; i++)
        {
            int indexOfFirstComma = tempArray[i].IndexOf(',');
            string deathType = tempArray[i].Substring(0, indexOfFirstComma);
            string flavor = tempArray[i].Substring(indexOfFirstComma + 1);

            if (deathText.ContainsKey(deathType))
            {
                deathText[deathType].Add(flavor);
            }
            else
            {
                List<string> firstList = new List<string>();
                firstList.Add(flavor); 
                deathText.Add(deathType, firstList); 
            }
        }
	}

    public string getFlavor(string deathType)
    {
        List<string> listToReturn = new List<string>();

        if (deathText.ContainsKey(deathType))
        {        
        listToReturn = deathText[deathType];

        int randomizer = Random.Range(0, listToReturn.Count);

            return listToReturn[randomizer];
        }
        // in case deathType is not contained in the Dictionary, then returns null;
        return null;
    }
}
