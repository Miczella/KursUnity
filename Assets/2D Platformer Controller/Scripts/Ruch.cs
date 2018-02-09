using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour {
	public Rigidbody2D Fizyka;
	public float MocSkoku;
	public float SzybkoscPoruszaniasie;
    public bool jestnaziemi;
	// Use this for initialization
	void Start () {
		Fizyka = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")&&jestnaziemi == true) {
			Fizyka.AddForce (Vector2.up*MocSkoku, ForceMode2D.Impulse);
		}
		if (Input.GetAxis ("Horizontal")!=0 && jestnaziemi == true) {
			Fizyka.AddForce (Vector2.right * SzybkoscPoruszaniasie*Input.GetAxis ("Horizontal"), ForceMode2D.Force);
		}
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ziemia")
        {
            jestnaziemi = true;
        }
    }
	void OnCollisionStay2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ziemia")
		{
			jestnaziemi = true;
		}
	}
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ziemia")
        {
            jestnaziemi = false;
        }
    }
}
