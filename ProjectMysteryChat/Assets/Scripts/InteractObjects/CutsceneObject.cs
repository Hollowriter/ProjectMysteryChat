using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneObject : InteractObject
{
    public List<SceneAlgorithm> scenes;

    public override void NearPlayer() // Nota: Falta testear este objeto bien. Guardar el codigo para terminar de realizar las pruebas con la colision directa del jugador.
    {
        CutsceneManager.instance.SetCutscenes(scenes);
        SetPermanentInteraction();
    }
}
