using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageProgressBarMeat: MonoBehaviour
{
    public GameObject interactObject;
    public UnityEvent onBarFilled;
    public GameObject plate;
    public int[] thisState;
    static int State;
    PlateScript plateS;
    
    // Время в секундах необходимое для заполнения Progressbar'а
    public float timeToFill = 1.0f;

    // Переменная, куда будет сохранена ссылка на компонент Image
    // текущего объекта, который является ProgressBar'ом
    private Image progressBarImage = null;
    public Coroutine barFillCoroutine = null;
    bool courStart = false;
    public bool isStartIng = false;
    bool corStart = false;
    void Start()
    {
        State = 0;
        plateS = plate.GetComponent<PlateScript>();
        // Получаем ссылку на компонент Image текущего объекта при
        // помощи метода GetComponent<>();
        progressBarImage = GetComponent<Image>();

        // Если у данного объекта нет компонента Image выводим ошибку
        // в консоль
        if (progressBarImage == null)
        {
            Debug.LogError("There is no referenced image on this component!");
        }

        // Создаём контроллер для события наведения указателя на объект
        EventTrigger eventTrigger = interactObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((eventData) => { StartFillingProgressBar(); });
        eventTrigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((eventData) => { StopFillingProgressBar(); });
        eventTrigger.triggers.Add(pointerExit);
    }

    void StartFillingProgressBar()
    {
        if ((plateS.Height > 0 || isStartIng|| State == 1) && thisState.Any(num => num == State))
        {
            corStart = true;
            barFillCoroutine = StartCoroutine("Fill");
        }

    }

    void StopFillingProgressBar()
    {
        if (corStart)
        {
            corStart = false;
            StopCoroutine(barFillCoroutine);
            progressBarImage.fillAmount = 0.0f;
        }

    }

    IEnumerator Fill()
    {
        
            float startTime = Time.time;
            float overTime = startTime + timeToFill;

            while (Time.time < overTime)
            {
                if (!plateS.ProductAddNow)
                    progressBarImage.fillAmount = Mathf.Lerp(0, 1, (Time.time - startTime) / timeToFill);
                else
                {
                    startTime = Time.time;
                    overTime = startTime + timeToFill;
                }
                yield return null;
            }

            progressBarImage.fillAmount = 0.0f;

            if (onBarFilled != null)
            {
                State++;
                if (State == 3) State = 0;
                onBarFilled.Invoke();
                
            }
            
        
    }

    public void End()
    {
        State = 0;
    }
}