using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    // Start is called before the first frame update

    //string practiceBlockImageFilePath = Presets.PracticeBlockImageFilePath;
    //string testBlockImageFilePath = Presets.TestBlockImageFilePath;

    public string imageDirectoryPath;
    public string[] imageFilePaths;
    public List<Texture2D> imageTextures = new List<Texture2D>(); // List to hold loaded textures


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //void loadImagesToTextures()
    //{
    //}

    //public void getImageFilePaths()
    //{
    //    if (imageDirectoryExist()) // if the image directory exist
    //    {
    //        string[] imageFilePaths = Directory.GetFiles(imageDirectoryPath, Presets.ImageFileFormat);
    //    }
    //    else
    //    {
    //        Debug.Log("File Does Not Exist");
    //    }
    //}


    public void loadImageToTextures()
    {
        if (imageDirectoryExist()) // if the image directory exist
        {
            string[] imageFilePaths = Directory.GetFiles(imageDirectoryPath, Presets.ImageFileFormat);

            foreach (string imageFilePath in imageFilePaths)
            {
                Texture2D imageTexture = GeneralUtils.LoadTextureFromFile(imageFilePath);
                imageTextures.Add(imageTexture);
            }

        }
        else
        {
            Debug.Log("File Does Not Exist");
        }

    }


    public bool imageDirectoryExist()
    {
        return Directory.Exists(imageDirectoryPath);
    }









}
