using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
    

	//private GameObject _enemy;
    private ArrayList _enemies;

    void Start()
    {
        _enemies = new ArrayList();

        GameObject newEnemy = new GameObject();

        newEnemy = Instantiate(enemyPrefab) as GameObject;

        newEnemy.transform.position = new Vector3(0, 1, 0);

        float angle = Random.Range(0, 360);

        newEnemy.transform.Rotate(0, angle, 0);

        _enemies.Add(newEnemy);

    }


    void Update() {

        foreach (GameObject enemy  in _enemies)
        {
            if (enemy == null)
            {   

                //add 1 enemy to restore the dead one 
                GameObject oldEnemy = Instantiate(enemyPrefab) as GameObject;
                oldEnemy.transform.position = new Vector3(0, 1, 0);
                float angle = Random.Range(0, 360);

                oldEnemy.transform.Rotate(0, angle, 0);

                _enemies.Add(oldEnemy);

                //remove the null element 
                _enemies.Remove(enemy);


                //now add a new enemy

                GameObject newEnemy = Instantiate(enemyPrefab) as GameObject;
                newEnemy.transform.position = new Vector3(0, 1, 0);
                angle = Random.Range(0, 360);

                newEnemy.transform.Rotate(0, angle, 0);

                _enemies.Add(newEnemy);
            }

        }
    }
}
