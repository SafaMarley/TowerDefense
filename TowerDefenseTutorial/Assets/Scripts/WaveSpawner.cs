using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform startPoint;
    public float timeBetweenSpawns = 5f;
    public Text countdownText;
    
    private float countdown = 2f;
    private int waveNumber = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenSpawns;
        }

        countdown -= Time.deltaTime;
        countdownText.text = Mathf.Ceil(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyPrefab, startPoint.transform.position, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
