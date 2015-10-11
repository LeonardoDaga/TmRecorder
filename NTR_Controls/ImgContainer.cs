using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTR_Controls
{
    public partial class ImgContainer : Component
    {
        public enum ImgListType
        {
            StarsLine,
            Match,
            StarsGrouped
        }

        public ImgContainer()
        {
            InitializeComponent();
        }

        internal ImageList GetImageList(ImgListType imgListType)
        {
            switch(imgListType)
            {
                case ImgListType.StarsLine:
                    return starRowImgList;
                case ImgListType.StarsGrouped:
                    return starImageList;
                case ImgListType.Match:
                    return matchImageList;
                default:
                    return null;
            }
        }

        public ImgContainer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
