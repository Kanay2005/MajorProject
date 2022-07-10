 using UnityEngine;
 public class DestroyAfterAnimation : MonoBehaviour {
     void Start () {
        //Destroy the game object after the animation is over
         Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
     }
 }
