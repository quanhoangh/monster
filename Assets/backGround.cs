using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    [SerializeField] Vector2 parallxEffectMutiplỉer; 
    [SerializeField] private bool infiniteHorizontal;
    [SerializeField] private bool infiniteVerical;
    private Transform camraTransform;
    private Vector3 cameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    // Start is called before the first frame update
    void Start()
    {
        camraTransform =Camera.main.transform;
        cameraPosition =camraTransform.position;
        Sprite sprite= GetComponent<SpriteRenderer>().sprite;
        Texture2D texture =sprite.texture;
        textureUnitSizeX =texture.width /sprite.pixelsPerUnit;
        textureUnitSizeY =texture.height/sprite.pixelsPerUnit;
    }

    // Update is called once per frame
     private void LateUpdate() {
         Vector3 deltaMovement =camraTransform.position -cameraPosition;
         
        transform.position +=new Vector3(deltaMovement.x *parallxEffectMutiplỉer.x,deltaMovement.y *parallxEffectMutiplỉer.y);
        cameraPosition =camraTransform.position;
        if(infiniteHorizontal){
        if(Mathf.Abs(camraTransform.position.x-transform.position.x) >=textureUnitSizeX){
            float offsetPositionX=(camraTransform.position.x-transform.position.x) % textureUnitSizeX;
            transform.position=new Vector3(camraTransform.position.x +offsetPositionX,transform.position.y);
        }
        }
        if(infiniteVerical){
        if(Mathf.Abs(camraTransform.position.y-transform.position.y) >=textureUnitSizeY){
            float offsetPositionY=(camraTransform.position.y-transform.position.y) % textureUnitSizeY;
            transform.position=new Vector3(transform.position.x,camraTransform.position.y +offsetPositionY);
        }
    }
     }
}
