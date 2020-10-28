using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

//[System.Serializable]
public class BulletPoolManager { 

    private GameObject bullet;
    //[SerializeField]
    private int _maxBullets = 6;

    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> _bulletPool;

    //singleton
    private static BulletPoolManager m_instance = null;

    private BulletPoolManager()
    {
        Start();
    }

    public static BulletPoolManager Instance()
    {
        if (m_instance == null)
        {
            m_instance = new BulletPoolManager();
        }

        return m_instance;
    }


    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load("Prefabs/Bullet") as GameObject;

        // TODO: add a series of bullets to the Bullet Pool
        _bulletPool = new Queue<GameObject>();
        _BuildBulletPool();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void _BuildBulletPool()
    {
        for (int i = 0; i < _maxBullets; i++)
        {
            var bulletClone = MonoBehaviour.Instantiate(bullet);
            bulletClone.SetActive(false);
            _bulletPool.Enqueue(bulletClone);
        }
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        if (!isEmpty())
        {
            bullet = _bulletPool.Dequeue();
        } else
        {
            _bulletPool.Enqueue(MonoBehaviour.Instantiate(bullet));
        }
        bullet.SetActive(true);
        return bullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject _bullet)
    {
        _bullet.SetActive(false);
        _bulletPool.Enqueue(_bullet);
    }

    public int currentSize()
    {
        return _bulletPool.Count;
    }

    public bool isEmpty()
    {
        return (_bulletPool.Count <= 0);
    }

}
