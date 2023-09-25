using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    [SerializeField] public static List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        GameObject listener = GameObject.Find("Listener");
        GameObject smeller = GameObject.Find("Smeller");

        if (listener != null)
            enemies.Add(listener);

        if (smeller != null)
            enemies.Add(smeller);

    }

    public void UpdateAllEnemyTarget(GameObject callingEnemy, Vector3 newTargetPos)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy == callingEnemy)
                continue;


            Debug.Log("Updating target for: " + enemy.name);
            if (enemy.name == "Listener")
            {
                Ears earsScript = enemy.GetComponent<Ears>();
                if (earsScript != null)
                {
                    earsScript.UpdatePath(newTargetPos);
                }
            }
            else if (enemy.name == "Smeller")
            {
                Smeller smellerScript = enemy.GetComponent<Smeller>();
                if (smellerScript != null)
                {
                    smellerScript.UpdatePath(newTargetPos);
                }
            }
        }
    }
}
