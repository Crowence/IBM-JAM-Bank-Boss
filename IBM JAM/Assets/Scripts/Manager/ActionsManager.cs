using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionsManager : MonoBehaviour
{

    public List<float[]> actionsList;

    void Start()
    {
        actionsList = new List<float[]>();

        actionsList.Add(new float[] { 0f, 0f, 0f, 0f, 19f});          // Do nothing
        actionsList.Add(new float[] { -5000f, 0f, 10f, 0f, 12f});     // Promote someone
        actionsList.Add(new float[] { -20000f, 1f, 0f, 0f, 18f});     // Upgrade security 1
        actionsList.Add(new float[] { -40000f, 1f, 0f, 0f, 18f});     // Upgrade security 2
        actionsList.Add(new float[] { -60000f, 1f, 0f, 0f, 18f});     // Upgrade security 3
        actionsList.Add(new float[] { -80000f, 1f, 0f, 0f, 18f});     // Upgrade security 4
        actionsList.Add(new float[] { -60000f, 0f, 0f, 30f, 15f});    // Spend on advertising
        actionsList.Add(new float[] { -10000f, 0f, 5f, 5f, 14f});     // Hire someone
        actionsList.Add(new float[] { 10000f, 0f, -5f, -5f, 13f});    // Fire someone
    }    

}
