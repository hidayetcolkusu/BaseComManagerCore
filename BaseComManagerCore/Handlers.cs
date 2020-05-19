using PackageManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseComManager
{

    public delegate bool SendPackage<T>(NetworkPackage package, T param);
    public delegate bool SendMessage<T>(string message, T param);
    public delegate bool SendByteArray<T>(byte[] bytes, T param);
    public delegate void NetworkPackageReceived(NetworkPackage package);
    public delegate void NetworkBytesReceived(byte[] bytes);
    public delegate void NetworkTextReceived(string text);
}
