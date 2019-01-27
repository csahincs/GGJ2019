using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Mission : MonoBehaviour
{

    public Button missionBtn;
    // Start is called before the first frame update
    void Start()
    {
        missionBtn.onClick.RemoveAllListeners();
        missionBtn.onClick.AddListener(MissionBtnClicked);
    }

    public void MissionBtnClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
