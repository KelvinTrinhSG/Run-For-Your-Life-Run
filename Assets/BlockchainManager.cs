using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using TMPro;
using UnityEngine.UI;

public class BlockchainManager : MonoBehaviour
{
    public string Address { get; private set; }

    public GameObject tokenGatePanel;
    public GameObject mainMenuPanel;
    public GameObject shopPanel;
    
    public Button loginButton;
    public Button tokenGateBtn;
    public Text tokenGateBtnText;

    public Button playButton;
    public Button shopButton;

    public Button hpBtn;
    public Button pistolBtn;
    public Button machinegunBtn;
    public Button shotgunBtn;
    public Button uziBtn;

    public Text claimStatusText;

    private bool isPanelVisible = false;

    public GameObject player;
    public GameObject gameManager;
    public GameObject canvasManager;

    public Button reviveButton;
    public Text reviveButtonText;
    public Button rePlayButton;


    private void Start()
    {
        tokenGatePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        shopPanel.SetActive(false);
        loginButton.gameObject.SetActive(true);
    }

    public async void Login()
    {
        hpBtn.gameObject.SetActive(true);
        hpBtn.interactable = true;
        pistolBtn.gameObject.SetActive(true);
        pistolBtn.interactable = true;
        machinegunBtn.gameObject.SetActive(true);
        machinegunBtn.interactable = true;
        shotgunBtn.gameObject.SetActive(true);
        shotgunBtn.interactable = true;
        uziBtn.gameObject.SetActive(true);
        uziBtn.interactable = true;

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        Debug.Log(Address);
        Contract contract = ThirdwebManager.Instance.SDK.GetContract("0xF36a094783F77C18094a828a03F943fE28Ef574C");
        List<NFT> nftList = await contract.ERC721.GetOwned(Address);
        if (nftList.Count == 0)
        {
            tokenGatePanel.SetActive(true);
            tokenGateBtn.gameObject.SetActive(true);
            tokenGateBtn.interactable = true;
        }
        else
        {
            mainMenuPanel.SetActive(true) ;
            playButton.gameObject.SetActive(true);
            shopButton.gameObject.SetActive(true);
        }
    }

    public async void ClaimNFTPass()
    {
        tokenGateBtnText.text = "Claiming...";
        tokenGateBtn.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0xF36a094783F77C18094a828a03F943fE28Ef574C");
        var result = await contract.ERC721.ClaimTo(Address, 1);
        tokenGateBtnText.text = "Claimed NFT Pass!";
        tokenGatePanel.SetActive(false);
    }

    public void TogglePanelVisibility()
    {
        // Toggle the panel visibility state
        isPanelVisible = !isPanelVisible;

        // Set the panel active or inactive based on the new state
        shopPanel.SetActive(isPanelVisible);
    }
       
    private bool hpBtnOriginalState;
    private bool pistolBtnOriginalState;
    private bool machinegunBtnOriginalState;
    private bool shotgunBtnOriginalState;
    private bool uziBtnOriginalState;

    public async void ClaimHP()
    {
        claimStatusText.gameObject.SetActive(true);
        claimStatusText.text = "Claiming!";
        hpBtn.gameObject.SetActive(false);
        pistolBtn.interactable = false;
        machinegunBtn.interactable = false;
        shotgunBtn.interactable = false;
        uziBtn.interactable = false;
        playButton.interactable = false;
        shopButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0x421D1Da942e804b1C1aaDF2e5304343bD7554C0F");
        var result = await contract.ERC20.Claim("1");
        //HP Added here
        // Get the Player script component attached to the Player GameObject
        Game_Manger gameManagerScript = gameManager.GetComponent<Game_Manger>();
        // Check if the Player script is found
        if (gameManagerScript != null)
        {
            // Change the value of Pistol_bullet to 20
            gameManagerScript.harts += 2;
            Debug.Log("harts + 2");
        }
        else
        {
            Debug.LogError("harts error");
        }

        Debug.Log("Token claimed");
        playButton.interactable = true;
        shopButton.interactable = true;
        hpBtn.interactable = true;
        pistolBtn.interactable = true;
        machinegunBtn.interactable = true;
        shotgunBtn.interactable = true;
        uziBtn.interactable = true;
        claimStatusText.text = "+2 Hearts";
        //+2
    }

    public async void ClaimPistol()
    {
        claimStatusText.gameObject.SetActive(true);
        claimStatusText.text = "Claiming!";
        hpBtn.interactable = false;
        pistolBtn.gameObject.SetActive(false);
        pistolBtn.interactable = false;
        machinegunBtn.interactable = false;
        shotgunBtn.interactable = false;
        uziBtn.interactable = false;
        playButton.interactable = false;
        shopButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0x421D1Da942e804b1C1aaDF2e5304343bD7554C0F");
        var result = await contract.ERC20.Claim("1");

        // Get the Player script component attached to the Player GameObject
        Player playerScript = player.GetComponent<Player>();
        // Check if the Player script is found
        if (playerScript != null)
        {
            // Change the value of Pistol_bullet to 20
            playerScript.Pistol_bullet = 20;
            Debug.Log("Pistol_bullet value changed to 20");
        }
        else
        {
            Debug.LogError("Player script not found on the Player GameObject");
        }

        Debug.Log("Token claimed");
        playButton.interactable = true;
        shopButton.interactable = true;
        hpBtn.interactable = true;
        pistolBtn.interactable = true;
        machinegunBtn.interactable = true;
        shotgunBtn.interactable = true;
        uziBtn.interactable = true;
        claimStatusText.text = "Pistol Equipped!";
        //+20
    }

    public async void ClaimMachinegun()
    {
        claimStatusText.gameObject.SetActive(true);
        claimStatusText.text = "Claiming!";
        hpBtn.interactable = false;
        pistolBtn.interactable = false;
        machinegunBtn.gameObject.SetActive(false);
        machinegunBtn.interactable = false;
        shotgunBtn.interactable = false;
        uziBtn.interactable = false;
        playButton.interactable = false;
        shopButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0x421D1Da942e804b1C1aaDF2e5304343bD7554C0F");
        var result = await contract.ERC20.Claim("1");

        // Get the Player script component attached to the Player GameObject
        Player playerScript = player.GetComponent<Player>();
        // Check if the Player script is found
        if (playerScript != null)
        {
            // Change the value of Pistol_bullet to 20
            playerScript.Machinegun_bullet = 20;
            Debug.Log("Pistol_bullet value changed to 20");
        }
        else
        {
            Debug.LogError("Player script not found on the Player GameObject");
        }

        Debug.Log("Token claimed");
        playButton.interactable = true;
        shopButton.interactable = true;
        hpBtn.interactable = true;
        pistolBtn.interactable = true;
        machinegunBtn.interactable = true;
        shotgunBtn.interactable = true;
        uziBtn.interactable = true;
        claimStatusText.text = "Machinegun Equipped!";
        //+20
    }

    public async void ClaimShotgun()
    {
        claimStatusText.gameObject.SetActive(true);
        claimStatusText.text = "Claiming!";
        hpBtn.interactable = false;
        pistolBtn.interactable = false;
        machinegunBtn.interactable = false;
        shotgunBtn.gameObject.SetActive(false);
        shotgunBtn.interactable = false;
        uziBtn.interactable = false;
        playButton.interactable = false;
        shopButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0x421D1Da942e804b1C1aaDF2e5304343bD7554C0F");
        var result = await contract.ERC20.Claim("1");

        // Get the Player script component attached to the Player GameObject
        Player playerScript = player.GetComponent<Player>();
        // Check if the Player script is found
        if (playerScript != null)
        {
            // Change the value of Pistol_bullet to 20
            playerScript.Shotgun_bullet = 20;
            Debug.Log("Pistol_bullet value changed to 20");
        }
        else
        {
            Debug.LogError("Player script not found on the Player GameObject");
        }

        Debug.Log("Token claimed");
        playButton.interactable = true;
        shopButton.interactable = true;
        hpBtn.interactable = true;
        pistolBtn.interactable = true;
        machinegunBtn.interactable = true;
        shotgunBtn.interactable = true;
        uziBtn.interactable = true;
        claimStatusText.text = "Shotgun Equipped!";
        //+20
    }

    public async void ClaimUzi()
    {
        claimStatusText.gameObject.SetActive(true);
        claimStatusText.text = "Claiming!";
        hpBtn.interactable = false;
        pistolBtn.interactable = false;
        machinegunBtn.interactable = false;
        shotgunBtn.interactable = false;
        uziBtn.gameObject.SetActive(false);
        uziBtn.interactable = false;
        playButton.interactable = false;
        shopButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0x421D1Da942e804b1C1aaDF2e5304343bD7554C0F");
        var result = await contract.ERC20.Claim("1");

        // Get the Player script component attached to the Player GameObject
        Player playerScript = player.GetComponent<Player>();
        // Check if the Player script is found
        if (playerScript != null)
        {
            // Change the value of Pistol_bullet to 20
            playerScript.Uzi_bullet = 20;
            Debug.Log("Pistol_bullet value changed to 20");
        }
        else
        {
            Debug.LogError("Player script not found on the Player GameObject");
        }

        Debug.Log("Token claimed");
        playButton.interactable = true;
        shopButton.interactable = true;
        hpBtn.interactable = true;
        pistolBtn.interactable = true;
        machinegunBtn.interactable = true;
        shotgunBtn.interactable = true;
        uziBtn.interactable = true;
        claimStatusText.text = "Uzi Equipped!";
        //+20
    }

    public async void RevivePlayer() {
        reviveButtonText.text = "Reviving!";
        reviveButton.interactable = false;
        rePlayButton.interactable = false;
        var contract = ThirdwebManager.Instance.SDK.GetContract("0x421D1Da942e804b1C1aaDF2e5304343bD7554C0F");
        var result = await contract.ERC20.Claim("1");

        Canvas_Manger canvasManagerScript = canvasManager.GetComponent<Canvas_Manger>();
        if (canvasManagerScript != null)
        {
            canvasManagerScript.Revive();
            Debug.Log("Revive");
        }
        else
        {
            Debug.LogError("Revive failed");
        }

        Debug.Log("Token claimed");
        reviveButton.interactable = true;
        rePlayButton.interactable = true;
        reviveButtonText.text = "Revive!";
    }
}
