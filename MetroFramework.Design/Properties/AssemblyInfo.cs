using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// JT: Ensure API compatibility
[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ae7e4b21-8ea9-4055-b81a-32f1ec123953")]

internal static class MetroFrameworkDesignAssembly
{
    internal const string Title = "MetroFramework.Design.dll";
    // JT: Use same information as main MetroFramework.dll
    internal const string Version = MetroFrameworkAssembly.Version;
    internal const string Description = MetroFrameworkAssembly.Description;
    internal const string Copyright = MetroFrameworkAssembly.Copyright;
    internal const string Company = MetroFrameworkAssembly.Company;
    internal const string Product = MetroFrameworkAssembly.Product;
}
