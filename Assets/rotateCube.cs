using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCube : MonoBehaviour
{
    Vector2 turn;
    
    public LayerMask draggableMask;
    GameObject selectObject;
    bool isDragging;

    void Start() {
        isDragging = false;
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity,draggableMask);
            if(hit.collider != null){
                Debug.Log(hit.collider.gameObject.name);
                selectObject = hit.collider.gameObject;
                isDragging = true;
            }
        }

        if(isDragging){
             turn.x = Input.GetAxis("Mouse X")*Mathf.Deg2Rad;    
             turn.y = Input.GetAxis("Mouse Y")*Mathf.Deg2Rad;              
            
            Debug.Log(turn.x*1000f);
            // if(turn.x > 0 || turn.y > 0){
            transform.Rotate(Vector3.forward    , Mathf.Abs (turn.x*1000f));   
            transform.Rotate(Vector3.forward    , Mathf.Abs (turn.y*1000f));   
            // }
            // else if(turn.x < 0 || turn.y < 0){
            // transform.Rotate(Vector3.forward    , -Mathf.Abs (turn.y*1000f));   
            
            // transform.Rotate(Vector3.forward    ,-Mathf.Abs (turn.x*1000f));   
            // } 
            
            }
        if(Input.GetMouseButtonUp(0)){
            isDragging = false;
        }
        
    }
     
}