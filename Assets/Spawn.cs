using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float playerPosX;
    public GameObject pointSpawn;
    public GameObject gobinsapwn;
    List<GameObject> mimions;
    // Start is called before the first frame update
    void Start()
    {   
        mimions = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= playerPosX){
        spawn();
        }else{notspawn();}
        
    }
    void spawn(){
        if(mimions.Count >= 7) return;
        int i=this.mimions.Count +1;
        GameObject gobin= Instantiate(gobinsapwn);
        gobin.name="gobin #"+i;
        gobin.transform.position=pointSpawn.transform.position;
        mimions.Add(gobinsapwn);
    }
    void notspawn(){
        Debug.Log("notspawn");
    }
}
