using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    private bool isOpened;
    private void Start()
    {
        result = new int[]{0,0,0,0};
        correctCombination = new int[] {2,9,1,3};
        isOpened = false;
        Rotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "WheelOne":
                result[0] = number;
                break;

            case "WheelTwo":
                result[1] = number;
                break;

            case "WheelThree":
                result[2] = number;
                break;

            case "WheelFour":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isOpened)
        {
            SceneManager.LoadScene("Menu");
            isOpened = true;
        }
    }

    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}
