using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
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
             turn.x += Input.GetAxis("Mouse X");
                if(turn.x>= -15 && turn.x <=15)
                    transform.localRotation = Quaternion.Euler(0,turn.x,0);
        }
        if(Input.GetMouseButtonUp(0)){
            isDragging = false;
        }
    }

    
}