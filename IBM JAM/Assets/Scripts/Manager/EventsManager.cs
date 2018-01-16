using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defining the values that an event contains within it for reference in the event callup

public class EventsManager : MonoBehaviour {

    //Variable definitions for values and array
    public List<float[]> eventList;
    public float    cash,
                    sM,
                    pM;
    // Use this for initialization

    void Start()
    {
        //Setting cash as the default value of money in the resource manager
        cash = GetComponent<ResourceManager>().money;
        sM = GetComponent<ResourceManager>().staffMorale;
        pM = GetComponent<ResourceManager>().publicMorale;
        eventList = new List<float[]>();
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 5000f, 6f, 5f, 0f, 5f }); //Investment (small)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 7000f, 6f, 5f, 0f, 5f }); //Investment (medium)
        eventList.Add(new float[] { 10000f, 6f, 5f, 0f, 5f }); //Investment (large)
        eventList.Add(new float[] { 10000f, 6f, 5f, 0f, 5f }); //Investment (large)
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { 0f, 0f, 0f, 0f, 4f }); //Loan Request
        eventList.Add(new float[] { -20000f, 6f, 0f, -20f, 1f }); //Lawsuit
        eventList.Add(new float[] { -5000f, 6f, -5f, -5f, 9f }); //Vandalism
        eventList.Add(new float[] { -5000f, 6f, -5f, -5f, 9f }); //Vandalism
        eventList.Add(new float[] { -15000f, 6f, -15f, 0f, 10f }); //Broken Toilets
        eventList.Add(new float[] { -35000f, 6f, -5f, -5f, 11f }); //Refurbishment
        eventList.Add(new float[] { -cash * 0.40f, 6f, -20f, -20f, 8f }); //Housing Market Crash
        eventList.Add(new float[] { -15000f, 6f, -45f, -30f, 6f }); //Worker Strike
        eventList.Add(new float[] { 65000f, 6f, -30f, -30f, 7f }); //War Bonds
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -25000f, 2f, -5f, 0f, 2f }); //Robbery Level 2
        eventList.Add(new float[] { -40000f, 3f, -5f, 0f, 2f }); //Robbery Level 3
        eventList.Add(new float[] { -40000f, 3f, -5f, 0f, 2f }); //Robbery Level 3
        eventList.Add(new float[] { -50000f, 4f, -15f, 0f, 2f }); //Robbery Level 4
        eventList.Add(new float[] { -65000f, 5f, -15f, 0f, 2f }); //Robbery Level 5
        eventList.Add(new float[] { 35000f, 6f, sM * 0.2f, pM * 0.2f, 0f }); //Holidays
    }

    

}
