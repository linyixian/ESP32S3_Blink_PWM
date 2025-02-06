using nanoFramework.Hardware.Esp32;
using System.Device.Pwm;
using System.Threading;

namespace ESP32S3_Blink_PWM
{
    public class Program
    {
        //LEDを接続しているGPIO
        const int ledPin = 2;       

        public static void Main()
        {
            //LEDピンにPWMを設定
            Configuration.SetPinFunction(ledPin, DeviceFunction.PWM1);

            //周波数40KHzとしてPWMを設定
            PwmChannel pwmChannel = PwmChannel.CreateFromPin(ledPin, 40000, 0);

            //PWMをスタート
            pwmChannel.Start();

            while (true)
            {
                //20ms毎に1%づつデューティ比を増やす。
                for(int i = 0; i <100;i++)
                {
                    //PWMのデューティ比は0.0～1.0で設定する。
                    pwmChannel.DutyCycle = (double)i / 100.0;       
                    Thread.Sleep(20);
                }
                //20ms毎に1%づつデューティ比を減らす。
                for (int i = 100; i > 0; i--)
                {
                    pwmChannel.DutyCycle = (double)i / 100.0;
                    Thread.Sleep(20);
                }
            }
        }
    }
}
