using Unity.VisualScripting;
using UnityEngine;

public class TokenTriggerEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Detector x1":
                
                break;
            case "Detector x2":

                break;
            case "Detector x3":

                break;
            case "Detector x4":

                break;
            case "Detector x5":

                break;
            case "Detector x6":

                break;
            case "Detector x7":

                break;
        }
    }
}
