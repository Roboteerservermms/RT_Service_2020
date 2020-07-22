using System;
using System.Collections.Generic;
/*
    RT_Service 속에서 사용되는 device들이 가지는 기본 라이브러리 입니다.
    
*/
namespace Utility.Library
{
    public class Device
    {
        public Int32 ID{    get; set;   }
        public Int32 code{  get; set;   }
        public String name{ get; set; }
        public Nullable<Int32> type{  get; set; }
        // status = activatied, deactivatied, configured 세 가지로 분류됨.
        public Nullable<Int32> status{  get; set;   }
        
        public Device(){}
        public Device (Object param_dev){
            /*
            어떤 자료형으로 할지 정하지 않음.
            if(Object != null){
                _dev.Add(param_dev);
            }
            */
        }
    }
}
