using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class XinYueStudioAsset
    {
    public string mAssetId;
    public string[] mTags;
    public string mAuthor;
    public string mCategory;
    public string mName;
    public string mCreatedAt;
    public string mUpdatedAt;
    public bool IsNew = true;   
    public bool IsFree = true;

    public XinYueStudioAsset(string id)
    {
        mAssetId = id;
    }
}

