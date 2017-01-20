using UnityEngine;
using System.Collections;
using AtoB.Debugging;
using UnityEngine.UI;
using System.Linq;

public class DeathPrinter : MonoBehaviour
{
    public DeathStrings deathStrings;
    public Text deathType;
    public Text deathReason;

    private string[] deathTypes;

    private void Start()
    {
        deathTypes = deathStrings.deathText.Keys.ToArray();
    }

    public void GetDeath()
    {
        string death = deathTypes[Random.Range(0, deathTypes.Length)];
        string deathReasonString = deathStrings.getFlavor(death);

        deathType.text = "Reason for death: " + death;
        deathReason.text = deathReasonString;
    }    
}
