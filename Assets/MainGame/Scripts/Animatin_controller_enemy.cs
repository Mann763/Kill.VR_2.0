using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animatin_controller_enemy : MonoBehaviour
{
    [SerializeField] GameObject[] _dpoints;
    [SerializeField] Transform _Destinationpoint;
    [SerializeField] int index;

    // Start is called before the first frame update
    void Start()
    {
        _dpoints = GameObject.FindGameObjectsWithTag("Dpoints");
        index = Random.Range(0, _dpoints.Length);
        _Destinationpoint= _dpoints[index].transform;
        transform.DOJump(_Destinationpoint.position, 2f, 1, 2f, false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.DOMove(_Destinationpoint.position, 2f);
    }
}
