using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9559a6f3-8cce-4644-a571-8aeeeb526094")]

[assembly:AllowPartiallyTrustedCallers]

[assembly: InternalsVisibleTo(MetroFramework.AssemblyRef.MetroFrameworkDesignIVT)]
[assembly: InternalsVisibleTo(MetroFramework.AssemblyRef.MetroFrameworkFontsIVT)]

internal static class MetroFrameworkAssembly
{
    internal const string Title = "MetroFramework.dll";
    internal const string Version = "1.4.0.0";
    internal const string Description = "Metro UI Framework for .NET WinForms";
    internal const string Copyright = "Copyright \x00a9 2011 Sven Walter, Dennis Magno.  All rights reserved.";
    internal const string Company = "Sven Walter, Dennis Magno";
    internal const string Product = "MetroFramework";
}

namespace MetroFramework
{
    internal static class AssemblyRef
    {

        // Design

        internal const string MetroFrameworkDesign_ = "MetroFramework.Design";

        internal const string MetroFrameworkDesignSN = "MetroFramework.Design, Version=" + MetroFrameworkAssembly.Version
                                                       + ", Culture=neutral, PublicKeyToken=" + MetroFrameworkKeyToken;

        internal const string MetroFrameworkDesignIVT = "MetroFramework.Design, PublicKey=" + MetroFrameworkKeyFull;

        // Fonts

        internal const string MetroFrameworkFonts_ = "MetroFramework.Fonts";

        internal const string MetroFrameworkFontsSN = "MetroFramework.Fonts, Version=" + MetroFrameworkAssembly.Version
                                                      + ", Culture=neutral, PublicKeyToken=" + MetroFrameworkKeyToken;

        internal const string MetroFrameworkFontsIVT = "MetroFramework.Fonts, PublicKey=" + MetroFrameworkKeyFull;

        internal const string MetroFrameworkFontResolver = "MetroFramework.Fonts.FontResolver, " + MetroFrameworkFontsSN;

        // Strong Name Key

        internal const string MetroFrameworkKey = "5f91a84759bf584a";

        internal const string MetroFrameworkKeyFull =
            "00240000048000009400000006020000002400005253413100040000010001004d3b6f2adab21d" +
            "00d59de966f5d7f4d8325296ded578ac35bca529580b534443bb4090600ff1f057136d58f20a22" +
            "5e0d025119aec656e9b6ac5691e12689c0b03d55c8b8822fd84e2acbde80a2d9124009d20f5adf" +
            "05d36cfa95ba164a0d6ab348a9f8e3a00f066f4d32c0b71b5be6d7f86616491f6dd0630e49ec15" +
            "a0c8f9c9";

        internal const string MetroFrameworkKeyToken = "5f91a84759bf584a";
    }
}