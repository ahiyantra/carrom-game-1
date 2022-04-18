using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerController : MonoBehaviour
{
    [SerializeField]
    Slider strikerSlider;

    [SerializeField]
    Transform strikerShoot;

    [SerializeField]
    Transform forcePoint;

    RaycastHit2D hit;

    Rigidbody2D rb;

    bool strikerForce;

    [SerializeField]
    float scaleValue;

    [SerializeField]
    float mag;

    [SerializeField]
    float limit;

    //[SerializeField]
    //float divider;

    [SerializeField]
    float multiplier;

    Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        strikerSlider.onValueChanged.AddListener(StrikerXpos);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mag = GetComponent<Rigidbody2D>().velocity.magnitude;

        //mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePos);

        //Collider2D targetObject = Physics2D.OverlapPoint(mousePos);
        //Debug.Log(targetObject.name);

        if (Input.GetMouseButton(0)) // GetMouseButtonDown
        {
            //mousePos = Input.mousePosition;
            //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(mousePos);

            hit = Physics2D.Raycast(mousePos, Vector3.forward);

            if (hit.collider && hit.transform.name == "striker") //
            {
                if (hit.transform.name == "striker") //
                {
                    strikerForce = true;
                }
                if (strikerForce) //
                {
                    strikerShoot.up = strikerShoot.position - new Vector3(hit.point.x, hit.point.y, strikerShoot.position.z); // 
                    //strikerShoot.LookAt(hit.point);
                }
                scaleValue = Vector3.Distance(transform.position, hit.point);
                //scaleValue = Vector3.Distance(transform.position, mousePos) / divider;
                strikerShoot.localScale = new Vector3(scaleValue,scaleValue,scaleValue);
                //Debug.Log(hit.transform.name);
            }
        }
        else if (Input.GetMouseButtonUp(0)) //
        {
            rb.AddForce((forcePoint.position - transform.position) * scaleValue * multiplier, ForceMode2D.Impulse);

            strikerForce = false;

            strikerShoot.localScale = Vector3.zero;
        }
        
    }

    public void StrikerXpos(float Value)
    {
        if (mag < limit)
        {
            transform.position = new Vector3(Value, -1.602f, 0f);

            rb.velocity = Vector2.zero;

            transform.rotation = Quaternion.identity;
        }
    }
}
