using System;
using System.Diagnostics;

namespace Utility.Library
{
  public class QRNG : Object
    {
        QRNG(){
        }
        private String random { get; set; }
        private String sending { get; set; }
        public void getQRNGNumber(){
            // 쉘 프로세스를 불러오는 부분
            var process = new Process(){
                StartInfo = new ProcessStartInfo{
                FileName = "adb",
                Arguments = "shell hexdump -C /dev/qrandom | head -n 1 | cut -c-62-77", // qrandom을 hexdump 시켰을때 생성되는 주요 문자들은 62~77에 존재하였음.
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            if (string.IsNullOrEmpty(error)) { random = output; }
            else {
                Debug d = new Debug(CategoryDebug.error,Situation.QRNG, error);
            }
        }

    }

    public class DMB{
        DMB(){

        }

    }
}

