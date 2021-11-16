using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isFollowingRules : MonoBehaviour
{
    [SerializeField] GameObject trafficLight;
    [SerializeField] string tag;
    [SerializeField] string sceneName;
    bool lightState;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Junction.");
        lightState = trafficLight.GetComponent<TrafficControl>().getLightState();
        if (other.gameObject.tag == tag && lightState)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
