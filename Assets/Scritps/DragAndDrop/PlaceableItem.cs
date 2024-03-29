using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class PlaceableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Public Variables

    // Transform that the item will snap to after being released from drag
    [HideInInspector] public Transform NextParent;

    #endregion

    #region Parameters

    [SerializeField] private float dragOutDuration = 0.2f;
    [SerializeField] private Ease dragOutTransition = Ease.OutCirc;
    [SerializeField] private float draggedScale = 1.2f;

    [Space(10)]
    [SerializeField] private float dragInDuration = 0.2f;
    [SerializeField] private Ease dragInTransition = Ease.OutCirc;


    #endregion

    #region Private Variables
    
    // Used to control the item iteractibility
    private CanvasGroup _canvasGroup;

    private Transform lastParent;

    #endregion

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastParent = transform.parent;
        NextParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        NextParent.GetComponent<INotifiableSlot>()?.OnItemDraggedOut(gameObject);

        _canvasGroup.blocksRaycasts = false;

        transform.DOKill();
        transform.DOScale(new Vector3(draggedScale, draggedScale, draggedScale), dragOutDuration).SetEase(dragOutTransition);
    }

    // Drag Out
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }


    // Drag In
    public void OnEndDrag(PointerEventData eventData)
    {

        if (lastParent == NextParent)
        {
            StateManager.Instance.AddLastItem();
        }

        // Parent after drag is called before by the drop handler thingy
        transform.SetParent(NextParent);

        _canvasGroup.blocksRaycasts = true;

        NextParent.GetComponent<INotifiableSlot>()?.OnItemDraggedIn(gameObject);

        transform.DOKill();
        transform.DOLocalMove(new(0, 0, 0), dragInDuration).SetEase(dragInTransition);

        transform.DOScale(new Vector3(1, 1, 1), dragInDuration).SetEase(dragInTransition);
    }

    private void OnDestroy()
    {
        transform.DOKill(gameObject);
    }
}
