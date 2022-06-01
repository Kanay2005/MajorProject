 using UnityEngine;
 public class DestroyAfterAnimation : MonoBehaviour {
     void Start () {
         Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
     }
 }
