using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {

    public Transform mHandMesh;

	// Update is called once per frame
	void Update () {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("balonas"))
            return;
        Debug.Log("Balonas lovit");
        // collision.gameObject.SetActive(false);

        Destroy(collision.gameObject);
    }
}
