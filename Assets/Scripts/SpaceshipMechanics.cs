using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class SpaceshipMechanics : MonoBehaviour
{

    [SerializeField]
    List<GameObject> HP = new List<GameObject>();


    [SerializeField]
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    

    // Update is called once per frame
    void Update()
    {
        if(HP.Count <= 0)
        {
            // when HP is low, inform game manager to show restart menu
            gameManager.GetComponent<PauseMenu>().IsDead = true;
        }
    }

    public void TakeDamage()
    {
        

        if(HP.Count > 0)
        {   
            // flash screen
            Destroy(HP[0]);
            HP.RemoveAt(0);
        }
        
    }
}
