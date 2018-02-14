using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacter : MonoBehaviour {
	private int _health;

    public Rect labelPosition;

    bool incrX = true;
	bool incrY = true;

    int x;
    int y;
    int height;
    int width;

    int diff = 5;


    private bool playerDead;

    void OnGUI(){
		
        GUI.Label(new Rect(10, 10, 100, 20), HealthBar());

        if (playerDead)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 27;
            //style.fontStyle;
            GUI.Label(labelPosition, "YOU DIED!!",style);
        }
	}

	void Start() {
		_health = 5;

        y = 100;
        x = 100;
        height = 100;
        width = 100;

        labelPosition = new Rect(x, y, width, height);
        playerDead = false;
		//_charController = GetComponent<CharacterController>();
	}

	public void Hurt(int damage) {
        if (_health > 0)
        {
            _health -= damage;
        }

        if (_health == 0)
        {
            playerDead = true;

            
        }
	}


    public void Update()
    {
		
        if (playerDead)
        {
            if (x <= 0)
            {
                incrX = true;

            }

            if (x >= Screen.width) {
                incrX = false;
            }
            
            if( y <= 0)
            {
                incrY = true;

            }

            if(y >= Screen.height)
            {

                incrY = false;
            }


        
            //now set x and y values 
            if (incrX)
            {

                x += diff;
                labelPosition.x += diff;
            }
            else
            {
                x -= diff;
                labelPosition.x -= diff;
            }

            if (incrY)
            {
                y += diff;
                labelPosition.y += diff;
            }
            else
            {
                labelPosition.y -= diff;
                y -= diff;
            }
            
        }

    }

	private string HealthBar(){
		
		string healthBar = "" + _health +": ";

		for(int i = 0; i < _health ; i++){
			healthBar = healthBar + "*";
		}

		return healthBar;
	}
}
