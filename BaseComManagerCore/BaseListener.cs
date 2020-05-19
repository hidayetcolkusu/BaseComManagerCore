using PackageManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseComManager
{
    public abstract class BaseListener<T, TT> : IBaseListener<T, TT> where T : IBaseDestInfo where TT : IBaseInitInfo
    { 
        public abstract event NetworkPackageReceived PackageReceived;
        public abstract event NetworkBytesReceived BytesPackageReceived;
        public abstract event NetworkTextReceived TextReceived;
        public abstract event SendPackage<T> SendPackage;
        public abstract event SendMessage<T> SendMessage;
        public abstract event SendByteArray<T> SendByteArray;

        public abstract void Initialize(NetworkPackageGenerator packageGenerator, TT param);
        public abstract void Connect();
        public abstract void Disconnect();
        public abstract bool Send(byte[] message, T param);
        public abstract bool Send(string text, T param);
        public abstract bool Send(NetworkPackage package, T param);
        public abstract bool SendFromApi(byte[] message, T param);
        public abstract bool SendFromApi(string text, T param);
        public abstract bool SendFromApi(NetworkPackage package, T param);
    }
}
