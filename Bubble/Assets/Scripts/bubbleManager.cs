using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleManager : MonoBehaviour {

    public GameObject mBubblePrefab;

    private List<bubble> mAllBubbles = new List<bubble>();
    private Vector2 mBottomLeft = Vector2.zero;
    private Vector2 mTopRight = Vector2.zero;

    private void Awake()
    {
        mBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane));
        mTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, Camera.main.farClipPlane));
    }
    
	private void Start ()
    {
        StartCoroutine(CreateBubbles());
	}
	
    private void OnDrawGigmoz()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane)), 0.5f);
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, Camera.main.farClipPlane)), 0.5f);
    }

	public Vector3 GetPlanePosition()
    {
        float targetX = Random.Range(mBottomLeft.x * 0.01f, mTopRight.x * 0.01f);
        float targetY = Random.Range(mBottomLeft.y * 0.01f, mTopRight.y * 0.01f);

        return new Vector3(targetX, targetY, 0);
    }

    private IEnumerator CreateBubbles()
    {
        while (mAllBubbles.Count < 5)
        {
            // Create and add
            GameObject newBubbleObject = Instantiate(mBubblePrefab, GetPlanePosition(), Quaternion.identity, transform);
            bubble newBubble = newBubbleObject.GetComponent<bubble>();

            //Setup bubble
            newBubble.mBubbleManager = this;
            mAllBubbles.Add(newBubble);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
