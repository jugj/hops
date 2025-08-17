using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    void Awake(){
        transform.Translate(new Vector3(0f, 0f, -10f));
        Debug.Log("Camera position (awake): "+ transform.position);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Camera position (start): "+ transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Camera position: "+ transform.position);
    }
}
