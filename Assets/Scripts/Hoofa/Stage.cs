using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage : MonoBehaviour {

    public Stage[] NextStages;
    public GameObject[] Holes;
    public GameObject[] Monsters;

    protected abstract void StartNextStage(int i);
    protected abstract void OnMonsterKilled(GameObject monster);
}
