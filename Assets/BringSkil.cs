using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringSkil : MonoBehaviour
{
    public Transform target;
    public GameObject skill_1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skill_1(){
        Instantiate(skill_1,target.position,transform.rotation);
    }
}
