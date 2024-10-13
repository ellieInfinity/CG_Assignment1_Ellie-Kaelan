using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuBehaviour : MonoBehaviour
{
    
    private GameManager gameManager;

    private int points;
    [SerializeField] private TextMeshProUGUI pointText;
    

    // Update is called once per frame
    void Update()
    {
        Reset();
        points = PointsStorage.totalScore;
        pointText.text = points.ToString();
        Debug.Log(points);
    }

    private void Reset()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Timer();
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
    }
}
