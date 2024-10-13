using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;


public class LightSwitch : MonoBehaviour
{
    [SerializeField] private float onTime;

    [SerializeField] private TextMeshProUGUI warning;

    private float waitTime;

    [SerializeField] private GameObject [] spotlights;

    private GameObject activeLight;

    private PlayerInteraction playerInteraction;

    private int rand;
    void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        foreach(GameObject light in spotlights)
        {
            light.SetActive(false);
        }
        StartCoroutine(Timer());
    }

    private int numberOfTimes;
    private IEnumerator Timer()
    {
        if (numberOfTimes > 5000) yield return null;
        
        
        waitTime = Random.Range(4f, 12f);
        yield return new WaitForSeconds(waitTime);
        ChooseLight();
        yield return new WaitForSeconds(2f);
        warning.text = "";
        yield return new WaitForSeconds(1f);
        ActivateSpotlight();
        FindObjectOfType<AudioManager>().Play("LightOn");
        yield return new WaitForSeconds(onTime);
        FindObjectOfType<AudioManager>().Play("LightOff");
        StartCoroutine(DeactivateSpotlight());
        
       
        numberOfTimes++;

        StartCoroutine(Timer());
    }

    private void ChooseLight()
    {
        rand = Random.Range(0, spotlights.Length);
        warning.text = spotlights[rand].name;
    }

    private void ActivateSpotlight()
    {
        spotlights[rand].SetActive(true);
        activeLight = spotlights[rand];
    }

    private IEnumerator DeactivateSpotlight()
    {
        activeLight.SetActive(false);
        activeLight = null;
        yield return new WaitForSeconds(1f);
        playerInteraction.isInSafeZone = false;
        
    }
}
