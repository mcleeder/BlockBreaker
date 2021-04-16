using UnityEngine;

public class startGame : MonoBehaviour
{

    public TMPro.TextMeshProUGUI pressSpace;
    public TMPro.TextMeshProUGUI levelNumber;

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
        levelNumber.text = "";
    }
}
