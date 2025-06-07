using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteBundleLoader : MonoBehaviour
{
    [Header("URL del AssetBundle")]
    public string bundleUrl = "http://localhost:3000/bundle";

    [Header("Nombre del prefab dentro del bundle")]
    public string assetName = "Player"; // el nombre exacto del prefab

    void Start()
    {
        StartCoroutine(LoadAssetBundle());
    }

    IEnumerator LoadAssetBundle()
    {
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al descargar el AssetBundle: " + uwr.error);
                yield break;
            }

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
            if (bundle == null)
            {
                Debug.LogError("AssetBundle nulo");
                yield break;
            }

            GameObject prefab = bundle.LoadAsset<GameObject>(assetName);
            if (prefab != null)
            {
                Instantiate(prefab, Vector3.zero, Quaternion.identity);
                Debug.Log("Personaje instanciado desde bundle.");
            }
            else
            {
                Debug.LogError($"No se encontró el prefab '{assetName}' en el bundle.");
            }

            bundle.Unload(false); // liberar memoria sin destruir objetos instanciados
        }
    }
}
