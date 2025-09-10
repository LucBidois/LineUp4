using NUnit.Framework;
using UnityEngine;



public class DetectorTriggered : MonoBehaviour
{
    public LogicScript logic;
    public int DetectorXPosition;
    private int yValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.AddTokenToList(DetectorXPosition, yValue);
        yValue += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
