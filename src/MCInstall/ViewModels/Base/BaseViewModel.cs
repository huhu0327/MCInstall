using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MCInstall.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged, IBaseViewModel, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnEnable() { }

        public virtual void OnDisable() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected bool _disposed { get; private set; }
        private readonly SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        protected virtual void Dispose(bool isDisposing)
        {
            if (_disposed) return;

            if (isDisposing)
            {
                _safeHandle.Dispose();
            }
            _disposed = true;
        }

        protected void OnPropertyChanged([CallerMemberName]string propetyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }

    }
}