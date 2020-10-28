using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    private int _maxBullets = 0;

    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> _bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        _bulletPool = new Queue<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        if (_bulletPool.Count < 0)
        {
            _bulletPool.Enqueue(bullet);
        }
        bullet = _bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject _bullet)
    {
        _bullet.SetActive(false);
        _bulletPool.Enqueue(_bullet);
    }
}
