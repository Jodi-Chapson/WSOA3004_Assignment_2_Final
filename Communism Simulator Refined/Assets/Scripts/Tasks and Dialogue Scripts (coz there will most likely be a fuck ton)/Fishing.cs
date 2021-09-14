using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [Header("References")]
    public bool isEnabled;
    public GameObject FISH;
    public int clickcounter = 0;
    public GameObject line;
    public Transform dropzone;
    public GameManager manager;
    public float collectiondistance;

    public Queue<GameObject> fishes;

    void Start()
    {
        fishes = new Queue<GameObject>();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        // get one tick of fish 
        // update fishing rod

        if (isEnabled)
        {
            if (Vector3.Distance(this.transform.position, manager.player.GetComponent<Transform>().transform.position) < collectiondistance)
            {
                clickcounter++;

                if (clickcounter == 1)
                {
                    line.transform.localEulerAngles = new Vector3(16, -4, 0);
                }
                else if (clickcounter == 2)
                {
                    line.transform.localEulerAngles = new Vector3(36, -20, 0);
                }
                if (clickcounter == 3)
                {
                    line.transform.localEulerAngles = Vector3.zero;
                    //instantiate fish at position
                    GameObject salmon = Instantiate(FISH, dropzone.position, Quaternion.identity);
                    fishes.Enqueue(salmon);

                    if (fishes.Count >= 4)
                    {
                        GameObject discard = fishes.Dequeue();
                        Destroy(discard);
                    }

                    clickcounter = 0;
                }
            }

        }

    }

    public void OnMouseEnter()
    {
        if (isEnabled)
        {
            if (Vector3.Distance(this.transform.position, manager.player.GetComponent<Transform>().transform.position) < collectiondistance)
            {
                manager.gameObject.GetComponent<GameManager>().cursorstate = 1;

            }
            else
            {
                manager.gameObject.GetComponent<GameManager>().cursorstate = 2;
            }


        }
    }

    public void OnMouseOver()
    {
        if (isEnabled)
        {
            if (Vector3.Distance(this.transform.position, manager.player.GetComponent<Transform>().transform.position) < collectiondistance)
            {
                manager.gameObject.GetComponent<GameManager>().cursorstate = 1;

            }
            else
            {
                manager.gameObject.GetComponent<GameManager>().cursorstate = 2;
            }


        }
    }

    public void OnMouseExit()
    {
        if (isEnabled)
        {
            if (manager.cursorstate == 1 || manager.cursorstate == 2)
            {
                manager.cursorstate = 0;
            }
        }
    }
}
