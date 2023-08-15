using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageLoaderController : MonoBehaviour
{
    public GameManager gameManager;
    public string imageDirectory; // Directory path where your images are located
    public List<Texture2D> loadedTextures = new List<Texture2D>(); // List to hold loaded textures
    public Image imageComponent;

    void Start()
    {
        LoadImages();
    }

    void Update()
    {
        if(imageComponent != null && loadedTextures.Count > 0 && gameManager.imageIndex >= 0 && gameManager.imageIndex < loadedTextures.Count)
        {
            if (gameManager.imageIndex.ToString() != imageComponent.sprite.name)
            {
                Texture2D selectedTexture = loadedTextures[gameManager.imageIndex];
                
                // Convert the selected Texture2D to a sprite
                Sprite sprite = Sprite.Create(selectedTexture, new Rect(0, 0, selectedTexture.width, selectedTexture.height), new Vector2(0.5f, 0.5f));
                sprite.name = gameManager.imageIndex.ToString();

                // Set the sprite as the Image component's sprite
                imageComponent.sprite = sprite;
            }
        }
    }

    void LoadImages()
    {
        string[] imagePaths = Directory.GetFiles(imageDirectory, "*.png");

        foreach (string imagePath in imagePaths)
        {
            Texture2D texture = LoadTextureFromFile(imagePath);
            if (texture != null)
            {
                texture.name = Path.GetFileNameWithoutExtension(imagePath);
                loadedTextures.Add(texture);
            }
        }
    }

    Texture2D LoadTextureFromFile(string filePath)
    {
        byte[] imageData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(5375, 2670); // You might need to adjust the size
        if (texture.LoadImage(imageData))
            return texture;
        else
            return null;
    }
}
