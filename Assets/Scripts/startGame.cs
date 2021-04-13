using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{

    public TMPro.TextMeshProUGUI pressSpace;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CubeController.Go = true;
            startGameUI();
        }
    }

    private void startGameUI()
    {
        pressSpace.text = "";
    }
}