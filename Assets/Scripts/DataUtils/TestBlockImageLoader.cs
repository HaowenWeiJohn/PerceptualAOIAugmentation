using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockImageLoader : ImageLoader
{
    // Start is called before the first frame update
    void Start()
    {
        imageDirectoryPath = Presets.TestBlockImageDirectoryPath;
        loadImageToTextures();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
