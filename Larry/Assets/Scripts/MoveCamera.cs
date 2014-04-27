using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
   public float speed = 20;
   public float personalSpace = 5;
   private Vector3 startPosition3;
   public Transform target;

   // Use this for initialization
   void Start ()
   {
      startPosition3 = transform.position;
   }
	
   // Update is called once per frame
   void Update ()
   {
      transform.LookAt (target);
      float vertValue = Input.GetAxis ("CameraV");
      float horValue = Input.GetAxis ("CameraH");
      float zoomValue = Input.GetAxis ("Zoom");
      if (Input.GetButtonDown ("ResetCamera")) {
         transform.position = startPosition3;
      } else {
         if (zoomValue != 0) {
            if (((target.position - transform.position).magnitude > personalSpace) || zoomValue < 0) {
               transform.Translate (Vector3.forward * zoomValue * speed * Time.deltaTime);
            }
         }
         if (vertValue != 0) {
            transform.Translate (Vector3.up * vertValue * speed * Time.deltaTime);
         }
         if (horValue != 0) {
            transform.Translate (Vector3.right * horValue * speed * Time.deltaTime);
         }
      }
   }

}
