using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderToyController : MonoBehaviour
{
    public Shader shaderToy;
    private Material shaderToyMaterial = null;

    public Material Material
    {
        get
        {
            shaderToyMaterial = GetMat(shaderToy, shaderToyMaterial);
            return shaderToyMaterial;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Material);
    }

    Material GetMat(Shader shader, Material material)
    {
        if(shader == null)
        {
            return null;
        }

        if (!shader.isSupported)
        {
            return null;
        }
        else
        {
            material = new Material(shader)
            {
                hideFlags = HideFlags.DontSave
            };
            return material;
        }
    }
}
