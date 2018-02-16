using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;

	//private Material greenMat;
	private Material fish; 

	//private Material greenMat;
	private Material turtle;

	//private Material greenMat;
	private Material jellyfish;

	//private Material greenMat;
	//private Texture2D tileTex;

	//private GameObject _enemy;
    private ArrayList _enemies;

    void Start()
    {
		//load enemy textures
		//greenMat = Resources.Load("GreenMaterial") as Material;
		fish = Resources.Load("fish") as Material;
		turtle = Resources.Load("turtle") as Material;
		jellyfish = Resources.Load("jellyfish") as Material;


		//add enemy to the scene 
        _enemies = new ArrayList();

        GameObject newEnemy = new GameObject();

        newEnemy = Instantiate(enemyPrefab) as GameObject;

		newEnemy.gameObject.GetComponent<Renderer>().material = fish;

        newEnemy.transform.position = new Vector3(0, 1, 0);

        float angle = Random.Range(0, 360);

        newEnemy.transform.Rotate(0, angle, 0);

        _enemies.Add(newEnemy);

    }

	Material getNextMat(){
		//Random r = new Random();
		int rInt = Random.Range(1, 3); //for ints

		if(rInt == 1){
			return jellyfish;
		}else if(rInt == 2){
			return turtle;
		}else{
			return fish;
		}

	}


    void Update() {

        foreach (GameObject enemy  in _enemies)
        {
            if (enemy == null)
            {   

                //add 1 enemy to restore the dead one 
                GameObject oldEnemy = Instantiate(enemyPrefab) as GameObject;

				oldEnemy.gameObject.GetComponent<Renderer>().material = getNextMat();

                oldEnemy.transform.position = new Vector3(0, 1, 0);
                float angle = Random.Range(0, 360);

                oldEnemy.transform.Rotate(0, angle, 0);

                _enemies.Add(oldEnemy);

                //remove the null element 
                _enemies.Remove(enemy);


                //now add a new enemy with a different texture 

                GameObject newEnemy = Instantiate(enemyPrefab) as GameObject;

				newEnemy.gameObject.GetComponent<Renderer>().material = getNextMat();

                newEnemy.transform.position = new Vector3(0, 1, 0);

                angle = Random.Range(0, 360);

                newEnemy.transform.Rotate(0, angle, 0);

                _enemies.Add(newEnemy);
            }

        }
    }
}
