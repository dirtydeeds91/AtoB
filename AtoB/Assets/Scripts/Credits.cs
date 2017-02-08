using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public TextAsset textAsset;
    public string allText;
    
    // Use this for initialization
<<<<<<< HEAD
    void Start () {
        string allText = textAsset.text;
=======
    void Start ()
    {
        allText = textAsset.text;
>>>>>>> a9f8a0462aacc4de36f94477bea2eaefb74100d7
	}

    public string getCredits(string allText)
    {
        return allText;
    }
}
