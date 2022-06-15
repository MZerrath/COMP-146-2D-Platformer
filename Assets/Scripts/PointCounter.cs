using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    BoxCollider2D _box;
    int points = 0;
    [SerializeField] int pointIncrement = 1;
    [SerializeField] LevelManager levelManager;

    public Text pointCount;

    void Awake()
    {
        _box = GetComponent<BoxCollider2D>();        
    }
    void Start()
    {
        SetPointsText();
    }

    // Activates when the player hits a coin, enemy, or water.
    void OnTriggerEnter2D(Collider2D item)
    {
        if (item.tag == "Coin")
        {
            CollectCollectable(pointIncrement, item.gameObject);
        }
        else if (item.tag == "Enemy")
        {
            Destroy(this.gameObject);
            levelManager.ShowGameOver();
        }
        else if (item.tag == "Goal")
        {
            Destroy(this.gameObject);
            levelManager.ShowLevelComplete();
        }
    }

    // This method is called when the player collects a coin, collects a gem, or hits the finish pole.
    void CollectCollectable(int prize, GameObject theItem)
    {
        points = points + prize;
            // Collectable has been collected, so destroy the collectable and update the score counter
            Destroy(theItem.gameObject);
            SetPointsText();
    }

    // Called in Start() and CollectCollectable().
    public void SetPointsText()
    {
        pointCount.text = "Points: " + points.ToString();
    }
}
