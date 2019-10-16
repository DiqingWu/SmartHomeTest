using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHome_V3
{
    public delegate void act();

    public class SHdata
    {
        Queue<DateTime> timer;
        DateTime desinationTime;
        MQTT_Message MQTT_send;
        Queue<act> actions;
        string homeid;
        public SHdata(string homeid)
        {
            this.homeid = homeid;
            timer = new Queue<DateTime>();
            MQTT_send = SmartHomeController._apiManager.SendMQTT;
            actions = new Queue<act>();
            desinationTime = DateTime.Now;
            Test1();
        }
        public void Clock_tick()
        {
            if(timer.Count > 0 )
            if (DateTime.Compare(timer.Peek(), DateTime.Now) <= 0)
            {
                timer.Dequeue();
                act a = actions.Dequeue();
                a();
            }

        }
        public void Test1()
        {

            // enviorment protection
            // measure temperature never > x value (110F?)
            /*
             *test 1
             *heater open 10 min
             *cooler 10 min
             *heater open 20 min
             *cooler 20 min
             *heater open 30 min 
             *cooler 20min
             *heater open 1 hour 
             *cooler 30 min
             */
            // test 1 start at 9/18/2019 2:38
            //Delay(1000);

            //this is delay then act. 

            Act_Delay_ms(Heater_On, 3000);

            Act_Delay_ms(Heater_On, 1000);
            Act_Delay_min(Heater_Off, 10);

            Act_Delay_ms(Cooler_On, 1000);
            Act_Delay_min(Cooler_Off, 10);

            Act_Delay_ms(Heater_On, 1000);
            Act_Delay_min(Heater_Off, 20);

            Act_Delay_ms(Cooler_On, 1000);
            Act_Delay_min(Cooler_Off, 20);

            Act_Delay_ms(Heater_On, 1000);
            Act_Delay_min(Heater_Off, 30);

            Act_Delay_ms(Cooler_On, 1000);
            Act_Delay_min(Cooler_Off, 30);
        }
        public void Test2() {



        }
        public void PlotTest() {

        }
        public void Act_Delay_min(act a, int min)
        {
            int ms = 60 * 1000 * min;
            timer.Enqueue(desinationTime.AddMilliseconds(ms));
            actions.Enqueue(a);
            desinationTime = desinationTime.AddMilliseconds(ms);
        }

        public void Delay(int ms)
        {
            timer.Enqueue(desinationTime.AddMilliseconds(ms));
            actions.Enqueue(UselessFunction);
            desinationTime = desinationTime.AddMilliseconds(ms);
        }
        public void Act_Delay_ms(act a,int ms)
        {
            timer.Enqueue(desinationTime.AddMilliseconds(ms));
            actions.Enqueue(a);
            desinationTime = desinationTime.AddMilliseconds(ms);

            /*
            DateTime sourcetime = DateTime.Now;
            DateTime destinationtime = sourcetime.AddMilliseconds(ms);

            while(DateTime.Compare(destinationtime,DateTime.Now) < 0)
            {
                // loop
            }

            //finish delay

            // add to buffer or excute linear?????
            // get this done latter 
            Thread thread = new Thread(new ThreadStart(CreatDelayThread));
            thread.Start();
            */
        }
        private void UselessFunction()
        {

        }
        private void Cooler_Off()
        {
            // turn off cooler
            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"cooler 1\",\"Status\":\"0\"}");
        }
        private void Cooler_On()
        {
            // turn on cooler
            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"cooler 1\",\"Status\":\"1\"}");
        }
        private void Heater_Off()
        {
            // turn off heater
            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"heater 1\",\"Status\":\"0\"}");
        }
        private void Heater_On()
        {
            // turn on heater
            MQTT_send(Constants.MQTT_Base, "{\"ID\":\"" + homeid + "\",\"Device\":\"heater 1\",\"Status\":\"1\"}");
        }


        private void CreatDelayThread()
        {
            try
            {
                //create job buffer.
                //while sourcetime != destinationtime.{}   
                //job done
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
