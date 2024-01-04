using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
	None,
	DoubleBoost,
	ExtraSpeed,
	Bullet,
	DeathRayOfDoom
}

public class PowerUp : MonoBehaviour
{
	public PowerUpType powerUpType;
}