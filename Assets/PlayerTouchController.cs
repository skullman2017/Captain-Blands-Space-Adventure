using UnityEngine;
using System.Collections;

public class PlayerTouchController : MonoBehaviour {

    private PlayerController theplayer;
   
    private Vector3 offset;
    private Vector3 touchPos;

    // Use this for initialization
	void Start () {
        theplayer = FindObjectOfType<PlayerController>();

        offset = new Vector3(2f, 2f, theplayer.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0); // screen has been touched, store the touch 

            if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary) // finger moved 
            {
                touchPos = Camera.main.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, theplayer.transform.position.z));

                offset = theplayer.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, theplayer.transform.position.z)); 
               
                theplayer.transform.position = Vector2.Lerp(theplayer.transform.position, touchPos, Time.deltaTime * 5f);
               
                //theplayer.movePlayer(_dir);
            }

        }


	} // end 
    
}
