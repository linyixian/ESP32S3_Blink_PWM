using nanoFramework.Hardware.Esp32;
using System.Device.Pwm;
using System.Threading;

namespace ESP32S3_Blink_PWM
{
    public class Program
    {
        //LED��ڑ����Ă���GPIO
        const int ledPin = 2;       

        public static void Main()
        {
            //LED�s����PWM��ݒ�
            Configuration.SetPinFunction(ledPin, DeviceFunction.PWM1);

            //���g��40KHz�Ƃ���PWM��ݒ�
            PwmChannel pwmChannel = PwmChannel.CreateFromPin(ledPin, 40000, 0);

            //PWM���X�^�[�g
            pwmChannel.Start();

            while (true)
            {
                //20ms����1%�Âf���[�e�B��𑝂₷�B
                for(int i = 0; i <100;i++)
                {
                    //PWM�̃f���[�e�B���0.0�`1.0�Őݒ肷��B
                    pwmChannel.DutyCycle = (double)i / 100.0;       
                    Thread.Sleep(20);
                }
                //20ms����1%�Âf���[�e�B������炷�B
                for (int i = 100; i > 0; i--)
                {
                    pwmChannel.DutyCycle = (double)i / 100.0;
                    Thread.Sleep(20);
                }
            }
        }
    }
}
