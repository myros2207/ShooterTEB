using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Transform player;

   
    

    
    public float spawnInterval = 1;

   
    float timeSinceSpawn;

    int points = 0;

  
   
    float spawnDistance = 30;


    public GameObject basherPrefab;

    public GameObject pointsCounter;

    public GameObject timeCounter;

    public GameObject gameOverScreen;

    //czas do koñca poziomu
    public float levelTime = 60f;



    // Start is called before the first frame update
    void Start()
    {
      
        player = GameObject.FindWithTag("Player").transform;

       
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
        timeSinceSpawn += Time.deltaTime;

      
        if (timeSinceSpawn > spawnInterval)
        {
        
            Vector2 random = Random.insideUnitCircle.normalized;

            Vector3 randomPosition = new Vector3(random.x, 0, random.y);

           
            randomPosition *= spawnDistance;

           
            randomPosition += player.position;

           
            if (!Physics.CheckSphere(new Vector3(randomPosition.x, 1, randomPosition.z), 0.5f))
            {
             
                Instantiate(basherPrefab, randomPosition, Quaternion.identity);

              
                timeSinceSpawn = 0;
            }
          

        }

        if (levelTime < 0)
        {
            GameOver();
        }
        else
        {
            levelTime -= Time.deltaTime;
            UpdateUI();
        }

    }
     public void AddPoints (int amount)
    {
        points += amount;
    }
    private void UpdateUI () {

        pointsCounter.GetComponent<TextMeshProUGUI>().text = "Punkty: " + points.ToString();

    }
    public void GameOver()
    {
        //wy³¹cz sterowanie gracza
        player.GetComponent<PlayerControl>().enabled = false;
        player.transform.Find("MainTurret").GetComponent<WeaponController>().enabled = false;

        //wylacz bashery
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject basher in enemyList)
        {
            basher.GetComponent<Basher>().enabled = false;
        }

        //wyswietl poprawnie wynik na ekranie koñcowym
        gameOverScreen.transform.Find("FinalScoreText").GetComponent<TextMeshProUGUI>().text = "Wynik koñcowy: " + points.ToString();

        //poka¿ ekran koñca gry
        gameOverScreen.SetActive(true);

    }
}