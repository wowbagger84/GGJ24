using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	private bool updateYPosition = false;

	void LateUpdate()
	{
		float desiredPositionY;

		if (updateYPosition || target.position.y + offset.y < transform.position.y)
		{
			desiredPositionY = target.position.y + offset.y;
		}
		else
		{
			desiredPositionY = transform.position.y;
		}

		float desiredPositionX = target.position.x + offset.x;
		float desiredPositionZ = target.position.z + offset.z;

<<<<<<< Updated upstream
		Vector3 desiredPosition = new Vector3(desiredPositionX, desiredPositionY, desiredPositionZ);
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}


	public void UpdateYPosition(bool updatedYPosition)
	{
		updateYPosition = updatedYPosition;
	}
=======
    Vector3 desiredPosition = new Vector3(desiredPositionX, desiredPositionY, desiredPositionZ);
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    transform.position = smoothedPosition;
}

    public void UpdateYPosition(bool updatedYPosition)
    {
        updateYPosition = updatedYPosition;
    }
>>>>>>> Stashed changes
}
