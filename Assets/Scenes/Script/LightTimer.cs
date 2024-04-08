using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public Light Light;
    public float Intensity, 
        Area, 
        Range, 
        SpotAngle;


    private void Start()
    {
        //gameObject.GetComponent<Cam>().enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        Light.intensity = Intensity;
        Light.range = Range;
        Light.spotAngle = SpotAngle;
        //Light.areaSize = Area;
    }
}
