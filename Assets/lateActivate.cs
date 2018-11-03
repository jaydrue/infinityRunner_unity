using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lateActivate : MonoBehaviour {

	public float sec = 9f;
     void Start()
     {
         StartCoroutine(LateCall());
     }

     IEnumerator LateCall()
     {

         yield return new WaitForSeconds(sec);

         gameObject.SetActive(true);
         //Do Function here...
     }


}
