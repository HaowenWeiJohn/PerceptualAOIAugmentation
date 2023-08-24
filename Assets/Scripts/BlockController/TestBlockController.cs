using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlockController : BlockController
{
    // Start is called before the first frame update

    [Header("Image Loader")]
    public ImageLoader testBlockImageLoader;
    public int imageIndex = 0;



    void Start()
    {
        experimentStates = ExperimentPreset.ConstructTestBlock();
        DisableSelf();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    public override void initExperimentBlockStates()
    {
        base.initExperimentBlockStates();
        experimentStates = ExperimentPreset.ConstructTestBlock();
    }

    //public override void initExperimentBloc
    





}
