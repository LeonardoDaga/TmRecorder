using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NTR_Controls
{
    public partial class ImgContainer : Component
    {
        public ImgContainer()
        {
            InitializeComponent();
        }

        public ImgContainer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
