using System;
using Ultra.Web.Core.Enums;
using Ultra.Web.Core.Cache;

namespace Ultra.Web.Core.Interface
{
    public interface IBusinessSurface : IBaseSurface
    {
        ICache Cacher { get; }

        EnViewEditMode EditMode { get; set; }
    }
}

