using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public  class XinYueStudioAssetGridPanel
{
    private int mNumAssets = 0;
    private bool mAssetsSetup = false;
    public static int mDefaultSize = 400;
    public static float mTextBoxHeight = 60f;
    private Vector2 mScrollPosition = Vector2.zero;
    private int mTileSizeDimension = 0;
    private int mGridTileWidth = 0;
    private int mTileRangeLow = 0;
    private int mTileRangeHigh = 0;
  
    public List<Texture> mTextureArray = new List<Texture>();
    public List<XinYueStudioAssetPanel> mAssetPanels = new List<XinYueStudioAssetPanel>();

    public void Start()
    {
        mAssetPanels.Clear();
        for (int i = 0; i < 10; i++)
        {
            XinYueStudioAssetPanel assetPanel = new XinYueStudioAssetPanel();
            mAssetPanels.Add(assetPanel);
        }


    }



    public void Update()
    {
        this.CalculateTileRangeToLoad();
      
        for (int i = 0; i < this.mAssetPanels.Count; i++)
        {
            bool flag = i >= this.mTileRangeLow && i <= this.mTileRangeHigh;
            if (flag)
            {
                this.mAssetPanels[i].CheckLoad();
            }
            else
            {
                this.mAssetPanels[i].Unload();
            }
        }
    }


    public void Render()
    {
        Rect position = XinYueStudioWindow.Instance.position;
        Rect rect = new Rect(220f, 61f, position.width - 220f, position.height - 83f);
        GUILayout.BeginArea(rect);
        rect.Set(0f, -1f, position.width - 220f, position.height - 81f);
        Color color = GUI.color;
        GUI.color = (XinYueStudioWindow.Instance.ColorSourceLightGraySlider);
        this.mScrollPosition = GUILayout.BeginScrollView(this.mScrollPosition, false, false, new GUILayoutOption[0]);
        GUI.color = (color);
        int num = 0;

        rect.Set(0f, -1f, position.width - 270f, position.height - 51f);
        this.CalculateTileSize(rect);
        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.fixedWidth = ((float)this.mTileSizeDimension);
        gUIStyle.fixedHeight = ((float)this.mTileSizeDimension + mTextBoxHeight);
        gUIStyle.margin = (new RectOffset(6, 1, 0, 0));
        Rect rect2 = new Rect(0f, 0f, position.width - 270f, ((float)this.mTileSizeDimension + mTextBoxHeight) * (float)(mAssetPanels.Count / this.mGridTileWidth + Math.Min(1, mAssetPanels.Count % this.mGridTileWidth)));
        GUILayoutUtility.GetRect(rect2.width, rect2.height);
        this.mTextureArray = new List<Texture>(mAssetPanels.Count);
        this.CalculateTileRangeToLoad();
        for (int i = this.mTileRangeLow; i < this.mTileRangeHigh; i++)
        {
            Rect rect3 = this.CalculateAssetRect(i, this.mGridTileWidth, this.mTileSizeDimension, (int)((float)this.mTileSizeDimension + mTextBoxHeight));
            rect3.y = (rect3.y + (float)num);
            this.mAssetPanels[i].Render(new Rect(rect3), new Rect(position));

            if (GUI.Button(rect3, "", gUIStyle))
            {

            }
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();

    }
    private void CalculateTileRangeToLoad()
    {

        this.mTileRangeLow = (int)Math.Max(0f, this.mScrollPosition.y / ((float)this.mTileSizeDimension + mTextBoxHeight) * (float)this.mGridTileWidth - (float)this.mGridTileWidth);
        this.mTileRangeHigh = (int)Math.Ceiling((double)Math.Min((float)this.mTileRangeLow + XinYueStudioWindow.Instance.position.height / (float)this.mTileSizeDimension * (float)this.mGridTileWidth + (float)(this.mGridTileWidth * 2), (float)mAssetPanels.Count));

    }
    private Rect CalculateAssetRect(int index, int rowWidth, int width, int height)
    {
        Rect result = default(Rect);
        result.x = ((float)(width * (index % rowWidth) + 6 * (index % rowWidth + 1)));
        result.y = ((float)(5 + height * (index / rowWidth))) * (387.0f/556.0f);
        result.width = ((float)width);
        result.height = ((float)height) * (387.0f / 556.0f);
        return result;
    }
    private void CalculateTileSize(Rect containerRect)
    {
        float num = containerRect.width / 4f;
        this.mTileSizeDimension = (int)num;
        this.mTileSizeDimension = Math.Max(250, Math.Min(this.mTileSizeDimension, 300));
        this.mGridTileWidth = (int)containerRect.width / this.mTileSizeDimension;
        this.mGridTileWidth = Math.Max(1, Math.Min(this.mGridTileWidth, 10));
        this.mTileSizeDimension = (int)(containerRect.width / (float)this.mGridTileWidth);
    }

    public void Clear()
    {
        this.mTextureArray.Clear();
        this.mAssetPanels.Clear();
        this.mNumAssets = 0;
        this.mAssetsSetup = false;
    }
}

