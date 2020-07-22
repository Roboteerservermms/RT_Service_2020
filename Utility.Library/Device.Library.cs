using System;
using System.Collections.Generic;
namespace Utility.Library
{
    public class Device<T>
    {
        private List<T> _dev;

        
        public Device(){}
        public Device (T param_dev){
            _dev.Add(param_dev);
        }
    }
}
