using UnityEngine;

public class Singleton<T> : InitMonoBehaviour where T : MonoBehaviour
{
    static T m_ins;

    public static T Instance
    {
        get
        {
            if (m_ins == null)
            {
                m_ins = GameObject.FindObjectOfType<T>();

                if (m_ins == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    m_ins = singleton.AddComponent<T>();
                }
            }
            return m_ins;
        }
    }

    protected override void Awake() => MakeSingleton(true);

    public void MakeSingleton(bool destroyOnload)
    {
        if (m_ins == null)
        {
            m_ins = this as T;
            if (destroyOnload)
            {
                var root = transform.root;

                if (root != transform)
                {
                    DontDestroyOnLoad(root);
                }
                else
                {
                    DontDestroyOnLoad(this.gameObject);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}