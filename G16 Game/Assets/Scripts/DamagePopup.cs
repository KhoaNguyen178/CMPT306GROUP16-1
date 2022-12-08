using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(Vector3 position, float damage)
    {
        Transform damagePopupTransform = Instantiate(GameManager.instance.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damage);
        return damagePopup;
    }

    [SerializeField] private Transform pfDamagePopup;
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    // Start is called before the first frame update

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(float damage)
    {
        textMesh.SetText(damage.ToString());
        textColor = textMesh.color;
        disappearTimer = 0.5f;
    }

    void Update()
    {
        float moveYSpeed = 5f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
