using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float lam_min;
    public float camloy;
    Vector3 offset;
    float lowy;
    // Start is called before the first frame update
    void Start()
    {
        offset=transform.position -target.position;
        lowy = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCampos=target.position +offset;
        transform.position =Vector3.Lerp (transform.position,targetCampos,lam_min+Time.deltaTime);
        if(transform.position.y <camloy){
            transform.position =new Vector3(transform.position.x,transform.position.y, transform.position.z);
        }
        
    }
}
