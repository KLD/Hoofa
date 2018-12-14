using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

    public Stage[] NextStages;
    public StageHole[] Holes;
    public GameObject[] Monsters;

    public Collider2D SouthBound; 


    private Vector2? Target; 

    private void Start() {
       for (int i = 0; i < Holes.Length; i++)
       {
           int x = i; 
            Holes[i].OnFall += () => {StartNextStage(x);}; //TODO optimize for memory if needed
       }
    }

    protected void StartNextStage(int i){
            Stage next = NextStages[i]; 
            next.gameObject.transform.position = new Vector2(0, StageController.Bottom);

            MoveStageTo(Vector2.up * StageController.Height);
            SouthBound.enabled = false; 
            
            next.MoveStageTo(Vector2.zero);
            next.SouthBound.enabled = true; 

    }




private void LateUpdate() {
    if(Target == null)
    return;

    transform.position = Vector2.Lerp(transform.position, Target.Value, Time.deltaTime); 
   
    if(Vector3.Distance(transform.position, (Vector3)Target.Value) == 0){
        Target = null; 
    }
}

public void MoveStageTo(Vector2 target){
Target = target; 
}

}
