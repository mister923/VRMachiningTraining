using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float angleDelta;

    [SerializeField] private float m_FadeDuration = 0.1f;       // How long it takes for the arrows to appear and disappear.
    [SerializeField] private float m_ShowAngle = 30f;// How far from the desired facing direction the player must be facing for the arrows to appear.
    [SerializeField] private float VGMaxAlpha = -2f;
    [SerializeField] private float VGMinAlpha = -0.5f;
    [SerializeField] private Transform m_DesiredLocation;      // Indicates which direction the player should be facing (uses world space forward if null).
    [SerializeField] private Transform m_Camera;                // Reference to the camera to determine which way the player is facing.
    [SerializeField] private Renderer[] m_ArrowRenderers;       // Reference to the renderers of the arrows used to fade them in and out.

    private float m_CurrentAlpha;                               // The alpha the arrows currently have.
    private float[] m_TargetAlpha;                              // The alpha the arrows are fading towards.
    private float VGAlpha;
    private float m_FadeSpeed;                                  // How much the alpha should change per second (calculated from the fade duration).
    private int angleSign;
    private const string k_MaterialPropertyName = "_Alpha";     // The name of the alpha property on the shader being used to fade the arrows.

    public TextManager textManager;
    public DataManager dataManager;

    private void Start()
    {
        // Speed is distance (zero alpha to one alpha) divided by time (duration).
        m_FadeSpeed = 1f / m_FadeDuration;
        transform.position = m_Camera.position;
        transform.eulerAngles = new Vector3(0, m_Camera.eulerAngles.y, 0);
    }

    public void nextPoint()
    {
        if (dataManager.attentionPosition[textManager.pageIndex] == "")
        {
            gameObject.SetActive(false);

        }
        else
        {
            m_DesiredLocation = GameObject.Find(dataManager.attentionPosition[textManager.pageIndex - textManager.offs]).transform;
            gameObject.SetActive(true);
        }
    }
    private void LiveAlpha()
    {
        VGAlpha = VGMinAlpha + (VGMaxAlpha - VGMinAlpha) * Mathf.Abs(angleDelta) / 180f;

    }
        void Update()
    {
        Vector3 directAim = m_DesiredLocation.transform.position - m_Camera.transform.position; // The vector shooting from camrea to the cat
        Vector3 desiredForward = m_DesiredLocation == null ? Vector3.forward : Vector3.ProjectOnPlane(directAim, Vector3.up).normalized;//The vector is now flat on x-z plane
        Vector3 flatCamForward = Vector3.ProjectOnPlane(m_Camera.forward, Vector3.up).normalized; // The forward vector of the camera as it would be on a flat plane.

        // The difference angle between the desired facing and the current facing of the player.
        angleSign = Vector3.Cross(desiredForward, flatCamForward).y < 0 ? -1 : 1; //Just -1 or 1
        angleDelta = angleSign * Vector3.Angle(desiredForward, flatCamForward);
        LiveAlpha();
        // If the difference is greater than the angle at which the arrows are shown, their target alpha is one otherwise it is zero.
        if (-1 * m_ShowAngle < angleDelta && angleDelta < m_ShowAngle)
        { //within in -30 to 30
            m_TargetAlpha = new float[] { 0f, 0f, 0f };
        }
        else if (angleDelta < -1 * m_ShowAngle)
        { // smaller than -30
            m_TargetAlpha = new float[] { VGAlpha, 0f, VGAlpha };
        }
        else if (m_ShowAngle < angleDelta)
        {   //lager than 30
            m_TargetAlpha = new float[] { 0f, VGAlpha, VGAlpha };
        }
        else
        {
            m_TargetAlpha = new float[] { VGAlpha, VGAlpha, VGAlpha };
        }
        for (int i = 0; i < m_ArrowRenderers.Length; i++)
        {
            m_ArrowRenderers[i].material.SetFloat(k_MaterialPropertyName, m_TargetAlpha[i]);
        }


        transform.position = m_Camera.position;
        Vector3 targetOnXZ = new Vector3(m_DesiredLocation.position.x, this.transform.position.y, m_DesiredLocation.position.z);
        transform.LookAt(targetOnXZ);// Refresh both posistion and rotation.
    }
}
