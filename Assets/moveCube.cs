using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour
{
    public LayerMask draggableMask;
    public Rigidbody2D rb;
    GameObject selectObject;
    public CollisionDetectionMode2D collisionDetectionMode;
    bool isDragging;



    void Start() {
        isDragging = false;
        rb = GetComponent<Rigidbody2D>();
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
        if(Input.GetMouseButtonUp(0)){
            isDragging = false;
        }
    }
  
    void FixedUpdate()
    {
        if (isDragging)
        {
            // Debug.Log(( Input.mousePosition.x) +  "xxxxxx" +( rb.position.x ));
            Debug.Log(( Input.mousePosition.y)+  "yyyyy" + (rb.position.y ));

            // Debug.Log(selectObject.name);
            // GameObject.FindGameObjectWithTag(selectObject.name).transform.position.x;
            // GameObject.FindGameObjectWithTag(selectObject.name).transform.position.y;
            //   Debug.Log(GameObject.Find(selectObject.name).transform.position.x);
            
            if(rb.position.y < GameObject.Find(selectObject.name).transform.position.y){
                if(rb.position.x < GameObject.Find(selectObject.name).transform.position.x)
                    rb.velocity = new Vector3(2f ,2f, 0f);
                else
                    rb.velocity = new Vector3(-2f ,2f, 0f);
            }else if(rb.position.y < GameObject.Find(selectObject.name).transform.position.y){
                if(rb.position.x < GameObject.Find(selectObject.name).transform.position.x)
                    rb.velocity = new Vector3(2f ,-2f, 0f);
                else
                    rb.velocity = new Vector3(-2f ,-2f, 0f);
            }else{
                if(rb.position.x < GameObject.Find(selectObject.name).transform.position.x)
                    rb.velocity = new Vector3(2f ,0f, 0f);
                else
                    rb.velocity = new Vector3(-2f ,0f, 0f);
            }
            
        }
    }
}