using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class daymanager : MonoBehaviour
{
    [Header("kaikki pelin henkilöt ja heidän tietonsa")]
    public List<CharacterData> allcharacters;

    [Header("päiväkohtaiset nimilistat")]
    public List<DailySchedule> allschedules;

    // tässä listassa ovat vain tänään paikalla olevat henkilöt tietoineen
    [Header("tämän päivän aktiiviset henkilöt (vain luku)")]
    public List<CharacterData> todayscharacters = new List<CharacterData>();

    private int currentday = 1;

    void Start()
    {
        startday(currentday);
    }

    public void nextday()
    {
        currentday++;
        startday(currentday);
    }

    public void startday(int day)
    {
        // 1. tyhjennä edellisen päivän lista
        todayscharacters.Clear();

        // 2. etsi tämän päivän nimilista
        DailySchedule todayschedule = allschedules.Find(s => s.dayNumber == day);

        // 3. etsi nimeä vastaavat tiedot ja lisää ne tämän päivän listaan
        if (todayschedule != null)
        {
            foreach (string nametofind in todayschedule.arrivingNames)
            {
                CharacterData foundperson = allcharacters.Find(c =>
                    c.characterName.Equals(nametofind.Trim(), System.StringComparison.OrdinalIgnoreCase));

                if (foundperson != null)
                {
                    todayscharacters.Add(foundperson);
                }
                else
                {
                    Debug.LogWarning($"henkilöä '{nametofind}' ei löytynyt tietokannasta!");
                }
            }
        }

        // testitulostus console-ikkunaan, jotta näet järjestelmän toimivan
        printtodayscharacters();
    }

    void printtodayscharacters()
    {
        Debug.Log($"--- päivä {currentday} ---");
        foreach (CharacterData person in todayscharacters)
        {
            Debug.Log($"nimi: {person.characterName}, ammatti: {person.region}, viesti: {person.dialogue}");
        }
    }
}