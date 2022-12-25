using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    [Header("Currency")]
    [SerializeField]
    TextMeshProUGUI currencyText;
    private int _currencyAmount;
    public int currencyAmount
    {
        get { return _currencyAmount; }
        set
        {
            _currencyAmount = value;

            currencyText.text = value.ToString();
        }

    }

    [Header("CurrencyPool")]
    [SerializeField] GameObject animatedCurrencyPrefab;
    [SerializeField] RectTransform target;
    [SerializeField] int maxCurrency;
    [SerializeField] TextMeshProUGUI amountText;
    Queue<GameObject> currencyQueue = new Queue<GameObject>();

    [Space]
    [Header("Animation Settings")]
    Vector3 targetPosition;
    [SerializeField] float animDuration;
    [SerializeField] float spread;
    [SerializeField] float spawnCenterOffset;
    [SerializeField] Ease easeType = Ease.Linear;


    [Space]
    [Header("LoadingScreen")]
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Slider loadingSlider;

    [Space]
    [Header("EndPanel")]
    [SerializeField]
    private GameObject EndPanel;
    [SerializeField] private GameObject WinPanel;


    private void Awake()
    {
        instance = this;

        targetPosition = target.anchoredPosition;

        PrepareCurrencies();

    }

    void PrepareCurrencies()
    {
        GameObject currency;
        for (int i = 0; i < maxCurrency; i++)
        {
            currency = Instantiate(animatedCurrencyPrefab);
            currency.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            currency.SetActive(false);
            currencyQueue.Enqueue(currency);
        }
    }

    void Animate(Vector3 collectedCurrencyPosition, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (currencyQueue.Count > 0)
            {
                GameObject currency = currencyQueue.Dequeue();
                currency.SetActive(true);

                RectTransform rect = currency.GetComponent<RectTransform>();
                rect.anchoredPosition = collectedCurrencyPosition + new Vector3(Random.Range(-spread,spread), Random.Range(-spread, spread), 0f);

                rect.DOAnchorPos(targetPosition, animDuration).OnComplete(() => GainCurrency(currency)).SetEase(easeType);
            }
        }
    }
    void GainCurrency(GameObject currency)
    {
        currency.SetActive(false);
        currencyQueue.Enqueue(currency);

        currencyAmount++;
    }
    private void Start()
    {
        amountText.text = currencyAmount.ToString();
    }

    public void WinUI()
    {
        WinPanel.SetActive(true);
    }

    public void FailUI()
    {
        EndPanel.SetActive(true);
    }

    public void AddCurrency(int amount)
    {
        Animate(Vector3.zero + Vector3.up*-spawnCenterOffset,amount);
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }
    IEnumerator LoadSceneAsync(int index)
    {
        LoadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;
            yield return null;
        }
    }

}
