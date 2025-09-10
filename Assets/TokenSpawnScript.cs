using JetBrains.Annotations;
using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TokenSpawnScript : MonoBehaviour
{
    public GameObject Player1Token;
    public GameObject Player2Token;
    public int y_position = 3; 
    Vector3 tokenSpawnPosition;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !logic.IsGamePaused())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float mouseX = ray.origin[0];
            SpawnToken(mouseX);
        }
    }

    public void SpawnToken(float mouseX = 0)
    {

        tokenSpawnPosition = new Vector3(mouseX, y_position, 1);
        if (logic.GetPlayerTurn() == 1)
        {
            Instantiate(Player1Token, tokenSpawnPosition, transform.rotation);

        } else if (logic.GetPlayerTurn() == 2)
        {
            Instantiate(Player2Token, tokenSpawnPosition, transform.rotation);
        }
        
    }
}
