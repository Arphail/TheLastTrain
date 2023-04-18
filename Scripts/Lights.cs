using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void TurnLightsOn()
    {
        print("LightsOn");
        gameObject.SetActive(true);
    }
}
