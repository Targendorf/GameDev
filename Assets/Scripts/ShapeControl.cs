using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShapeControl : MonoBehaviour {

	public GameObject cube;
	public GameObject plane;
	public GameObject triangle;
	public ParticleSystem _particle;
	public Camera _camera;
	public float mouseSensitivity = 0.1f; //порог чувствительности
	public Vector2 planeMinMaxScale = new Vector2(3,20);
	public Vector2 triangleMinMaxAngle = new Vector2(40,70); 
	public Vector2 cubeMinMaxAngle = new Vector2(70,110);
	private List<Vector3> position;
	private bool isMove;
	private float curTime;

	void Start () 
	{
		Reset();
	}

	void Reset()
	{
		_particle.emissionRate = 0;
		position = new List<Vector3>();
		isMove = true;
		curTime = 0;
	}

	void AddShape(int pointCount)
	{
		float angle;
		Vector3 center;
		Vector3 tmp;
		float scale;
		float S1, S2, S3, S4;
		switch(pointCount)
		{
		case 2:
			scale = Vector3.Distance(position[0], position[1]);
			if(scale <= planeMinMaxScale.y && scale >= planeMinMaxScale.x)
			{
				center = (position[0] + position[1])/2;
				tmp = position[1] - center;
				angle = Mathf.Atan2(tmp.y, tmp.x) * Mathf.Rad2Deg;
				GameObject obj = Instantiate(plane, center, Quaternion.identity) as GameObject;
				obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				obj.transform.localScale = new Vector3(scale/3, 1, 1);
			}
			break;
		case 4:
			scale = Vector3.Distance(position[0], position[1]);
			S1 = AngleRelativeToPoint(position[1], position[2], position[0]);
			S2 = AngleRelativeToPoint(position[0], position[2], position[1]);
			S3 = AngleRelativeToPoint(position[1], position[2], position[3]);
			//проверка углов
			if((S1 < triangleMinMaxAngle.y && S1 > triangleMinMaxAngle.x) && 
			   (S2 < triangleMinMaxAngle.y && S2 > triangleMinMaxAngle.x) && 
			   (S3 < triangleMinMaxAngle.y && S3 > triangleMinMaxAngle.x))
			{
				center = (position[0] + position[1])/2;
				center = (center + position[2])/2;
				tmp = position[2] - center;
				angle = Mathf.Atan2(tmp.y, tmp.x) * Mathf.Rad2Deg;
				GameObject obj = Instantiate(triangle, center, Quaternion.identity) as GameObject;
				obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				obj.transform.localScale = Vector3.one * scale/3;
			}
			break;
		case 5:
			scale = Vector3.Distance(position[0], position[2]);
			S1 = AngleRelativeToPoint(position[1], position[3], position[0]);
			S2 = AngleRelativeToPoint(position[0], position[2], position[1]);
			S3 = AngleRelativeToPoint(position[4], position[2], position[3]);
			S4 = AngleRelativeToPoint(position[1], position[3], position[4]);

			if((S1 < cubeMinMaxAngle.y && S1 > cubeMinMaxAngle.x) && 
			   (S2 < cubeMinMaxAngle.y && S2 > cubeMinMaxAngle.x) && 
			   (S3 < cubeMinMaxAngle.y && S3 > cubeMinMaxAngle.x) && 
			   (S4 < cubeMinMaxAngle.y && S4 > cubeMinMaxAngle.x))
			{
				center = (position[0] + position[2])/2;
				tmp = ((position[0] + position[1])/2) - center;
				angle = Mathf.Atan2(tmp.y, tmp.x) * Mathf.Rad2Deg;
				GameObject obj = Instantiate(cube, center, Quaternion.identity) as GameObject;
				obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				obj.transform.localScale = Vector3.one * scale/3;
			}
			break;
		}

		Reset();
	}

	float AngleRelativeToPoint(Vector3 posA, Vector3 posB, Vector3 point)
	{
		var ab = point - posA;
		var ac = point - posB;
		float angle = Vector3.Angle(ab, ac);
		return Mathf.Round(angle);
	}

	void Update () 
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(_camera.transform.position.z));
		Vector3 mouse = _camera.ScreenToWorldPoint(curScreenPoint);
		if(Input.GetMouseButton(0))
		{
			_particle.transform.position = mouse;
			_particle.emissionRate = 200;
			if(Mathf.Abs(Input.GetAxis("Mouse X")) > mouseSensitivity || Mathf.Abs(Input.GetAxis("Mouse Y")) > mouseSensitivity)
			{
				isMove = true;
				curTime = 0;
			}
			else if(Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") == 0)
			{
				curTime += Time.deltaTime;
				if(curTime > 0.1f)
				{
					if(isMove)
					{
						isMove = false;
						position.Add(mouse);
					}
				}

			}
		}
		else if(Input.GetMouseButtonUp(0))
		{
			AddShape(position.Count);
		}

	}
}
