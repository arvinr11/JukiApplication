using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AturDeskripsi : MonoBehaviour
{
    [Header("Deskripsi Jamu")]
    public TrackableAR[] tr;
    public string[] nama;
    [TextArea]
    public string[] deskripsi;

    [Header("UI Deskripsi")]
    public TMP_Text txtNama;
    public TMP_Text txtDeskripsi;
    public GameObject goNama;
    public GameObject goDeskripsi;

    public bool[] cekMarker;
    int countMarker;

    void Start()
    {
        cekMarker = new bool[tr.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tr.Length; i++)
        {
            if (tr[i].GetMarker())
            {
                txtNama.text = nama[i];
                txtDeskripsi.text = deskripsi[i];

                if(!cekMarker[i])
                {
                    countMarker++;
                    cekMarker[i] = true;
                }
            } 
            else
            {
                if(cekMarker[i])
                {
                    countMarker--;
                    cekMarker[i] = false;
                }
            }
        }

        DeskripsiPanel();
    }

    private void DeskripsiPanel()
    {
        if(countMarker == 0)
        {
            goNama.SetActive(false);
            goDeskripsi.SetActive(false);
        }
        else
        {
            goNama.SetActive(true);
            goDeskripsi.SetActive(true);
        }
    }
}
