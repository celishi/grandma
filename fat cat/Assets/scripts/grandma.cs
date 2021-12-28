 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grandma : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector2 targetPos;
    public float Yincrement;

    public float YSpeed;
    public float maxHeight;
    public float minHeight;

    public int health;

    public float DistanceTravelled;
    public float XSpeed;
    public float MaxSpeed;
    private int CurrentLane = 2;
    public bool slowed = false;
    private bool SlowedState = false;
    public float SpeedDecrease;
    private float SpeedPlaceholder = 0;

    void Start()
    {
        DistanceTravelled = 0;
        targetPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, YSpeed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            CurrentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            CurrentLane++;
        }
        if (slowed == true && SlowedState == true) 
        {
            health--;
            XSpeed = XSpeed - SpeedDecrease;
            slowed = false;
        }
        else if (slowed == true) 
        {
            SpeedPlaceholder = XSpeed;
            XSpeed = XSpeed - SpeedDecrease;
            SlowedState = true;
            slowed = false;
        }
        if (XSpeed >= SpeedPlaceholder)
        {
            SlowedState = false;
        }
        if (SlowedState == true) 
        {
            XSpeed = XSpeed + (float)0.25 * Time.deltaTime * SpeedDecrease;
        }
        if (SlowedState == false) 
        {
            XSpeed = Mathf.Pow((float)1.2, (float)0.2 * (Time.time) - 10) + 5;
            if (XSpeed > MaxSpeed)
            {
                XSpeed = MaxSpeed;
                
            }
        }
        DistanceTravelled = DistanceTravelled + (float)0.01 * XSpeed;
        if (CurrentLane == 1) 
        {
            GetComponent<SpriteRenderer>().sortingLayerID = -1794490669;
        }
        if (CurrentLane == 2)
        {
            GetComponent<SpriteRenderer>().sortingLayerID = 1916578653;
        }
        if (CurrentLane == 3)
        {
            GetComponent<SpriteRenderer>().sortingLayerID = -1016285291;
        }
    }
}
