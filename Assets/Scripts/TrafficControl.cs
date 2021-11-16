using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficControl : MonoBehaviour
{
    [SerializeField] float trafficRate;
    bool lightState;
    Material green, red;
    Color greenColor, redColor,brightGreen,brightRed;
    [SerializeField] float brightFactor=10f;
    // Start is called before the first frame update
    void Start()
    {
        red = this.transform.GetChild(2).GetComponent<Renderer>().material;
        green = this.transform.GetChild(3).GetComponent<Renderer>().material;
        greenColor = green.color;
        redColor = red.color;
        StartCoroutine(changeLights());
        brightGreen = new Color(greenColor.r * brightFactor, greenColor.g * brightFactor, greenColor.b*brightFactor);
        brightRed = new Color(redColor.r * brightFactor, redColor.g * brightFactor, redColor.b, brightFactor * brightFactor);
        lightState = true;
    }

    IEnumerator changeLights()
    {
        while (true)
        {
            if (lightState)
            {
                brightGreen = new Color(greenColor.r * brightFactor, greenColor.g * brightFactor, greenColor.b * brightFactor);
                lightState = false;
                red.color = redColor;
                green.color = brightGreen;
            }
            else
            {
                green.color = greenColor;
                red.color = brightRed;
                lightState = true;
            }
            yield return new WaitForSeconds(trafficRate);
        }
    }

    public bool getLightState()
    {
        return lightState;
    }
}
