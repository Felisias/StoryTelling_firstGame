using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] spawningConnectables;
    [SerializeField] private float coolDown =1f;
    [SerializeField] private bool canSpawning = true;

    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        spawnPosition.position = new Vector2(Mathf.Clamp(cam.ScreenToWorldPoint(Input.mousePosition).x, leftBorder.position.x, rightBorder.position.x), spawnPosition.position.y);

        if (Input.GetKeyUp(KeyCode.Mouse0))
            StartCoroutine(TryToInstantiateConnectable());
    }

    private IEnumerator TryToInstantiateConnectable()
    {
        if (canSpawning)
        {
            canSpawning = false;

            int rnd = Random.Range(0, spawningConnectables.Length);

            Instantiate(spawningConnectables[rnd], spawnPosition.position, Quaternion.identity);

            yield return new WaitForSeconds(coolDown);

            canSpawning = true;
        }
    }
}