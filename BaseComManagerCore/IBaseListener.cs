using PackageManager;
using System;
using System.Collections.Generic;
using System.Text; 

namespace BaseComManager
{
    public interface IBaseListener<T, TT>
    { 
        event NetworkTextReceived TextReceived;
        event NetworkPackageReceived PackageReceived;
        event NetworkBytesReceived BytesPackageReceived;
        event SendPackage<T> SendPackage;
        event SendMessage<T> SendMessage;
        event SendByteArray<T> SendByteArray;
        void Initialize(NetworkPackageGenerator packageGenerator, TT param);
        void Connect();
        void Disconnect();
        bool Send(byte[] message, T param);
        bool Send(string text, T param);
        bool Send(NetworkPackage package, T param);
        bool SendFromApi(byte[] message, T param);
        bool SendFromApi(string text, T param);
        bool SendFromApi(NetworkPackage package, T param);
    }
}
