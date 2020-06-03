using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

internal class XinYueStudioImageDownloaderJob
    {

    public Action<Texture2D> mProcessAction;
    public bool mWorkDone = false;
    public Texture2D mTexture;
    public bool mCache = false;
    public bool mWebImage = false;
    public string mFileStorePath = "";
    public string mImageUrl = "";
    public bool mFileLoaded = false;
    private const int CACHE_IMAGE_TIME_TO_LIVE = 30;
 
    public XinYueStudioImageDownloaderJob(string filepath)
    {
        bool flag = File.Exists(filepath);
        if (flag)
        {
            this.mImageUrl = filepath;
            this.mFileLoaded = true;
        }
    }
    public void Update()
    {
        bool flag = this.mFileLoaded;
        if (flag)
        {
            bool flag2 = File.Exists(this.mImageUrl);
            if (flag2)
            {
                this.mTexture = new Texture2D(2, 2, TextureFormat.ARGB32, false, false);
                ImageConversion.LoadImage(this.mTexture, File.ReadAllBytes(this.mImageUrl), false);
            }
            this.mWorkDone = true;
        }
    }
}

