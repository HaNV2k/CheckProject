using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
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
            Vector3 pos = mousePos();
            selectObject.transform.position = pos;
        }
        if(Input.GetMouseButtonUp(0)){
            isDragging = false;
        }
    }

    Vector3 mousePos(){
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
    }

}