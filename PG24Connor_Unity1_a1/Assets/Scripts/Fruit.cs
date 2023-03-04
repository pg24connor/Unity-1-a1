using UnityEngine;

public class Fruit : Score
{
    //speed is the speed of the fruit, xSpan is the radius of the spawn radius, points is the amount of points you earn per fruit destryed
    public float speed = 10;
    public float xSpan = 20;
    public int points = 10;

    //starting position of the fruit, cutEffect is the particle system used for when the fruit is cut
    private Vector3 startPos;
    private ParticleSystem cutEffect;

    //set the postion and rotation of the fruit, set cuteffect
    //I know that 'FindGameObjectWithTag(String Tag)' isn't the best way of doing this but the game is running at over 200fps on this computer and i find it more readable
    void Start()
    {
        startPos = transform.position;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 1);
        transform.position = new Vector3(Random.Range(-xSpan, xSpan), transform.position.y, transform.position.z);
        cutEffect = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
    }

    //move the fruit toward the player in the simplist way posible, probally not the most proformant but again, over 200fps
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    /// <summary>
    /// reset the fruit
    /// </summary>
    private void Restart()
    {
        gameObject.SetActive(false);
        transform.position = startPos;
        Destroy(gameObject.GetComponent<Fruit>());
    }

    /// <summary>
    /// all the effects that should happen when the fruit gets cut
    /// </summary>
    private void Effects()
    {
        AddScore(points);
        cutEffect.transform.position = transform.position;
        cutEffect.Play();
    }

    /// <summary>
    /// if it collides with anything ecept the ground, restart, if the sword all the effects
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ground"))
        {
            if (other.CompareTag("Sword")) Effects();
            Restart();
        }
    }
}