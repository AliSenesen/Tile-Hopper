using System.Collections.Generic;
using UnityEngine;

namespace GameMng.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> uiPanelsList;
        
        public void OnOpenPanel(UIPanels panels)
        {
          uiPanelsList[(int)panels].SetActive(true);
        }

        public void OnClosePanel(UIPanels panels)
        {
            uiPanelsList[(int)panels].SetActive(false);
        }
        
    }
    
   
}