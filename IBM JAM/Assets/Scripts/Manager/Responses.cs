using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responses : MonoBehaviour
{

    public string[] responseArray;
	
	void Start ()
    {
        responseArray = new string[20];

        responseArray[0] = "It's the holidays! Everyone's happy to spend!";
        responseArray[1] = "You have been sued! Money and Public Morale have decreased!";
        responseArray[2] = "A robbery has occurred! Our security wasn't up to the task...";
        responseArray[3] = "A robbery has occurred! Luckily our security defeated them!";
        responseArray[4] = "A loan has been requested! What would you like to do?";
        responseArray[5] = "Congratulations! Someone has invested in your bank! Money and Staff Morale have increased!";
        responseArray[6] = "Your staff are going on strike! Money, Staff Morale and Public Morale have decreased!";
        responseArray[7] = "War has been declared! Investments are up but Staff and Public Morale are down!";
        responseArray[8] = "The Housing Market has crashed! Money, Staff Morale and Public Morale have plummeted!";
        responseArray[9] = "Someone has vandalised your bank! Money, Staff Morale and Public Morale have decreased!";
        responseArray[10] = "The toilets have broken! Money and Staff Morale have decreased!";
        responseArray[11] = "Your bank needs refurbishing! Money, Staff Morale and Public Morale have decreased!";
        responseArray[12] = "Are you sure you want to promote someone?";
        responseArray[13] = "Are you sure you want to fire someone?";
        responseArray[14] = "Are you sure you want to hire someone?";
        responseArray[15] = "Are you sure you want to spend money on advertising?";
        responseArray[16] = "Are you sure you want to accept this loan?";
        responseArray[17] = "Are you sure you want to deny this loan?";
        responseArray[18] = "Are you sure you want to upgrade security?";
        responseArray[19] = "Are you sure you want to do nothing?";
	}

}
