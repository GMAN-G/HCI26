using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
            }
            return m_instance;
        }
    }

    static GameManager m_instance;

    public void GameOver()
    {
        Application.Quit();
    }
}
