using System.Collections;
using TMPro;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.UI
{

    public class AlertView : MonoBehaviour
    {   

        [SerializeField]  
        private float m_AlertTime = 3f;

        [SerializeField]  
        private TextMeshProUGUI m_AlertText;

        [SerializeField]
        private TextMeshProUGUI m_AlertTextBg;

        [SerializeField]
        private GameObject m_View;

        private Coroutine m_AlertCoroutine;

        public void SetData(string value, bool overwrite)
        {
            if(overwrite && m_AlertCoroutine != null)
            {
                StopCoroutine(m_AlertCoroutine);
                m_View.SetActive(false);
            }

            if(m_View.activeInHierarchy)
                return;

            m_AlertText.text = value;
            m_AlertTextBg.text = value;

            m_AlertCoroutine = StartCoroutine(DisplayAlert());
        }
        
        private IEnumerator DisplayAlert()
        {
            m_View.SetActive(true);

            yield return new WaitForSeconds(m_AlertTime);

            m_View.SetActive(false);
        }
    }
}