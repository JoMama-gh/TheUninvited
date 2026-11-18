using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDailySchedule", menuName = "Game/Daily Schedule")]
public class DailySchedule : ScriptableObject
{
    public int dayNumber;
    public List<string> arrivingNames; // Esim. "Matti", "Maija"
}