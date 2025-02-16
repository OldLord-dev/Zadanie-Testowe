using UnityEngine;

[CreateAssetMenu(fileName = "doorData", menuName = "Door Data", order = 50)]
public class DoorData : ScriptableObject
{
    [SerializeField]
    private float asteroidScale;
    [SerializeField]
    private float asteroidSpeed;
    [SerializeField]
    private float asteroidPoints;

    public float AsteroidScale { get { return asteroidScale; } }
    public float AsteroidSpeed { get { return asteroidSpeed; } }
    public float AsteroidPoints { get { return asteroidPoints; } }
}