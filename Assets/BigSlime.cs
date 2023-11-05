using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSlime : MonoBehaviour
{
    DamageablePlayer damageablePlayer;
    public GameObject smallSlimePrefab;
    bool finishSplitting = true;
    public bool isBigSlime = true;

    private void Start()
    {
        damageablePlayer = GetComponent<DamageablePlayer>();
    }

    private void FixedUpdate()
    {
        if (finishSplitting == false && isBigSlime == true)
        {
            SpawnSmallSlime();
            SpawnSmallSlime();
            finishSplitting = true;
            
        }
        
        

        
    }


    public void SpawnSmallSlime()
    {
        Instantiate(smallSlimePrefab, (gameObject.transform.position), Quaternion.identity);
        
    }

    public void SplitSlime()
    {
        finishSplitting = false;
    }
}
