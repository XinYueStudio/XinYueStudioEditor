using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class XinYueStudioImageDownloader
{
    private static XinYueStudioImageDownloader _Instance;
    private List<XinYueStudioImageDownloaderJob> mJobList = new List<XinYueStudioImageDownloaderJob>();
    public int mMaxJobCount = 10;
    public static XinYueStudioImageDownloader Instance
    {
        get
        {
            bool flag = XinYueStudioImageDownloader._Instance == null;
            if (flag)
            {
                XinYueStudioImageDownloader._Instance = new XinYueStudioImageDownloader();
            }
            return XinYueStudioImageDownloader._Instance;
        }
    }
    public int GetJobCount()
    {
        return this.mJobList.Count;
    }
    public void AddJob(XinYueStudioImageDownloaderJob job, Action<Texture2D> callback)
    {
        job.mProcessAction = callback;
        this.mJobList.Add(job);
    }
    public void UpdateJobs()
    {
        for (int i = this.mJobList.Count - 1; i >= 0; i--)
        {
            this.mJobList[i].Update();
            bool mWorkDone = this.mJobList[i].mWorkDone;
            if (mWorkDone)
            {
                this.mJobList[i].mProcessAction(this.mJobList[i].mTexture);
                this.mJobList.RemoveAt(i);
            }
        }
    }
}