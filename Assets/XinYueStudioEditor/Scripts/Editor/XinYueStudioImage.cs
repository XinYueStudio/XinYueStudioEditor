using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class XinYueStudioImage
    {

    public bool mImageLoaded = false;
    public bool mImageStartedLoading = false;
    public Texture2D mImage = null;
    public XinYueStudioImage(string imageID = "", string label = "", bool isAssetImage = false, int height = 100, int width = 100)
    {
        bool flag = imageID == "";
        if (!flag)
        {
            this.mImageStartedLoading = true;
            XinYueStudioImageDownloaderJob job;
         
                job = new XinYueStudioImageDownloaderJob(imageID);
            
            XinYueStudioImageDownloader.Instance.AddJob(job, delegate (Texture2D image)
            {
                this.mImage = image;
                this.mImageLoaded = true;
                this.mImageStartedLoading = false;
                bool flag2 = this.mImage != null;
                if (flag2)
                {
                    this.PostLoadProcess();
                }
            });
        }
    }
    public virtual void PostLoadProcess()
    {
    }
}

