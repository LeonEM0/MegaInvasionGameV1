using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BlastWave : MonoBehaviour
{
    public int pointsCount;
    public float maxRadius;
    public float speed;
    public float startWidth;
    public GameObject wave_particles;
    public GameObject wave_particles2;
    public Transform player;
    public AudioClip powerupsound;
    public AudioClip powerupsound2reigan;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount + 1;

    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            AudioManagerSingleton.Instance.PlaySound(powerupsound2reigan);
            AudioManagerSingleton.Instance.PlaySound(powerupsound);
            StartCoroutine(Blast());

            StartCoroutine(InstatiateWithDelay());

            
            
            Debug.Log("explosion");
        }
    }
   

    private IEnumerator Blast()
    {
        float currentRadius = 0f;
        while(currentRadius < maxRadius)
        {
            currentRadius += Time.deltaTime * speed;
            Draw(currentRadius);
            yield return 5f;
           
        }

    }
    IEnumerator InstatiateWithDelay()
    {
        GameObject aura1 = Instantiate(wave_particles, player.transform.position, this.transform.rotation);
        GameObject aura2 = Instantiate(wave_particles2, player.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(0.1f);

        Destroy(aura1, 2f);
        Destroy(aura2, 2f);
         


    }

    private void Draw(float currentRadius)
    {
        float angleBetweenPoints = 360f / pointsCount;
         
        for(int i = 0; i <= pointsCount; i++)
        {
            float angle = i * angleBetweenPoints * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            Vector3 position = direction * currentRadius;

            lineRenderer.SetPosition(i, position);
        }

        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius / maxRadius);

    }


}
