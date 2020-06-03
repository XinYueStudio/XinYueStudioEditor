using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public   class XinYueStudioAssetPanel
{
    public bool mImageLoading = false;
    public bool mImageLoaded = true;
    public XinYueStudioImage mThumbnailImage = null;
    public float mdeltime = 0f;
    public int mCurrAnimFrame = 0;
    public XinYueStudioAsset mAsset;
    public void CheckLoad()
    {
        bool flag = !this.mImageLoading && this.mThumbnailImage == null && XinYueStudioImageDownloader.Instance.GetJobCount() < XinYueStudioImageDownloader.Instance.mMaxJobCount;
        if (flag)
        {
            this.mImageLoading = true;
            this.mThumbnailImage = XinYueStudioWindow.Instance.mThumbnailImage;
        }
    }
    public void Unload()
    {
        bool flag = !this.mImageLoading;
        if (flag)
        {
            this.mThumbnailImage = null;
        }
    }



    public void Render(Rect rPos, Rect windowPos)
    {
        Vector2 mousePosition = Event.current.mousePosition;
        bool flag = rPos.Contains(mousePosition);
        if (flag)
        {
            this.mdeltime += Time.fixedDeltaTime;
            bool flag2 = this.mdeltime > 1f / (float)XinYueStudioWindow.Instance.mAssetDownload.mFramesPerSecond;
            if (flag2)
            {
                this.mCurrAnimFrame++;
                this.mdeltime = 0f;
            }
            bool flag3 = this.mCurrAnimFrame >= XinYueStudioWindow.Instance.mAssetDownload.mNumFrames;
            if (flag3)
            {
                this.mCurrAnimFrame = XinYueStudioWindow.Instance.mAssetDownload.mNumFrames - 1;
            }
        }
        else
        {
            this.mdeltime += Time.fixedDeltaTime;
            bool flag4 = this.mdeltime > 1f / (float)XinYueStudioWindow.Instance.mAssetDownload.mFramesPerSecond;
            if (flag4)
            {
                this.mCurrAnimFrame--;
                this.mdeltime = 0f;
            }
            bool flag5 = this.mCurrAnimFrame < 0;
            if (flag5)
            {
                this.mCurrAnimFrame = 0;
            }
        }



        GUI.BeginGroup(rPos);
        Rect rect = new Rect(rPos);
        rect.height = (rect.height * 0.9f);



        if (this.mThumbnailImage != null)
        {

            if (this.mThumbnailImage.mImageLoaded)
            {
                this.mImageLoading = false;
                GUI.DrawTexture(new Rect(0f, 0f, rect.width, rect.height), this.mThumbnailImage.mImage);

            }
        }
        else
        {

            if (XinYueStudioWindow.Instance.mSpinnerImage != null)
            {
                GUI.DrawTexture(new Rect(rect.width / 2f - 30f, rect.height / 2f - 30f, 60f, 60f), XinYueStudioWindow.Instance.mSpinnerImage.mSprites[XinYueStudioWindow.Instance.mSpinnerImage.mCurrFrameIndex]);
            }
        }
        Rect rect2 = new Rect(0f, rect.height, rPos.width, rPos.height - rect.height);
        GUI.Label(rect2, "XinYueStudioAsset", XinYueStudioWindow.Instance.mAssetLabelStyle);
        rect2 = new Rect(0f, rect.height, rPos.width, rPos.height - rect.height + 15f);

        GUI.Label(rect2, "Updated", XinYueStudioWindow.Instance.mUpdatedTextStyle);

        if (XinYueStudioWindow.Instance.mOwnedTag != null)
        {
            GUI.DrawTexture(new Rect(0f, 0f, 100f, 40f), XinYueStudioWindow.Instance.mOwnedTag.mImage, 0);
        }


        if (XinYueStudioWindow.Instance.mNewTag != null)
        {
            GUI.DrawTexture(new Rect(rect.width - 50f, 0f, 50f, 50f), XinYueStudioWindow.Instance.mNewTag.mImage, 0);
        }

        if (XinYueStudioWindow.Instance.mFreeTag != null)
        {
            GUI.DrawTexture(new Rect(0f, rect.height - 50f, 50f, 50f), XinYueStudioWindow.Instance.mFreeTag.mImage, 0);
        }


        Rect rect3 = new Rect(rect.width - 98f, rect.height - 98f, 98f, 98f);

        if (this.mCurrAnimFrame > 0 && XinYueStudioWindow.Instance.mAssetDownload.mSprites != null)
        {
            XinYueStudioWindow.Instance.mAssetDownload.mSprites[this.mCurrAnimFrame].mipMapBias = (-1f);
            GUI.DrawTexture(rect3, XinYueStudioWindow.Instance.mAssetDownload.mSprites[this.mCurrAnimFrame]);
        }

        if (this.mCurrAnimFrame == XinYueStudioWindow.Instance.mAssetDownload.mNumFrames - 1)
        {
            GUIStyle gUIStyle = new GUIStyle();

            if (GUI.Button(rect3, "", gUIStyle))
            {

                if (mousePosition.x - rPos.x - rect3.x + (mousePosition.y - rPos.y - rect3.y) > rect3.width)
                {

                }
                else
                {

                }
            }
        }
        GUI.EndGroup();
    }

}

