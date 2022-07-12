using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class SpaceshipMechanics : MonoBehaviour
{

    [SerializeField]
    List<GameObject> HP = new List<GameObject>(); // hit points GUI ref


    [SerializeField]
    GameObject gameManager;

    [SerializeField]
    GameObject flashScreenOnDamage;
 

    // Start is called before the first frame update
    void Start()
    {
        flashScreenOnDamage.SetActive(false);
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

        flashScreenOnDamage.SetActive(true);

        StartCoroutine(FlashScreenDisable());

        if (HP.Count > 0)
        {
            
            // flash screen
            Destroy(HP[0]);
            HP.RemoveAt(0);
        }
        
    }

    IEnumerator FlashScreenDisable()
    {
        yield return new WaitForSeconds(0.3f);

        flashScreenOnDamage.SetActive(false);
    }

}
