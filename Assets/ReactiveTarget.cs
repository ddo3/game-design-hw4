using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
    [SerializeField] private GameObject tombstonePrefab;


    public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		StartCoroutine(Die());
	}


	//This is where the enemy dies
	private IEnumerator Die() {
        float angle = 0;
        bool angleIs90 = false;
        while (!angleIs90)
        {
            angle += 10;

            this.transform.Rotate(10, 0, 0);

            yield return new WaitForSeconds(0.027f);

            angleIs90 = (angle == 90);
        }

        yield return new WaitForSeconds(1.5f);

        
        Vector3 objectsPostion = this.transform.position;
        //add the rotating tombstone 

        GameObject tombstone = new GameObject();

        tombstone = Instantiate(tombstonePrefab) as GameObject;

        tombstone.transform.position = objectsPostion;

        Destroy(this.gameObject);
    }
}
