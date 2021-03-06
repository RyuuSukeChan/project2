﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    Vector2 arrowPos;
    Vector2 direction;
    float speed = 10;
    int damage = 5;

	void Start ()
    {
        arrowPos = Camera.main.WorldToScreenPoint(transform.position);
        direction = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - arrowPos).normalized;
    }

	void Update ()
    {
        this.transform.Translate(new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "Slime")
        {
            other.GetComponent<Slime>().RecieveDamage();
        }
        if (other.gameObject.tag == "SpitterSlime")
        {
            other.GetComponent<SpitterSlime>().RecieveDamage(damage);
        }
        if (other.gameObject.tag == "PassiveSlime")
        {
            other.GetComponent<PassiveSlime>().RecieveDamage(damage);
        }
        if (other.gameObject.tag == "BossSlime")
        {
            other.GetComponent<BossSlime>().RecieveDamage();
        }
        if (other.gameObject.tag == "MiniBossSlime")
        {
            other.GetComponent<MiniBossSlime>().RecieveDamage(damage);
        }

        Destroy(this.gameObject);

    }
}
