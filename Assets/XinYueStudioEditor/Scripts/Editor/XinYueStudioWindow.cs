
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using UnityEditor;
using UnityEngine;
public class XinYueStudioWindow : EditorWindow
{
    private static XinYueStudioWindow _Instance;

    public static XinYueStudioWindow Instance
    {
        get
        {
            bool flag = XinYueStudioWindow._Instance == null;
            if (flag)
            {
                XinYueStudioWindow._Instance = EditorWindow.GetWindow<XinYueStudioWindow>(false, "XinYueStudio");
                XinYueStudioWindow._Instance.minSize = (new Vector2(800f, 400f));
                Timer timer = new Timer(1500000.0);
                timer.Elapsed += new ElapsedEventHandler(XinYueStudioWindow.RefreshUser);
                timer.Enabled = true;
                timer.AutoReset = true;
            }
            return XinYueStudioWindow._Instance;
        }
    }
    private static void RefreshUser(object sender, ElapsedEventArgs e)
    {

    }
    [MenuItem("XinYueStudio/EdiorView")]
    public static void ShowWindow()
    {
        XinYueStudioWindow.Instance.Show();
        XinYueStudioWindow.Instance.Reload();
    }
    public XinYueStudioAssetGridPanel mAssetGridPanel = new XinYueStudioAssetGridPanel();
    	
    private void Reload()
    {
        this.mAssetGridPanel = new XinYueStudioAssetGridPanel();
      
        this.mAssetGridPanel.Clear();
        this.mAssetGridPanel.Start();
        InitStyle();
        InitImages();
    }
 

    public XinYueStudioAnimatedImage mLoadingImage = null;
    public XinYueStudioAnimatedImage mSpinnerImage = null;
    public XinYueStudioAnimatedImage mAssetDownload = null;
    public XinYueStudioImage mFreeTag = null;
    public XinYueStudioImage mOwnedTag = null;
    public XinYueStudioImage mNewTag = null;
    public XinYueStudioImage mSourceLogo = null;
    public XinYueStudioImage mSubstanceLogo = null;
    public XinYueStudioImage mRightArrow = null;
    public XinYueStudioImage mLeftArrow = null;
    public XinYueStudioImage mDetailExitButton = null;
    public XinYueStudioImage mDownloadButton = null;
    public XinYueStudioImage mAvailableDownloadsButton = null;
    public XinYueStudioImage mLoginButton = null;
    public XinYueStudioImage mLogoutButton = null;
    public XinYueStudioImage mMyAssetsButton = null;
    public XinYueStudioImage mMagnifyingGlass = null;
    public XinYueStudioImage mSourceIcon = null;
    public XinYueStudioImage mThumbnailImage = null;


    public void SetupRender()
    {
        Rect position = XinYueStudioWindow.Instance.position;
        Rect rect = new Rect(position.width / 2f - 160f, position.height / 2f - 160f, 320f, 320f);
        bool flag = XinYueStudioWindow.Instance.mLoadingImage != null;
        if (flag)
        {
            GUI.DrawTexture(rect, XinYueStudioWindow.Instance.mLoadingImage.mImage);
        }
    }


    public Color ColorSourceDarkGray;
    public Color ColorSourceLightGrayDetailTransparent;
    public Color ColorSourceScrollBarGray;
    public Color ColorSourceBlue;
    public Color ColorSourceLightGray;
    public Color ColorSourceLightGrayTransparent;
    public Color ColorSourceLightGraySlider;

   
    public GUIStyle mBoxStyle = null;
    public GUIStyle mCategoryButtonStyle = null;
    public GUIStyle mMainButtonStyle = null;
    public GUIStyle mAvailableDownloadsStyle = null;
    public GUIStyle mHiddenButtonStyle = null;
    public GUIStyle mLoginButtonStyle = null;
    public GUIStyle mAssetLabelStyle = null;
    public GUIStyle mNormalTextStyle = null;
    public GUIStyle mArrowButtonStyle = null;
    public GUIStyle mHyperlinkStyle = null;
    public GUIStyle mAssetTagStyle = null;
    public GUIStyle mSearchBarStyle = null;
    public GUIStyle mUpdatedTextStyle = null;
    public GUISkin mSourceSkin = null;
    public GUIStyle mWhiteBackgroundBox = null;
    public GUIStyle mLightGrayBackgroundBox = null;
    public GUIStyle mDarkGrayBackgroundBox = null;
    public GUIStyle mBlackBackgroundBox = null;

    public void InitStyle()
    {
        bool flag = PlayerSettings.colorSpace == ColorSpace.Linear;
        if (flag)
        {
            this.ColorSourceDarkGray = new Color(0.0390625f, 0.0390625f, 0.0390625f, 1f);
            this.ColorSourceLightGrayDetailTransparent = new Color(0.1171875f, 0.1171875f, 0.1171875f, 0.75f);
            this.ColorSourceScrollBarGray = new Color(0.14453125f, 0.14453125f, 0.14453125f, 1f);
            this.ColorSourceBlue = new Color(0f, 0.46875f, 0.7109375f, 1f);
            this.ColorSourceLightGray = new Color(0.078125f, 0.078125f, 0.078125f, 1f);
            this.ColorSourceLightGrayTransparent = new Color(0.0703125f, 0.0703125f, 0.0703125f, 0.5f);
            this.ColorSourceLightGraySlider = new Color(0.3515625f, 0.3515625f, 0.3515625f, 1f);
        }
        else
        {
            this.ColorSourceDarkGray = new Color(0.19921875f, 0.19921875f, 0.19921875f, 1f);
            this.ColorSourceLightGrayDetailTransparent = new Color(0.703125f, 0.703125f, 0.703125f, 0.75f);
            this.ColorSourceScrollBarGray = new Color(0.14453125f, 0.14453125f, 0.14453125f, 1f);
            this.ColorSourceBlue = new Color(0f, 0.734375f, 0.9453125f, 1f);
            this.ColorSourceLightGray = new Color(0.265625f, 0.265625f, 0.265625f, 1f);
            this.ColorSourceLightGrayTransparent = new Color(0.265625f, 0.265625f, 0.265625f, 0.5f);
            this.ColorSourceLightGraySlider = new Color(0.3515625f, 0.3515625f, 0.3515625f, 1f);
        }


        this.mBoxStyle = new GUIStyle();
        this.mCategoryButtonStyle = new GUIStyle();
        this.mCategoryButtonStyle.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mCategoryButtonStyle.normal.background.SetPixels(new Color[]
        {
                this.ColorSourceDarkGray,
                this.ColorSourceDarkGray
        });
        this.mCategoryButtonStyle.normal.background.Apply();
        this.mCategoryButtonStyle.normal.textColor = (Color.grey);
        this.mCategoryButtonStyle.onNormal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mCategoryButtonStyle.onNormal.background.SetPixels(new Color[]
        {
                this.ColorSourceBlue,
                this.ColorSourceBlue
        });
        this.mCategoryButtonStyle.onNormal.background.Apply();
        this.mCategoryButtonStyle.onNormal.textColor = (Color.white);
        this.mCategoryButtonStyle.hover.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mCategoryButtonStyle.hover.background.SetPixels(new Color[]
        {
                this.ColorSourceLightGray,
                this.ColorSourceLightGray
        });
        this.mCategoryButtonStyle.hover.background.Apply();
        this.mCategoryButtonStyle.hover.textColor = (Color.white);
        this.mCategoryButtonStyle.fixedHeight = (35f);
        this.mCategoryButtonStyle.fontSize = (12);
        this.mCategoryButtonStyle.alignment = (TextAnchor)(3);
        this.mMainButtonStyle = new GUIStyle();
        this.mMainButtonStyle.normal.background = (new Texture2D(150, 60, TextureFormat.ARGB32, false, true));
        this.mMainButtonStyle.normal.background.SetPixels(XinYueStudioWindow.CreateBoxWithBorder(150, 60, this.ColorSourceLightGray, this.ColorSourceDarkGray, true, true, false, false));
        this.mMainButtonStyle.normal.background.Apply();
        this.mMainButtonStyle.normal.textColor = (Color.white);
        this.mMainButtonStyle.fontSize = (12);
        this.mMainButtonStyle.alignment = (TextAnchor)(4);
        this.mMainButtonStyle.border = (new RectOffset(1, 1, 1, 1));
        this.mMainButtonStyle.margin = (new RectOffset(2, 2, 2, 2));
        this.mMainButtonStyle.padding = (new RectOffset(0, 0, 0, 0));
        this.mLoginButtonStyle = new GUIStyle();
        this.mLoginButtonStyle.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mLoginButtonStyle.normal.background.SetPixels(new Color[]
        {
                this.ColorSourceBlue,
                this.ColorSourceBlue
        });
        this.mLoginButtonStyle.normal.background.Apply();
        this.mLoginButtonStyle.normal.textColor = (Color.white);
        this.mLoginButtonStyle.fontSize = (12);
        this.mLoginButtonStyle.alignment = (TextAnchor)(4);
        this.mLoginButtonStyle.margin = (new RectOffset(2, 2, 2, 2));
        this.mHiddenButtonStyle = new GUIStyle();
        this.mHiddenButtonStyle.hover.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mHiddenButtonStyle.hover.background.SetPixels(new Color[]
        {
                this.ColorSourceLightGrayTransparent,
                this.ColorSourceLightGrayTransparent
        });
        this.mHiddenButtonStyle.hover.background.Apply();
        this.mHiddenButtonStyle.hover.textColor = (Color.white);
        this.mHiddenButtonStyle.fontSize = (12);
        this.mHiddenButtonStyle.alignment = (TextAnchor)(3);
        this.mAssetLabelStyle = new GUIStyle();
        this.mAssetLabelStyle.normal.textColor = (Color.white);
        this.mAssetLabelStyle.fontSize = (12);
        this.mAssetLabelStyle.alignment = (TextAnchor)(0);
        this.mAssetLabelStyle.wordWrap = (false);
        this.mAssetLabelStyle.clipping = (TextClipping)(1);
        this.mNormalTextStyle = new GUIStyle();
        this.mNormalTextStyle.normal.textColor = (Color.white);
        this.mNormalTextStyle.fontSize = (16);
        this.mNormalTextStyle.alignment = (TextAnchor)(4);
        this.mNormalTextStyle.wordWrap = (true);
        this.mNormalTextStyle.clipping = (TextClipping)(1);
        this.mHyperlinkStyle = new GUIStyle();
        this.mHyperlinkStyle.normal.textColor = (this.ColorSourceBlue);
        this.mHyperlinkStyle.fontSize = (16);
        this.mHyperlinkStyle.alignment = (TextAnchor)(4);
        this.mHyperlinkStyle.wordWrap = (true);
        this.mHyperlinkStyle.clipping = (TextClipping)(1);
        this.mArrowButtonStyle = new GUIStyle();
        this.mAssetTagStyle = new GUIStyle();
        this.mAssetTagStyle.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mAssetTagStyle.normal.background.SetPixels(new Color[]
        {
                this.ColorSourceLightGray,
                this.ColorSourceLightGray
        });
        this.mAssetTagStyle.normal.background.Apply();
        this.mAssetTagStyle.normal.textColor = (Color.grey);
        this.mAssetTagStyle.active.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mAssetTagStyle.active.background.SetPixels(new Color[]
        {
                this.ColorSourceDarkGray,
                this.ColorSourceDarkGray
        });
        this.mAssetTagStyle.active.background.Apply();
        this.mAssetTagStyle.active.textColor = (Color.white);
        this.mAssetTagStyle.normal.textColor = (Color.white);
        this.mAssetTagStyle.fontSize = (12);
        this.mAssetTagStyle.alignment = (TextAnchor)(4);
        this.mAssetTagStyle.border = (new RectOffset(1, 1, 1, 1));
        this.mAssetTagStyle.margin = (new RectOffset(2, 2, 2, 2));
        this.mAssetTagStyle.padding = (new RectOffset(0, 0, 0, 0));
        this.mLightGrayBackgroundBox = new GUIStyle();
        this.mLightGrayBackgroundBox.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mLightGrayBackgroundBox.normal.background.SetPixels(new Color[]
        {
                this.ColorSourceLightGray,
                this.ColorSourceLightGray
        });
        this.mLightGrayBackgroundBox.normal.background.Apply();
        this.mDarkGrayBackgroundBox = new GUIStyle();
        this.mDarkGrayBackgroundBox.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mDarkGrayBackgroundBox.normal.background.SetPixels(new Color[]
        {
                this.ColorSourceDarkGray,
                this.ColorSourceDarkGray
        });
        this.mDarkGrayBackgroundBox.normal.background.Apply();
        this.mWhiteBackgroundBox = new GUIStyle();
        this.mWhiteBackgroundBox.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mWhiteBackgroundBox.normal.background.SetPixels(new Color[]
        {
                Color.white,
                Color.white
        });
        this.mWhiteBackgroundBox.normal.background.Apply();
        this.mBlackBackgroundBox = new GUIStyle();
        this.mBlackBackgroundBox.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mBlackBackgroundBox.normal.background.SetPixels(new Color[]
        {
                Color.black,
                Color.black
        });
        this.mBlackBackgroundBox.normal.background.Apply();
        this.mAvailableDownloadsStyle = new GUIStyle();
        this.mAvailableDownloadsStyle.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mAvailableDownloadsStyle.normal.background.SetPixels(new Color[]
        {
                this.ColorSourceLightGray,
                this.ColorSourceLightGray
        });
        this.mAvailableDownloadsStyle.normal.background.Apply();
        this.mAvailableDownloadsStyle.normal.textColor = (Color.grey);
        this.mSearchBarStyle = new GUIStyle();
        this.mSearchBarStyle.normal.background = (new Texture2D(1, 1, TextureFormat.ARGB32, false, true));
        this.mSearchBarStyle.normal.background.SetPixels(new Color[]
        {
                this.ColorSourceLightGray,
                this.ColorSourceLightGray
        });
        this.mSearchBarStyle.normal.background.Apply();
        this.mSearchBarStyle.normal.textColor = (Color.white);
        this.mSearchBarStyle.clipping = (TextClipping)(1);
        this.mUpdatedTextStyle = new GUIStyle();
        this.mUpdatedTextStyle.normal.textColor = (new Color(0.078125f, 0.53515625f, 0.66796875f));
        this.mUpdatedTextStyle.fontSize = (10);
        this.mUpdatedTextStyle.alignment = (TextAnchor)(2);
        this.mUpdatedTextStyle.wordWrap = (true);
        this.mUpdatedTextStyle.clipping = (TextClipping)(1);
    }

    public static Color[] CreateBoxWithBorder(int width, int height, Color fillcolor, Color bordercolor, bool left = true, bool right = true, bool top = true, bool bottom = true)
    {
        Color[] array = new Color[width * height];
        for (int i = 0; i < width * height; i++)
        {
            int num = i % width;
            int num2 = i / width;
            bool flag = (num == 0 & left) || (num == width - 1 & right) || (num2 == 0 & top) || (num2 == height - 1 & bottom);
            if (flag)
            {
                array[i] = bordercolor;
            }
            else
            {
                array[i] = fillcolor;
            }
        }
        return array;
    }

    public static string GetDirectory()
    {
        string dllfilepath = Application.dataPath + "\\Plugins";
        if (Application.isEditor)
        {
            dllfilepath = Application.dataPath + "\\XinYueStudioEditor\\Plugins\\Editor\\";
            // UnityEngine.Debug.Log(dllfilepath);
        }
        return dllfilepath;// Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }

    public void InitImages()
    {
        this.mSpinnerImage = new XinYueStudioAnimatedImage(GetDirectory() + "/Images/spinner.png", "", false, 15, 6, 3, 134, 106);
        this.mLoadingImage = new XinYueStudioAnimatedImage(GetDirectory() + "/Images/substancesourceloading.png", "", false, 32, 10, 8, 315, 315);
        this.mAssetDownload = new XinYueStudioAnimatedImage(GetDirectory() + "/Images/AssetDownload.png", "", false, 12, 20, 3, 98, 98);
        this.mSubstanceLogo = new XinYueStudioImage(GetDirectory() + "/Images/logo-substance.png", "", false, 100, 100);
        this.mSourceLogo = new XinYueStudioImage(GetDirectory() + "/Images/logo-white.png", "", false, 100, 100);
        this.mFreeTag = new XinYueStudioImage(GetDirectory() + "/Images/free.png", "", false, 100, 100);
        this.mOwnedTag = new XinYueStudioImage(GetDirectory() + "/Images/1.jpg", "", false, 556, 387);
        this.mNewTag = new XinYueStudioImage(GetDirectory() + "/Images/new.png", "", false, 100, 100);
        this.mRightArrow = new XinYueStudioImage(GetDirectory() + "/Images/rightarrow.png", "", false, 100, 100);
        this.mLeftArrow = new XinYueStudioImage(GetDirectory() + "/Images/leftarrow.png", "", false, 100, 100);
        this.mDownloadButton = new XinYueStudioImage(GetDirectory() + "/Images/download.png", "", false, 100, 100);
        this.mAvailableDownloadsButton = new XinYueStudioImage(GetDirectory() + "/Images/AvailableDownloads.png", "", false, 100, 100);
        this.mLoginButton = new XinYueStudioImage(GetDirectory() + "/Images/LoginButton.png", "", false, 100, 100);
        this.mLogoutButton = new XinYueStudioImage(GetDirectory() + "/Images/LogoutButton.png", "", false, 100, 100);
        this.mMyAssetsButton = new XinYueStudioImage(GetDirectory() + "/Images/MyAssetsButton.png", "", false, 100, 100);
        this.mMagnifyingGlass = new XinYueStudioImage(GetDirectory() + "/Images/MagnifyingGlass.png", "", false, 100, 100);
        this.mSourceIcon = new XinYueStudioImage(GetDirectory() + "/Images/Source.Icon.png", "", false, 100, 100);
        this.mDetailExitButton = new XinYueStudioImage(GetDirectory() + "/Images/DetailExitButton.png", "", false, 100, 100);

         this.mThumbnailImage = new XinYueStudioImage(GetDirectory() + "/Images/1.jpg", "", false, 556, 387);

       
    }


    private Vector2 mScrollPosition = Vector2.zero;
    private string[] mCategoryArray = new string[3] { "All Categories", "New Assets", "Free Assets" };
    private int mSelectedIndex = 0;
    public  void Navigation()
    {
        Rect rect = new Rect(2f, 61f, 218f, XinYueStudioWindow.Instance.position.height - 82f);
        GUILayout.BeginArea(rect);
        Color color = GUI.color;
        GUI.color = (XinYueStudioWindow.Instance.ColorSourceLightGraySlider);
        this.mScrollPosition = GUILayout.BeginScrollView(this.mScrollPosition, false, false, new GUILayoutOption[0]);
        GUI.color = (color);
        
        int num = GUILayout.SelectionGrid(this.mSelectedIndex, this.mCategoryArray, 1, XinYueStudioWindow.Instance.mCategoryButtonStyle, new GUILayoutOption[0]);
        bool flag2 = this.mSelectedIndex != num;
        if (flag2)
        {
            this.SetSelectedIndex(num);
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
  
    public void SetSelectedIndex(int index)
    {
        this.mSelectedIndex = index;
      
    }




    public void OnEnable()
    {
        
    }


    private void Update()
    {
        XinYueStudioImageDownloader.Instance.UpdateJobs();
        if(this.mSpinnerImage!=null)
        this.mSpinnerImage.Update();
        this.mAssetGridPanel.Update();
    }
     private void OnGUI()
    {
        //SetupRender();

        Navigation();
        this.mAssetGridPanel.Render();

        base.Repaint();
    }
}
