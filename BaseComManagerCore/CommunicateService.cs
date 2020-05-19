using Microsoft.Extensions.Hosting;
using PackageManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseComManager
{
    public abstract class CommunicateService<T,TT>  : BackgroundService
    {
        public IBaseListener<T, TT> Listener; 

        public CommunicateService(IBaseListener<T, TT> listener) 
        {
            Listener = listener;
            Listener.SendMessage   += this.SendMessage;
            Listener.SendByteArray += this.SendByteArray;
            Listener.SendPackage   += this.SendPackage;

            Listener.BytesPackageReceived += BytesPackageReceived;
            Listener.PackageReceived      += PackageReceived;
            Listener.TextReceived         += TextReceived; 
        }

        public bool SendMessage(string message, T param)
        {
            return Listener.Send(message, param);
        }

        public bool SendByteArray(byte[] bytes, T param)
        {
            return Listener.Send(bytes, param);
        }

        public bool SendPackage(NetworkPackage package, T param)
        {
            return Listener.Send(package, param);
        }         
        
        public abstract void TextReceived(string text);
        
        public abstract void PackageReceived(NetworkPackage package);
        
        public abstract void BytesPackageReceived(byte[] bytes);

        public abstract void OnListenerBuilding();

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            OnListenerBuilding();
            Listener.Connect();
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1, stoppingToken);
            }
        }

    }
}
