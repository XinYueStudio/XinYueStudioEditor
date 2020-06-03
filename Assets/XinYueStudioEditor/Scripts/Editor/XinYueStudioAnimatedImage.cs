using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class XinYueStudioAnimatedImage :XinYueStudioImage
    {
    public Texture2D[] mSprites = null;
    public int mNumFrames = 0;
    public int mFramesPerSecond = 0;
    public int mFramesPerRow = 0;
    public int mFrameWidth = 0;
    public int mFrameHeight = 0;
    public int mCurrFrameIndex = 0;
    public   float mdeltime = 0f;
    public XinYueStudioAnimatedImage(string imageID = "", string label = "", bool isAssetImage = false, int numframes = 0, int fps = 0, int framesperrow = 0, int framewidth = 0, int frameheight = 0) : base(imageID, label, isAssetImage, 100, 100)
    {
        this.mNumFrames = numframes;
        this.mFramesPerSecond = fps;
        this.mFramesPerRow = framesperrow;
        this.mFrameWidth = framewidth;
        this.mFrameHeight = frameheight;
    }
    public void SplitSpriteSheet()
    {
        this.mSprites = new Texture2D[this.mNumFrames];
        for (int i = 0; i < this.mNumFrames; i++)
        {
            int num = (int)(Math.Ceiling((double)this.mNumFrames / (double)this.mFramesPerRow) - 1.0) * this.mFrameHeight;
            int num2 = i % this.mFramesPerRow;
            int num3 = i / this.mFramesPerRow;
            this.mSprites[i] = new Texture2D(this.mFrameWidth, this.mFrameHeight, TextureFormat.ARGB32, false, true);
            this.mSprites[i].SetPixels(this.mImage.GetPixels(num2 * this.mFrameWidth, num - num3 * this.mFrameHeight, this.mFrameWidth, this.mFrameHeight));
            this.mSprites[i].Apply();
        }
    }
    public void Update()
    {
        this.mdeltime += Time.fixedDeltaTime;
        bool flag = this.mdeltime > 1f / (float)this.mFramesPerSecond;
        if (flag)
        {
            this.mCurrFrameIndex++;
            this.mdeltime = 0f;
        }
        bool flag2 = this.mCurrFrameIndex >= this.mNumFrames;
        if (flag2)
        {
            this.mCurrFrameIndex = 0;
        }
    }
    public override void PostLoadProcess()
    {
        base.PostLoadProcess();
        this.SplitSpriteSheet();
    }

}
 