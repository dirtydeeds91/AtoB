using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Credits : MonoBehaviour {

    public TextAsset textAsset;
    public string allText;
    
    // Use this for initialization
    void Start () {
        string allText = textAsset.text;
	}

    public string getCredits(string allText)
    {
        return allText;
    }
}
