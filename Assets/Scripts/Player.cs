using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerMoveSpeed;

	void Update () {
        PlayerMove();
	}

    void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime;

        transform.Translate(moveX, 0, moveZ);
    }
}
