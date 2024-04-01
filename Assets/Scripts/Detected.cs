using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detected : MonoBehaviour
{
    static private int score=0;
    private float maxBar = 1;
    private float increaseBarValue=0;
    [SerializeField] private int hungreLevel;
    private int currentHungreBar=0;
    [SerializeField] private HungreBar hungreBar;

    private void Update()
    {
        if (currentHungreBar == hungreLevel)
        {
            score++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        { 
          //  Destroy(gameObject); 
            Destroy(other.gameObject);
            Debug.Log($"Score : {score}");
            HungerBarModify();
        }

    }
    private void HungerBarModify()
    {
        currentHungreBar++;
        increaseBarValue += maxBar/ hungreLevel;
        hungreBar.SatietyLevel(maxBar, increaseBarValue);
    }
}
