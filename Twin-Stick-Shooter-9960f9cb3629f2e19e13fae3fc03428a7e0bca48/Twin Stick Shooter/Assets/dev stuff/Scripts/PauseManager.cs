using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    public bool IsPaused;

    [SerializeField]
    private GameObject PauseScreen;
    private List<ParticleSystem> m_ParticleSystems;
    [SerializeField]
    private List<Rigidbody> m_Rigidbodies;
    [SerializeField]
    private List<NavMeshAgent> m_NavMeshes;
    [SerializeField]
    private List<WalkerScript> m_Walkers;
    private List<RigidbodyData> m_RigidbodyData;

    private void Awake()
    {
        Instance = this;

        m_ParticleSystems = new List<ParticleSystem>();
        //m_Rigidbodies = new List<Rigidbody>();
        m_RigidbodyData = new List<RigidbodyData>();
        //m_NavMeshes = new List<NavMeshAgent>();
    }

    public void Add(Rigidbody _rigidbody)
    {
        m_Rigidbodies.Add(_rigidbody);
    }
    public void Add(ParticleSystem _ps)
    {

    }
    public void Add(NavMeshAgent _navmesh)
    {
        m_NavMeshes.Add(_navmesh);
    }
    public void Add(WalkerScript _Walkers)
    {
        m_Walkers.Add(_Walkers);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }
        if (IsPaused == true)
        {
            Pause();
        }
        if (IsPaused == false)
        {
            Resume();
        }
    }
    public void Pause()
    {
        Cursor.visible = true;
        PauseScreen.SetActive(true);
        for (int i = 0; i < m_NavMeshes.Count; i++)
        {
            m_NavMeshes[i].speed = 0;
        }
        for (int r = 0; r < m_Rigidbodies.Count; r++)
        {
            // Store backup data
            RigidbodyData _data = new RigidbodyData()
            {
                InstanceID = m_Rigidbodies[r].GetInstanceID(),
                Velocity = m_Rigidbodies[r].velocity,
                Drag = m_Rigidbodies[r].drag,
                AngularDrag = m_Rigidbodies[r].angularDrag
            };
            m_RigidbodyData.Add(_data);

            // Reset values
            m_Rigidbodies[r].velocity = Vector3.zero;
            m_Rigidbodies[r].drag = 0;
            m_Rigidbodies[r].angularDrag = 0;

            // Paused
            m_Rigidbodies[r].isKinematic = true;
            m_Rigidbodies[r].Sleep();
        }
        for (int i = 0; i < m_Walkers.Count; i++)
        {
            m_Walkers[i].enabled = false;
        }

        IsPaused = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        PauseScreen.SetActive(false);
        for (int i = 0; i < m_NavMeshes.Count; i++)
        {
            m_NavMeshes[i].speed = 3.5f;
        }
        for (int r = 0; r < m_Rigidbodies.Count; r++)
        {
            // Fetch data
            RigidbodyData _data = m_RigidbodyData.Find(i => i.InstanceID == m_Rigidbodies[r].GetInstanceID());

            // Set data back
            m_Rigidbodies[r].velocity = _data.Velocity;
            m_Rigidbodies[r].drag = _data.Drag;
            m_Rigidbodies[r].angularDrag = _data.AngularDrag;

            // Resume physics
            m_Rigidbodies[r].isKinematic = false;
            m_Rigidbodies[r].WakeUp();
        }
        for (int i = 0; i < m_Walkers.Count; i++)
        {
            m_Walkers[i].enabled = true;
        }
        m_RigidbodyData.Clear();
        IsPaused = false;
    }

    public struct RigidbodyData
    {
        public int InstanceID;
        public Vector3 Velocity;
        public float Drag;
        public float AngularDrag;
    }
    public void ResumeButton()
    {
        IsPaused = !IsPaused;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen (proto)");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
